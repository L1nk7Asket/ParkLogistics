using System;
using System.Windows.Forms;

namespace CargoTransportation
{
    public partial class MenuUC : UserControl
    {
        public MenuUC()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        }

        public event EventHandler TransportVehicleFilesMenu;
        public event EventHandler WaybillsMenu;
        public event EventHandler PaymentToDriversMenu;
        public event EventHandler ReportsMenu;

        private void btnTransportVehicleFilesMenu_Click(object sender, System.EventArgs e)
        {
            TransportVehicleFilesMenu?.Invoke(this, new EventArgs());
        }

        private void btnWaybillsMenu_Click(object sender, EventArgs e)
        {
            WaybillsMenu?.Invoke(this, new EventArgs());
        }

        private void btnPaymentToDriversMenu_Click(object sender, EventArgs e)
        {
            PaymentToDriversMenu?.Invoke(this, new EventArgs());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsMenu?.Invoke(this, new EventArgs());
        }

        private void flpMenu_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(Properties.Resources.texture, new System.Drawing.Rectangle(0, 0, Width, Height));
        }
    }
}
