using System;
using System.Collections.Generic;
using System.Collections;

namespace List
{
	/// A class that realizes IList.
	/// Is T generic.
	/// Is enumerable.
	/// Does not contained methodes and properties, not described in interfaces.
	public class List<T> : IList<T> where T : IEquatable<T>
	{
		public List()
		{
			First = new ListElement<T>();
			Last = null;
		}

		/// Prefirst element in the list.
		public IListElement<T> First {get; set;}

		/// Last element in the list.
		public IListElement<T> Last {get; set;}

		/// Adds element to the end of the list.
		public void Add(T value)
		{
			if (First.Next == null)
			{
				First.Next = new ListElement<T>(value);
				Last = First.Next;
			}
			else 
			{
				Last.Next = new ListElement<T>(value);
				Last = Last.Next;
			}
		}

		/// Finds element by value in the list.
		/// If found, deletes it.
		public void Delete(T value)
		{
			if (First.Next != null)
			{
				if (First.Next.Value.Equals(value))
				{
					if (Last == First.Next)
					{
						Last = Last.Next;
					}
					First.Next = First.Next.Next;
				}
				else
				{
					var current = First.Next;
					while (current.Next != null && !current.Next.Value.Equals(value))
					{
						current = current.Next;
					}
					if (current.Next != null)
					{
						if (current.Next == null)
						{
							Last = current;
						}
						current.Next = current.Next.Next;
					}
				}
			}
		}

		/// Finds element by value in the list.
		/// Returns true, if found.
		/// If not, guess.
		public bool Search(T value)
		{
			var current = First.Next;
			while (current != null && !current.Value.Equals(value))
			{
				current = current.Next;
			}
			return current != null;
		}

		/// Needed method to IEnurable interface.
	    IEnumerator IEnumerable.GetEnumerator()
	    {
	        return this.GetEnumerator();
	    }

	    /// Realization of GetEnumerator. Returns ListEnumerator, created with help of First.
		public System.Collections.Generic.IEnumerator<T> GetEnumerator()
		{
			return new ListEnumerator<T>(First);
		}
	}
}