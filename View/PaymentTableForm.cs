using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CargoTransportationModel;

namespace CargoTransportationView
{
    public partial class PaymentTableForm : Form
    {
        public PaymentTableForm()
        {
            InitializeComponent();
        }

        private void PaymentTableForm_Load(object sender, EventArgs e)
        {
            FillTable();
        }

        /// <summary>
        /// Заполнение таблицы платежей водителям
        /// </summary>
        private void FillTable()
        {
            using (var server = new Server())
            {
                var data = Payment.SelectList(server.Connection);
                lvTable.Items.Clear();
                if (data.Tables.Count == 0) return;
                foreach (var row in data.Tables[0].Rows.Cast<DataRow>())
                {
                    var id = (int)row["Id"];
                    var lvi = new ListViewItem($"{id}") { Tag = id };
                    lvTable.Items.Add(lvi);
                    lvi.SubItems.Add($"№{row["Накладная"]}");
                    // для наименования маршрута
                    var waybill = Waybill.SelectItem(server.Connection, (int)row["Накладная"]);
                    var order = Order.SelectItem(server.Connection, waybill.Order);
                    var route = Route.SelectItem(server.Connection, order.Route);
                    lvi.SubItems.Add(route.Code);
                    // для ФИО водителя
                    var tv = TransportVehicle.SelectItem(server.Connection, waybill.StateNumber);
                    var driver = DriverCard.SelectItem(server.Connection, tv.DriverName);
                    var vals = driver.FullName.Split(' ');
                    var fio = vals[0];
                    if (vals.Length > 1) fio += $" {vals[1].Substring(0, 1)}.";
                    if (vals.Length > 2) fio += $"{vals[2].Substring(0, 1)}.";
                    lvi.SubItems.Add(fio);
                    // вид оплаты
                    lvi.SubItems.Add(PaymentType.SelectItem(server.Connection, (int)row["Тип_платежа"]).Name);
                    // сумма к оплате
                    lvi.SubItems.Add(((double)row["Сумма"]).ToString("0.00"));
                }
            }
        }

        /// <summary>
        /// Управление разрешением кнопок
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
            var frm = new PaymentDetailForm();
            var item = new Payment();
            frm.Build(item);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var server = new Server())
                    {
                        var id = Payment.AddItem(server.Connection, frm.Data);
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
        /// Изменить текущую запись
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
                    var frm = new PaymentDetailForm();
                    using (var server = new Server())
                    {
                       var item = Payment.SelectItem(server.Connection, id);
                       frm.Build(item);
                       if (frm.ShowDialog() == DialogResult.OK)
                       {
                           Payment.ChangeItem(server.Connection, id, item);
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
        /// Удалить текущую запись
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
                            Payment.RemoveItem(server.Connection, id);
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
        /// Двойной щелчок вызывает редактирование записи
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
