using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace DeweyDecimalSystem
{
    public partial class MainPage : Form
    {
      

        public MainPage()
        {
            InitializeComponent();
        }


        private void picBoxReplaceBooks_Click(object sender, EventArgs e)
        {
            ReplaceBooks RB = new ReplaceBooks();
            this.Hide();
            RB.ShowDialog();
           
        }
    }
}
