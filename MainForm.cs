using CargoTransportationModel;
using CargoTransportationView;
using Reports;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CargoTransportation
{
    public partial class MainForm : Form
    {
        private readonly Stack<Action> actionStack = new Stack<Action>();
        private readonly CustomPanel pnlForm = new CustomPanel() { Dock = DockStyle.Fill, BackgroundImageLayout = ImageLayout.Zoom };
        // Переменная для хранения текущего типа меню.
        private MenuKind MenuKind = MenuKind.None;

        public MainForm()
        {
            InitializeComponent();
            // размещение принимающей панели для табличных форм
            tableLayoutPanel1.Controls.Add(pnlForm, 1, 0);
            // начальное запрещение пунктов меню, кроме первого
            UpdateTopMenu(false);
            // загрузка сохраненной конфигурации
            ApplicationData.LoadConfiguration("diplom");
            LoadMenu();
        }

        private void UpdateTopMenu(bool flag)
        {
            // перебираем все элементы панели, выбирая только кнопки со списком, начиная со второй
            foreach (var item in toolStrip1.Items.OfType<ToolStripDropDownButton>().Skip(1))
            {
                item.Enabled = flag;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // отложенный вызов формы входа в систему
            loginTimer.Enabled = true;
        }

        private void tsmiLogin_Click(object sender, EventArgs e)
        {
            // отложенный вызов формы входа в систему
            loginTimer.Enabled = true;
        }

        /// <summary>
        /// Обработчик таймера для показа формы входа в систему
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginTimer_Tick(object sender, EventArgs e)
        {
            loginTimer.Enabled = false;
            // создается форма входа
            var frm = new LoginForm();
            // создается пустой объект для его заполнения формой ввода
            var item = new User();
            // форма ввода заполняется данными
            frm.Build(item);
            // вызываем диалог работы с пользователем
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // проверка учётных данных на совпадение
                if (frm.Data.Login == "sa" && frm.Data.Password == "sa")
                {
                    tspbProgress.Visible = true;
                    // проверка соединения с сервером
                    Сonnected = ApplicationData.ServerConnected();
                    tspbProgress.Visible = false;
                }
                else
                {
                    Сonnected = false;
                    // выводим сообщение об ошибке входа
                    MessageBox.Show("Пользователь не вошёл в систему!", "Ошибка ввода данных",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обработчик события закрытия формы при любом закрытии формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            // спрашиваем подтверждение пользователя
            if (MessageBox.Show(this, "Завершить работу с приложением?", "Завершение работы",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // делаем необходимые действия перед закрытием программы
            }
            else
                // пользователь отменил закрытие приложения
                e.Cancel = true;    
        }

        private bool сonnected;

        private bool Сonnected
        {
            get { return сonnected; }
            set
            {
                сonnected = value;
                pnlMenu.Enabled = сonnected;
                pnlForm.Enabled = сonnected;
                UpdateTopMenu(сonnected);
                tsslMessage.Text = сonnected ? "Соединение с базой данных установлено" : "Нет подключения к базе данных";
            }
        }

        /// <summary>
        /// Кнопка назад достает из стека предыдущее действие по загрузке меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbBack_Click(object sender, EventArgs e)
        {
            pnlForm.Controls.Clear();
            if (actionStack.Count > 0)
            {
                var action = actionStack.Pop();
                action.Invoke();
            }
        }

        /// <summary>
        /// Активизация или запрет кнопки Назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkActionStack_Tick(object sender, EventArgs e)
        {
            tsbBack.Enabled = actionStack.Count > 0;
        }

        /// <summary>
        /// Загрузка корневого меню
        /// </summary>
        private void LoadMenu()
        {
            if (MenuKind == MenuKind.LoadMenu) return;
            MenuKind = MenuKind.LoadMenu;
            pnlForm.Controls.Clear();
            actionStack.Clear();
            var ucMenu = new MenuUC() { Dock = DockStyle.Fill, Margin = new Padding() };
            pnlMenu.Controls.Clear();
            pnlMenu.Controls.Add(ucMenu);
            ucMenu.TransportVehicleFilesMenu += (o, e) => LoadTools();
            ucMenu.WaybillsMenu += (o, e) => LoadWaybills();
            ucMenu.PaymentToDriversMenu += (o, e) => LoadPaymentToDrivers();
            ucMenu.ReportsMenu += (o, e) => LoadReports();
            pnlForm.BackgroundImage = Properties.Resources.LogoLoadMenu;
        }

        /// <summary>
        /// Загрузка меню инструментов
        /// </summary>
        private void LoadTools()
        {
            if (MenuKind == MenuKind.LoadTools) return;
            MenuKind = MenuKind.LoadTools;
            pnlForm.Controls.Clear();
            actionStack.Push(LoadMenu);
            var ucTools = new ToolsUC() { Dock = DockStyle.Fill, Margin = new Padding() };
            pnlMenu.Controls.Clear();
            pnlMenu.Controls.Add(ucTools);
            ucTools.TransportVehicleTypesForm += (o, e) =>
                CreateAndShowForm(typeof(TransportVehicleTypeTableForm));
            ucTools.TransportVehicleBrandsForm += (o, e) =>
                CreateAndShowForm(typeof(TransportVehicleBrandTableForm));
            ucTools.DriverCardsForm += (o, e) =>
                CreateAndShowForm(typeof(DriverCardTableForm));
            ucTools.FuelAndLubricantsForm += (o, e) =>
                CreateAndShowForm(typeof(FuelTableForm));
            ucTools.DivisionsForm += (o, e) =>
                CreateAndShowForm(typeof(DivisionTableForm));
            ucTools.TransportVehiclesForm += (o, e) =>
                CreateAndShowForm(typeof(TransportVehicleTableForm));
            pnlForm.BackgroundImageLayout = ImageLayout.Stretch;
            pnlForm.BackgroundImage = Properties.Resources.LogoToolsMenu;          

        }


        private void tsmiTransportVehicleTypes_Click(object sender, EventArgs e)
        {
            LoadTools();
            CreateAndShowForm(typeof(TransportVehicleTypeTableForm));
        }

        private void tsmiTransportVehicleBrands_Click(object sender, EventArgs e)
        {
            LoadTools();
            CreateAndShowForm(typeof(TransportVehicleBrandTableForm));
        }

        private void tsmiDriverCards_Click(object sender, EventArgs e)
        {
            LoadTools();
            CreateAndShowForm(typeof(DriverCardTableForm));
        }

        private void tsmiFuels_Click(object sender, EventArgs e)
        {
            LoadTools();
            CreateAndShowForm(typeof(FuelTableForm));
        }

        private void tsmiDivisions_Click(object sender, EventArgs e)
        {
            LoadTools();
            CreateAndShowForm(typeof(DivisionTableForm));
        }

        private void tsmiTransportVehicles_Click(object sender, EventArgs e)
        {
            LoadTools();
            CreateAndShowForm(typeof(TransportVehicleTableForm));
        }

        /// <summary>
        /// Загрузка меню путевых листов
        /// </summary>
        private void LoadWaybills()
        {
            if (MenuKind == MenuKind.LoadWaybills) return;
            MenuKind = MenuKind.LoadWaybills;
            pnlForm.Controls.Clear();
            actionStack.Push(LoadMenu);
            var ucWaybills = new WaybillsUC() { Dock = DockStyle.Fill, Margin = new Padding() };
            pnlMenu.Controls.Clear();
            pnlMenu.Controls.Add(ucWaybills);
            ucWaybills.OrganizationsForm += (o, e) =>
                CreateAndShowForm(typeof(OrganizationTableForm));
            ucWaybills.RoutesForm += (o, e) =>
                CreateAndShowForm(typeof(RouteTableForm));
            ucWaybills.RatesForm += (o, e) =>
                CreateAndShowForm(typeof(RateTableForm));
            ucWaybills.ServicesForm += (o, e) =>
                CreateAndShowForm(typeof(ServiceTableForm));
            ucWaybills.OrdersForm += (o, e) =>
                CreateAndShowForm(typeof(OrderTableForm));
            ucWaybills.WaybillsForm += (o, e) =>
                CreateAndShowForm(typeof(WaybillTableForm));
            pnlForm.BackgroundImage = Properties.Resources.LogoWaybillsMenu;
        }

        private void tsmiOrganizations_Click(object sender, EventArgs e)
        {
            LoadWaybills();
            CreateAndShowForm(typeof(OrganizationTableForm));
        }

        private void tsmiRoutes_Click(object sender, EventArgs e)
        {
            LoadWaybills();
            CreateAndShowForm(typeof(RouteTableForm));
        }

        private void tsmiRates_Click(object sender, EventArgs e)
        {
            LoadWaybills();
            CreateAndShowForm(typeof(RateTableForm));
        }

        private void tsmiServices_Click(object sender, EventArgs e)
        {
            LoadWaybills();
            CreateAndShowForm(typeof(ServiceTableForm));
        }

        private void tsmiOrders_Click(object sender, EventArgs e)
        {
            LoadWaybills();
            CreateAndShowForm(typeof(OrderTableForm));
        }

        private void tsmiWaybills_Click(object sender, EventArgs e)
        {
            LoadWaybills();
            CreateAndShowForm(typeof(WaybillTableForm));
        }

        /// <summary>
        /// Загрузка меню оплат водителям
        /// </summary>
        private void LoadPaymentToDrivers()
        {
            if (MenuKind == MenuKind.LoadPaymentToDrivers) return;
            MenuKind = MenuKind.LoadPaymentToDrivers;
            pnlForm.Controls.Clear();
            actionStack.Push(LoadMenu);
            var ucPaymentToDrivers = new PaymentToDriversUC() { Dock = DockStyle.Fill, Margin = new Padding() };
            pnlMenu.Controls.Clear();
            pnlMenu.Controls.Add(ucPaymentToDrivers);
            ucPaymentToDrivers.PaymentTypesForm += (o, e) =>
                CreateAndShowForm(typeof(PaymentTypeTableForm));
            ucPaymentToDrivers.PaymentToDriversForm += (o, e) =>
                CreateAndShowForm(typeof(PaymentTableForm));
            pnlForm.BackgroundImage = Properties.Resources.LogoPaymentToDriversMenu;
        }

        private void tsmiPaymentTypes_Click(object sender, EventArgs e)
        {
            LoadPaymentToDrivers();
            CreateAndShowForm(typeof(PaymentTypeTableForm));
        }

        private void tsmiPayments_Click(object sender, EventArgs e)
        {
            LoadPaymentToDrivers();
            CreateAndShowForm(typeof(PaymentTableForm));
        }

        /// <summary>
        /// Загрузка меню отчётов
        /// </summary>
        private void LoadReports()
        {
            if (MenuKind == MenuKind.LoadReports) return;
            MenuKind = MenuKind.LoadReports;
            pnlForm.Controls.Clear();
            actionStack.Push(LoadMenu);
            var ucReports = new ReportsUC() { Dock = DockStyle.Fill, Margin = new Padding() };
            pnlMenu.Controls.Clear();
            pnlMenu.Controls.Add(ucReports);
             ucReports.SalaryStatementForm += (o, e) =>
                CreateAndShowForm(typeof(ReportsForm), ReportsBuilder.SalaryStatementReport());
            ucReports.WaybillsRegistrationJournalForm += (o, e) =>
                CreateAndShowForm(typeof(ReportsForm), ReportsBuilder.WaybillLogReport());
            ucReports.CustomersRegisterForm += (o, e) =>
                CreateAndShowForm(typeof(ReportsForm), ReportsBuilder.CustomersRegisterReport());
            pnlForm.BackgroundImage = Properties.Resources.LogoReporsMenu;
        }

        private void tsmiReport1_Click(object sender, EventArgs e)
        {
            LoadReports();
            CreateAndShowForm(typeof(ReportsForm), ReportsBuilder.SalaryStatementReport());
        }

        private void tsmiReport2_Click(object sender, EventArgs e)
        {
            LoadReports();
            CreateAndShowForm(typeof(ReportsForm), ReportsBuilder.WaybillLogReport());
        }

        private void tsmiReport3_Click(object sender, EventArgs e)
        {
            LoadReports();
            CreateAndShowForm(typeof(ReportsForm), ReportsBuilder.CustomersRegisterReport());
        }

        /// <summary>
        /// Создание и показ формы в границах панели просмотра
        /// </summary>
        /// <param name="form"></param>
        /// <param name="report"></param>
        private void CreateAndShowForm(Type form, Report report = null)
        {
            var frm = report == null 
                ? (Form)Activator.CreateInstance(form) 
                : (Form)Activator.CreateInstance(form, report);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Location = new Point(-frm.Width, 0);
            frm.Height = pnlForm.ClientSize.Height;
            frm.Shown += async (o, e) =>
            {
                while (report == null && frm.Location.X < 0)
                {
                    await Task.Delay(1);
                    var lx = frm.Location.X + (frm.Width - frm.Location.X) / 16;
                    if (lx > 0) lx = 0;
                    frm.Location = new Point(lx, frm.Location.Y);
                }
                frm.Dock = report == null ? DockStyle.Left : DockStyle.Fill;
            };
            pnlForm.Controls.Clear();
            pnlForm.AutoScroll = report == null;
            pnlForm.Controls.Add(frm);
            frm.Show();
        }

        /// <summary>
        /// Обработчик пункта меню Завершение работы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            // требуем закрытия главной формы
            Close();
        }

        /// <summary>
        /// Настройка соединения с базой данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiTuningConnection_Click(object sender, EventArgs e)
        {
            // вызываем форму настройки соединения с сервером и базой данных
            if (new FormConnectionTuning().ShowDialog(this) != DialogResult.OK) return;
            // отложенный вызов формы входа в систему
            loginTimer.Enabled = true;
        }

        private void miDatabase_Click(object sender, EventArgs e)
        {
            LoadMenu();
        }

        private void miTools_Click(object sender, EventArgs e)
        {
            LoadTools();
        }

        private void miWaybills_Click(object sender, EventArgs e)
        {
            LoadWaybills();
        }

        private void miPayments_Click(object sender, EventArgs e)
        {
            LoadPaymentToDrivers();
        }

        private void miReports_Click(object sender, EventArgs e)
        {
            LoadReports();
        }
        
    }
    /// <summary>
    /// Перечисление MenuKind определяет типы меню, которые могут быть загружены в приложении.
    /// </summary>
    public enum MenuKind
    {
        None,
        LoadMenu,
        LoadTools,
        LoadWaybills,
        LoadPaymentToDrivers,
        LoadReports
    }
}
