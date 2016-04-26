using System;
using System.Collections.Generic;

namespace List
{
	/// Interface for a List.
	/// Contains two properties - First and Last elements.
	/// Contains Addition, Deletion void methodes.
	/// Also contains boolean Search method.
	/// Is enumerable.
	/// Is T generic.
	public interface IList<T> : IEnumerable<T>
	{
		/// Prefirst element in the List.
		IListElement<T> First {get; set;}

		/// Last element in the List.
		IListElement<T> Last {get; set;}

		/// Adds element to the end of the List.
		void Add(T value);

		/// Finds element by value and deletes it.
		void Delete(T value);

		/// Finds element by value and returns status of its existence.
		bool Search(T value);
	}
}