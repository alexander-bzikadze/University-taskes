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
			First = new ListElement();
			Last = null;
		}

		/// Prefirst element in the list.
		private ListElement First {get; set;}

		/// Last element in the list.
		private ListElement Last {get; set;}

		/// Adds element to the end of the list.
		public void Add(T value)
		{
			if (First.Next == null)
			{
				First.Next = new ListElement(value);
				Last = First.Next;
			}
			else 
			{
				Last.Next = new ListElement(value);
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
			return new ListEnumerator(First);
		}

			/// Enumeration of a List.
		/// Does not contain other methodes or properties,
		/// not described in Interfaces.
		public class ListEnumerator : IEnumerator<T>
		{
			private ListElement First {get;}

			private ListElement _current;

			public T Current
			{
				get
				{
					return _current.Value;
				}
			}


		    object System.Collections.IEnumerator.Current
		    {
		        get { return Current; }
		    }

			public ListEnumerator(ListElement first)
			{
				this.First = first;
				Reset();
			}

			public bool MoveNext()
			{
				if (_current.Next != null)
				{
					_current = _current.Next;	
					return true;
				}
				return false;
			}

			public void Reset()
			{
				_current = First;
			}

			void IDisposable.Dispose()
			{

			}
		}

			/// A class that realizes IListElement.
		/// Does not contain methodes and properties,
		/// not declared in Interface.
		/// Contains two constructors.
		public class ListElement
		{
			public T Value {get;}
			public ListElement Next {get; set;}

			public ListElement()
			{
				Value = default(T);
				Next = null;
			}

			public ListElement(T value)
			{
				this.Value = value;
				Next = null;
			}
		}
	}
}