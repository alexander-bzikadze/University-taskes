using System;

namespace Set
{
	/// Interface of a Set.
	/// Elements can be added, deleted, searched for.
	/// Is generic. T must be comparable.
	/// Sets can be crossed and united.
	public interface ISet<T> where T : IComparable<T>
	{
		/// Adds element to the set, if element is not found already in the set.
		void Add(T value);

		/// Deletes element from the set.
		void Delete(T value);

		/// Searches for element in the set and returns result of searchings.
		bool Search(T value);

		/// Returns ISet, that contains all element from current ISet and other Set.
		ISet<T> Unite(Set<T> set2);

		/// Returns ISet, that contains elements that are from current ISet and other Set at the same time.
		ISet<T> Cross(Set<T> set2);
	}
}