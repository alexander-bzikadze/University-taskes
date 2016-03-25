using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;

namespace Clocks
{
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
            label.Text = DateTime.Now.ToString();

            space = new TableLayoutPanel();
            space.Controls.Add(label);
            this.Controls.Add(space);

            var timer = new Timer();
            timer.Start();
            timer.Tick += ChangeTime;
        }

        private void ChangeTime(object sender, EventArgs args)
        {
            label.Text = DateTime.Now.ToString();
        }
    }
}