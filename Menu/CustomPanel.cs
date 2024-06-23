using System.ComponentModel;
using System.Windows.Forms;

namespace CargoTransportation
{
    public partial class CustomPanel : Panel
    {
        public CustomPanel()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public CustomPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
