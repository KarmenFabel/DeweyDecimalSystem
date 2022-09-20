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
/*
 _____          _          __    __ _ _      
|  ___|        | |        / _|  / _(_) |     
| |__ _ __   __| |   ___ | |_  | |_ _| | ___ 
|  __| '_ \ / _` |  / _ \|  _| |  _| | |/ _ \
| |__| | | | (_| | | (_) | |   | | | | |  __/
\____/_| |_|\__,_|  \___/|_|   |_| |_|_|\___|
                                             
                                             

 */