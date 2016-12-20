using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;

namespace Clocks
{
	/// A class that describes form that shows current time.
	public class Clocks : Form
	{
		private TableLayoutPanel space = null;
		private Label label = null;
		// private Timer timer = null;

		public Clocks()
		{
			DisplayGUI();
		}

		private void DisplayGUI()
		{
			this.Size = new Size(SystemInformation.VirtualScreen.Width / 13,
				SystemInformation.VirtualScreen.Height / 14);

			label = new Label();
			label.Size = this.Size;
			label.Text = DateTime.Now.ToString();
			label.Font = new Font("Arial", this.Size.Width / 18,FontStyle.Bold);

			space = new TableLayoutPanel();
			space.Controls.Add(label);
			this.Controls.Add(space);

			var timer = new Timer();
			timer.Start();
			timer.Tick += ChangeTime;
			this.Resize += ChangeFontSize;
		}

		private void ChangeTime(object sender, EventArgs args)
		{
			label.Text = DateTime.Now.ToString();
		}

		private void ChangeFontSize(object sender, EventArgs args)
		{
			label.Size = this.Size;
			label.Font = new Font("Arial", this.Size.Width / 18,FontStyle.Bold);
		}
	}
}
