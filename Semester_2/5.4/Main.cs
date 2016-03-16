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

            eventLoop.Start += consoleTravel.Start;
            eventLoop.LeftHandler += consoleTravel.OnLeft;
            eventLoop.RightHandler += consoleTravel.OnRight;
            eventLoop.UpHandler += consoleTravel.OnUp;
            eventLoop.DownHandler += consoleTravel.OnDown;

            eventLoop.Run(); 
            
            // try
            // {
            // }
            // catch(WrongInputException)
            // {
            //     Console.WriteLine("Wrong Input. Quiting.");
            // }
        }
    }
}