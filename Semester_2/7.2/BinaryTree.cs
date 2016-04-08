using System;

namespace Set
{
	/// Class of a Binary Tree. Heir to IBinaryTree.
	/// BinaryTree does not contain any public methodes or properties, 
	/// not described in IBinaryTree.
	/// If documentation needed, try IBinaryTree.
	public class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
	{
		public IBinaryTreeVertex<T> Root {get; set;}

		public BinaryTree()
		{
			this.Root = null;
			Reset();
		}

		public BinaryTree(IBinaryTreeVertex<T> vertex)
		{
			this.Root = vertex;
			Reset();
		}

		public BinaryTree(T value)
		{
			this.Root = new BinaryTreeVertex<T>(value);
			Reset();
		}

		private IBinaryTreeVertex<T> Enumerator {get; set;}

		public void Reset()
		{
			Enumerator = Root;
			if (Enumerator != null)
			{
				while (Enumerator.LeftChild != null)
				{
					Enumerator = Enumerator.LeftChild;
				}
			}
		}

		public bool MoveForward()
		{
			if (Enumerator.RightChild != null)
			{
				Enumerator = Enumerator.RightChild;
				while (Enumerator.LeftChild != null)
				{
					Enumerator = Enumerator.LeftChild;
				}
			}
			else if (Enumerator.Parent != null)
			{
				while (Enumerator.Parent != null && Enumerator.Parent.Value.CompareTo(Enumerator.Value) < 0)
				{
					Enumerator = Enumerator.Parent;
				}
				Enumerator = Enumerator.Parent;
				if (Enumerator == null)
				{
					Reset();
					return false;
				}
			}
			else
			{
				Reset();
				return false;
			}
			return true;
		}

		public T GetCurrentValue()
		{
			return Enumerator.Value;
		}

		public bool Add(IBinaryTreeVertex<T> vertex)
		{
			if (Root == null)
			{
				Root = vertex;
			}
			else
			{
				var current = Root;
				while (current.Value.CompareTo(vertex.Value) > 0 && current.LeftChild != null
						|| current.Value.CompareTo(vertex.Value) < 0 && current.RightChild != null)
				{
					if (current.Value.CompareTo(vertex.Value) > 0)
					{
						current = current.LeftChild;
					}
					else if (current.Value.CompareTo(vertex.Value) < 0)
					{
						current = current.RightChild;
					}
				}
				if (current.Value.CompareTo(vertex.Value) == 0)
				{
					return false;
				}
				if (current.Value.CompareTo(vertex.Value) > 0)
				{
					current.LeftChild = vertex;
					current.LeftChild.Parent = current;
				}
				else if (current.Value.CompareTo(vertex.Value) < 0)
				{
					current.RightChild = vertex;
					current.RightChild.Parent = current;
				}
			}
			Reset();
			return true;
		}

		public bool Add(T value)
		{
			return Add(new BinaryTreeVertex<T>(value));
		}

		private IBinaryTreeVertex<T> SearchForVertex(IBinaryTreeVertex<T> vertex)
		{
			var current = Root;
			while (current != null && current.Value.CompareTo(vertex.Value) != 0)
			{
				if (current.Value.CompareTo(vertex.Value) > 0)
				{
					current = current.LeftChild;
				}
				else if (current.Value.CompareTo(vertex.Value) < 0)
				{
					current = current.RightChild;
				}
			}
			return current;
		}

		private IBinaryTreeVertex<T> SearchForVertex(T value)
		{
			return SearchForVertex(new BinaryTreeVertex<T>(value));
		}

		public bool Delete(IBinaryTreeVertex<T> vertex)
		{
			var deleted = SearchForVertex(vertex);
			var current = deleted;
			if (current == null)
			{
				return false;
			}
			if (current.LeftChild == null && current.RightChild == null)
			{
				current = current.Parent;
				if (current == null)
				{
					Root = null;
				}
				else if (current.Value.CompareTo(deleted.Value) > 0)
				{
					current.LeftChild = null;
				}
				else
				{
					current.RightChild = null;
				}
				return true;
			}
			if (current.RightChild != null)
			{
				current = current.RightChild;
				if (current.LeftChild != null)
				{
					while (current.LeftChild != null)
					{
						current = current.LeftChild;
					}
				}
			}
			else
			{
				current = current.LeftChild;
				if (current.RightChild != null)
				{
					while (current.RightChild != null)
					{
						current = current.RightChild;
					}
				}
			}

			if (current.Parent.Value.CompareTo(current.Value) > 0)
			{
				if (current.LeftChild == null)
				{
					current.Parent.LeftChild = current.RightChild;
					if (current.RightChild != null)
					{
						current.RightChild.Parent = current.Parent;
					}
				}
				else
				{
					current.Parent.LeftChild = current.LeftChild;
					if (current.LeftChild != null)
					{
						current.LeftChild.Parent = current.Parent;
					}
				}
			}
			else
			{
				if (current.RightChild == null)
				{
					current.Parent.RightChild = current.LeftChild;
					if (current.LeftChild != null)
					{
						current.LeftChild.Parent = current.Parent;
					}
				}
				else
				{
					current.Parent.RightChild = current.RightChild;
					if (current.RightChild != null)
					{
						current.RightChild.Parent = current.Parent;
					}
				}
			}

			Reset();
			deleted.Value = current.Value;

			return true;
		}

		public bool Delete(T value)
		{
			return Delete(new BinaryTreeVertex<T>(value));
		}

		public bool Search(IBinaryTreeVertex<T> vertex)
		{
			return SearchForVertex(vertex) != null;
		}

		public bool Search(T value)
		{
			return SearchForVertex(value) != null;
		}

		public void Print()
		{
			Print(Root);

		}

		private void Print(IBinaryTreeVertex<T> vertex, int level = 0)
		{
			if (vertex == null)
			{
				return;
			}

			Print(vertex.LeftChild, level + 1);

			for (int i = 0; i < level; ++i)
			{
				Console.Write(".");
			}
			Console.WriteLine(vertex.Value);

			Print(vertex.RightChild, level + 1);
		}
	}
}