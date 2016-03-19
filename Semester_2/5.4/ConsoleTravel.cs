using System;

namespace ConsoleTravel
{
    /// Class of receiver of signals. Moves cursor depending on signals.
    public class ConsoleTravel
    {
        private Coordinates max = new Coordinates();

        public void Start(object sender, EventArgs args)
        {
            int y = 9; //height of travel zone.
            int x = 17; //length of "Here u can travel."
            Console.CursorTop = 0;
            Console.WriteLine("Here u cannot travel.");
            for (int i = 0; i < y; ++i)
            {
                Console.WriteLine("Here u can travel.");
            }
            Console.WriteLine("Type 'Q' to quit.");
            max = new Coordinates(x, Console.CursorTop - 1);
            Console.CursorTop -= y;
        }

        /// Moves cursor left, if possible.
        public void OnLeft(object sender, EventArgs args)
        {
            try
            {
                Console.CursorLeft--;
            }
            catch(ArgumentOutOfRangeException)
            {
                // Console.WriteLine("Unable to go left.");
            }
        }

        /// Moves cursor right, if possible.
        public void OnRight(object sender, EventArgs args)
        {
            if (Console.CursorLeft != max.X)
            {
                Console.CursorLeft++;
            }
        }

        /// Moves cursor up, if possible.
        public void OnUp(object sender, EventArgs args)
        {
            if (Console.CursorTop != max.Y - 9)
            {
                Console.CursorTop--;
            }
        }

        /// Moves cursor down, if possible.
        public void OnDown(object sender, EventArgs args)
        {
            if (Console.CursorTop != max.Y)
            {
                Console.CursorTop++;
            }
        }
    }
}