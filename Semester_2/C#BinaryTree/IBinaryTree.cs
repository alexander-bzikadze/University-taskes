using System;

namespace BinaryTree
{
	public interface IBinaryTree<T> where T : IComparable<T>
	{
		IBinaryTreeVertex<T> Root {get; set;}

		void Reset();
		bool MoveForward();
		T GetCurrentValue();

		bool Add(IBinaryTreeVertex<T> vertex);
		bool Add(T value);
		bool Delete(IBinaryTreeVertex<T> vertex);
		bool Delete(T value);
		bool Search(IBinaryTreeVertex<T> vertex);
		bool Search(T value);

		void Print();
	}
}