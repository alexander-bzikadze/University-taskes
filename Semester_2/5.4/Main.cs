using ConsoleTravel;
using System;

namespace ConsoleTravel
{
    public class CL
    {
        static public void Main()
        {
            var eventLoop = new EventLoop();
            var consoleTravel = new ConsoleTravel();

            eventLoop.LeftHandler += consoleTravel.OnLeft;
            eventLoop.RightHandler += consoleTravel.OnRight;
            eventLoop.UpHandler += consoleTravel.OnUp;
            eventLoop.DownHandler += consoleTravel.OnDown;

            try
            {
                eventLoop.Run(); 
            }
            catch(WrongInputException)
            {
                Console.WriteLine("Wrong Input. Quiting.");
            }
        }
    }
}