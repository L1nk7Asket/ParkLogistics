using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CargoTransportationModel;

namespace CargoTransportationView
{
    public partial class TransportVehicleDetailForm : Form
    {
        // данные
        public TransportVehicle Data { get; private set; }

        public TransportVehicleDetailForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Занесение данных из объекта данных в контролы
        /// </summary>
        /// <param name="data">Объект с данными для заполнения контролов</param>
        public void Build(TransportVehicle data)
        {
            // сохраняем объект в своём свойстве
            Data = data;
            tbStateNumber.Text = Data.StateNumber;
            tbBrandCode.Items.Clear();
            using (var server = new Server())
            {
                var dsBrandCode = TransportVehicleBrand.SelectList(server.Connection);
                foreach (var row in dsBrandCode.Tables[0].Rows.Cast<DataRow>())
                {
                    var typeName = TransportVehicleType.SelectItem(server.Connection, (int)row["ТипТС"]).Name;
                    var item = new SelectorItem() 
                    { 
                        Id = (int)row["Id"], 
                        Name = $"{row["Код"]} ({typeName})" 
                    };
                    tbBrandCode.Items.Add(item);
                }
            }
            tbBrandCode.SelectedItem = tbBrandCode.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.BrandCode);
            tbDivisionCode.Items.Clear();
            using (var server = new Server())
            {
                var dsDivisionCode = Division.SelectList(server.Connection);
                foreach (var row in dsDivisionCode.Tables[0].Rows.Cast<DataRow>())
                {
                    var item = new SelectorItem() { Id = (int)row["Id"], Name = (string)row["Имя"] };
                    tbDivisionCode.Items.Add(item);
                }
            }
            tbDivisionCode.SelectedItem = tbDivisionCode.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.DivisionCode);
            tbMainEquipmentFuel.Items.Clear();
            using (var server = new Server())
            {
                var dsMainEquipmentFuel = Fuel.SelectList(server.Connection);
                foreach (var row in dsMainEquipmentFuel.Tables[0].Rows.Cast<DataRow>())
                {
                    var item = new SelectorItem() { Id = (int)row["Id"], Name = (string)row["Код"] };
                    tbMainEquipmentFuel.Items.Add(item);
                }
            }
            tbMainEquipmentFuel.SelectedItem = tbMainEquipmentFuel.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.MainEquipmentFuel);
            tbAdditionalEquipmentFuel.Items.Clear();
            using (var server = new Server())
            {
                var dsAdditionalEquipmentFuel = Fuel.SelectList(server.Connection);
                foreach (var row in dsAdditionalEquipmentFuel.Tables[0].Rows.Cast<DataRow>())
                {
                    var item = new SelectorItem() { Id = (int)row["Id"], Name = (string)row["Код"] };
                    tbAdditionalEquipmentFuel.Items.Add(item);
                }
            }
            tbAdditionalEquipmentFuel.SelectedItem = tbAdditionalEquipmentFuel.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.AdditionalEquipmentFuel);
            tbDriverName.Items.Clear();
            using (var server = new Server())
            {
                var dsDriverName = DriverCard.SelectList(server.Connection);
                foreach (var row in dsDriverName.Tables[0].Rows.Cast<DataRow>())
                {
                    var item = new SelectorItem() { Id = (int)row["Id"], Name = (string)row["ФИО"] };
                    tbDriverName.Items.Add(item);
                }
            }
            tbDriverName.SelectedItem = tbDriverName.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.DriverName);
            tbMainConsumptionRate.Value = (decimal)Data.MainConsumptionRate;
            tbAdditionalConsumptionRate.Value = (decimal)Data.AdditionalConsumptionRate;
            btnOk.Enabled = false;
        }

        /// <summary>
        /// Парсинг и проверка на правильность
        /// </summary>
        public void UpdateValue()
        {
            Data.StateNumber = tbStateNumber.Text;
            Data.BrandCode = ((SelectorItem)tbBrandCode.SelectedItem).Id;
            Data.DivisionCode = ((SelectorItem)tbDivisionCode.SelectedItem).Id;
            Data.MainEquipmentFuel = ((SelectorItem)tbMainEquipmentFuel.SelectedItem).Id;
            Data.AdditionalEquipmentFuel = ((SelectorItem)tbAdditionalEquipmentFuel.SelectedItem).Id;
            Data.DriverName = ((SelectorItem)tbDriverName.SelectedItem).Id;
            Data.MainConsumptionRate = (int)tbMainConsumptionRate.Value;
            Data.AdditionalConsumptionRate = (int)tbAdditionalConsumptionRate.Value;
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
            btnOk.Enabled = !string.IsNullOrWhiteSpace(tbStateNumber.Text) &&
                tbBrandCode.SelectedItem != null &&
                tbDivisionCode.SelectedItem != null &&
                tbMainEquipmentFuel.SelectedItem != null &&
                tbAdditionalEquipmentFuel.SelectedItem != null &&
                tbDriverName.SelectedItem != null &&
                tbMainConsumptionRate.Value > 0;
        }

    }
}
