using System;
using System.Collections;
using System.Collections.Generic;

namespace Robots
{
	/// Static class that provides a range of static methods - implementation of algorithms.
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
				Dfs(nextVertex, changeColor(currentColor), colors);
			}
		}

		private static Color changeColor(Color currentColor)
		{
			switch (currentColor)
			{
				case Color.noColor:
				{
					throw new UnexpectedSwitchCase("Cannot change noColor");
				}
				case Color.firstColor:
				{
					return Color.secondColor;
				}
				case Color.secondColor:
				{
					return Color.firstColor;
				}
				default:
				{
					throw new UnexpectedSwitchCase("Unknown color given.");
				}
			}
		}

		/// Is thrown if switch case reached logically wrong case.
		public class UnexpectedSwitchCase : Exception
		{
			public UnexpectedSwitchCase() { }
			public UnexpectedSwitchCase(string message) : base(message) { }
			public UnexpectedSwitchCase(string message, Exception inner) : 
			base(message, inner) { }

			protected UnexpectedSwitchCase(
				System.Runtime.Serialization.SerializationInfo info,
				System.Runtime.Serialization.StreamingContext context) :
			base(info, context) { }
		}	}
}