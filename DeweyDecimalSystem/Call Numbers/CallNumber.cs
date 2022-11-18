using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace DeweyDecimalSystem.Call_Numbers
{
    public partial class CallNumber : Form
    {
        public string UserAnswer { get; set; }
       public int buttonClicks = 0;
        public CallNumber()
        {
            InitializeComponent();
            
           // CreateTree();
            GetRandomThird();

            //myTree.FindTreeNode

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainPage MP = new MainPage();
            this.Hide();
            MP.ShowDialog();
        }

        private void question_Click(object sender, EventArgs e)
        {
            
        }
   
        private void CallNumber_Load(object sender, EventArgs e)
        {

            readJSON();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserAnswer = answer1.Text;
            MessageAfterButton();
            buttonClicks++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserAnswer = answer2.Text;
            MessageAfterButton();
            buttonClicks++;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserAnswer = answer3.Text;
            MessageAfterButton();
            buttonClicks++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserAnswer = answer4.Text;
            MessageAfterButton();
            buttonClicks++;
        }
    }
}
//Reference:
//https://stackoverflow.com/questions/7105230/how-to-access-the-files-in-bin-debug-within-the-project-folder-in-visual-studio