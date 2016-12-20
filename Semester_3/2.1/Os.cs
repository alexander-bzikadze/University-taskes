using System;
using System.Collections.Generic;
using System.Collections;

namespace Net
{
	/// Os for the computer. Contains its name.
	public class Os
	{
		/// Standart constructor.
		public Os()
		{
			this.Name = null;
		}

		/// Constructor that defines name.
		public Os(String name)
		{
			this.Name = name;
		}

		/// Name of the Os.
		public String Name { get; private set; }

		/// Gives provided virus os name and virus returns chance of the poisoning.
		/// Returns true if os got poisoned.
		public bool PoisonAttempt(Virus virus)
		{
			var rnd = RandomSingleton.Instance();
			var chance = rnd.NextDouble();
			return chance > virus.Poison(this.Name);
		}

		private class RandomSingleton
		{
			private RandomSingleton()
			{
				random = new Random();
			}

			public static RandomSingleton Instance()
			{
				if (!isInstanced)
				{
					isInstanced = true;
					instancedRandom = new RandomSingleton();
				}
				return instancedRandom;
			}

			public double NextDouble()
			{
				return random.NextDouble();
			}

			private static bool isInstanced = false;
			private Random random;
			private static RandomSingleton instancedRandom;
		}
	}
}