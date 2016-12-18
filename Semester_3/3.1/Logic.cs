using System;

namespace Robots
{
	/// Main logic.
	public static class Logic
	{
		/// Main Process. Takes reader and returns boolean if there is such a plan to destroy all robots.
		public static bool MainProcess(IReader reader)
		{
			var result = reader.Read();
			var colors = Algorithm.ColorGraph(result.Graph);
			int firstColorNumber = 0;
			int secondColorNumber = 0;
			for (int i = 0; i < colors.Length; ++i)
			{
				switch (colors[i])
				{
					case Algorithm.Color.noColor:
					{
						throw new Logic.WrongArgument("Not connected graph given.");
					}
					case Algorithm.Color.firstColor:
					{
						if (result.IsRobotThere[i])
						{
							firstColorNumber++;
						}
						break;
					}
					case Algorithm.Color.secondColor:
					{
						if (result.IsRobotThere[i])
						{
							secondColorNumber++;
						}
						break;
					}
					default:
					{
						throw new UnexpectedSwitchCase();
					}
				}
			}
			return firstColorNumber != 1 && secondColorNumber != 1;
		}

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
		}
	}
}