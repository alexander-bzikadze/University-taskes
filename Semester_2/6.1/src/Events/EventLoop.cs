using System;
using System.Windows.Forms;

namespace Calculator
{
    /// A class used to understand calculator signals.
    public class EventLoop
    {
        /// Sends signals for AddDigit() in Calculator.
        public event EventHandler<ButtonIntClickedArguments> AddDigitSlot = (sender, args) => {};

        /// Sends signals for AddChar() in Calculator.
        public event EventHandler<ButtonCharClickedArguments> AddChar = (sender, args) => {};

        /// Sends signals for DeleteAll() in Calculator.
        public event EventHandler<EventArgs> DeleteEvent = (sender, args) => {};

        /// List of functions that transform signals of calculator buttons into something useful.
        public void AddDigit(object sender, EventArgs args)
        {
            var button = sender as Button;
            AddDigit(sender, new ButtonIntClickedArguments(ButtonToInt(button.Text)));
        }

        public void AddAdd(object sender, EventArgs args)
        {
            AddChar(sender, new ButtonCharClickedArguments("+"));
        }

        public void AddSubtract(object sender, EventArgs args)
        {
            AddChar(sender, new ButtonCharClickedArguments("-"));
        }

        public void AddMultiply(object sender, EventArgs args)
        {
            AddChar(sender, new ButtonCharClickedArguments("*"));
        }

        public void AddDivide(object sender, EventArgs args)
        {
            AddChar(sender, new ButtonCharClickedArguments("/"));
        }

        public void AddEqual(object sender, EventArgs args)
        {
            AddChar(sender, new ButtonCharClickedArguments("="));
        }

        public void Delete(object sender, EventArgs args)
        {
            DeleteEvent(sender, new EventArgs());
        }

        private int ButtonToInt(string text)
        {
            return (int)(text[text.Length - 1] - '0');
        }
    }
}