using System;

namespace Calculator
{
    /// A class for AddChar event in EventLoop. Contains string property.
    public class ButtonCharClickedArguments : EventArgs
    {
        public ButtonCharClickedArguments(string value = " ")
        {
            this.Value = value;
        }

        public string Value {get;}
    }
}