using System;
using System.Windows.Forms;

namespace CargoTransportation
{
    public partial class ToolsUC : UserControl
    {
        public ToolsUC()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        }

        public event EventHandler TransportVehicleTypesForm;
        public event EventHandler TransportVehicleBrandsForm;
        public event EventHandler DriverCardsForm;
        public event EventHandler FuelAndLubricantsForm;
        public event EventHandler DivisionsForm;
        public event EventHandler TransportVehiclesForm;

        private void btnTransportVehicleTypes_Click(object sender, EventArgs e)
        {
            TransportVehicleTypesForm?.Invoke(this, new EventArgs());
        }

        private void btnTransportVehicleBrands_Click(object sender, EventArgs e)
        {
            TransportVehicleBrandsForm?.Invoke(this, new EventArgs());
        }

        private void btnDriverCards_Click(object sender, EventArgs e)
        {
            DriverCardsForm?.Invoke(this, new EventArgs());
        }

        private void btnFuelAndLubricants_Click(object sender, EventArgs e)
        {
            FuelAndLubricantsForm?.Invoke(this, new EventArgs());
        }

        private void btnDivisions_Click(object sender, EventArgs e)
        {
            DivisionsForm?.Invoke(this, new EventArgs());
        }

        private void btnTransportVehicles_Click(object sender, EventArgs e)
        {
            TransportVehiclesForm?.Invoke(this, new EventArgs());
        }

        private void ToolsUC_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(Properties.Resources.texture, new System.Drawing.Rectangle(0, 0, Width, Height));
        }
    }
}
