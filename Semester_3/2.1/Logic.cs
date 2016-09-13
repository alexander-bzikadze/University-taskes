using System;
using System.Collections.Generic;
using System.Collections;

namespace Net
{
	/// Simulates work of the net. Stops only when all computers are poisoned.
	/// Requirs IReader, IViewer objects to control input/output.
	static public class Logic
	{
		public static void MainProcess(IReader reader, IViewer viewer)
		{
			var input = reader.ReadFromFile();
			var net = new Net(input.Item1, input.Item2);
			bool notAllPoisoned = false;
			int iteration = 0;
			while (!notAllPoisoned)
			{
				notAllPoisoned = true;
				for (int i = 0; i < net.Matrix.GetLength(0); ++i)
				{
					if (net.Comps[i].isPoisoned())
					{
						for (int j = 0; j < net.Matrix.GetLength(1); ++j)
						{
							if (j == i)
							{
								continue;
							}
							if (net.Matrix[i, j])
							{
								if (!net.Comps[j].isPoisoned())
								{
									net.Comps[j].Poison(net.Comps[i].Virus);
								}
							}
						}
					}
					else
					{
						notAllPoisoned = false;
					}
				}
				viewer.View(net, iteration++);
			}
		}
	}
}