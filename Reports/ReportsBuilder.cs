using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using CargoTransportationModel;
using CargoTransportationView;

namespace Reports
{
    /// <summary>
    /// Построитель отчетов
    /// </summary>
    public static class ReportsBuilder
    {

        /// <summary>
        /// Реестр по заказчикам
        /// </summary>
        /// <returns></returns>
        public static Report CustomersRegisterReport()
        {
            var caption = "Реестр по заказчикам";
            var report = new Report
            {
                Caption = caption,
                Landscape = true
            };
            report.ReportTopColumns.Add(
                    new ReportColumn("Заказчик", 150),
                    new ReportColumn("Наименование маршрута", 250),
                    new ReportColumn("Марка ТС", 150),
                    new ReportColumn("Гос.номер ТС", 130),
                    new ReportColumn("Количество ПЛ", 200),
                    new ReportColumn("Услуга", 200)
                );
            // определение обработчика печати страницы отчета
            report.PrintPage = (o, e, rect, offset) =>
            {
                var leftShift = 10;
                SizeF strSize = new SizeF();
                var strPoint = offset;
                // составляем список из верхнего, среднего и нижнего заголовков
                var headerList = new List<ReportColumns>()
                {
                    report.ReportTopColumns,
                };
                // Печать заголовка таблицы
                using (var headerfont = new Font("Times New Roman", 12, FontStyle.Bold))
                using (var sf = new StringFormat())
                {
                    sf.LineAlignment = StringAlignment.Center;
                    strPoint.X = rect.X + leftShift;
                    // выводим заголовки построчно один под другим
                    foreach (var columns in headerList)
                    {
                        // выводим колонки заголовка
                        foreach (var header in columns)
                        {
                            sf.Alignment = header.Alignment;
                            strSize = e.Graphics.MeasureString(header.Text, headerfont);
                            var r = new Rectangle(Point.Ceiling(strPoint), new Size(header.Width, (int)strSize.Height));
                            // рисуем рамку вокруг заголовка колонки
                            e.Graphics.DrawRectangle(Pens.Gray, r);
                            // рисуем текст заголовка колонки
                            e.Graphics.DrawString(header.Text, headerfont, Brushes.Black, r, sf);
                            strPoint.X += header.Width;
                        }
                        // перемещаем точку привязки в левую позицию листа
                        strPoint.X = rect.X + leftShift;
                        // перемещаемся на следующую строчку
                        strPoint.Y += (int)strSize.Height;
                    }
                }
                strPoint.Y += 3; // небольшой отступ от заголовка

                AddCustomersRegisterReportRows(report);

                // Печать строк тела таблицы
                using (var rowfont = new Font("Times New Roman", 12, FontStyle.Regular))
                using (var sf = new StringFormat())
                {
                    sf.LineAlignment = StringAlignment.Center;
                    foreach (var row in report.ReportRows)
                    {
                        strPoint.X = rect.X + leftShift;
                        // здесь будет значение
                        string value;
                        // получаем значимый заголовок (где реальное количество столбцов)
                        var columns = headerList[headerList.Count - 1];
                        for (var i = 0; i < columns.Count; i++)
                        {
                            sf.Alignment = columns[i].Alignment;
                            value = row.Items[i];
                            var r = new Rectangle(Point.Ceiling(strPoint),
                                new Size(columns[i].Width, (int)strSize.Height));
                            // рисуем значение
                            e.Graphics.DrawString(value, rowfont, Brushes.Black, r, sf);
                            // смещается к следующей колонке
                            strPoint.X += columns[i].Width;
                        }
                        // смещаемся к следующей строке
                        strPoint.Y += (int)strSize.Height;
                    }
                }

            };
            return report;
        }

