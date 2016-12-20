using System;
using System.Windows.Forms;
using System.Drawing;

namespace Calculator
{
	public class Calculator : Form
	{
		private Button[] buttons = new Button[16];
		private TextBox textBox = new TextBox();

		private int leftValue = 0;
		private char operation = '+';
		private int rightValue = 0;

		private static string nullWarning = "You shall not divide by zero!";

		public Calculator ()
		{
			DisplayGUI ();
		}

		private void DisplayGUI ()
		{
			this.Name = "Calculator";
			this.Text = "Calculator";
			this.Size = new Size (165, 225);
			this.StartPosition = FormStartPosition.CenterScreen;

			AddAllButtons();

			textBox = new TextBox();
			textBox.Name = "TextBox";
			textBox.Text = "0";
			textBox.Size = new Size(160, 40);
			textBox.Location = new Point();
			textBox.KeyPress += new KeyPressEventHandler(
				(object sender, KeyPressEventArgs args) => 
				{args.Handled = true;});

			this.Controls.Add(textBox);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
		}

		private void AddAllButtons()
		{
			Size sizeOfButton = new Size(40, 40);
			for (int i = 1; i < 10; ++i)
			{
				buttons[i] = AddButton("button_" + i.ToString(), i.ToString(), sizeOfButton,
					new Point(40 * ((i - 1) % 3), 40 * ((i - 1) / 3 + 1)));
			}
			buttons[0] = AddButton("button_0", 0.ToString(), sizeOfButton,
				new Point(40 * 1, 40 * 4));

			buttons[10] = AddButton("button_+", "+", sizeOfButton,
				new Point(40 * 3, 40 * 1));
			buttons[11] = AddButton("button_-", "-", sizeOfButton,
				new Point(40 * 3, 40 * 2));
			buttons[12] = AddButton("button_*", "*", sizeOfButton,
				new Point(40 * 3, 40 * 3));
			buttons[13] = AddButton("button_/", "/", sizeOfButton,
				new Point(40 * 3, 40 * 4));
			buttons[14] = AddButton("button_=", "=", sizeOfButton,
				new Point(40 * 2, 40 * 4));
			buttons[15] = AddButton("button_C", "C", sizeOfButton,
				new Point(40 * 0, 40 * 4));

			for (int i = 0; i < 10; ++i) 
			{
				buttons[i].Click += AddDigit;
			}

			for (int i = 10; i < 15; ++i) 
			{
				buttons[i].Click += AddChar;
			}

			buttons [15].Click += DeleteAll;
		}

		private Button AddButton(String name, String text, Size size, Point point)
		{
			var result = new Button();
			result.Name = name;
			result.Text = text;
			result.Size = size;
			result.Location = point;
			this.Controls.Add(result);
			return result;
		}

		private void AddDigit(object sender, EventArgs args)
		{
			if (textBox.Text == nullWarning)
			{
				textBox.Text = "";
			}
			else if (textBox.Text[0] == '0')
			{
				textBox.Text = "";
				operation = '+';
			}
			var button = sender as Button;
			textBox.Text += button.Text[0];
			rightValue *= 10;
			rightValue += (int)button.Text[0] - '0';
		}

		private void AddChar(object sender, EventArgs args)
		{
			var button = sender as Button;
			if (!(textBox.Text [0] <= '9'
			    && textBox.Text [0] >= '0')) {
				if (leftValue != 0) {
					textBox.Text = leftValue.ToString ();
				}
				textBox.Text += button.Text[0];
				operation = button.Text[0];
			} else {
				switch (operation) {
				case '+':
					{
						leftValue += rightValue;
						break;
					}
				case '-':
					{
						leftValue -= rightValue;
						break;
					}
				case '*':
					{
						leftValue *= rightValue;
						break;
					}
				case '/':
					{
						if (rightValue == 0) {
							textBox.Text = nullWarning;
							return;
						}
						leftValue /= rightValue;
						break;
					}
				}
				textBox.Text = leftValue.ToString ();
				textBox.Text += button.Text[0];
				operation = button.Text[0];
				rightValue = 0;
			}
		}

		public void DeleteAll(object sender, EventArgs args)
		{
			textBox.Text = "0";
			leftValue = 0;
			operation = '+';
			rightValue = 0;
		}
	}
}

