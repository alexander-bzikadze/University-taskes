using System;

namespace Robots
{
	/// Container for Graph and robot's positions.
	public class ReadResults
	{
		/// Default constructor.
		public ReadResults()
		{
			this.Graph = null;
			this.IsRobotThere = null;
		}

		/// Takes graph and bool[] and sets them as properties.
		public ReadResults(Graph graph, bool[] isRobotThere)
		{
			this.Graph = graph;
			this.IsRobotThere = isRobotThere;
		}

		/// Read graph.
		public Graph Graph { get; private set; }

		/// Bool array that containes answer is there a robot in vertex i.
		public bool[] IsRobotThere { get; private set; }
	}
}