using System;

namespace Robots
{
	public class CL
	{
		public static void Main()
		{
			Console.WriteLine(Logic.MainProcess(new FileReader("input.txt")));
		}
	}
}