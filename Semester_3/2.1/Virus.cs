using System;
using System.Collections.Generic;
using System.Collections;

namespace Net
{
	/// Class for virus. Contains its name and list of oses and chances of poisoning them.
	public class Virus
	{
		public Virus()
		{
			this.Name = "None";
			this.risks = null;
		}

		public Virus(String name, Tuple<String, Double>[] risks)
		{
			this.Name = name;
			this.risks = risks;
		}

		/// Name of the virus.
		public String Name { get; private set; }

		/// Risks of poisoning oses.
		private Tuple<String, Double>[] risks; 

		/// Returns chance of poisoning by the name of the os given.
		public Double Poison (String os)
		{
			foreach (var elem in risks)
			{
				if (os == elem.Item1)
				{
					return elem.Item2;
				}
			}
			return 1e-10;
		}
	}
}