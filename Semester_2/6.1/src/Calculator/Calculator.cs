using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator
{
    /// A windows form application that is a calculator.
    /// Contains 0-9 buttons to add digits, '+', '-', '*', '/', '=' for operations
    /// add 'C' button to clear the textbox.
    public class Calculator : Form
    {
        private Button[] buttons = new Button[16];
        private TextBox textBox = new TextBox();

        private EventLoop eventLoop = new EventLoop();

        private int leftValue = 0;
        private char operation = '+';
        private int rightValue = 0;

        private static string nullWarning = "You shall not divide by zero!";

        public Calculator()
        {
            DisplayGUI();
        }

        private void DisplayGUI()
        {
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.Size = new Size(165, 225);
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

        /// Adds sended digit to textBox. If the first simbol is '0' or anything like that,
        /// replaces it with new value.
        public void AddDigit(object sender, ButtonIntClickedArguments args)
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
            textBox.Text += args.Value.ToString();
            rightValue *= 10;
            rightValue += args.Value;
        }

        /// Complex process of adding operation to current stage.
        public void AddChar(object sender, ButtonCharClickedArguments args)
        {
            if (!(textBox.Text[textBox.Text.Length - 1] <= '9' 
                    && textBox.Text[textBox.Text.Length - 1] >= '0'))
            {
                if (leftValue != 0)
                {
                    textBox.Text = leftValue.ToString();
                }
                textBox.Text += args.Value;
                operation = args.Value[0];
            }
            else 
            {
                switch (operation)
                {
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
                        if (rightValue == 0)
                        {
                            textBox.Text = nullWarning;
                            return;
                        }
                        leftValue /= rightValue;
                        break;
                    }
                }
                textBox.Text = leftValue.ToString();
                textBox.Text += args.Value;
                operation = args.Value[0];
                rightValue = 0;
            }
        }

        /// Clears textBox up to default condition.
        public void DeleteAll(object sender, EventArgs args)
        {
            textBox.Text = "0";
            leftValue = 0;
            operation = '+';
            rightValue = 0;
        }

        private void AddAllButtons()
        {
            Size sizeOfButton = new Size(40, 40);
            for (int i = 1; i < 10; ++i)
            {
                buttons[i] = AddButton("button_" + i.ToString(), i.ToString(), sizeOfButton,
                                                    new Point(40 * ((i - 1) % 3), 40 * ((i - 1) / 3 + 1)));
            }
            buttons[0] = AddButton("button_1", 0.ToString(), sizeOfButton,
                                                    new Point(40 * 1, 40 * 4));

            buttons[10] = AddButton("button_+", "+", sizeOfButton,
                                                    new Point(40 * 3, 40 * 1));
            buttons[11] = AddButton("button_-", "-", sizeOfButton,
                                                    new Point(40 * 3, 40 * 2));
            buttons[12] = AddButton("button_*", "*", sizeOfButton,
                                                    new Point(40 * 3, 40 * 3));
            buttons[13] = AddButton("button_/", "/", sizeOfButton,
                                                    new Point(40 * 3, 40 * 4));
            buttons[14] = AddButton("button_C", "C", sizeOfButton,
                                                    new Point(40 * 0, 40 * 4));
            buttons[15] = AddButton("button_=", "=", sizeOfButton,
                                                    new Point(40 * 2, 40 * 4));

            buttons[0].Click += eventLoop.AddDigit_0;
            buttons[1].Click += eventLoop.AddDigit_1;
            buttons[2].Click += eventLoop.AddDigit_2;
            buttons[3].Click += eventLoop.AddDigit_3;
            buttons[4].Click += eventLoop.AddDigit_4;
            buttons[5].Click += eventLoop.AddDigit_5;
            buttons[6].Click += eventLoop.AddDigit_6;
            buttons[7].Click += eventLoop.AddDigit_7;
            buttons[8].Click += eventLoop.AddDigit_8;
            buttons[9].Click += eventLoop.AddDigit_9;

            buttons[10].Click += eventLoop.AddAdd;
            buttons[11].Click += eventLoop.AddSubtract;
            buttons[12].Click += eventLoop.AddMultiply;
            buttons[13].Click += eventLoop.AddDivide;
            buttons[14].Click += eventLoop.Delete;
            buttons[15].Click += eventLoop.AddEqual;

            eventLoop.AddDigit += AddDigit;
            eventLoop.AddChar += AddChar;
            eventLoop.DeleteEvent += DeleteAll;
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
    }
}