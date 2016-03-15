using System;

namespace ConsoleTravel
{
    public class ConsoleTravel
    {
        public void OnLeft(object sender, EventArgs args)
        {
            try
            {
                Console.CursorLeft--;
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("Unable to go left.");
            }
        }
        public void OnRight(object sender, EventArgs args)
        {
            try
            {
                Console.CursorLeft++;
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("Unable to go right.");
            }
        }
        public void OnUp(object sender, EventArgs args)
        {
            try
            {
                Console.CursorTop--;
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("Unable to go up.");
            }
        }
        public void OnDown(object sender, EventArgs args)
        {
            try
            {
                Console.CursorTop++;
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("Unable to go down.");
            }
        }
    }
}