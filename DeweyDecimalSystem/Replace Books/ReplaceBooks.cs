using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeweyDecimalSystem
{
    public partial class ReplaceBooks : Form
    {
        List<int> Dewey = RandomNumbers();
        private static Random rnd = new Random();
        public ReplaceBooks()
        {

            InitializeComponent();
            LabelsToList();
            timer1.Start();

        }

        public static List<int> RandomNumbers()
        {
            List<int> dewey = new List<int>();

            for (int i = 1; i <= 10; i++)
            {
               int nums = rnd.Next(100, 1000);
                dewey.Add(nums);
            }
            for (int i = 0; i < dewey.Count; i++) ;
            return dewey;
        }
        public static List<int> Sorted(List<int> sorted)
        {
            int j;
            int minIndex;
            for (int i = 0; i < sorted.Count - 1; i++)
            {
                minIndex = i;
                for (j = i + 1; j < sorted.Count; j++)
                {
                    if (sorted[j] < sorted[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    int temp = sorted[minIndex];
                    sorted[minIndex] = sorted[i];
                    sorted[i] = temp;
                }
            }
            return sorted;
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
            sortedList(flPanel1, 0);

        }



        private void button1_Click(object sender, EventArgs e)
        {



        }
        public void Progress(FlowLayoutPanel panel, List<int> sort, int i)
        {
            foreach (var item in panel.Controls)
            {
                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel book = (FlowLayoutPanel)item;
                    foreach (var thing in book.Controls)
                    {
                        if (thing is Label)
                        {
                            Label label = (Label)thing;
                            if (label.Text == sort[i].ToString())
                            {
                                progressBar1.Increment(1);
                            }
                        }
                    }
                }
            }
        }

        public void sortedList(FlowLayoutPanel panel, int i)
        {

            List<int> sortedDewey = new List<int>();
            var newDew = Sorted(Dewey);
            foreach (var item in newDew)
            {
                sortedDewey.Add(item);
            }
            Progress(panel, sortedDewey, i);
            /*
            foreach (var item in flPanel1.Controls)
            {
                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel book = (FlowLayoutPanel)item;
                    foreach (var thing in book.Controls)
                    {
                        if (thing is Label)
                        {
                            Label label = (Label)thing;


                            if (label.Text == sortedDewey[0].ToString())
                            {

                            //Create a method for only one increment
                            //progressBar1.Increment(1);
                            return;
                                //MessageBox.Show("Correct!!");

                            }
                        }
                    }

                }
            }
            foreach (var item in flPanel2.Controls)
            {
                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel book = (FlowLayoutPanel)item;
                    foreach (var thing in book.Controls)
                    {
                        if (thing is Label)
                        {
                            Label label = (Label)thing;


                            if (label.Text == sortedDewey[1].ToString())
                            {
                                progressBar1.Value = 2;
                                //MessageBox.Show("Correct!!");

                            }
                        }
                    }

                }
            }
            foreach (var item in flPanel3.Controls)
            {
                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel book = (FlowLayoutPanel)item;
                    foreach (var thing in book.Controls)
                    {
                        if (thing is Label)
                        {
                            Label label = (Label)thing;


                            if (label.Text == sortedDewey[2].ToString())
                            {
                            progressBar1.Increment(1);
                            // MessageBox.Show("Correct!!");

                        }
                        }
                    }

                }
            }
            foreach (var item in flPanel4.Controls)
            {
                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel book = (FlowLayoutPanel)item;
                    foreach (var thing in book.Controls)
                    {
                        if (thing is Label)
                        {
                            Label label = (Label)thing;


                            if (label.Text == sortedDewey[3].ToString())
                            {
                                progressBar1.Value = 4;
                                //MessageBox.Show("Correct!!");

                            }
                        }
                    }

                }
            }
            foreach (var item in flPanel5.Controls)
            {
                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel book = (FlowLayoutPanel)item;
                    foreach (var thing in book.Controls)
                    {
                        if (thing is Label)
                        {
                            Label label = (Label)thing;


                            if (label.Text == sortedDewey[4].ToString())
                            {
                                progressBar1.Value = 5;
                                //MessageBox.Show("Correct!!");

                            }
                        }
                    }

                }
            }
            foreach (var item in flPanel6.Controls)
            {
                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel book = (FlowLayoutPanel)item;
                    foreach (var thing in book.Controls)
                    {
                        if (thing is Label)
                        {
                            Label label = (Label)thing;


                            if (label.Text == sortedDewey[5].ToString())
                            {
                                progressBar1.Value = 6;
                                //MessageBox.Show("Correct!!");

                            }
                        }
                    }

                }
            }
            foreach (var item in flPanel7.Controls)
            {
                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel book = (FlowLayoutPanel)item;
                    foreach (var thing in book.Controls)
                    {
                        if (thing is Label)
                        {
                            Label label = (Label)thing;


                            if (label.Text == sortedDewey[6].ToString())
                            {
                                progressBar1.Value = 7;
                                //MessageBox.Show("Correct!!");

                            }
                        }
                    }

                }
            }
            foreach (var item in flPanel8.Controls)
            {
                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel book = (FlowLayoutPanel)item;
                    foreach (var thing in book.Controls)
                    {
                        if (thing is Label)
                        {
                            Label label = (Label)thing;


                            if (label.Text == sortedDewey[7].ToString())
                            {
                                progressBar1.Value = 8;
                                //MessageBox.Show("Correct!!");

                            }
                        }
                    }

                }
            }
            foreach (var item in flPanel9.Controls)
            {
                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel book = (FlowLayoutPanel)item;
                    foreach (var thing in book.Controls)
                    {
                        if (thing is Label)
                        {
                            Label label = (Label)thing;


                            if (label.Text == sortedDewey[8].ToString())
                            {
                                progressBar1.Value = 9;
                                //MessageBox.Show("Correct!!");

                            }
                        }
                    }

                }
            }
            foreach (var item in flPanel10.Controls)
            {
                if (item is FlowLayoutPanel)
                {
                    FlowLayoutPanel book = (FlowLayoutPanel)item;
                    foreach (var thing in book.Controls)
                    {
                        if (thing is Label)
                        {
                            Label label = (Label)thing;


                            if (label.Text == sortedDewey[9].ToString())
                            {
                                progressBar1.Value = 10;
                                //MessageBox.Show("Correct!!");

                            }
                        }
                    }

                }
            }
            */
        }

        private void flPanel2_DragDrop(object sender, DragEventArgs e)
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
            sortedList(flPanel2, 1);
        }

        private void flPanel3_DragDrop(object sender, DragEventArgs e)
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
            sortedList(flPanel3, 2);
        }

        private void flPanel4_DragDrop(object sender, DragEventArgs e)
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
            sortedList(flPanel4, 3);
        }

        private void flPanel5_DragDrop(object sender, DragEventArgs e)
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
            sortedList(flPanel5, 4);
        }

        private void flPanel6_DragDrop(object sender, DragEventArgs e)
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
            sortedList(flPanel6, 5);
        }

        private void flPanel7_DragDrop(object sender, DragEventArgs e)
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
            sortedList(flPanel7, 6);
        }

        private void flPanel8_DragDrop(object sender, DragEventArgs e)
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
            sortedList(flPanel8, 7);
        }

        private void flPanel9_DragDrop(object sender, DragEventArgs e)
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
            sortedList(flPanel9, 8);
        }

        private void flPanel10_DragDrop(object sender, DragEventArgs e)
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
            sortedList(flPanel10, 9);
        }
    }
}