        private static void AddCustomersRegisterReportRows(Report report)
        {
            // добавляем строки в отчет
            using (var server = new Server())
            {
                var data = Organization.SelectList(server.Connection);
                if (data.Tables.Count == 1)
                {
                    foreach (var row in data.Tables[0].Rows.Cast<DataRow>())
                    {
                        var customer = Organization.SelectItem(server.Connection, (int)row["Id"]);
                        var ordersData = Order.SelectList(server.Connection);
                        if (ordersData.Tables.Count == 0) continue;
                        foreach (var row1 in data.Tables[0].Rows.Cast<DataRow>())
                        {
                            var order = Order.SelectItem(server.Connection, (int)row1["Id"]);
                            if (order.Сustomer != customer.Id) continue;
                            // выбираем заказы только с этим заказчиком
                            var waybillsData = Waybill.SelectList(server.Connection);
                            if (waybillsData.Tables.Count == 0) continue;
                            var waybillCount = 0;
                            // подсчёт кол-ва путевых листов по данному заказу
                            string brandName = "", stateNumber = "";
                            foreach (var row2 in data.Tables[0].Rows.Cast<DataRow>())
                            {
                                var waybill = Waybill.SelectItem(server.Connection, (int)row2["Id"]);
                                if (waybill.Order != order.Id) continue;
                                // выбираем путевые листы только с этим заказом
                                var tv = TransportVehicle.SelectItem(server.Connection, waybill.StateNumber);
                                brandName = TransportVehicleBrand.SelectItem(server.Connection, tv.BrandCode).Code;
                                stateNumber = tv.StateNumber;
                                waybillCount++;
                            }
                            report.ReportRows.Add(
                                customer.Name,                                              // организация-заказчик
                                Route.SelectItem(server.Connection, order.Route).Code,      // наименование маршрута
                                brandName,                                                  // марка ТС
                                stateNumber,                                                // гос.номер ТС
                                waybillCount.ToString(),                                    // количество ПЛ
                                Service.SelectItem(server.Connection, order.Service).Name   // услуга
                            );
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Журнал регистрации путевых листов
        /// </summary>
        /// <returns></returns>
        public static Report WaybillLogReport()
        {
            var caption = "Журнал регистрации путевых листов";
            var report = new Report
            {
                Caption = caption,
                Landscape = true
            };
            report.ReportTopColumns.Add(
                new ReportColumn("№ п/п", 60),
                new ReportColumn("Номер ПЛ", 90),
                new ReportColumn("Дата", 70),
                new ReportColumn("Водитель", 270),
                new ReportColumn("Гос.номер", 90),
                new ReportColumn("Показания спидометра", 210),
                new ReportColumn("Показатели расхода ГСМ, л", 300)
                );
            report.ReportMiddleColumns.Add(
                new ReportColumn(" ", 60),  // № п/п
                new ReportColumn(" ", 90),  // Номер ПЛ
                new ReportColumn(" ", 70),  // Дата
                new ReportColumn("Фамилия И.О.", 210, StringAlignment.Near),
                new ReportColumn("Таб.№", 60),
                new ReportColumn(" ", 90),  // Гос.номер ТС
                // показания спидометра
                new ReportColumn("Выезд", 70),
                new ReportColumn("Приезд", 70),
                new ReportColumn("Пробег", 70),
                // показатели расхода топлива
                new ReportColumn("Было", 60),
                new ReportColumn("Выдано", 60),
                new ReportColumn("Остаток", 60),
                new ReportColumn("Сдано", 60),
                new ReportColumn("Расход", 60)
                );
            // добавляем строки в отчет
            using (var server = new Server())
            {
                var data = Waybill.SelectList(server.Connection);
                if (data.Tables.Count == 1)
                {
                    var npp = 1;
                    foreach (var row in data.Tables[0].Rows.Cast<DataRow>())
                    {
                        var waybill = Waybill.SelectItem(server.Connection, (int)row["Id"]);
                        var tv = TransportVehicle.SelectItem(server.Connection, waybill.StateNumber);
                        var division = Division.SelectItem(server.Connection, tv.DivisionCode);
                        var driver = DriverCard.SelectItem(server.Connection, tv.DriverName);
                        report.ReportRows.Add(
                            npp.ToString(),                                     // номер по порядку
                            waybill.Id.ToString(),                              // номер ПЛ
                            waybill.IssueDate.ToString("dd.MM.yy"),             // дата выдачи ПЛ
                            driver.FullName,                                    // фамилия и.о.
                            driver.ServiceNumber,                               // табельный номер
                            tv.StateNumber,                                     // гос.номер ТС
                            waybill.DepartureSpeedometerReadings.ToString(),    // спидометр при выезе
                            waybill.ReturningSpeedometerReadings.ToString(),    // спидометр при заезде
                            (waybill.ReturningSpeedometerReadings - waybill.DepartureSpeedometerReadings).ToString(), // пробег
                            waybill.InitialFuelBalance.ToString(),              // начальный остаток (л)
                            waybill.FuelIssued.ToString(),                      // выдано (л)
                            waybill.FinalFuelRemainder.ToString(),              // конечный остаток (л)
                            waybill.FuelPassed.ToString(),                      // сдано (л)
                            (waybill.InitialFuelBalance + waybill.FuelIssued - waybill.FinalFuelRemainder).ToString() // расход
                        );
                        npp++;
                    }
                }
            }
            // определение обработчика печати страницы отчета
            report.PrintPage = (o, e, rect, offset) =>
            {
                var leftShift = 10;
                SizeF strSize = new SizeF();
                var strPoint = offset;

                strPoint.X = rect.X + leftShift;
                Rectangle r;
                // составляем список из верхнего, среднего и нижнего заголовков
                var headerList = new List<ReportColumns>()
                {
                    report.ReportTopColumns,
                    report.ReportMiddleColumns,
                };
                // Печать заголовка таблицы
                using (var headerfont = new Font("Times New Roman", 9, FontStyle.Bold))
                using (var sf = new StringFormat())
                {
                    sf.LineAlignment = StringAlignment.Center;
                    strPoint.X = rect.X + leftShift;
                    // выводим заголовки построчно один под другим
                    foreach (var columns in headerList)
                    {
                        // выводим колонки заголовка
                        foreach (var header in columns)
                        {
                            sf.Alignment = header.Alignment;
                            strSize = e.Graphics.MeasureString(header.Text, headerfont);
                            strSize.Height += 3;
                            r = new Rectangle(Point.Ceiling(strPoint), new Size(header.Width, (int)strSize.Height));
                            // рисуем рамку вокруг заголовка колонки
                            e.Graphics.DrawRectangle(Pens.Gray, r);
                            // рисуем текст заголовка колонки
                            e.Graphics.DrawString(header.Text, headerfont, Brushes.Black, r, sf);
                            strPoint.X += header.Width;
                        }
                        // перемещаем точку привязки в левую позицию листа
                        strPoint.X = rect.X + leftShift;
                        // перемещаемся на следующую строчку
                        strPoint.Y += (int)strSize.Height;
                    }
                }
                // Печать строк тела таблицы
                using (var rowfont = new Font("Times New Roman", 12, FontStyle.Regular))
                using (var sf = new StringFormat())
                {
                    sf.LineAlignment = StringAlignment.Center;
                    foreach (var row in report.ReportRows)
                    {
                        strPoint.X = rect.X + leftShift;
                        // здесь будет значение
                        string value;
                        // получаем значимый заголовок (где реальное количество столбцов)
                        var columns = headerList[headerList.Count - 1];
                        for (var i = 0; i < columns.Count; i++)
                        {
                            sf.Alignment = columns[i].Alignment;
                            value = row.Items[i];
                            strSize = e.Graphics.MeasureString(value, rowfont);
                            strSize.Height += 3;
                            r = new Rectangle(Point.Ceiling(strPoint),
                                new Size(columns[i].Width, (int)strSize.Height));
                            // рисуем рамку вокруг заголовка колонки
                            e.Graphics.DrawRectangle(Pens.Gray, r);
                            // рисуем значение
                            e.Graphics.DrawString(value, rowfont, Brushes.Black, r, sf);
                            // смещается к следующей колонке
                            strPoint.X += columns[i].Width;
                        }
                        // смещаемся к следующей строке
                        strPoint.Y += (int)strSize.Height;
                    }
                }
            };
            return report;
        }

        /// <summary>
        /// Ведомость заработной платы по путевым листам
        /// </summary>
        /// <returns></returns>
        public static Report SalaryStatementReport()
        {
            var caption = "Ведомость заработной платы по путевым листам";
            var report = new Report
            {
                Caption = caption,
                Landscape = true
            };
            report.ReportTopColumns.Add(
                new ReportColumn("Дата", 80),
                new ReportColumn("Номер ПЛ", 100),
                new ReportColumn("Марка ТС", 100),
                new ReportColumn("Отработано", 210),
                new ReportColumn("Оплата по путевым листам, руб.", 610)
                );
            report.ReportMiddleColumns.Add(
                new ReportColumn(" ", 80),
                new ReportColumn(" ", 100),
                new ReportColumn(" ", 100),
                new ReportColumn("Дни", 60),
                new ReportColumn("Часы", 60),
                new ReportColumn("Пробег", 90),
                new ReportColumn("Повременная", 130, StringAlignment.Far),
                new ReportColumn("Сдельная", 100, StringAlignment.Far),
                new ReportColumn("Ночные", 100, StringAlignment.Far),
                new ReportColumn("Вечерние", 100, StringAlignment.Far),
                new ReportColumn("Ремонт", 80, StringAlignment.Far),
                new ReportColumn("Итого", 100, StringAlignment.Far)
                );
            // определение обработчика печати страницы отчета
            report.PrintPage = (o, e, rect, offset) =>
            {
                var leftShift = 10;
                SizeF strSize = new SizeF();
                var strPoint = offset;

                var infos = SalaryStatementDriversInfo();
                foreach (var driverId in infos.Keys)
                {
                    // Печать данных водителя
                    var items = infos[driverId];
                    strPoint.X = rect.X + leftShift;
                    Rectangle r;
                    using (var headerfont = new Font("Times New Roman", 12, FontStyle.Bold))
                    {
                        var flip = false;
                        // слова из списка items печатаются друг за другом, у чётного слова ширина чуть больше 
                        foreach (var text in items)
                        {
                            // если пустое поле, то нужно сделать переход на начало новой строки
                            if (string.IsNullOrWhiteSpace(text))
                            {
                                strPoint.X = rect.X + leftShift;
                                strPoint.Y += strSize.Height + 10;
                                continue;
                            }
                            strSize = e.Graphics.MeasureString(text, headerfont);
                            // здесь управляем шириной чётного слова
                            r = new Rectangle(Point.Ceiling(strPoint), new Size((int)strSize.Width + (flip ? 20 : 3), (int)strSize.Height));
                            e.Graphics.DrawString(text, headerfont, Brushes.Black, r);
                            strPoint.X += r.Width;
                            // признак чётного слова
                            flip = !flip;
                        }
                    }
                    strPoint.Y += strSize.Height + 10;
                    // составляем список из верхнего, среднего и нижнего заголовков
                    var headerList = new List<ReportColumns>()
                    {
                        report.ReportTopColumns,
                        report.ReportMiddleColumns,
                    };
                    // Печать заголовка таблицы
                    using (var headerfont = new Font("Times New Roman", 14, FontStyle.Bold))
                    using (var sf = new StringFormat())
                    {
                        sf.LineAlignment = StringAlignment.Center;
                        strPoint.X = rect.X + leftShift;
                        // выводим заголовки построчно один под другим
                        foreach (var columns in headerList)
                        {
                            // выводим колонки заголовка
                            foreach (var header in columns)
                            {
                                sf.Alignment = header.Alignment;
                                strSize = e.Graphics.MeasureString(header.Text, headerfont);
                                r = new Rectangle(Point.Ceiling(strPoint), new Size(header.Width, (int)strSize.Height));
                                // рисуем рамку вокруг заголовка колонки
                                e.Graphics.DrawRectangle(Pens.Gray, r);
                                // рисуем текст заголовка колонки
                                e.Graphics.DrawString(header.Text, headerfont, Brushes.Black, r, sf);
                                strPoint.X += header.Width;
                            }
                            // перемещаем точку привязки в левую позицию листа
                            strPoint.X = rect.X + leftShift;
                            // перемещаемся на следующую строчку
                            strPoint.Y += (int)strSize.Height;
                        }
                    }
                    strPoint.Y += 3; // небольшой отступ от заголовка

                    // добавляем строки в отчет
                    SalaryStatementAddReportRows(report, driverId);

                    // Печать строк тела таблицы
                    using (var rowfont = new Font("Times New Roman", 12, FontStyle.Regular))
                    using (var sf = new StringFormat())
                    {
                        sf.LineAlignment = StringAlignment.Center;
                        foreach (var row in report.ReportRows)
                        {
                            strPoint.X = rect.X + leftShift;
                            // здесь будет значение
                            string value;
                            // получаем значимый заголовок (где реальное количество столбцов)
                            var columns = headerList[headerList.Count - 1];
                            for (var i = 0; i < columns.Count; i++)
                            {
                                sf.Alignment = columns[i].Alignment;
                                value = row.Items[i];
                                r = new Rectangle(Point.Ceiling(strPoint),
                                    new Size(columns[i].Width, (int)strSize.Height));
                                // рисуем рамку вокруг заголовка колонки
                                e.Graphics.DrawRectangle(Pens.Gray, r);
                                // рисуем значение
                                e.Graphics.DrawString(value, rowfont, Brushes.Black, r, sf);
                                // смещается к следующей колонке
                                strPoint.X += columns[i].Width;
                            }
                            // смещаемся к следующей строке
                            strPoint.Y += (int)strSize.Height;
                        }
                    }
                    strPoint.Y += (int)strSize.Height; // отступ для следующего водителя
                }
            };
            return report;
        }

        /// <summary>
        /// Получение данных о водителях в рамках оплаты путевых листов
        /// </summary>
        /// <returns></returns>
        private static Dictionary<int, List<string>> SalaryStatementDriversInfo()
        {
            var result = new Dictionary<int, List<string>>();
            using (var server = new Server())
            {
                var data = Payment.SelectList(server.Connection);
                if (data.Tables.Count == 1)
                {
                    foreach (var row in data.Tables[0].Rows.Cast<DataRow>())
                    {
                        var waybill = Waybill.SelectItem(server.Connection, (int)row["Накладная"]);
                        var tv = TransportVehicle.SelectItem(server.Connection, waybill.StateNumber);
                        var division = Division.SelectItem(server.Connection, tv.DivisionCode);
                        var driver = DriverCard.SelectItem(server.Connection, tv.DriverName);
                        if (!result.ContainsKey(tv.DriverName))
                            result.Add(tv.DriverName, new List<string>()
                        {
                            "Наименование подразделения:", division.Name, "",
                            "Водитель:", driver.FullName,
                            "Таб.№:", driver.ServiceNumber,
                            "Класс:", driver.Grade
                        });
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Добавление строк в отчет по оплате водителям
        /// </summary>
        /// <param name="report">Отчет, куда добавляем строки</param>
        private static void SalaryStatementAddReportRows(Report report, int driverId)
        {
            report.ReportRows.Clear();
            using (var server = new Server())
            {
                var data = Payment.SelectList(server.Connection);
                if (data.Tables.Count == 1)
                {
                    foreach (var row in data.Tables[0].Rows.Cast<DataRow>())
                    {
                        var waybill = Waybill.SelectItem(server.Connection, (int)row["Накладная"]);
                        var tv = TransportVehicle.SelectItem(server.Connection, waybill.StateNumber);
                        if (tv.DriverName != driverId) continue;
                        var driver = DriverCard.SelectItem(server.Connection, tv.DriverName);
                        // для расчета суммы оплаты за путевой лист
                        var hourTaxRate = driver.HourlyTariffRate;
                        var paytypeCode = PaymentType.SelectItem(server.Connection, (int)row["Тип_платежа"]).Code;
                        // paytypeCode == 1 - повременная оплата, paytypeCode == 2 - сдельная оплата
                        var ToNightTime = TimeSpan.FromHours(waybill.NightTime).TotalHours * hourTaxRate * 2.0;
                        var ToEveningTime = TimeSpan.FromHours(waybill.EveningTime).TotalHours * hourTaxRate * 1.5;
                        var ToRepairTime = TimeSpan.FromHours(waybill.RepairTime).TotalHours * hourTaxRate;
                        var summa = (double)row["Сумма"];
                        // добавляем строку в отчёт
                        report.ReportRows.Add(
                            waybill.IssueDate.ToString("dd.MM.yy"), // дата ПЛ
                            waybill.Id.ToString(),                  // номер ПЛ
                            TransportVehicle.SelectItem(server.Connection, waybill.StateNumber).StateNumber,            // марка ТС
                            "",                                                                                         // отработано, дни
                            (waybill.DrivingTime + waybill.RepairTime).ToString(),                                      // отработано, часы
                            (waybill.ReturningSpeedometerReadings - waybill.DepartureSpeedometerReadings).ToString(),   // отработано, пробег
                            paytypeCode == 1 ? summa.ToString("0.00") : "",                 // повременная
                            paytypeCode == 2 ? summa.ToString("0.00") : "",                 // сдельная
                            paytypeCode == 1 ? ToNightTime.ToString("0.00") : "",           // за ночные
                            paytypeCode == 1 ? ToEveningTime.ToString("0.00") : "",         // за вечерние
                            ToRepairTime.ToString("0.00"),                                  // ремонт
                            (summa + ToRepairTime).ToString("0.00")                         // итого
                        );
                    }
                }
            }
        }
    }
}
