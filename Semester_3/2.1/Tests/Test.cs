using System;
using Net;
using NUnit.Framework;

namespace NetTests
{
	[TestFixture]
	public class NetTests
	{
		private class TestReaderAllPoisoned : Net.IReader
		{
			public ReadResult ReadFromFile()
			{
				long fixedNumber = 1;
				ReadResult result = new ReadResult();
				result.adjacencyMatrix = new bool[fixedNumber, fixedNumber];
				result.computers = new Computer[fixedNumber];
				result.oses = new Os[fixedNumber];
				result.oses[0] = new Os("Test Os");
				result.computers[0] = new Computer(result.oses[0]);
				result.viruses = new Virus[fixedNumber];
				var PoisonChances = new Tuple<String, Double>[fixedNumber];
				PoisonChances[0] = new Tuple<String, Double>("Test Os", 1);
				result.viruses[0] = new Virus("Test Virus", PoisonChances);
				result.computers[0].Virus = result.viruses[0];
				return result;
			}
		}

		private class NullViewer : Net.IViewer
		{
			public void View(Net.Net net, ulong iteration)
			{

			}
		}

		[Test]
		public void AllPoisonedTest()
		{
			Assert.AreEqual(Net.Logic.MainProcess(new TestReaderAllPoisoned(), new NullViewer()), 0);
		}

		[Test]
		public void ComputerIsCreatedWithNoVirus()
		{
			Assert.IsFalse((new Computer()).isPoisoned());
		}

		[Test]
		public void ComputerPoisonsCorrectly()
		{
			var comp = new Computer();
			comp.Virus = new Virus("Test Virus", null);
			Assert.IsTrue(comp.isPoisoned());
		}

		[Test]
		public void AlwaysBeenPoisonedOs()
		{
			var os = new Os("Sorry os");
			var PoisonChances = new Tuple<String, Double>[1];
			PoisonChances[0] = new Tuple<String, Double>("Sorry os", 1.46);
			var virus = new Virus("Hyper virus", PoisonChances);
			Assert.IsFalse(os.PoisonAttempt(virus));
		}

		[Test]
		public void NeverBeenPoisonedOs()
		{
			var os = new Os("Hyper one");
			var PoisonChances = new Tuple<String, Double>[1];
			PoisonChances[0] = new Tuple<String, Double>("Hyper one", -1.46);
			var virus = new Virus("Sorry virus", PoisonChances);
			Assert.IsTrue(os.PoisonAttempt(virus));
		}
	}
}