using System;

namespace Set
{
	/// Class of a Binary Tree. Heir to IBinaryTree.
	/// BinaryTree does contain public methodes or properties, 
	/// not described in IBinaryTree. They are given documentation.
	/// If other documentation needed, try IBinaryTree.
	public class Set<T> : ISet<T> where T : IComparable<T>
	{
		private IBinaryTree<T> tree;

		public Set()
		{
			this.tree = new BinaryTree<T>();
		}

		public void Add(T value)
		{
			tree.Add(value);
		}

		public void Delete(T value)
		{
			tree.Delete(value);
		}

		public bool Search(T value)
		{
			return tree.Search(value);
		}

		public ISet<T> Unite(Set<T> set2)
		{
			return this + set2;
		}

		public ISet<T> Cross(Set<T> set2)
		{
			return this * set2;
		}

		/// Unites two sets and returns result.
		public static Set<T> operator + (Set<T> set1, Set<T> set2)
		{
			var result = new Set<T>();
			set1.tree.Reset();
			do
			{
				result.Add(set1.tree.GetCurrentValue());
			}
			while (set1.tree.MoveForward());
			set2.tree.Reset();
			do
			{
				result.Add(set2.tree.GetCurrentValue());
			}
			while (set2.tree.MoveForward());
			return result;
		}

		/// Crosses two sets and returns result.
		public static Set<T> operator * (Set<T> set1, ISet<T> set2)
		{
			var result = new Set<T>();
			set1.tree.Reset();
			do
			{
				if (set2.Search(set1.tree.GetCurrentValue()))
				{
					result.Add(set1.tree.GetCurrentValue());
				}
			}
			while (set1.tree.MoveForward());
			return result;
		}

		/// Prints Set.
		public void Print()
		{
			this.tree.Reset();
			do
			{
				Console.Write("{0} ", this.tree.GetCurrentValue());
			}
			while (this.tree.MoveForward());
			Console.WriteLine();
		}
	}
}