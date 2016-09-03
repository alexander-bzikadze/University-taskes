using System;
using System.Collections.Generic;
using System.Collections;

namespace BinaryTree
{
	/// Class of a Binary Tree. Heir to IBinaryTree.
	/// BinaryTree does not contain any public methodes or properties, 
	/// not described in IBinaryTree.
	/// If documentation needed, try IBinaryTree.
	public partial class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
	{
		/// Interface of a Vertex of IBinaryTree.
		/// Contains four properties: T value and three nearest vertexes.
		/// Is generic. T must be comparable.
		private interface IBinaryTreeVertex
		{
			T Value {get; set;}
			IBinaryTreeVertex Parent {get; set;}
			IBinaryTreeVertex LeftChild {get; set;}
			IBinaryTreeVertex RightChild {get; set;}
		}

		/// Class of a Vertex of BinaryTree. Heir to IBinaryTreeVertex.
		/// BinaryTreeVertex does not contain any public methodes or properties, 
		/// not described in IBinaryTreeVertex.
		/// If documentation needed, try IBinaryTreeVertex.
		private class BinaryTreeVertex : IBinaryTreeVertex
		{
			public BinaryTreeVertex()
			{
				this.Value = default(T);
				this.Parent = null;
				this.LeftChild = null;
				this.RightChild = null;
			}

			public IBinaryTreeVertex Parent {get; set;}
			public IBinaryTreeVertex LeftChild {get; set;}
			public IBinaryTreeVertex RightChild {get; set;}
			public T Value {get; set;}

			public BinaryTreeVertex(T Value)
			{
				this.Value = Value;
				this.Parent = null;
				this.LeftChild = null;
				this.RightChild = null;
			}
		}

		/// Args for Deletion event. Contains deletedVertex and a vertex to replace it.
		private class DeletionArgs : EventArgs
		{
			public DeletionArgs(IBinaryTreeVertex deletedVertex, IBinaryTreeVertex newVertex)
			{
				this.DeletedVertex = deletedVertex;
				this.NewVertex = newVertex;
			}

			public IBinaryTreeVertex DeletedVertex { get; private set; }
			public IBinaryTreeVertex NewVertex { get; private set; }
		}

		/// Is sent to all iterators existing.
		private event EventHandler<DeletionArgs> Deletion = (sender, args) => {};

		/// Enumerator for BinaryTree.
		private class BinaryTreeEnumerator : IBinaryTreeEnumerator<T>
		{
			private BinaryTree<T> tree;
			private IBinaryTreeVertex current;

			public BinaryTreeEnumerator(BinaryTree<T> tree)
			{
				this.tree = tree;
				this.Reset();
				tree.Deletion += DeletionCheck;
			}

			~BinaryTreeEnumerator()
			{
				tree.Deletion -= DeletionCheck;
			}

			public T Current
			{
				get
				{
					return current.Value;
				}
			}


			object System.Collections.IEnumerator.Current
			{
		 		get { return Current; }
			}

			private void DeletionCheck(object sender, DeletionArgs args)
			{
				if (current == args.DeletedVertex)
				{
					if (current.Value.CompareTo(args.NewVertex.Value) > 0)
					{
						current = null;
					}
					else
					{
						current = args.NewVertex;
					}
				}
				if (current == null)
				{
					Reset();
				}
			}

			public void Reset()
			{
				current = new BinaryTreeVertex();
				var first = tree.Root;
				if (first != null)
				{
					while (first.LeftChild != null)
					{
						first = first.LeftChild;
					}
				}
				current.RightChild = first;
			}

			public bool MoveNext()
			{
				if (this.IsEmpty())
				{
					return false;
				}
				if (current.RightChild != null)
				{
					current = current.RightChild;
					while (current.LeftChild != null)
					{
						current = current.LeftChild;
					}
				}
				else if (current.Parent != null)
				{
					while (current.Parent != null && current.Parent.Value.CompareTo(current.Value) < 0)
					{
						current = current.Parent;
					}
					current = current.Parent;
				}
				return !IsEmpty();
			}

			public bool IsEmpty()
			{
				return current == null;
			}

			public void Remove()
			{
				tree.Delete(current);
			}

			void IDisposable.Dispose()
			{

			}
		}

		/// Needed method to IEnurable interface.
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		/// Realization of GetEnumerator. Returns BinaryTreeEnumerator as IEnumerator<T>.
		public System.Collections.Generic.IEnumerator<T> GetEnumerator()
		{
			return new BinaryTreeEnumerator(this);
		}

		/// Returns BinaryTreeEnumerator, but it is IBinaryTreeEnumerator<T>.
		public IBinaryTreeEnumerator<T> GetBinaryTreeEnumerator()
		{
			return new BinaryTreeEnumerator(this);
		}

		private IBinaryTreeVertex Root {get; set;}

		public BinaryTree()
		{
			this.Root = null;
		}

		public BinaryTree(T value)
		{
			this.Root = new BinaryTreeVertex(value);
		}


		private bool Add(IBinaryTreeVertex vertex)
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
			return true;
		}

		/// Adds element to the tree. Returns true, if successful; false, if element is already in the tree.
		public bool Add(T value)
		{
			return Add(new BinaryTreeVertex(value));
		}

		private IBinaryTreeVertex SearchForVertex(IBinaryTreeVertex vertex)
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

		private IBinaryTreeVertex SearchForVertex(T value)
		{
			return SearchForVertex(new BinaryTreeVertex(value));
		}

		private bool Delete(IBinaryTreeVertex vertex)
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
					var prevVal = deleted.Value;
					while (current != Root && current.Value.CompareTo(prevVal) < 0)
					{
						prevVal = current.Value;
						current = current.Parent;
					}
				}
				Deletion(this, new DeletionArgs(vertex, current));
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

			deleted.Value = current.Value;
			Deletion(this, new DeletionArgs(vertex, deleted));

			return true;
		}

		/// Deletes element from the tree. Returns false, if not found; true, if successful.
		public bool Delete(T value)
		{
			return Delete(new BinaryTreeVertex(value));
		}

		private bool Search(IBinaryTreeVertex vertex)
		{
			return SearchForVertex(vertex) != null;
		}

		/// Returns result of searching for element in the tree.
		public bool Search(T value)
		{
			return SearchForVertex(value) != null;
		}

		/// Prints tree.
		public void Print()
		{
			Print(Root);
		}

		private void Print(IBinaryTreeVertex vertex, int level = 0)
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