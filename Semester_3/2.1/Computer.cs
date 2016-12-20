using System;
using System.Collections.Generic;
using System.Collections;

namespace Net
{
	/// Class for computer. Contains Os and Virus property.
	public class Computer
	{
		public Computer()
		{
			this.Os = new NullOs();
			this.Virus = new Virus();
		}

		public Computer(Os os)
		{
			this.Os = os;
			this.Virus = new Virus();
		}

		/// Os that is installed on the computer.
		public Os Os { get; private set; }

		/// Virus that computer is poisoned by. Contains standart Virus if computer is clear.
		public Virus Virus { get; set; }

		/// Returns if computer is poisoned.
		public bool isPoisoned()
		{
			return Virus.Name != "None";
		}

		/// Tryes to poison computer.
		public void Poison(Virus virus)
		{
			if (this.Os.PoisonAttempt(virus))
			{
				this.Virus = virus;
			} 
		}
	}
}