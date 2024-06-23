using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CargoTransportationModel;

namespace CargoTransportationView
{
    public partial class PaymentTypeTableForm : Form
    {
        public PaymentTypeTableForm()
        {
            InitializeComponent();
        }

        private void PaymentTypeTableForm_Load(object sender, EventArgs e)
        {
            FillTable();
        }

        /// <summary>
        /// Заполнение таблицы выдов оплат
        /// </summary>
        private void FillTable()
        {
            using (var server = new Server())
            {
                var data = PaymentType.SelectList(server.Connection);
                lvTable.Items.Clear();
                if (data.Tables.Count == 0) return;
                foreach (var row in data.Tables[0].Rows.Cast<DataRow>())
                {
                    var id = (int)row["Id"];
                    var lvi = new ListViewItem($"{id}") { Tag = id };
                    lvTable.Items.Add(lvi);
                    lvi.SubItems.Add(row["Имя"].ToString());
                    lvi.SubItems.Add(row["Код"].ToString());
                }
            }
        }

        /// <summary>
        /// Управление разрешениями кнопок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            var anySelected = lvTable.SelectedIndices.Count > 0;
            btnUpdate.Enabled = anySelected;
            btnRemove.Enabled = anySelected;
        }

        /// <summary>
        /// Добавить новую запись
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAppend_Click(object sender, EventArgs e)
        {
            var frm = new PaymentTypeDetailForm();
            var item = new PaymentType();
            frm.Build(item);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var server = new Server())
                    {
                        var id = PaymentType.AddItem(server.Connection, frm.Data);
                        FillTable();
                        var lvi = lvTable.FindItemWithText($"{id}");
                        if (lvi != null)
                        {
                            lvi.Selected = true;
                            lvi.EnsureVisible();
                            lvTable.FocusedItem = lvi;
                            lvTable.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Ошибка добавления элемента", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
            }
        }

        /// <summary>
        /// Изменить выбранную запись
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var lvi = lvTable.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (lvi != null)
            {
                try
                {
                    var id = (int)lvi.Tag;
                    var frm = new PaymentTypeDetailForm();
                    using (var server = new Server())
                    {
                       var item = PaymentType.SelectItem(server.Connection, id);
                       frm.Build(item);
                       if (frm.ShowDialog() == DialogResult.OK)
                       {
                           PaymentType.ChangeItem(server.Connection, id, item);
                           FillTable();
                           lvi = lvTable.FindItemWithText($"{id}");
                           if (lvi != null)
                           {
                               lvi.Selected = true;
                               lvi.EnsureVisible();
                               lvTable.FocusedItem = lvi;
                               lvTable.Focus();
                           }
                       }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Ошибка изменения элемента", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
            }
        }

        /// <summary>
        /// Удалить выбранную запись
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Удалить выделенный элемент из списка?", "Удаление элемента", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                var lvi = lvTable.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
                if (lvi != null)
                {
                    try
                    {
                        var id = (int)lvi.Tag;
                        using (var server = new Server())
                            PaymentType.RemoveItem(server.Connection, id);
                        lvTable.Items.Remove(lvi);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Ошибка удаления элемента", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }
                }
            }
        }

        /// <summary>
        /// Двойной щелчок вызывает изменение записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvTable_DoubleClick(object sender, EventArgs e)
        {
            var lvi = lvTable.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (lvi != null)
            {
                btnUpdate.PerformClick();
            }
        }
    }
}
