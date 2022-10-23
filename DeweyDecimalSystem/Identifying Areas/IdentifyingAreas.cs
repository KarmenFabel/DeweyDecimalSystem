using DeweyLibrary;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DeweyDecimalSystem
{
	public partial class IdentifyingAreas : Form
	{
		public IdentifyingAreas()
		{
			InitializeComponent();
			DescFirst();

		}
		private void btnSwitch_Click(object sender, EventArgs e)
		{
			if (lblquestion.Text == Library.CallNumber)
			{
				//Hide();
				//var reopen = new IdentifyingAreas();
				//reopen.ShowDialog();
				// Dispose();

				ButtonClickClear();
				DescFirst();
			}
			else
            {
                ButtonClickClear();
                CalNumsFirst();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			MainPage MP = new MainPage();
			this.Hide();
			MP.ShowDialog();

		}

		private void flPanel1_DragDrop(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent(typeof(string)))
				return;
			var name = e.Data.GetData(typeof(string)) as string;
			var control = Controls.Find(name, true).FirstOrDefault();
			control.Parent.Controls.Remove(control);
			((FlowLayoutPanel)sender).Controls.Add(control);

		}

		private void flPanel1_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}
		private void answer1_MouseDown(object sender, MouseEventArgs e)
		{
			var control = sender as Control;
			this.DoDragDrop(control.Name, DragDropEffects.Move);
		}
		private void btnDone_Click(object sender, EventArgs e)
        {
            PanelCorrect();
            EndScoreMessage();

            MainPage MP = new MainPage();
            this.Hide();
            MP.ShowDialog();

        }
        private void button1_Click(object sender, EventArgs e)
		{
			PanelCorrect();
			if (lblquestion.Text == Library.CallNumber)
			{
				ButtonClickClear();
				CalNumsFirst();
			}
			else
			{
				ButtonClickClear();
				DescFirst();
			}

		}
	}
}
