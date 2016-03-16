using System;

namespace ConsoleTravel
{
    /// Class with two int getable and setable properties.
    public class Coordinates
    {
        public int x {get; set;}
        public int y {get; set;}

        public Coordinates(int y = 0, int x = 0)
        {
            this.x = x;
            this.y = y;
        }
    }
}