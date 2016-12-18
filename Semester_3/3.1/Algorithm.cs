using System;
using System.Collections;
using System.Collections.Generic;

namespace Robots
{
	/// Static class, that provides a range of static methodes - implementation of algorithms.
	public static class Algorithm
	{
		/// Enum, used to color the graph.
		public enum Color
		{
			noColor = 0,
			firstColor = 1,
			secondColor = 2
		}

		/// Colors connected graph in two colors.
		public static Color[] ColorGraph(Graph graph)
		{
			Color[] colors = new Color[graph.Vertexes.Length];
			Dfs(graph.Vertexes[0], Color.firstColor, colors);
			return colors;
		}

		private static void Dfs(Vertex vertex, Color currentColor, Color[] colors)
		{
			switch (colors[vertex.Number])
			{
				case Color.noColor:
				{
					colors[vertex.Number] = currentColor;
					break;
				}
				default:
				{
					if (colors[vertex.Number] != currentColor)
					{
						for (var i = 0; i < colors.Length; ++i)
						{
							colors[i] = Color.firstColor;
						}
					}
					return;
				}
			}
			foreach (var nextVertex in vertex.Connections)
			{
				Dfs(nextVertex, 3 - currentColor, colors);
			}
		}
	}
}