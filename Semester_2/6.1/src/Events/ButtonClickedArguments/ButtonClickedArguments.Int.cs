using System;

namespace Calculator
{
    /// A class for AddDigit event in EventLoop. Contains int property.
    public class ButtonIntClickedArguments : EventArgs
    {
        public ButtonIntClickedArguments(int value = 0)
        {
            this.Value = value;
        }

        public int Value {get;}
    }
}