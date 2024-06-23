using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CargoTransportationModel;

namespace CargoTransportationView
{
    public partial class WaybillTableForm : Form
    {
        public WaybillTableForm()
        {
            InitializeComponent();
        }

        private void WaybillTableForm_Load(object sender, EventArgs e)
        {
            FillTable();
        }

        /// <summary>
        /// Заполнение таблицы путевых листов
        /// </summary>
        private void FillTable()
        {
            using (var server = new Server())
            {
                var data = Waybill.SelectList(server.Connection);
                lvTable.Items.Clear();
                if (data.Tables.Count == 0) return;
                foreach (var row in data.Tables[0].Rows.Cast<DataRow>())
                {
                    var id = (int)row["Id"];
                    var lvi = new ListViewItem($"{id}") { Tag = id };
                    lvTable.Items.Add(lvi);
                    lvi.SubItems.Add(((DateTime)row["Дата_выпуска"]).ToString("dd.MM.yyyy"));
                    lvi.SubItems.Add(TransportVehicle.SelectItem(server.Connection, (int)row["Гос_номер"]).StateNumber);
                    var order = Order.SelectItem(server.Connection, (int)row["Заказ"]);
                    lvi.SubItems.Add($"{order.Id} ({Route.SelectItem(server.Connection, order.Route).Code})");
                    lvi.SubItems.Add(((DateTime)row["Дата_отправки"]).ToString("dd.MM.yyyy HH:mm"));
                    lvi.SubItems.Add(((DateTime)row["Дата_возврат"]).ToString("dd.MM.yyyy HH:mm"));
                    lvi.SubItems.Add(row["Время_вождения"].ToString()); 
                    lvi.SubItems.Add(Service.SelectItem(server.Connection, order.Service).Name);
                    lvi.SubItems.Add(Rate.SelectItem(server.Connection, order.Rate).Name);
                }
            }
        }

        /// <summary>
        /// Перемещение по строкам таблицы вызывает этот метод управления разрешением кнопок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            var anySelected = lvTable.SelectedIndices.Count > 0;
            btnUpdate.Enabled = anySelected;
            btnRemove.Enabled = anySelected;
            // кнопки формирования печати путевого листа доступны только после его формирования
            btnWaybillFace.Enabled = anySelected;
        }

        /// <summary>
        /// Добавить новый ПЛ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAppend_Click(object sender, EventArgs e)
        {
            var frm = new WaybillDetailForm();
            var item = new Waybill() 
            { 
                IssueDate = DateTime.Now.Date,
                ProcessingDate = DateTime.Now.Date,
                DepartureDateTime = DateTime.Now,
                ReturnDateTime = DateTime.Now,
            };
            frm.Build(item);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var server = new Server())
                    {
                        var id = Waybill.AddItem(server.Connection, frm.Data);
                        FillTable();
                        var lvi = lvTable.FindItemWithText($"{id}");
                        if (lvi != null)
                        {
                            lvi.Selected = true;
                            lvi.EnsureVisible();
                            lvTable.FocusedItem = lvi;
                            lvTable.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Ошибка добавления элемента", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
            }
        }

