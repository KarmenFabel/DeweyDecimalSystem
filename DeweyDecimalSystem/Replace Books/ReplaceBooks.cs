
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DeweyLibrary;
using static DeweyDecimalSystem.ReplaceBooks;

namespace DeweyDecimalSystem
{
    public partial class ReplaceBooks  : Form
    {
       
        public ReplaceBooks()
        {
            InitializeComponent();
            LabelsToList();

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
            MDragEnter(e);
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
            MDragEnter(e);
        }
        
      
       /// <summary>
       /// Timer 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimerTickMethod();

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