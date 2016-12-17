using System;
using System.Collections.Generic;
using System.Collections;

namespace Net
{
	/// Null replacement for Os.
	public class NullOs : Os
	{
		public NullOs()
		{
			this.Name = "None";
		}

		public NullOs(String name)
		{
			this.Name = "None";
		}

		new public String Name { get; private set; }

		/// 100 procent chance of poisoning.
		new public bool PoisonAttempt(Virus virus)
		{
			var rnd = new Random();
			var chance = rnd.NextDouble();
			return chance > virus.Poison(this.Name);
		}
	}
}