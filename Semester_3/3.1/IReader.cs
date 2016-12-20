using System;

namespace Robots
{
	/// Interface to read input data.
	public interface IReader
	{
		/// Reads input and returns ReadResult.
		ReadResults Read();
	}
}