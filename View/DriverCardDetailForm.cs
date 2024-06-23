using System;
using System.Windows.Forms;
using CargoTransportationModel;

namespace CargoTransportationView
{
    public partial class DriverCardDetailForm : Form
    {
        // данные
        public DriverCard Data { get; private set; }

        public DriverCardDetailForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Занесение данных из объекта данных в контролы
        /// </summary>
        /// <param name="data">Объект с данными для заполнения контролов</param>
        public void Build(DriverCard data)
        {
            // сохраняем объект в своём свойстве
            Data = data;
            tbServiceNumber.Text = Data.ServiceNumber;
            tbFullName.Text = Data.FullName;
            tbGrade.Text = Data.Grade;
            tbCategory.Text = Data.Category;
            tbIdentityCardNumber.Text = Data.IdentityCardNumber;
            tbHourlyTariffRate.Value = (decimal)Data.HourlyTariffRate;
            btnOk.Enabled = false;
        }

        /// <summary>
        /// Парсинг и проверка на правильность
        /// </summary>
        public void UpdateValue()
        {
            Data.ServiceNumber = tbServiceNumber.Text;
            Data.FullName = tbFullName.Text;
            Data.Grade = tbGrade.Text;
            Data.Category = tbCategory.Text;
            Data.IdentityCardNumber = tbIdentityCardNumber.Text;
            Data.HourlyTariffRate = (double)tbHourlyTariffRate.Value;
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
