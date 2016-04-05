using System;

namespace List
{
	public interface IListElement<T>
	{
		T Value {get;}
		IListElement<T> Next {get; set;}
	}
}