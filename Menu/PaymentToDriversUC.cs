using System;
using System.Windows.Forms;

namespace CargoTransportation
{
    public partial class PaymentToDriversUC : UserControl
    {
        public PaymentToDriversUC()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        }

        public event EventHandler PaymentTypesForm;
        public event EventHandler PaymentToDriversForm;

        private void btnPaymentTypes_Click(object sender, EventArgs e)
        {
            PaymentTypesForm?.Invoke(this, new EventArgs());
        }

        private void btnPaymentToDrivers_Click(object sender, EventArgs e)
        {
            PaymentToDriversForm?.Invoke(this, new EventArgs());
        }

        private void PaymentToDriversUC_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.texture, new System.Drawing.Rectangle(0, 0, Width, Height));
        }
    }
}
