using System;

namespace List
{
	/// An interface for and element of a List.
	/// Is T generic.
	/// Contains two Properties: T gettered Value
	/// and IListElement Next, that is gettered and settered.
	public interface IListElement<T>
	{
		T Value {get;}
		IListElement<T> Next {get; set;}
	}
}