using System;

namespace ConsoleTravel
{
    public class ConsoleTravel
    {
        private Coordinates max = new Coordinates();

        public void Start(object sender, EventArgs args)
        {
            Console.CursorTop = 0;
            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine("Here u can travel.");
            }
            max = new Coordinates(Console.CursorTop - 1, 17);
            Console.CursorTop -= 10;
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