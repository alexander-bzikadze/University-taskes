using System;

namespace Calculator
{
    /// A class used to understand calculator signals.
    public class EventLoop
    {
        /// Sends signals for AddDigit() in Calculator.
        public event EventHandler<ButtonIntClickedArguments> AddDigit = (sender, args) => {};

        /// Sends signals for AddChar() in Calculator.
        public event EventHandler<ButtonCharClickedArguments> AddChar = (sender, args) => {};

        /// Sends signals for DeleteAll() in Calculator.
        public event EventHandler<EventArgs> DeleteEvent = (sender, args) => {};

        /// List of functions that transform signals of calculator buttons into something useful.
        public void AddDigit_0(object sender, EventArgs args)
        {
            AddDigit(sender, new ButtonIntClickedArguments(0));
        }

        public void AddDigit_1(object sender, EventArgs args)
        {
            AddDigit(sender, new ButtonIntClickedArguments(1));
        }

        public void AddDigit_2(object sender, EventArgs args)
        {
            AddDigit(sender, new ButtonIntClickedArguments(2));
        }

        public void AddDigit_3(object sender, EventArgs args)
        {
            AddDigit(sender, new ButtonIntClickedArguments(3));
        }

        public void AddDigit_4(object sender, EventArgs args)
        {
            AddDigit(sender, new ButtonIntClickedArguments(4));
        }

        public void AddDigit_5(object sender, EventArgs args)
        {
            AddDigit(sender, new ButtonIntClickedArguments(5));
        }

        public void AddDigit_6(object sender, EventArgs args)
        {
            AddDigit(sender, new ButtonIntClickedArguments(6));
        }

        public void AddDigit_7(object sender, EventArgs args)
        {
            AddDigit(sender, new ButtonIntClickedArguments(7));
        }

        public void AddDigit_8(object sender, EventArgs args)
        {
            AddDigit(sender, new ButtonIntClickedArguments(8));
        }

        public void AddDigit_9(object sender, EventArgs args)
        {
            AddDigit(sender, new ButtonIntClickedArguments(9));
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
    }
}