        /// <summary>
        /// Изменить текущий ПЛ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Выбор первого выбранного элемента списка
            var lvi = lvTable.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (lvi != null)
            {
                try
                {
                    // Получение идентификатора из тега элемента
                    var id = (int)lvi.Tag;
                    // Создание экземпляра формы WaybillDetailForm
                    var frm = new WaybillDetailForm();
                    using (var server = new Server())
                    {
                        // Получение элемента накладной
                        var item = Waybill.SelectItem(server.Connection, id);
                        // Заполнение формы данными элемента
                        frm.Build(item);
                        // Отображение формы и обработка результата
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            // Изменение элемента накладной
                            Waybill.ChangeItem(server.Connection, id, item);
                            // Обновление таблицы
                            FillTable();
                            // Поиск и выделение обновленного элемента в списке
                            lvi = lvTable.FindItemWithText($"{id}");
                            if (lvi != null)
                            {
                                lvi.Selected = true;
                                lvi.EnsureVisible();
                                lvTable.FocusedItem = lvi;
                                lvTable.Focus();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибки и вывод сообщения
                    MessageBox.Show(this, ex.Message, "Ошибка изменения записи", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
            }
        }


        /// <summary>
        /// Удалить текущий ПЛ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Показать диалоговое окно с вопросом о удалении элемента
            if (MessageBox.Show(this, "Удалить выделенный элемент из списка?", "Удаление элемента", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // Выбор первого выбранного элемента списка
                var lvi = lvTable.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
                if (lvi != null)
                {
                    try
                    {
                        // Получение идентификатора из тега элемента
                        var id = (int)lvi.Tag;
                        // Создание подключения к серверу
                        using (var server = new Server())
                        {
                            // Удаление элемента накладной
                            Waybill.RemoveItem(server.Connection, id);
                        }
                        // Удаление элемента из списка
                        lvTable.Items.Remove(lvi);
                    }
                    catch (Exception ex)
                    {
                        // Обработка ошибки и вывод сообщения
                        MessageBox.Show(this, ex.Message, "Ошибка удаления элемента", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                    }
                }
            }
        }


        /// <summary>
        /// Двойной щелчок вызывает редактирование ПЛ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvTable_DoubleClick(object sender, EventArgs e)
        {
            var lvi = lvTable.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (lvi != null)
            {
                btnUpdate.PerformClick();
            }
        }

        /// <summary>
        /// Формирование путевого листа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWaybillFace_Click(object sender, EventArgs e)
        {
            var lvi = lvTable.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (lvi == null) return;
            var id = (int)lvi.Tag;
            var filename = BuildWaybillOnExcel(id);
            if (!string.IsNullOrWhiteSpace(filename))
            {
                Process.Start(filename);
            }
        }

        /// <summary>
        /// Построение данных путевого листа на основе двухстраничного шаблона Excel
        /// </summary>
        /// <param name="id"></param>
        private string BuildWaybillOnExcel(int id)
        {
            var resultfilename = string.Empty;
            using (var server = new Server())
            {
                // Получаем объект ПЛ
                var waybill = Waybill.SelectItem(server.Connection, id);
                // Формируем папку с шаблонами
                var templates = Path.Combine(Application.StartupPath, "ArchiveLists");
                if (!Directory.Exists(templates))
                    Directory.CreateDirectory(templates);
                // Файл шаблона ПЛ
                var filename = Path.Combine(templates, "put_list.XLS");
                if (!File.Exists(filename))
                {
                    // Если не было, то создаем из ресурсов приложения
                    File.WriteAllBytes(filename, CargoTransportation.Properties.Resources.put_list_ori);
                    // Если не сформировался, выходим
                    if (!File.Exists(filename)) return resultfilename;
                }
                // Запускаем установленный на компьютере Excel
                dynamic xl = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
                Cursor = Cursors.WaitCursor; // длительная операция
                try
                {
                    var wb1 = xl.Workbooks.Open(filename, 0, true);
                    try
                    {
                        try
                        {
                            var count = wb1.Sheets.Count;
                            // Этот шаблон содржить ровно два листа
                            if (count == 2)
                            {
                                // работаем с лицевой стороной ПЛ
                                var sheet1 = wb1.Sheets[1];
                                sheet1.Cells[3, "CW"].Value = waybill.Id;                           // номер ПЛ
                                sheet1.Cells[5, "BG"].Value = waybill.IssueDate.Day;                // число даты выдачи ПЛ
                                sheet1.Cells[5, "BP"].Value = waybill.IssueDate.ToString("MMM");    // месяц даты выдачи ПЛ
                                sheet1.Cells[5, "CL"].Value = waybill.IssueDate.Year;               // год даты выдачи ПЛ
                                sheet1.Cells[6, "Q"].Value = "ООО \"Автомобилист\"";                // название транспортной компании

                                // извлекаем объект "Транспортное Средство"                            
                                var tv = TransportVehicle.SelectItem(server.Connection, waybill.StateNumber);
                                // извлекаем объект "Марка ТС"
                                var brand = TransportVehicleBrand.SelectItem(server.Connection, tv.BrandCode);
                                sheet1.Cells[13, "Q"].Value = brand.Code;                           // марка автомобиля
                                sheet1.Cells[14, "AB"].Value = tv.StateNumber;                      // гос.номер

                                // извлекаем объект "Карточка водителя"
                                var card = DriverCard.SelectItem(server.Connection, tv.DriverName);
                                sheet1.Cells[15, "I"].Value = card.FullName;                        // Ф.И.О. водителя
                                sheet1.Cells[15, "CI"].Value = card.ServiceNumber;                  // табельный номер водителя
                                sheet1.Cells[17, "P"].Value = card.IdentityCardNumber;              // удостоверение водителя
                                sheet1.Cells[17, "AS"].Value = card.Grade;                          // класс водителя

                                // извлекаем объект "Заказ"
                                var order = Order.SelectItem(server.Connection, waybill.Order);
                                var customer = Organization.SelectItem(server.Connection, order.Сustomer);
                                sheet1.Cells[37, "A"].Value = customer.Name;                        // заказчик

                                // извлекаем объект "Маршрут"
                                var route = Route.SelectItem(server.Connection, order.Route);
                                var routes = route.Code.Split('-');
                                var routeA = routes[0].Trim();
                                var routeB = routes.Length > 1 ? routes[1].Trim() : "";
                                sheet1.Cells[37, "AT"].Value = routeA;                              // маршрут пункт А
                                sheet1.Cells[37, "CE"].Value = routeB;                              // маршрут пункт Б

                                sheet1.Cells[37, "FB"].Value = 1;                                   // количество ездок
                                sheet1.Cells[37, "FL"].Value = route.Length;                        // расстояние, км

                                sheet1.Cells[14, "DM"].Value = waybill.DepartureDateTime.Day;       // число выезда
                                sheet1.Cells[14, "DT"].Value = waybill.DepartureDateTime.Month;     // месяц выезда
                                sheet1.Cells[14, "EA"].Value = waybill.DepartureDateTime.Hour;      // час выезда
                                sheet1.Cells[14, "EH"].Value = waybill.DepartureDateTime.Minute;    // минута выезда
                                sheet1.Cells[14, "EV"].Value = waybill.DepartureSpeedometerReadings;                // спидометр выеза
                                sheet1.Cells[14, "FH"].Value = waybill.DepartureDateTime.ToString("dd MMM, HH:mm"); // дата выезда факт

                                sheet1.Cells[15, "DM"].Value = waybill.ReturnDateTime.Day;          // число возвращения
                                sheet1.Cells[15, "DT"].Value = waybill.ReturnDateTime.Month;        // месяц возвращения
                                sheet1.Cells[15, "EA"].Value = waybill.ReturnDateTime.Hour;         // час возвращения
                                sheet1.Cells[15, "EH"].Value = waybill.ReturnDateTime.Minute;       // минута возвращения
                                sheet1.Cells[15, "EV"].Value = waybill.ReturningSpeedometerReadings;                // спидометр возвращения
                                sheet1.Cells[15, "FH"].Value = waybill.ReturnDateTime.ToString("dd MMM, HH:mm");    // дата возвращения факт

                                // извлекаем объект "ГСМ"
                                var fuel = Fuel.SelectItem(server.Connection, tv.MainEquipmentFuel);
                                sheet1.Cells[24, "CX"].Value = fuel.Name;                           // марка горючего
                                sheet1.Cells[24, "DG"].Value = fuel.Code;                           // код марки горючего
                                sheet1.Cells[24, "DO"].Value = waybill.FuelIssued;                  // выдано, л
                                sheet1.Cells[24, "DX"].Value = waybill.InitialFuelBalance;          // начальный остаток, л
                                sheet1.Cells[24, "EG"].Value = waybill.FinalFuelRemainder;          // конечный остаток, л
                                sheet1.Cells[24, "EQ"].Value = waybill.FuelPassed;                  // сдано, л

                                // работаем с обратной стороной ПЛ
                                var sheet2 = wb1.Sheets[2];
                                // расход горючего по норме, л
                                sheet2.Cells[36, "A"].Value = route.Length * tv.MainConsumptionRate;
                                // расход горючего фактически, л
                                sheet2.Cells[36, "I"].Value = waybill.InitialFuelBalance + waybill.FuelIssued - waybill.FinalFuelRemainder;
                                var totalTime = TimeSpan.FromHours(waybill.DrivingTime + waybill.RepairTime);
                                sheet2.Cells[36, "R"].Value = $"{totalTime.Hours}:{totalTime.Minutes}";       // общее время в наряде
                                var drivingTime = TimeSpan.FromHours(waybill.DrivingTime);
                                sheet2.Cells[36, "AH"].Value = $"{drivingTime.Hours}:{drivingTime.Minutes}";  // время в движении
                                var repairTime = TimeSpan.FromHours(waybill.RepairTime);
                                sheet2.Cells[36, "AU"].Value = $"{repairTime.Hours}:{repairTime.Minutes}";    // общее время в простое
                                sheet2.Cells[36, "CD"].Value = $"{repairTime.Hours}:{repairTime.Minutes}";    // по техническим неисправностям
                                // пробег автомобиля
                                sheet2.Cells[36, "DI"].Value = waybill.ReturningSpeedometerReadings - waybill.DepartureSpeedometerReadings;
                                // в том числе с грузом
                                sheet2.Cells[36, "DX"].Value = waybill.ReturningSpeedometerReadings - waybill.DepartureSpeedometerReadings;

                                // для расчета суммы оплаты за путевой лист
                                var driver = DriverCard.SelectItem(server.Connection, tv.DriverName);
                                var hourTaxRate = driver.HourlyTariffRate;
                                var hourRemains = TimeSpan.FromHours(waybill.DrivingTime).TotalHours -
                                    TimeSpan.FromHours(waybill.NightTime).TotalHours -
                                    TimeSpan.FromHours(waybill.EveningTime).TotalHours;
                                var summa = hourRemains * hourTaxRate +
                                    TimeSpan.FromHours(waybill.NightTime).TotalHours * hourTaxRate * 2.0 +
                                    TimeSpan.FromHours(waybill.EveningTime).TotalHours * hourTaxRate * 1.5;
                                // зарплата
                                sheet2.Cells[36, "FT"].Value = summa.ToString("0.00");
                                // формируем папку выходных документов
                                var documents = Path.Combine(Application.StartupPath, "Documents");
                                // создаем директорию, если необходимо
                                if (!Directory.Exists(documents))
                                    Directory.CreateDirectory(documents);
                                // записываем заполненный файл путевого листа
                                resultfilename = Path.Combine(documents, $"plist_na_zakaz{waybill.Id}.xls");
                                if (File.Exists(resultfilename))
                                    File.Delete(resultfilename);
                                wb1.SaveAs(resultfilename);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка подготовки Excel листа", MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
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
                    Cursor = Cursors.Default;
                }
            }
            return resultfilename;
        }
    }
}


/*
  /// <summary>
        /// Построение данных путевого листа на основе двухстраничного шаблона Excel
        /// </summary>
        /// <param name="id"></param>
        private string BuildWaybillOnExcel(int id)
        {
            var resultfilename = string.Empty;
            using (var server = new Server())
            {
                var waybill = Waybill.SelectItem(server.Connection, id);              
                var templates = Path.Combine(Application.StartupPath, "ArchiveLists");
                if (!Directory.Exists(templates))
                    Directory.CreateDirectory(templates);            
                var filename = Path.Combine(templates, "put_list.XLS");
                if (!File.Exists(filename))
                {
                  
                    File.WriteAllBytes(filename, CargoTransportation.Properties.Resources.put_list_ori);                
                    if (!File.Exists(filename)) return resultfilename;
                }
               
                dynamic xl = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
                Cursor = Cursors.WaitCursor; // длительная операция
                try
                {
                    var wb1 = xl.Workbooks.Open(filename, 0, true);
                    try
                    {
                        try
                        {
                            var count = wb1.Sheets.Count;
                         
                            if (count == 2)
                            {
                                // работаем с лицевой стороной ПЛ
                                var sheet1 = wb1.Sheets[1];
                                sheet1.Cells[3, "CW"].Value = waybill.Id;                      
                                sheet1.Cells[5, "BG"].Value = waybill.IssueDate.Day;              
                                sheet1.Cells[5, "BP"].Value = waybill.IssueDate.ToString("MMM");    
                                sheet1.Cells[5, "CL"].Value = waybill.IssueDate.Year;           
                                sheet1.Cells[6, "Q"].Value = "ООО \"Автомобилист\"";               

                                // извлекаем объект "Транспортное Средство"                            
                                var tv = TransportVehicle.SelectItem(server.Connection, waybill.StateNumber);
                                // извлекаем объект "Марка ТС"
                                var brand = TransportVehicleBrand.SelectItem(server.Connection, tv.BrandCode);
                                sheet1.Cells[13, "Q"].Value = brand.Code;                          
                                sheet1.Cells[14, "AB"].Value = tv.StateNumber;                    

                                // извлекаем объект "Карточка водителя"
                                var card = DriverCard.SelectItem(server.Connection, tv.DriverName);
                                sheet1.Cells[15, "I"].Value = card.FullName;                       
                                sheet1.Cells[15, "CI"].Value = card.ServiceNumber;                 
                                sheet1.Cells[17, "P"].Value = card.IdentityCardNumber;             
                                sheet1.Cells[17, "AS"].Value = card.Grade;                         
                                var order = Order.SelectItem(server.Connection, waybill.Order);
                                var customer = Organization.SelectItem(server.Connection, order.Сustomer);
                                sheet1.Cells[37, "A"].Value = customer.Name;                    

                                var route = Route.SelectItem(server.Connection, order.Route);
                                var routes = route.Code.Split('-');
                                var routeA = routes[0].Trim();
                                var routeB = routes.Length > 1 ? routes[1].Trim() : "";
                                sheet1.Cells[37, "AT"].Value = routeA;                        
                                sheet1.Cells[37, "CE"].Value = routeB;                             

                                sheet1.Cells[37, "FB"].Value = 1;                                
                                sheet1.Cells[37, "FL"].Value = route.Length;                       

                                sheet1.Cells[14, "DM"].Value = waybill.DepartureDateTime.Day;       
                                sheet1.Cells[14, "DT"].Value = waybill.DepartureDateTime.Month;     
                                sheet1.Cells[14, "EA"].Value = waybill.DepartureDateTime.Hour;      
                                sheet1.Cells[14, "EH"].Value = waybill.DepartureDateTime.Minute;   
                                sheet1.Cells[14, "EV"].Value = waybill.DepartureSpeedometerReadings;                
                                sheet1.Cells[14, "FH"].Value = waybill.DepartureDateTime.ToString("dd MMM, HH:mm"); 

                                sheet1.Cells[15, "DM"].Value = waybill.ReturnDateTime.Day;        
                                sheet1.Cells[15, "DT"].Value = waybill.ReturnDateTime.Month;      
                                sheet1.Cells[15, "EA"].Value = waybill.ReturnDateTime.Hour;         
                                sheet1.Cells[15, "EH"].Value = waybill.ReturnDateTime.Minute;       
                                sheet1.Cells[15, "EV"].Value = waybill.ReturningSpeedometerReadings;               
                                sheet1.Cells[15, "FH"].Value = waybill.ReturnDateTime.ToString("dd MMM, HH:mm");    

                              
                                var fuel = Fuel.SelectItem(server.Connection, tv.MainEquipmentFuel);
                                sheet1.Cells[24, "CX"].Value = fuel.Name;                           
                                sheet1.Cells[24, "DG"].Value = fuel.Code;                           
                                sheet1.Cells[24, "DO"].Value = waybill.FuelIssued;                 
                                sheet1.Cells[24, "DX"].Value = waybill.InitialFuelBalance;        
                                sheet1.Cells[24, "EG"].Value = waybill.FinalFuelRemainder;         
                                sheet1.Cells[24, "EQ"].Value = waybill.FuelPassed;                 
                            
                                sheet2.Cells[36, "A"].Value = route.Length * tv.MainConsumptionRate;                               
                                sheet2.Cells[36, "I"].Value = waybill.InitialFuelBalance + waybill.FuelIssued - waybill.FinalFuelRemainder;
                                var totalTime = TimeSpan.FromHours(waybill.DrivingTime + waybill.RepairTime);
                                sheet2.Cells[36, "R"].Value = $"{totalTime.Hours}:{totalTime.Minutes}";      
                                var drivingTime = TimeSpan.FromHours(waybill.DrivingTime);
                                sheet2.Cells[36, "AH"].Value = $"{drivingTime.Hours}:{drivingTime.Minutes}";  
                                var repairTime = TimeSpan.FromHours(waybill.RepairTime);
                                sheet2.Cells[36, "AU"].Value = $"{repairTime.Hours}:{repairTime.Minutes}";    
                                sheet2.Cells[36, "CD"].Value = $"{repairTime.Hours}:{repairTime.Minutes}";                                
                                sheet2.Cells[36, "DI"].Value = waybill.ReturningSpeedometerReadings - waybill.DepartureSpeedometerReadings;                               
                                sheet2.Cells[36, "DX"].Value = waybill.ReturningSpeedometerReadings - waybill.DepartureSpeedometerReadings;                                
                                var driver = DriverCard.SelectItem(server.Connection, tv.DriverName);
                                var hourTaxRate = driver.HourlyTariffRate;
                                var hourRemains = TimeSpan.FromHours(waybill.DrivingTime).TotalHours -
                                    TimeSpan.FromHours(waybill.NightTime).TotalHours -
                                    TimeSpan.FromHours(waybill.EveningTime).TotalHours;
                                var summa = hourRemains * hourTaxRate +
                                    TimeSpan.FromHours(waybill.NightTime).TotalHours * hourTaxRate * 2.0 +
                                    TimeSpan.FromHours(waybill.EveningTime).TotalHours * hourTaxRate * 1.5;                               
                                sheet2.Cells[36, "FT"].Value = summa.ToString("0.00");
                                var documents = Path.Combine(Application.StartupPath, "Documents");                               
                                if (!Directory.Exists(documents))
                                    Directory.CreateDirectory(documents);                                
                                resultfilename = Path.Combine(documents, $"plist_na_zakaz{waybill.Id}.xls");
                                if (File.Exists(resultfilename))
                                    File.Delete(resultfilename);
                                wb1.SaveAs(resultfilename);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка подготовки Excel листа", MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
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
                    Cursor = Cursors.Default;
                }
            }
            return resultfilename;
        }
 */