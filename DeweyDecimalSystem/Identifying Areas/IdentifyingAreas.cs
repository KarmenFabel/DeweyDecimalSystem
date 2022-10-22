using DeweyLibrary;
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
    public partial class IdentifyingAreas : Form
    {
       

        String CallNumber = "Call Number";
        String Description = "Descriptions";

        public IdentifyingAreas()
        {
            InitializeComponent();
            CalNumsFirst();
            int count = testDictionary2.Keys.Count;
        }
       
        public void DescFirst()
        {
            lblquestion.Text = Description;
            lblAnswer.Text = CallNumber;
            var labels = new[] { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6 ,
                lbl7 };
            var questions = new[] {question1,lblquestion2,lblquestion3, lblquestion4 };

            Random random = new Random();
           

            for (int i = 0; i < 7; ++i)
            {
                int index = random.Next(testDictionary2.Count);
                KeyValuePair< int, DeweyDecimalGroup> pair = testDictionary2.ElementAt(index);
                labels[i].Text = pair.Value.deweyDescrip;
                //dataGridView1.Rows.Add(pair.Value.deweyDescrip);

                // Console.WriteLine("key: " + pair.Key + ", value: " + pair.Value);
//Dit werk nie want hy kry net die eerste een in die for loop se waarde
                for (int b = 0; b < 4; ++b)
                {
                    questions[b].Text = pair.Key.ToString();
                    

                }
               
            }




        }
        public void CalNumsFirst()
        {

            lblquestion.Text = CallNumber;
            lblAnswer.Text= Description;
            Random random = new Random();
            var labels = new[] { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6 ,
                lbl7 };
            for (int i = 0; i < 7; ++i)
            {
                int index = random.Next(testDictionary2.Count);
                KeyValuePair<int, DeweyDecimalGroup> pair = testDictionary2.ElementAt(index);
                labels[i].Text = pair.Value.deweyKey.ToString();
                //  dataGridView1.Rows.Add(pair.Value.deweyKey.ToString());

                // Console.WriteLine("key: " + pair.Key + ", value: " + pair.Value);
            }
        }


        private void btnSwitch_Click(object sender, EventArgs e)
        {
            if(lblquestion.Text ==CallNumber)
            {
                this.Controls.Clear();
                this.InitializeComponent();
                
                DescFirst();


            }
            else
            {
                
                this.Controls.Clear();
                this.InitializeComponent();
                CalNumsFirst();
            }
            
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainPage MP = new MainPage();
            this.Hide();
            MP.ShowDialog();

        }

        private void flPanel1_DragDrop(object sender, DragEventArgs e)
        {
            //implements drag drop control
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

        private void flPanel1_DragEnter(object sender, DragEventArgs e)
        {
            //Implements drag enter control
            if (!e.Data.GetDataPresent(typeof(string)))
                return;

            var name = e.Data.GetData(typeof(string)) as string;
            var control = this.Controls.Find(name, true).FirstOrDefault();
            if (control != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void answer1_MouseDown(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            this.DoDragDrop(control.Name, DragDropEffects.Move);
        }
    }
}
