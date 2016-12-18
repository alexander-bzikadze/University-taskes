using System;

namespace Robots
{
	/// Container for Graph and robot's positions.
	public class ReadResults
	{
		public ReadResults()
		{
			this.Graph = null;
			this.IsRobotThere = null;
		}

		public ReadResults(Graph graph, bool[] isRobotThere)
		{
			this.Graph = graph;
			this.IsRobotThere = isRobotThere;
		}

		public Graph Graph { get; private set; }
		public bool[] IsRobotThere { get; private set; }
	}
}