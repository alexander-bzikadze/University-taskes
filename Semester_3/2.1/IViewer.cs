using System;
using System.Collections.Generic;
using System.Collections;

namespace Net
{
	/// Interface for viewer.
	public interface IViewer
	{
		/// Printes current status of net.
		void View(Net net, ulong iteration);
	}
}