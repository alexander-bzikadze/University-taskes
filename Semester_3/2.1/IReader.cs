using System;
using System.Collections.Generic;
using System.Collections;

namespace Net
{
	/// Interface for Reader of input data.
	public interface IReader 
	{
		Tuple<bool[,], Computer[], Os[], Virus[]> ReadFromFile();
	}
}