using System;
using System.Windows.Forms;

namespace CargoTransportationView
{
    public partial class FormConnectionTuning : Form
    {
        public FormConnectionTuning()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загружаем сохраненные настройки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormConnectionTuning_Load(object sender, EventArgs e)
        {
            tbDatabase.Text = ApplicationData.Database;
            tbServer.Text = ApplicationData.Server;
            nudPort.Value = Convert.ToDecimal(ApplicationData.Port);
            tbUser.Text = ApplicationData.User;
            tbPassword.Text = ApplicationData.Password;
        }

        /// <summary>
        /// Записываем новую конфигурацию по кнопке "ОК"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            ApplicationData.SaveConfiguration(tbDatabase.Text, tbServer.Text, 
                Convert.ToInt32(nudPort.Value), tbUser.Text, tbPassword.Text);
        }

        /// <summary>
        /// Тестирование настроек соединения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            // Вызывается метод TestConfiguration класса ApplicationData.
            ApplicationData.TestConfiguration(tbDatabase.Text, tbServer.Text,
                Convert.ToInt32(nudPort.Value), tbUser.Text, tbPassword.Text);
            // Проверяется, установлено ли подключение к серверу.
            if (ApplicationData.ServerConnected())
                // Если подключение установлено, отображается сообщение об успешном подключении.
                MessageBox.Show(this, "Успешное подключение", "Проверка подключения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                // Если подключение не установлено, отображается сообщение об ошибке.
                MessageBox.Show(this, Server.LastError, "Проверка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
