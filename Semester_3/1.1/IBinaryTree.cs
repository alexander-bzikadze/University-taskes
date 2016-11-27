using System;
using System.Collections.Generic;

namespace BinaryTree
{
	/// Interface of a Binary Tree.
	/// Has a property Root - first Vertex of all.
	/// Elements can be added, deleted and searched for.
	/// Can be printed.
	/// Is generic. T must be comparable.
	public interface IBinaryTree<T> : IEnumerable<T> where T : IComparable<T>
	{
		/// Adds given value to the Tree.
		/// Returns true, if successful.
		/// Returns false, if element is found in the Tree.
		bool Add(T value);

		/// Deletes given value from tree.
		/// Returns true, if successful.
		/// Returns false, if element is not found in the Tree.
		bool Delete(T value);

		/// Searches for value in Tree and returns result of searchings (True = successful).
		bool Search(T value);

		/// Prints Tree.
		void Print();

		/// Enumerator with ability to delete current element from the tree.
		IBinaryTreeEnumerator<T> GetBinaryTreeEnumerator();
	}
}