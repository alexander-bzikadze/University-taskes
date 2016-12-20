using System;
using System.Collections.Generic;
using System.Collections;

namespace Net
{
	/// Simulates work of the net. Stops only when all computers are poisoned.
	/// Requirs IReader, IViewer objects to control input/output.
	static public class Logic
	{
		/// Launches net poisoning process until all computers are not poisoned.
		public static ulong MainProcess(IReader reader, IViewer viewer)
		{
			var input = reader.ReadFromFile();
			var net = new Net(input.adjacencyMatrix, input.computers);
			ulong iteration = 0;
			while (!Logic.Iteration(net))
			{
				viewer.View(net, iteration++);
			}
			viewer.View(net, iteration++);
			return iteration;
		}

		/// Iterates one time. Tries to spread viruses from poisoned computers.
		/// Returns true if all computers are poisoned.
		public static bool Iteration(Net net)
		{
			Net new_net = net;
			bool notAllPoisoned = true;
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
								new_net.Comps[j].Poison(net.Comps[i].Virus);
							}
						}
					}
				}
				else
				{
					notAllPoisoned = false;
				}
			}
			net = new_net;
			return notAllPoisoned;
		}
	}
}