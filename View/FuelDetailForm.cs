using System;
using System.Windows.Forms;
using CargoTransportationModel;

namespace CargoTransportationView
{
    public partial class FuelDetailForm : Form
    {
        // данные
        public Fuel Data { get; private set; }

        public FuelDetailForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Занесение данных из объекта данных в контролы
        /// </summary>
        /// <param name="data">Объект с данными для заполнения контролов</param>
        public void Build(Fuel data)
        {
            // сохраняем объект в своём свойстве
            Data = data;
            tbCode.Text = Data.Code;
            tbName.Text = Data.Name;
            tbDensity.Value = (decimal)Data.Density;
            tbFuelUnit.Text = Data.FuelUnit;
            btnOk.Enabled = false;
        }

        /// <summary>
        /// Парсинг и проверка на правильность
        /// </summary>
        public void UpdateValue()
        {
            Data.Code = tbCode.Text;
            Data.Name = tbName.Text;
            Data.Density = (float)tbDensity.Value;
            Data.FuelUnit = tbFuelUnit.Text;
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

        private void FuelDetailForm_Load(object sender, EventArgs e)
        {

        }
    }
}
