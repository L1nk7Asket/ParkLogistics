using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CargoTransportationModel;

namespace CargoTransportationView
{
    public partial class TransportVehicleBrandDetailForm : Form
    {
        // данные
        public TransportVehicleBrand Data { get; private set; }

        public TransportVehicleBrandDetailForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Занесение данных из объекта данных в контролы
        /// </summary>
        /// <param name="data">Объект с данными для заполнения контролов</param>
        public void Build(TransportVehicleBrand data)
        {
            // сохраняем объект в своём свойстве
            Data = data;
            tbName.Text = Data.Name;
            tbVehicleType.Items.Clear();
            using (var server = new Server())
            {
                var dsVehicleType = TransportVehicleType.SelectList(server.Connection);
                foreach (var row in dsVehicleType.Tables[0].Rows.Cast<DataRow>())
                {
                    var item = new SelectorItem() { Id = (int)row["Id"], Name = (string)row["Имя"] };
                    tbVehicleType.Items.Add(item);
                }
            }
            tbVehicleType.SelectedItem = tbVehicleType.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.VehicleType);
            tbCode.Text = Data.Code;
            btnOk.Enabled = false;
        }

        /// <summary>
        /// Парсинг и проверка на правильность
        /// </summary>
        public void UpdateValue()
        {
            Data.Name = tbName.Text;
            Data.VehicleType = ((SelectorItem)tbVehicleType.SelectedItem).Id;
            Data.Code = tbCode.Text;
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
            btnOk.Enabled = true;
        }

    }
}
