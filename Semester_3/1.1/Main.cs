using System;

namespace BinaryTree
{
	public class CL
	{
		public static void Main()
		{
			var tree = new BinaryTree<int>();
			tree.Add(2);
			tree.Add(1);
			tree.Add(3);
			var it = tree.GetEnumerator();
			it.MoveNext();
			it.MoveNext();
			Console.WriteLine(it.Current);
		}
	}
}