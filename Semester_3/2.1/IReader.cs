using System;
using System.Collections.Generic;
using System.Collections;

namespace Net
{
	/// Interface for Reader of input data.
	public interface IReader 
	{
		/// Reads data from file and returns ReadResualt object.
		ReadResult ReadFromFile();
	}
}