using System;
using Robots;
using NUnit.Framework;

namespace RobotsTests
{
	[TestFixture]
	public class NetTests
	{
		[Test]
		public void Test1()
		{
			Assert.IsFalse((Logic.MainProcess(new FileReader("Tests/inputTest1.txt"))));
		}

		[Test]
		public void Test2()
		{
			Assert.IsFalse((Logic.MainProcess(new FileReader("Tests/inputTest2.txt"))));
		}
		
		/// Odd cycle
		[Test]
		public void Test3()
		{
			Assert.IsTrue((Logic.MainProcess(new FileReader("Tests/inputTest3.txt"))));
		}

		[Test]
		public void Test4()
		{
			Assert.IsTrue((Logic.MainProcess(new FileReader("Tests/inputTest4.txt"))));
		}
		
		[Test]
		public void Test5()
		{
			Assert.IsFalse((Logic.MainProcess(new FileReader("Tests/inputTest5.txt"))));
		}
		
		/// Wrong edge input
		[Test]
		[ExpectedException(typeof(Robots.FileReader.WrongArgument))]
		public void Test6()
		{
			Logic.MainProcess(new FileReader("Tests/inputTest6.txt"));
		}
	
		/// Wrong number of robots in their line	
		[Test]
		[ExpectedException(typeof(Robots.FileReader.WrongArgument))]
		public void Test7()
		{
			Logic.MainProcess(new FileReader("Tests/inputTest7.txt"));
		}
		
		/// Vertex index lesser then 1
		[Test]
		[ExpectedException(typeof(Robots.FileReader.WrongArgument))]
		public void Test8()
		{
			Logic.MainProcess(new FileReader("Tests/inputTest8.txt"));
		}
		
		/// Vertex index greater then vertex number
		[Test]
		[ExpectedException(typeof(Robots.FileReader.WrongArgument))]
		public void Test9()
		{
			Logic.MainProcess(new FileReader("Tests/inputTest9.txt"));
		}
		
		/// Adding two robots to one vertex
		[Test]
		[ExpectedException(typeof(Robots.FileReader.WrongArgument))]
		public void Test10()
		{
			Logic.MainProcess(new FileReader("Tests/inputTest10.txt"));
		}
		
		/// Graph is not connected
		[Test]
		[ExpectedException(typeof(Robots.Logic.WrongArgument))]
		public void Test11()
		{
			Logic.MainProcess(new FileReader("Tests/inputTest11.txt"));
		}
	}
}