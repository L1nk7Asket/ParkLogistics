using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CargoTransportationModel;

namespace CargoTransportationView
{
    public partial class PaymentDetailForm : Form
    {
        // данные
        public Payment Data { get; private set; }

        public PaymentDetailForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Занесение данных из объекта данных в контролы
        /// </summary>
        /// <param name="data">Объект с данными для заполнения контролов</param>
        public void Build(Payment data)
        {
            // сохраняем объект в своём свойстве
            Data = data;
            tbPaymentType.Items.Clear();
            using (var server = new Server())
            {
                var dsPaymentType = PaymentType.SelectList(server.Connection);
                foreach (var row in dsPaymentType.Tables[0].Rows.Cast<DataRow>())
                {
                    var item = new SelectorItem() { Id = (int)row["Id"], Name = (string)row["Имя"] };
                    tbPaymentType.Items.Add(item);
                }
                tbPaymentType.SelectedItem = tbPaymentType.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.PaymentType);
                if (tbPaymentType.SelectedItem != null)
                {
                    var paytype = PaymentType.SelectItem(server.Connection, ((SelectorItem)tbPaymentType.SelectedItem).Id);
                    tbSumma.Enabled = paytype.Code == 2; // разрешено изменение при сдельной оплате
                }
            }
            tbSumma.Value = (decimal)Data.Summa;
            tbWaybill.Items.Clear();
            using (var server = new Server())
            {
                var dsWaybill = Waybill.SelectList(server.Connection);
                foreach (var row in dsWaybill.Tables[0].Rows.Cast<DataRow>())
                {
                    var item = new SelectorItem() 
                    { 
                        Id = (int)row["Id"], 
                        Name = $"№{row["Id"]}" 
                    };
                    tbWaybill.Items.Add(item);
                }
            }
            tbWaybill.SelectedItem = tbWaybill.Items.Cast<SelectorItem>().FirstOrDefault(item => item.Id == Data.Waybill);
            btnOk.Enabled = false;
        }

        /// <summary>
        /// Парсинг и проверка на правильность
        /// </summary>
        public void UpdateValue()
        {
            Data.Waybill = ((SelectorItem)tbWaybill.SelectedItem).Id;
            Data.PaymentType = ((SelectorItem)tbPaymentType.SelectedItem).Id;
            Data.Summa = (double)tbSumma.Value;
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
            btnOk.Enabled = tbWaybill.SelectedItem != null &&
                tbPaymentType.SelectedItem != null;
        }

        private void tbWaybill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbWaybill.SelectedItem == null || tbPaymentType.SelectedItem == null) return;
            using (var server = new Server())
            {
                // для маршрута
                var waybill = Waybill.SelectItem(server.Connection, ((SelectorItem)tbWaybill.SelectedItem).Id);
                var order = Order.SelectItem(server.Connection, waybill.Order);
                var route = Route.SelectItem(server.Connection, order.Route);
                tbRouteCode.Text = route.Code;
                // для ФИО водителя
                var tv = TransportVehicle.SelectItem(server.Connection, waybill.StateNumber);
                var driver = DriverCard.SelectItem(server.Connection, tv.DriverName);
                var vals = driver.FullName.Split(' ');
                var fio = vals[0];
                if (vals.Length > 1) fio += $" {vals[1].Substring(0, 1)}.";
                if (vals.Length > 2) fio += $"{vals[2].Substring(0, 1)}.";
                tbDriverName.Text = fio;
                var paytype = PaymentType.SelectItem(server.Connection, ((SelectorItem)tbPaymentType.SelectedItem).Id);
                if (paytype.Code == 1)
                {
                    // для расчета суммы оплаты за путевой лист
                    var hourTaxRate = driver.HourlyTariffRate;
                    var hourRemains = TimeSpan.FromHours(waybill.DrivingTime).TotalHours -
                        TimeSpan.FromHours(waybill.NightTime).TotalHours -
                        TimeSpan.FromHours(waybill.EveningTime).TotalHours;
                    var summa = hourRemains * hourTaxRate +
                        TimeSpan.FromHours(waybill.NightTime).TotalHours * hourTaxRate * 2.0 +
                        TimeSpan.FromHours(waybill.EveningTime).TotalHours * hourTaxRate * 1.5;
                    // если оплата повременная, то корректируем сумму оплаты
                    tbSumma.Text = summa.ToString("0.00");
                }
                tbSumma.Enabled = paytype.Code == 2; // разрешено изменение при сдельной оплате
            }
        }
    }
}
