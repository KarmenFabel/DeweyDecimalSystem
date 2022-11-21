using System;
using System.Windows.Forms;

namespace DeweyDecimalSystem.Call_Numbers
{
    public partial class CallNumber : Form
    {

        public CallNumber()
        {
            InitializeComponent();
            TreeData.GetTreeData();
            GetRandomLeaf();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainPage MP = new MainPage();
            this.Hide();
            MP.ShowDialog();
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