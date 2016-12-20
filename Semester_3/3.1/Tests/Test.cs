using System;
using Robots;
using NUnit.Framework;

namespace RobotsTests
{
	[TestFixture]
	public class NetTests
	{
		[Test]
		public void ThreeVertexRobotsInFirstInSecond()
		{
			Assert.IsFalse((Logic.MainProcess(new FileReader("Tests/inputTest1.txt"))));
		}

		[Test]
		public void RandomTest()
		{
			Assert.IsFalse((Logic.MainProcess(new FileReader("Tests/inputTest2.txt"))));
		}
		
		[Test]
		public void TestWithOddCycle()
		{
			Assert.IsTrue((Logic.MainProcess(new FileReader("Tests/inputTest3.txt"))));
		}

		[Test]
		public void ThreeVertexRobotsInFirstInThird()
		{
			Assert.IsTrue((Logic.MainProcess(new FileReader("Tests/inputTest4.txt"))));
		}
		
		[Test]
		public void OneRobotInGraph()
		{
			Assert.IsFalse((Logic.MainProcess(new FileReader("Tests/inputTest5.txt"))));
		}
		
		[Test]
		public void WronEdgeParams()
		{
		    Assert.IsTrue(SpecAssert<Robots.FileReader.WrongArgument>.LogicMainProcessAssert("Tests/inputTest6.txt"));
		}
	
		[Test]
		public void RobotSetOutOfRangeOfVertexes_greater()
		{
			Assert.IsTrue(SpecAssert<Robots.FileReader.WrongArgument>.LogicMainProcessAssert("Tests/inputTest7.txt"));
		}
		
		[Test]
		public void RobotSetOutOfRangeOfVertexes_less()
		{
			Assert.IsTrue(SpecAssert<Robots.FileReader.WrongArgument>.LogicMainProcessAssert("Tests/inputTest8.txt"));
		}
		
		[Test]
		public void RobotSetOutOfRangeOfVertexes_min_greater()
		{
			Assert.IsTrue(SpecAssert<Robots.FileReader.WrongArgument>.LogicMainProcessAssert("Tests/inputTest9.txt"));
		}
		
		[Test]
		public void EmptyGraph()
		{
			Assert.IsTrue(SpecAssert<Robots.FileReader.WrongArgument>.LogicMainProcessAssert("Tests/inputTest10.txt"));
		}

		[Test]
		public void NotConnectedGraph()
		{
			Assert.IsTrue(SpecAssert<Robots.Logic.WrongArgument>.LogicMainProcessAssert("Tests/inputTest11.txt"));
		}

		private class SpecAssert<T> where T : Exception
		{
			public static bool LogicMainProcessAssert(string filename)
			{
				try
				{
					Logic.MainProcess(new FileReader(filename));
				}
				catch (T)
				{
					return true;
				}
				catch (Exception)
				{
					return false;
				}
				return false;
			}
		}
	}
}