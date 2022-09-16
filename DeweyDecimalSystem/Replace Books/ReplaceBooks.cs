﻿using DeweyDecimalSystem.Replace_Books;
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

        private Point start;

        public ReplaceBooks()
        {




            InitializeComponent();
            // MessageBox.Show(Dewey.ToString());
            LabelsToList();
           /* if (panel1.Location == paneltest.Location)
            {
                MessageBox.Show("dragged over");

            }
            if (panel1.Controls.Count > 0)
            {
                MessageBox.Show("dragged over");
            }*/

            //Controls.Add(panel1);
        }

        private void mainToolStrip_Click(object sender, EventArgs e)
        {
            MainPage MP = new MainPage();
            this.Hide();
            MP.ShowDialog();
        }
        /// <summary>
        /// Extras
        /// </summary>
        /// <returns></returns>



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
            var labels = new[] { lblbook1, lblbook2, lblbook3, lblbook4, lblbook5, lblbook6 ,
                lblbook7 , lblbook8 , lblbook9 , lblbook10 };
            for (var i = 0; i != Dewey.Count; i++)
            {
                labels[i].Text = Dewey[i].ToString();

            }
        }

        /* public  List<int> RandomNumbers()
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
        if (book1.Location== new System.Drawing.Point(199, 258))
            {
                panel1.Controls.Add(this.book1);
                MessageBox.Show("Book one is added to panel 1");
        MessageBox.Show("dragged over");

            }*/
        public static void Selection_Sort(List<int> ss_arr)
        {
            //Min position to keep track of position from lowest value
            int min_position;
            //temp to conduct swap during selection sort
            int temp;

            for (int i = 0; i < ss_arr.Count; i++)
            {
                //initialize min position to index of array
                min_position = i;
                //from min positon check if next element is smaller
                for (int x = i + 1; x < ss_arr.Count; x++)
                {
                    //if smaller then make new min position
                    if (ss_arr[x] < ss_arr[min_position])
                    {
                        //min position keeps track of the index that min is in 
                        min_position = x;

                    }
                }//end of inner loop
                //if min does not equal current element in loop then swap initialted
                if (min_position != i)
                {
                    temp = ss_arr[i];
                    ss_arr[i] = ss_arr[min_position];
                    ss_arr[min_position] = temp;

                }
                Console.Write(" " + ss_arr[i]);
            }
        }

        private void ReplaceBooks_Load(object sender, EventArgs e)
        {

        }

      

     

        private void ReplaceBooks_MouseUp(object sender, MouseEventArgs e)
        {
           /* if (sender != null && sender.GetType() == typeof(Panel))
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    //PictureBox answer = (PictureBox)sender;

                    if (paneltest.Location.X < panel1.Location.X && paneltest.Location.Y > panel1.Location.Y)
                    {
                        if (paneltest.Location.X + paneltest.Width > panel1.Location.X)
                        {
                            if ((paneltest.Location.X + paneltest.Width) < panel1.Location.X + panel1.Width)
                            {
                                paneltest.Location = panel1.Location;
                            }
                        }
                    }
                    else if (paneltest.Location.X < panel1.Location.X && paneltest.Location.Y > panel1.Location.Y)
                    {
                        if (paneltest.Location.X + paneltest.Width > panel1.Location.X)
                        {
                            if ((paneltest.Location.X + paneltest.Width) < panel1.Location.X + panel1.Width)
                            {
                                paneltest.Location = panel1.Location;
                            }
                        }
                    }
                }
            }
            if (panel1.Location == paneltest.Location)
            {
                MessageBox.Show("dragged over");

            }
            if (panel1.Controls.Count > 0)
            {
                MessageBox.Show("dragged over");
            }*/
        }


    }
}
//https://www.youtube.com/watch?v=YPGzfDN8-SA&list=TLPQMTEwOTIwMjIYnSeACSiecg&index=2&ab_channel=ClintonDaniel