using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CargoTransportationModel;

namespace CargoTransportationView
{
    public partial class OrderDetailForm : Form
    {
        // данные
        public Order Data { get; private set; }

        public OrderDetailForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Занесение данных из объекта данных в контролы
        /// </summary>
        /// <param name="data">Объект с данными для заполнения контролов</param>
        public void Build(Order data)
        {
            // сохраняем объект в своём свойстве
            Data = data;
            tbOrderNumber.Text = data.ToString();
            tbRoute.Items.Clear();
            using (var server = new Server())
            {
                var dsRoute = Route.SelectList(server.Connection);
                foreach (var row in dsRoute.Tables[0].Rows.Cast<DataRow>())
                {
                    var item = new SelectorItem() { Id = (int)row["Id"], Name = (string)row["Имя"] };
                    tbRoute.Items.Add(item);
                }
            }
            tbRoute.SelectedItem = tbRoute.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.Route);
            tbDivision.Items.Clear();
            using (var server = new Server())
            {
                var dsDivision = Division.SelectList(server.Connection);
                foreach (var row in dsDivision.Tables[0].Rows.Cast<DataRow>())
                {
                    var item = new SelectorItem() { Id = (int)row["Id"], Name = (string)row["Имя"] };
                    tbDivision.Items.Add(item);
                }
            }
            tbDivision.SelectedItem = tbDivision.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.Division);
            tbСustomer.Items.Clear();
            using (var server = new Server())
            {
                var dsСustomer = Organization.SelectList(server.Connection);
                foreach (var row in dsСustomer.Tables[0].Rows.Cast<DataRow>())
                {
                    var item = new SelectorItem() { Id = (int)row["Id"], Name = (string)row["Имя"] };
                    tbСustomer.Items.Add(item);
                }
            }
            tbСustomer.SelectedItem = tbСustomer.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.Сustomer);
            tbService.Items.Clear();
            using (var server = new Server())
            {
                var dsService = Service.SelectList(server.Connection);
                foreach (var row in dsService.Tables[0].Rows.Cast<DataRow>())
                {
                    var item = new SelectorItem() { Id = (int)row["Id"], Name = (string)row["Имя"] };
                    tbService.Items.Add(item);
                }
            }
            tbService.SelectedItem = tbService.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.Service);
            tbRate.Items.Clear();
            using (var server = new Server())
            {
                var dsRate = Rate.SelectList(server.Connection);
                foreach (var row in dsRate.Tables[0].Rows.Cast<DataRow>())
                {
                    var item = new SelectorItem() { Id = (int)row["Id"], Name = (string)row["Имя"] };
                    tbRate.Items.Add(item);
                }
            }
            tbRate.SelectedItem = tbRate.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.Rate);
            btnOk.Enabled = false;
        }

        /// <summary>
        /// Парсинг и проверка на правильность
        /// </summary>
        public void UpdateValue()
        {
            Data.Route = ((SelectorItem)tbRoute.SelectedItem).Id;
            Data.Division = ((SelectorItem)tbDivision.SelectedItem).Id;
            Data.Сustomer = ((SelectorItem)tbСustomer.SelectedItem).Id;
            Data.Service = ((SelectorItem)tbService.SelectedItem).Id;
            Data.Rate = ((SelectorItem)tbRate.SelectedItem).Id;
        }

        /// <summary>
        /// Декларация приватного класса для поддержки списков выбора значения
        /// </summary>
        private class SelectorItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }

        /// <summary>
        /// Обработчик кнопки "Ввод"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                // парсинг и проверка на правильность
                UpdateValue();                 
                // выход из формы, если всё введено правильно
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                // выводим сообщение об ошибке и не закрываем форму
                MessageBox.Show(ex.Message, "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик кнопки "Отмена"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // выход из формы
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Обработчик события изменения текста контрола
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbControl_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = tbRoute.SelectedItem != null &&
                tbDivision.SelectedItem != null &&
                tbСustomer.SelectedItem != null &&
                tbService.SelectedItem != null &&
                tbRate.SelectedItem != null;
        }

    }
}
