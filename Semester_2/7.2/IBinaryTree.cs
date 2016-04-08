using System;

namespace Set
{
	/// Interface of a Binary Tree.
	/// Has a property Root - first Vertex of all.
	/// Has Enumerator and three method, connected to it.
	/// Elements can be added, deleted and searched for.
	/// Can be printed.
	/// Is generic. T must be comparable.
	public interface IBinaryTree<T> where T : IComparable<T>
	{
		IBinaryTreeVertex<T> Root {get; set;}

		/// Sets Enumerator at minimal Element.
		void Reset();

		/// Moves Enumerator to the nearest by value Element.
		bool MoveForward();

		/// Gets Value from Enumerator.
		T GetCurrentValue();

		/// Adds given element to the Tree.
		/// Returns true, if successful.
		/// Returns false, if element is found in the Tree.
		bool Add(IBinaryTreeVertex<T> vertex);

		/// Overloaded method of Add(IBinaryTreeVertex).
		bool Add(T value);

		/// Deletes given element from tree.
		/// Returns true, if successful.
		/// Returns false, if element is not found in the Tree.
		bool Delete(IBinaryTreeVertex<T> vertex);

		/// Overloaded method of Delete(IBinaryTreeVertex).
		bool Delete(T value);

		/// Searches for element in Tree and returns result of searchings (True = successful).
		bool Search(IBinaryTreeVertex<T> vertex);

		/// Overloaded method of Search(IBinaryTreeVertex).
		bool Search(T value);

		/// Prints Tree.
		void Print();
	}
}