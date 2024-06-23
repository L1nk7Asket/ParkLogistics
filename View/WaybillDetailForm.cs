using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CargoTransportationModel;

namespace CargoTransportationView
{
    public partial class WaybillDetailForm : Form
    {
        // данные
        public Waybill Data { get; private set; }

        public WaybillDetailForm()
        {
            // Инициализация компонентов формы
            InitializeComponent();
            // Добавление обработчика событий для события TextChanged контрола tbIssueDate
            // Событие TextChanged срабатывает, когда текст в текстовом поле изменяется
            ((Control)tbIssueDate).TextChanged += tbControl_TextChanged;
            ((Control)tbProcessingDate).TextChanged += tbControl_TextChanged;
            ((Control)tbDepartureDateTime).TextChanged += tbControl_TextChanged;
            ((Control)tbReturnDateTime).TextChanged += tbControl_TextChanged;
        }

        /// <summary>
        /// Занесение данных из объекта данных в контролы
        /// </summary>
        /// <param name="data">Объект с данными для заполнения контролов</param>
        public void Build(Waybill data)
        {
            // сохраняем объект в своём свойстве
            Data = data;
            tbWaybillNumber.Text = data.Id > 0 ? data.Id.ToString() : "";
            tbIssueDate.Value = Data.IssueDate < tbIssueDate.MinDate 
              ? tbIssueDate.MinDate 
              : Data.IssueDate > tbIssueDate.MaxDate 
                  ? tbIssueDate.MaxDate 
                  : Data.IssueDate;
            tbProcessingDate.Value = Data.ProcessingDate < tbProcessingDate.MinDate 
              ? tbProcessingDate.MinDate 
              : Data.ProcessingDate > tbProcessingDate.MaxDate 
                  ? tbProcessingDate.MaxDate 
                  : Data.ProcessingDate;
            tbStateNumber.Items.Clear();
            using (var server = new Server())
            {
                var dsStateNumber = TransportVehicle.SelectList(server.Connection);
                foreach (var row in dsStateNumber.Tables[0].Rows.Cast<DataRow>())
                {
                    var item = new SelectorItem() { Id = (int)row["Id"], Name = (string)row["Гос_номер"] };
                    tbStateNumber.Items.Add(item);
                }
            }
            tbStateNumber.SelectedItem = tbStateNumber.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.StateNumber);
            tbDepartureSpeedometerReadings.Value = Data.DepartureSpeedometerReadings;
            tbReturningSpeedometerReadings.Value = Data.ReturningSpeedometerReadings;
            tbInitialFuelBalance.Value = Data.InitialFuelBalance;
            tbFuelIssued.Value = Data.FuelIssued;
            tbFinalFuelRemainder.Value = Data.FinalFuelRemainder;
            tbFuelPassed.Value = Data.FuelPassed;
            tbOrder.Items.Clear();
            using (var server = new Server())
            {
                var dsOrder = Order.SelectList(server.Connection);
                foreach (var row in dsOrder.Tables[0].Rows.Cast<DataRow>())
                {
                    var item = new SelectorItem() { Id = (int)row["Id"], Name = $"{row["Id"]}" };
                    tbOrder.Items.Add(item);
                }
            }
            tbOrder.SelectedItem = tbOrder.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.Order);
            tbDepartureDateTime.Value = Data.DepartureDateTime < tbDepartureDateTime.MinDate 
              ? tbDepartureDateTime.MinDate 
              : Data.DepartureDateTime > tbDepartureDateTime.MaxDate 
                  ? tbDepartureDateTime.MaxDate 
                  : Data.DepartureDateTime;
            tbReturnDateTime.Value = Data.ReturnDateTime < tbReturnDateTime.MinDate 
              ? tbReturnDateTime.MinDate 
              : Data.ReturnDateTime > tbReturnDateTime.MaxDate 
                  ? tbReturnDateTime.MaxDate 
                  : Data.ReturnDateTime;
            tbRepairTime.Value = (decimal)Data.RepairTime;
            tbDrivingTime.Value = (decimal)Data.DrivingTime;
            tbEveningTime.Value = (decimal)Data.EveningTime;
            tbNightTime.Value = (decimal)Data.NightTime;
            btnOk.Enabled = false;
        }

        /// <summary>
        /// Парсинг и проверка на правильность
        /// </summary>
        public void UpdateValue()
        {
            Data.IssueDate = tbIssueDate.Value;
            Data.ProcessingDate = tbProcessingDate.Value;
            Data.StateNumber = ((SelectorItem)tbStateNumber.SelectedItem).Id;
            Data.DepartureSpeedometerReadings = (int)tbDepartureSpeedometerReadings.Value;
            Data.ReturningSpeedometerReadings = (int)tbReturningSpeedometerReadings.Value;
            Data.InitialFuelBalance = (int)tbInitialFuelBalance.Value;
            Data.FuelIssued = (int)tbFuelIssued.Value;
            Data.FinalFuelRemainder = (int)tbFinalFuelRemainder.Value;
            Data.FuelPassed = (int)tbFuelPassed.Value;
            Data.Order = ((SelectorItem)tbOrder.SelectedItem).Id;
            Data.DepartureDateTime = tbDepartureDateTime.Value;
            Data.ReturnDateTime = tbReturnDateTime.Value;
            Data.RepairTime = (float)tbRepairTime.Value;
            Data.DrivingTime = (float)tbDrivingTime.Value;
            Data.EveningTime = (float)tbEveningTime.Value;
            Data.NightTime = (float)tbNightTime.Value;
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
            btnOk.Enabled = tbStateNumber.SelectedItem != null &&
                tbOrder.SelectedItem != null &&
                tbIssueDate.Value.Date <= tbProcessingDate.Value.Date &&
                tbDepartureDateTime.Value >= tbIssueDate.Value.Date &&
                tbReturnDateTime.Value > tbDepartureDateTime.Value;
        }

        /// <summary>
        /// Обработчик события изменения выбора гос.номера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbStateNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbStateNumber.SelectedItem != null)
            {
                using (var server = new Server())
                {
                    // извлекаем объект "Транспортное Средство"
                    var tv = TransportVehicle.SelectItem(server.Connection, ((SelectorItem)tbStateNumber.SelectedItem).Id);
                    // извлекаем объект "Марка ТС"
                    var brand = TransportVehicleBrand.SelectItem(server.Connection, tv.BrandCode);
                    tbBrandCode.Text = brand.Code;
                    // извлекаем объект "Подразделение"
                    var division = Division.SelectItem(server.Connection, tv.DivisionCode);
                    tbDivision.Text = division.Name;
                    // извлекаем объект "Карточка водителя"
                    var card = DriverCard.SelectItem(server.Connection, tv.DriverName);
                    tbServiceNumber.Text = card.ServiceNumber;
                    tbDriverFullName.Text = card.FullName;
                    // извлекаем объект "ГСМ"
                    var fuel = Fuel.SelectItem(server.Connection, tv.MainEquipmentFuel);
                    tbMainEquipmentFuelName.Text = fuel.Name;
                    // извлекаем норму расхода основного топлива
                    tbMainConsumptionRate.Text = tv.MainConsumptionRate.ToString();
                }
            }
            else
            {
                tbBrandCode.Text = string.Empty;
                tbDivision.Text = string.Empty;
                tbServiceNumber.Text = string.Empty;
                tbDriverFullName.Text = string.Empty;
                tbMainEquipmentFuelName.Text = string.Empty;
                tbMainConsumptionRate.Text = string.Empty;
            }
        }

        private void tbOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbOrder.SelectedItem != null)
            {
                using (var server = new Server())
                {
                    // извлекаем объект "Заказ"
                    var order = Order.SelectItem(server.Connection, ((SelectorItem)tbOrder.SelectedItem).Id);
                    // извлекаем объект "Маршрут"
                    var route = Route.SelectItem(server.Connection, order.Route);
                    tbRouteName.Text = route.Name;
                    // извлекаем объект "Услуга"
                    var service = Service.SelectItem(server.Connection, order.Service);
                    tbServiceName.Text = service.Name;
                    // извлекаем объект "Тариф"
                    var rate = Rate.SelectItem(server.Connection, order.Rate);
                    tbRateName.Text = rate.Name;
                    // извлекаем объект "Организация-заказчик"
                    var customer = Organization.SelectItem(server.Connection, order.Сustomer);
                    tbСustomer.Text = customer.Name;
                }
            }
            else
            {
                tbRouteName.Text = string.Empty;
                tbServiceName.Text = string.Empty;
                tbRateName.Text = string.Empty;
                tbСustomer.Text = string.Empty;
            }
        }

        /// <summary>
        /// Расчет времени в поездке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculateTime_Click(object sender, EventArgs e)
        {
            if (tbOrder.SelectedItem == null || tbStateNumber.SelectedItem == null) return;
            CalculateDriverTime(((SelectorItem)tbOrder.SelectedItem).Id,
                ((SelectorItem)tbStateNumber.SelectedItem).Id);
        }

        private void CalculateDriverTime(int orderId, int stateNumberId)
        {
            using (var server = new Server())
            {
                // заказ
                var order = Order.SelectItem(server.Connection, orderId);
                // маршрут
                var route = Route.SelectItem(server.Connection, order.Route);
                // всего километров пути
                var travelLength = route.Length;
                // всего часов в пути, по маршруту в заказе
                var travelTimeHours = TimeSpan.FromHours(route.TravelTime);
                // корректировка показаний спидометра при возвращении
                tbReturningSpeedometerReadings.Value = tbDepartureSpeedometerReadings.Value + (decimal)travelLength;
                // время движения
                tbDrivingTime.Value = (decimal)travelTimeHours.TotalHours;
                // время простоя для ремонта
                var repairTimeHours = TimeSpan.FromHours((float)tbRepairTime.Value);
                var totalhours = Math.Round((travelTimeHours + repairTimeHours).TotalHours);
                // дата возвращения
                tbReturnDateTime.Value = tbDepartureDateTime.Value + TimeSpan.FromHours(totalhours);
                // примерный расчёт часов движения вечером и ночью
                var eveningHours = 0f;
                var nightHours = 0f;
                while (totalhours-- > 0)
                {
                    var dt = tbReturnDateTime.Value - TimeSpan.FromHours(totalhours);
                    if (dt.TimeOfDay.Hours >= 5 && dt.TimeOfDay.Hours < 17)
                    {
                        // 5.00 - 17.00 - дневное время
                    }
                    else if (dt.TimeOfDay.Hours >= 17 && dt.TimeOfDay.Hours < 23)
                    {
                        // 17.00 — 23.00 — вечер (x 1.5)
                        eveningHours += 1.0f;
                    }
                    else
                    {
                        // 23.00 — 5.00 — ночь (x 2)
                        nightHours += 1.0f;
                    }
                }
                // езда вечером
                tbEveningTime.Value = (decimal)eveningHours;
                // езда ночью
                tbNightTime.Value = (decimal)nightHours;

                /*
                 * На длинных маршрутах расчет потребления топлива дает отрицательное число остатка, т.к. транспорту надо периодически заправляться на маршруте, поэтому этот расчёт применять не буду                
                 
                // транспортное средство
                var tv = TransportVehicle.SelectItem(server.Connection, stateNumberId);
                // примерный расчёт расхода топлива
                var startTotalFuel = tbInitialFuelBalance.Value + tbFuelIssued.Value;
                var finishTotalFuel = startTotalFuel - (decimal)travelLength * tv.MainConsumptionRate;
                // остаток топлива фиксируем здесь
                tbFinalFuelRemainder.Value = finishTotalFuel;
                
                */
            }
        }

        /// <summary>
        /// Формирование лицевой стороны путевого листа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWaybillFrontFace_Click(object sender, EventArgs e)
        {
            var filename = Path.Combine(Application.StartupPath, "put_list.XLS");
            dynamic xl = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            try
            {
                var wb1 = xl.Workbooks.Open(filename, 0, true);
                try
                {
                    var count = wb1.Sheets.Count;
                    if (count == 2)
                    {
                        var sheet1 = wb1.Sheets[1];
                        sheet1.Cells[3, "CW"].Value = 123;

                        var documents = Path.Combine(Application.StartupPath, "Documents");
                        if (!Directory.Exists(documents))
                            Directory.CreateDirectory(documents);
                        wb1.SaveAs(Path.Combine(documents, $"plist_na_zakaz{Data.Id}.XLS"));
                    }
                }
                finally
                {
                    wb1.Close(false);
                }
            }
            finally
            {
                xl.Quit();
            }
        }

        /// <summary>
        /// Формирование обороной стороны путевого листа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWaybillBackFace_Click(object sender, EventArgs e)
        {

        }
    }
}
