using System;

namespace List
{
	public class ListElement<T> : IListElement<T>
	{
		public T Value {get;}
		public IListElement<T> Next {get; set;}

		public ListElement()
		{
			Value = default(T);
			Next = null;
		}

		public ListElement(T Value)
		{
			this.Value = Value;
			Next = null;
		}
	}
}