using System;

namespace BinaryTree
{
	public static class CL
	{
		static public void Main()
		{
			IBinaryTree<string> tree = new BinaryTree<string>();
			tree.Add("ak");
			tree.Add("aa");
			tree.Add("Dg)");
			tree.Add("jgd)");
			tree.Print();
			do
			{
				Console.WriteLine(tree.GetCurrentValue());
			}
			while (tree.MoveForward());
		}
	}
}