using System;
using System.Collections.Generic;

namespace List
{
	public interface IList<T> : IEnumerator<T>
	{
		IListElement<T> First {get; set;}
		IListElement<T> Last {get; set;}
		IListElement<T> CurrentElement {get; set;}
		T Current {get; set;}

		void Add(T value);
		void Delete(T value);
		bool Search(T value);

		bool MoveNext();
		void Reset();
		void Dispose();
	}
}