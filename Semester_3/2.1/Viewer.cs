using System;
using System.Collections.Generic;
using System.Collections;

namespace Net
{
	/// Prints input information into console.
	/// Input information is Net and number of iteration.
	public class Viewer : IViewer
	{
		public void View(Net net, int iteration)
		{
			Console.WriteLine("Iteration number {0}. Current Matrix:", iteration);
			for (int i = 0; i < net.Matrix.GetLength(0); ++i)
			{
				for (int j = 0; j < net.Matrix.GetLength(1); ++j)
				{
					Console.Write("{0} ", Convert.ToInt16(net.Matrix[i, j]));
				}
				Console.WriteLine();
			}
			Console.WriteLine("Current computers status:");
			foreach (var comp in net.Comps)
			{
				Console.WriteLine("Os - {0}, virus - {1}.", comp.Os.Name, comp.Virus.Name);
			}
			Console.WriteLine();
		}
	}
}