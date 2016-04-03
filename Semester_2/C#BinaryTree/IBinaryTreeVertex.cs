using System;

namespace BinaryTree
{
	public interface IBinaryTreeVertex<T> where T : IComparable<T>
	{
		T Value {get; set;}
		IBinaryTreeVertex<T> Parent {get; set;}
		IBinaryTreeVertex<T> LeftChild {get; set;}
		IBinaryTreeVertex<T> RightChild {get; set;}
	}
}