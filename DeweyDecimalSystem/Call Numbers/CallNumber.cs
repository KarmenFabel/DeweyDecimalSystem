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
            GetSet2();
            GetRandomLeaf();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainPage MP = new MainPage();
            this.Hide();
            MP.ShowDialog();
        }

        private void CallNumber_Load(object sender, EventArgs e)
        {

            readJSON();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ButtonActions(answer1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            ButtonActions(answer2);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonActions(answer3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonActions(answer4);
        }
    }
}
//Reference:
//https://stackoverflow.com/questions/7105230/how-to-access-the-files-in-bin-debug-within-the-project-folder-in-visual-studio