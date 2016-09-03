using System;
using System.Collections.Generic;

namespace BinaryTree 
{
	/// An enumerator for BinaryTree with ability to delete current element.
	/// Is T generic.
	public interface IBinaryTreeEnumerator<T> : IEnumerator<T>
	{
		/// Removes element, that is now iterated.
		void Remove();
	}
}