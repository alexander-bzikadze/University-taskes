using System;
using System.Collections.Generic;
using System.Collections;

namespace Net
{
	public class ReadResult
	{
		public ReadResult()
		{
			this.adjacencyMatrix = null;
			this.computers = null;
			this.oses = null;
			this.viruses = null;
		}

		public ReadResult(Tuple<bool[,], Computer[], Os[], Virus[]> inputTuple)
		{
			this.adjacencyMatrix = inputTuple.Item1;
			this.computers = inputTuple.Item2;
			this.oses = inputTuple.Item3;
			this.viruses = inputTuple.Item4;
		}

		/// Adjacency matrix of the net.
		public bool[,] adjacencyMatrix { get; set; }

		/// Array of computers in the net.
		public Computer[] computers { get; set; }

		/// Array of os types.
		public Os[] oses {get; set; }

		/// Array of virus types.
		public Virus[] viruses { get; set; }
	}
}