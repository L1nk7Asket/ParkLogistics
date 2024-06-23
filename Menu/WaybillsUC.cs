using System;
using System.Windows.Forms;

namespace CargoTransportation
{
    public partial class WaybillsUC : UserControl
    {
        public WaybillsUC()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        }

        public event EventHandler OrganizationsForm;
        public event EventHandler RoutesForm;
        public event EventHandler RatesForm;
        public event EventHandler ServicesForm;
        public event EventHandler OrdersForm;
        public event EventHandler WaybillsForm;

        private void btnOrganizations_Click(object sender, EventArgs e)
        {
            OrganizationsForm?.Invoke(this, new EventArgs());
        }

        private void btnRoutes_Click(object sender, EventArgs e)
        {
            RoutesForm?.Invoke(this, new EventArgs());
        }

        private void btnRates_Click(object sender, EventArgs e)
        {
            RatesForm?.Invoke(this, new EventArgs());
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            ServicesForm?.Invoke(this, new EventArgs());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OrdersForm?.Invoke(this, new EventArgs());
        }

        private void btnWaybills_Click(object sender, EventArgs e)
        {
            WaybillsForm?.Invoke(this, new EventArgs());
        }

        private void WaybillsUC_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.texture, new System.Drawing.Rectangle(0, 0, Width, Height));
        }
    }
}
