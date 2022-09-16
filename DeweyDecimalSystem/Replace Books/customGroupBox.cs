using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeweyDecimalSystem.Replace_Books
{
    //creates custom picture box
    public class CustomGroupBox: GroupBox
    {
        Point point;
        public CustomGroupBox(IContainer container)
        {
            container.Add(this);
            AllowDrop = true;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
             
            point = e.Location;
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
            base.OnMouseMove(e);
        }

    }
}
//https://www.youtube.com/watch?v=wQJfxtcSRFs&list=PLmHA0SV2rhvM8MHKk4p8rX1S_8GkGYjDD&index=16&ab_channel=FoxLearn