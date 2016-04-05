using System;

namespace List
{
	public class List<T> : IList<T> where T : IEquatable<T>
	{
		public List()
		{
			First = null;
			Last = null;
			CurrentElement = First;
		}

		public IListElement<T> First {get; set;}
		public IListElement<T> Last {get; set;}

		public IListElement<T> CurrentElement {get; set;}

		public T Current
		{
			get
			{
				return CurrentElement.Value;
			}
			set {}
		}

		public bool MoveNext()
		{
			if (CurrentElement.Next != null)
			{
				CurrentElement = CurrentElement.Next;	
				return true;
			}
			return false;
		}

		public void Reset()
		{
			CurrentElement = First;
		}

		public void Dispose()
		{

		}

		public void Add(T value)
		{
			if (First == null)
			{
				First = new ListElement<T>(value);
				Last = First;
			}
			else 
			{
				Last.Next = new ListElement<T>(value);
				Last = Last.Next;
			}
		}

		public void Delete(T value)
		{
			if (First != null)
			{
				if (First.Value.Equals(value))
				{
					if (Last == First)
					{
						Last = Last.Next;
					}
					First = First.Next;
				}
				var current = First;
				while (current.Next != null && !current.Value.Equals(value))
				{
					current = current.Next;
				}
				if (current.Next != null)
				{
					current.Next = current.Next.Next;
				}
			}
		}

		public bool Search(T value)
		{
			var current = First;
			while (current != null && !current.Value.Equals(value))
			{
				current = current.Next;
			}
			return current != null;
		}
	}
}