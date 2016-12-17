using System;
using System.Collections.Generic;
using System.Collections;

namespace Net
{
	/// Class that describes net of the computers in terms of a graph and list of computers.
	public class Net
	{
		public Net()
		{
			this.Matrix = null;
			this.Comps = null;
		}

		public Net(bool[,] Matrix, Computer[] comps)
		{
			this.Matrix = Matrix;
			this.Comps = comps;
		}

		/// Adjacency matrix.
		public bool[,] Matrix { get; private set; }

		/// List of compiters. Numeration is the same as in Matrix.
		public Computer[] Comps { get; private set; }
	}
}