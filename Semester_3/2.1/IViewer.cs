using System;
using System.Collections.Generic;
using System.Collections;

namespace Net
{
	/// Interface for viewer.
	public interface IViewer
	{
		void View(Net net, ulong iteration);
	}
}