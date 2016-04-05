using System;
using System.Collections.Generic;

namespace List
{
	public interface IListEnumerator<T> : IEnumerator<T>
	{
		new IListElement<T> Current {get;}
	}
}