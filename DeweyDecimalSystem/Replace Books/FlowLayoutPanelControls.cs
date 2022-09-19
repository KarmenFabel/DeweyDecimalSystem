using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalSystem.Replace_Books
{
    public partial class FlowLayoutPanelControls : Component
    {
        public FlowLayoutPanelControls()
        {
            InitializeComponent();
        }

        public FlowLayoutPanelControls(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
