using System;
using System.Collections.Generic;


namespace List
{
	/// Enumeration of a List.
	/// Does not contain other methodes or properties,
	/// not described in Interfaces.
	public class ListEnumerator<T> : IEnumerator<T>
	{
		private IListElement<T> First {get;}

		private IListElement<T> _current;

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

		public ListEnumerator(IListElement<T> First)
		{
			this.First = First;
			Reset();
		}

		new public bool MoveNext()
		{
			if (_current.Next != null)
			{
				_current = _current.Next;	
				return true;
			}
			return false;
		}

		new public void Reset()
		{
			_current = First;
		}

		void IDisposable.Dispose()
		{

		}
	}
}