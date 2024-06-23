using CargoTransportationModel;
using CargoTransportationView;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace CargoTransportationView
{
    // Класс формы входа
    public partial class LoginForm : Form
    {
        // данные
        public User Data { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Занесение данных из объекта данных в контролы
        /// </summary>
        /// <param name="data">Объект с данными для заполнения контролов</param>
        public void Build(User data)
        {
            // сохраняем объект в своём свойстве
            Data = data;
            tbLogin.Text = Data.Login;
            tbPassword.Text = Data.Password;
            // кнопка ввода разрешена, если поля ввода не пустые
            btnOk.Enabled = !string.IsNullOrWhiteSpace(tbLogin.Text) &&
                !string.IsNullOrWhiteSpace(tbPassword.Text);
        }

        /// <summary>
        /// Парсинг и проверка на правильность
        /// </summary>
        public void UpdateValue()
        {
            Data.Login = tbLogin.Text;
            Data.Password = tbPassword.Text;
           /* tbPassword.UseSystemPasswordChar = false;
            tbLogin.MaxLength = 50;
            tbPassword.MaxLength = 50;*/
        }

        /// <summary>
        /// Обработчик кнопки "Ok"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, System.EventArgs e)
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
        private void btnCancel_Click(object sender, System.EventArgs e)
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
            // кнопка ввода разрешена, если поля ввода не пустые
            btnOk.Enabled = !string.IsNullOrWhiteSpace(tbLogin.Text) &&
                !string.IsNullOrWhiteSpace(tbPassword.Text);
        }
        /*
        /// <summary>
        /// Обработчик скрытия пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                tbPassword.UseSystemPasswordChar = false;
                tbPassword.PasswordChar = '\0'; 
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
                tbPassword.PasswordChar = '*'; 
            }
        }*/
    }
}

