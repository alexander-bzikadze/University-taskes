using System;

namespace Robots
{
	/// Implementation of IReader. Reads from file.
	public class FileReader : IReader
	{
		public FileReader(String filename = "input.txt")
		{
			this.filename = filename;
		}

		private string filename;

		/// Reads from file, given in constructor and returns ReadResults.
		public ReadResults Read()
		{
			using (var file = new System.IO.StreamReader(this.filename))
			{
				var line = file.ReadLine().Split(' ');
				ulong VertexNumber = Convert.ToUInt64(line[0]);
				ulong EdgeNumber = Convert.ToUInt64(line[1]);
				ulong RobotsNumber = Convert.ToUInt64(line[2]);
				Graph graph = new Graph(VertexNumber);
				bool[] isRobotThere = new bool[VertexNumber];
				for (ulong i = 0; i < EdgeNumber; ++i)
				{
					line = file.ReadLine().Split(' ');
					if (line.Length != 2)
					{
						throw new WrongArgument("Cannot add edge, wrogh args number.");
					}
					ulong vertex1 = Convert.ToUInt64(line[0]);
					ulong vertex2 = Convert.ToUInt64(line[1]);
					vertex1--;
					vertex2--;
					graph.AddEdge(vertex1, vertex2);
				}
				if (RobotsNumber != 0)
				{
					line = file.ReadLine().Split(' ');
					if (Convert.ToUInt64(line.Length) != RobotsNumber)
					// Yes, Length is for some reason int. And it cannot be compared to ulong.
					// God knows why it is not uint.
					{
						throw new WrongArgument("Wrong robots number given.");
					}
					for (ulong i = 0; i < RobotsNumber; ++i)
					{
						if (Convert.ToUInt64(line[i]) > VertexNumber || Convert.ToInt64(line[i]) < 1)
						{
							throw new WrongArgument("Wrong vertex number. Given value is outside array range.");
						}
						if (isRobotThere[Convert.ToUInt64(line[i]) - 1])
						{
							throw new WrongArgument("Cannot add two robots to one vertex.");
						}
						isRobotThere[Convert.ToUInt64(line[i]) - 1] = true;
					}
				}
				return new ReadResults(graph, isRobotThere);
			}
		}

		/// Signals that exception is caused by wrong input arguments.
		public class WrongArgument : Exception
		{
			public WrongArgument() { }
			public WrongArgument(string message) : base(message) { }
			public WrongArgument(string message, Exception inner) : 
			base(message, inner) { }

			protected WrongArgument(
				System.Runtime.Serialization.SerializationInfo info,
				System.Runtime.Serialization.StreamingContext context) :
			base(info, context) { }
		}
	}
}