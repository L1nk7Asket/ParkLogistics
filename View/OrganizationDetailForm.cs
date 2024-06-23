using System;
using System.Windows.Forms;
using CargoTransportationModel;

namespace CargoTransportationView
{
    public partial class OrganizationDetailForm : Form
    {
        // данные
        public Organization Data { get; private set; }

        public OrganizationDetailForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Занесение данных из объекта данных в контролы
        /// </summary>
        /// <param name="data">Объект с данными для заполнения контролов</param>
        public void Build(Organization data)
        {
            // сохраняем объект в своём свойстве
            Data = data;
            tbName.Text = Data.Name;
            tbDirectorName.Text = Data.DirectorName;
            tbIndividualTaxNumber.Text = Data.IndividualTaxNumber;
            tbContactDetails.Text = Data.ContactDetails;
            btnOk.Enabled = false;
        }

        /// <summary>
        /// Парсинг и проверка на правильность
        /// </summary>
        public void UpdateValue()
        {
            Data.Name = tbName.Text;
            Data.DirectorName = tbDirectorName.Text;
            Data.IndividualTaxNumber = tbIndividualTaxNumber.Text;
            Data.ContactDetails = tbContactDetails.Text;
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
            btnOk.Enabled = !string.IsNullOrWhiteSpace(tbName.Text) &&
                !string.IsNullOrWhiteSpace(tbDirectorName.Text) &&
                !string.IsNullOrWhiteSpace(tbIndividualTaxNumber.Text) &&
                tbIndividualTaxNumber.Text.Length == 10;
        }

    }
}
