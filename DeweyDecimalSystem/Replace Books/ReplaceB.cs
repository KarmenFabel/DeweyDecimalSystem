using DeweyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeweyDecimalSystem
{
    public partial class ReplaceBooks
    {
        
        /// <summary>
        /// Main List of Dewey
        /// </summary>
       public List<decimal> Dewey = Library.RandomNumbers();


        /// <summary>
        /// Adding List to array of labels
        /// </summary>

        public void LabelsToList()
        {
            //adds the dewey list to array of labels
            var labels = new[] { lbl1, lbl2, lbl3, lbl4, lbl5, lbl6 ,
                lbl7 , lbl8 , lbl9 , lbl10 };
            for (var i = 0; i != Dewey.Count; i++)
            {
                //foreach label add a dewey list number
                labels[i].Text = Dewey[i].ToString();
            }
        }
        private void MDragDrop(object sender, DragEventArgs e)
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
        private void MDragEnter(DragEventArgs e)
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
        /// <summary>
        /// Method that confirms if a panel contains a book
        /// and confirms if a book contains a label 
        /// that matches the sorted list version
        /// and increases the progressbar
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="sort"></param>
        /// <param name="i"></param>
        public void Progress(FlowLayoutPanel panel, List<decimal> sort, int i)
        {
            //finding controls within the Bookcase
            foreach (var item in panel.Controls)
            {
                if (item is FlowLayoutPanel)
                {
                    //confirms book is inside bookcase
                    FlowLayoutPanel book = (FlowLayoutPanel)item;
                    foreach (var thing in book.Controls)
                    {
                        if (thing is Label)
                        {
                            // confirm Label is inside book
                            Label label = (Label)thing;
                            //confirms if label is the same as the sorted dewey list
                            if (label.Text == sort[i].ToString())
                            {
                                //with each correct answer add to progress Bar
                                newProgressBar1.Increment(1);

                            }
                            if (label.Text != sort[i].ToString())
                            {
                                //when user gets book wrong 
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
            //sorted list
            List<decimal> sortedDewey = new List<decimal>();
            var newDew = Library.Sorted(Dewey);
            //add each number of Dewey list to the sorted list
            foreach (var item in newDew)
            {
                sortedDewey.Add(item);
            }
            //add sorted list to progress method
            Progress(panel, sortedDewey, i);

        }
        /// <summary>
        /// Adding seconds and min and split seconds to timer and label
        /// </summary>
        private void TimerMethod()
        {
            //Add split seconds
            Library.splitsec++;
            //Add seconds 
            Library.secs = (int)Math.Floor((decimal)Library.splitsec / 10);
            //add minutes
            Library.mins = (int)Math.Floor((decimal)Library.secs / 60);
            //add all timers to label 
            time.Text = Library.mins.ToString() + ":" + Library.secs.ToString() + ":" + (Library.splitsec % 60).ToString();
        }
        /// <summary>
        /// Setting Label to timer and stopping Timer
        /// </summary>
        private void TimerTickMethod()
        {
            TimerMethod();
            //When Progress Bar is done stop timer and let user know their time
            if (newProgressBar1.Value == 10)
            {
                timer1.Stop();

                MessageBox.Show("Weldone! You took " + time.Text);

            }
        }
    }
}
/*
 _____          _          __    __ _ _      
|  ___|        | |        / _|  / _(_) |     
| |__ _ __   __| |   ___ | |_  | |_ _| | ___ 
|  __| '_ \ / _` |  / _ \|  _| |  _| | |/ _ \
| |__| | | | (_| | | (_) | |   | | | | |  __/
\____/_| |_|\__,_|  \___/|_|   |_| |_|_|\___|
                                             
                                             

 */
//References:
//RandomNumbers from:
//https://www.youtube.com/watch?v=gog3_xnf86M&ab_channel=Web%26GraphicDesign-Stock%26OptionsTrading
//ProgressBar 
//https://stackoverflow.com/questions/778678/how-to-change-the-color-of-progressbar-in-c-sharp-net-3-5
//https://stackoverflow.com/questions/17497588/i-want-to-keep-a-function-running-continuously-in-my-winform-c-sharp-project-un
//selection sort method
//https://www.youtube.com/watch?v=hZGVLIqzS9A&ab_channel=LearnWithCode
