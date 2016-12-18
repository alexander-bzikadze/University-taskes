using System;
using System.Collections.Generic;

namespace Robots
{
	/// Implementation of Vertex, used in Graph.
	/// Contains all vertexes, that are connected to this one.
	public class Vertex
	{
		public Vertex()
		{
			this.Connections = new List<Vertex>();
			this.Number = 0;
		}

		/// Adds connection to vertex.
		public void AddConnection(Vertex connected)
		{
			Connections.Add(connected);
		}

		public List<Vertex> Connections { get; private set; }
		public ulong Number;
	}
}