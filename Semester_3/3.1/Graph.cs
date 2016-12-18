using System;
using System.Collections.Generic;

namespace Robots
{
	/// Implementation of undirected graph.
	public class Graph
	{
		public Graph(ulong vertexNumber = 0)
		{
			Vertexes = new Vertex[vertexNumber];
			for (ulong i = 0; i < vertexNumber; ++i)
			{
				Vertexes[i] = new Vertex();
				Vertexes[i].Number = i;
			}
		}

		/// Add edge between two vertexes.
		public void AddEdge(ulong vertex1, ulong vertex2)
		{
			Vertexes[vertex1].AddConnection(Vertexes[vertex2]);
			Vertexes[vertex2].AddConnection(Vertexes[vertex1]);
		}

		/// Array of vertexes.
		public Vertex[] Vertexes { get; private set; }
	}
}