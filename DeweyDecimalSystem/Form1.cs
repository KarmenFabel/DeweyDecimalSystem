using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeweyDecimalSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            this.DoDragDrop(control.Name, DragDropEffects.Move);

        }

        private void flowLayoutPanel1_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                control.Parent.Controls.Remove(control);
                var panel = sender as FlowLayoutPanel;
                ((FlowLayoutPanel)sender).Controls.Add(control);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
