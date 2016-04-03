using System;

namespace BinaryTree
{
	public class BinaryTreeVertex<T> : IBinaryTreeVertex<T> where T : IComparable<T>
	{
		public BinaryTreeVertex()
		{
			this.Value = default(T);
			this.Parent = null;
			this.LeftChild = null;
			this.RightChild = null;
		}

		public IBinaryTreeVertex<T> Parent {get; set;}
		public IBinaryTreeVertex<T> LeftChild {get; set;}
		public IBinaryTreeVertex<T> RightChild {get; set;}
		public T Value {get; set;}

		public BinaryTreeVertex(T Value)
		{
			this.Value = Value;
			this.Parent = null;
			this.LeftChild = null;
			this.RightChild = null;
		}
	}
}