
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DeweyLibrary;

namespace DeweyDecimalSystem
{
    public partial class ReplaceBooks : Form
    {
        public ReplaceBooks()
        {
            InitializeComponent();
            LabelsToList();

        }
        /// <summary>
        /// Main List of Dewey
        /// </summary>
         List<int> Dewey = Library.RandomNumbers();
        /// <summary>
        /// Adding List to array of labels
        /// </summary>
        public void LabelsToList()
        {
            var labels = new[] { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6 ,
                lbl7 , lbl8 , lbl9 , lbl10 };
            for (var i = 0; i != Dewey.Count; i++)
            {
                labels[i].Text = Dewey[i].ToString();
            }
        }
        /// <summary>
        /// Home button to navigate to home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainPage MP = new MainPage();
            this.Hide();
            MP.ShowDialog();
        }
       
        /// <summary>
        /// dragDrop method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MDragDrop(object sender, DragEventArgs e)
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
        /// <summary>
        /// MouseDown method to allow moving books
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Book1_MouseDown(object sender, MouseEventArgs e)
        {
            var control = sender as Control;
            this.DoDragDrop(control.Name, DragDropEffects.Move);
        }
        /// <summary>
        /// DragEnter method to allow the moving of books into panels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            timer1.Start();
        }
        /// <summary>
        /// Calling DragDrop method to each panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flPanel1_DragDrop(object sender, DragEventArgs e)
        {
            MDragDrop(sender, e);
            sortedList(flPanel1, 0);

        }
        private void flPanel2_DragDrop(object sender, DragEventArgs e)
        {
            MDragDrop(sender, e);
            sortedList(flPanel2, 1);
        }

        private void flPanel3_DragDrop(object sender, DragEventArgs e)
        {
            MDragDrop(sender, e);
            sortedList(flPanel3, 2);
        }

        private void flPanel4_DragDrop(object sender, DragEventArgs e)
        {
            MDragDrop(sender, e);
            sortedList(flPanel4, 3);
        }

        private void flPanel5_DragDrop(object sender, DragEventArgs e)
        {
            MDragDrop(sender, e);
            sortedList(flPanel5, 4);
        }

        private void flPanel6_DragDrop(object sender, DragEventArgs e)
        {
            MDragDrop(sender, e);
            sortedList(flPanel6, 5);
        }

        private void flPanel7_DragDrop(object sender, DragEventArgs e)
        {
            MDragDrop(sender, e);
            sortedList(flPanel7, 6);
        }

        private void flPanel8_DragDrop(object sender, DragEventArgs e)
        {
            MDragDrop(sender, e);
            sortedList(flPanel8, 7);
        }

        private void flPanel9_DragDrop(object sender, DragEventArgs e)
        {
            MDragDrop(sender, e);
            sortedList(flPanel9, 8);
        }

        private void flPanel10_DragDrop(object sender, DragEventArgs e)
        {
            MDragDrop(sender, e);
            sortedList(flPanel10, 9);
        }
        private void flowLayoutPanel1_DragDrop(object sender, DragEventArgs e)
        {
            MDragDrop(sender, e);

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
        /// <summary>
        /// Method that confirms if a panel contains a book
        /// and confirms if a book contains a label 
        /// that matches the sorted list version
        /// and increases the progressbar
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="sort"></param>
        /// <param name="i"></param>
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
                                newProgressBar1.Increment(1);

                            }
                            if(label.Text != sort[i].ToString())
                            {
                                MessageBox.Show("Incorrect, Double check the last book");
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Method that sorts the Dewey List
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="i"></param>
        public void sortedList(FlowLayoutPanel panel, int i)
        {

            List<int> sortedDewey = new List<int>();
            var newDew = Library.Sorted(Dewey);
            foreach (var item in newDew)
            {
                sortedDewey.Add(item);
            }
            Progress( panel, sortedDewey, i);
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (newProgressBar1.Value == 10)
            {
                timer1.Stop();
//NOT RIGHT!
                MessageBox.Show("You took " + timer1.ToString());

            }

        }
    }
}
