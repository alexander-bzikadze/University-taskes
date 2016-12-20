using System;

namespace Robots
{
	/// Implementation of IReader. Reads from file.
	public class FileReader : IReader
	{
		/// Constructor that takes string - name of the file that shall be read.
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
				ulong vertexNumber = Convert.ToUInt64(line[0]);
				ulong edgeNumber = Convert.ToUInt64(line[1]);
				ulong robotsNumber = Convert.ToUInt64(line[2]);
				Graph graph = new Graph(vertexNumber);
				bool[] isRobotThere = new bool[vertexNumber];
				for (ulong i = 0; i < edgeNumber; ++i)
				{
					line = file.ReadLine().Split(' ');
					if (line.Length != 2)
					{
						throw new WrongArgument("Cannot add edge, wrogh args number.");
					}
					ulong vertex1 = Convert.ToUInt64(line[0]);
					ulong vertex2 = Convert.ToUInt64(line[1]);
					if (vertex1 == vertex2)
					{
						throw new WrongArgument("Cannot add loop.");
					}
					vertex1--;
					vertex2--;
					graph.AddEdge(vertex1, vertex2);
				}
				if (robotsNumber != 0)
				{
					line = file.ReadLine().Split(' ');
					if (Convert.ToUInt64(line.Length) != robotsNumber)
					// Yes, Length is for some reason int. And it cannot be compared to ulong.
					// God knows why it is not uint.
					{
						throw new WrongArgument("Wrong robots number given.");
					}
					for (ulong i = 0; i < robotsNumber; ++i)
					{
						if (Convert.ToUInt64(line[i]) > vertexNumber || Convert.ToInt64(line[i]) < 1)
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