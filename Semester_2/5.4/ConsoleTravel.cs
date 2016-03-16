using System;

namespace ConsoleTravel
{
    /// Class of receiver of signals. Moves cursor depending on signals.
    public class ConsoleTravel
    {
        private Coordinates max = new Coordinates();

        public void Start(object sender, EventArgs args)
        {
            int y = 10; //height of travel zone.
            int x = 17; //length of "Here u can travel."
            Console.CursorTop = 0;
            for (int i = 0; i < y; ++i)
            {
                Console.WriteLine("Here u can travel.");
            }
            Console.WriteLine("Type 'Q' to quit.");
            max = new Coordinates(Console.CursorTop - 1, x);
            Console.CursorTop -= y;
        }

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
        public void OnRight(object sender, EventArgs args)
        {
            if (Console.CursorLeft != max.x)
            {
                Console.CursorLeft++;
            }
        }
        public void OnUp(object sender, EventArgs args)
        {
            if (Console.CursorTop != max.y - 9)
            {
                Console.CursorTop--;
            }
        }
        public void OnDown(object sender, EventArgs args)
        {
            if (Console.CursorTop != max.y)
            {
                Console.CursorTop++;
            }
        }
    }
}