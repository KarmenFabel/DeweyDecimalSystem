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
    public partial class ReplaceBooks : Form
    {
        public ReplaceBooks()
        {
           
            InitializeComponent();
            LabelsToList();
           

        }
        List<int> Dewey = RandomNumbers();

        private static Random rnd = new Random();
        public static List<int> RandomNumbers()
        {

            string newLine = Environment.NewLine;
            int nums = rnd.Next(100, 1000);
            List<int> Dewey = new List<int>();

            for (int i = 1; i <= 10; i++)
            {
                nums = rnd.Next(100, 1000);

                Dewey.Add(nums);
            }
            for (int i = 0; i < Dewey.Count; i++) ;
            return Dewey;


        }
        public void LabelsToList()
        {
            var labels = new[] { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6 ,
                lbl7 , lbl8 , lbl9 , lbl10 };
            for (var i = 0; i != Dewey.Count; i++)
            {
                labels[i].Text = Dewey[i].ToString();

            }
        }
        private void flowLayoutPanel2_MouseDown(object sender, MouseEventArgs e)
        {

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

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainPage MP = new MainPage();
            this.Hide();
            MP.ShowDialog();
        }

        private void Book1_MouseDown(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            this.DoDragDrop(control.Name, DragDropEffects.Move);
        }

        private void flPanel1_DragEnter(object sender, DragEventArgs e)
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

        private void flPanel1_DragDrop(object sender, DragEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {

            if (flPanel1.Controls.Count >= 1)
            {
                // flPanel1.Controls.Add(this.Book1);
               // MessageBox.Show(Selection_Sort(Dewey));


            }

        }
        public static void Selection_Sort(List<int> dew)
        {
            //Min position to keep track of position from lowest value
            int min_position;
            //temp to conduct swap during selection sort
            int temp;

            for (int i = 0; i < dew.Count; i++)
            {
                //initialize min position to index of array
                min_position = i;
                //from min positon check if next element is smaller
                for (int x = i + 1; x < dew.Count; x++)
                {
                    //if smaller then make new min position
                    if (dew[x] < dew[min_position])
                    {
                        //min position keeps track of the index that min is in 
                        min_position = x;

                    }
                }//end of inner loop
                //if min does not equal current element in loop then swap initialted
                if (min_position != i)
                {
                    temp = dew[i];
                    dew[i] = dew[min_position];
                    dew[min_position] = temp;

                }
               // Console.Write(" " + ss_arr[i]);
            }
        }
    }
}
