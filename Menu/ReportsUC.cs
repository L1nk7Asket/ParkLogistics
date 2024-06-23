using System;
using System.Windows.Forms;

namespace CargoTransportation
{
    public partial class ReportsUC : UserControl
    {
        public ReportsUC()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
        }

        public event EventHandler SalaryStatementForm;
        public event EventHandler WaybillsRegistrationJournalForm;
        public event EventHandler CustomersRegisterForm;

        private void btnSalaryStatement_Click(object sender, EventArgs e)
        {
            SalaryStatementForm?.Invoke(this, new EventArgs());
        }

        private void btnWaybillsRegistrationJournal_Click(object sender, EventArgs e)
        {
            WaybillsRegistrationJournalForm?.Invoke(this, new EventArgs());
        }

        private void btnCustomersRegister_Click(object sender, EventArgs e)
        {
            CustomersRegisterForm?.Invoke(this, new EventArgs());
        }

        private void ReportsUC_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.texture, new System.Drawing.Rectangle(0, 0, Width, Height));
        }
    }
}
