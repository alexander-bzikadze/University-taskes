using System;
using BinaryTree;
using NUnit.Framework;

namespace BinaryTreeIteratorTests
{
	[TestFixture]
	public class BinaryTreeIteratorTests
	{
		private IBinaryTree<int> tree;

		[SetUp]
		public void SettingUpIntTree()
		{
			tree = new BinaryTree<int>();
			tree.Add(8);
			tree.Add(4);
			tree.Add(12);
			tree.Add(2);
			tree.Add(6);
			tree.Add(10);
			tree.Add(14);
			tree.Add(1);
			tree.Add(3);
			tree.Add(5);
			tree.Add(7);
			tree.Add(9);
			tree.Add(11);
			tree.Add(13);
			tree.Add(15);
		}

		[Test]
		public void CorrectAdditionOfRoot()
		{
			Assert.IsTrue(tree.Search(8));
		}

		[Test]
		public void CorrectAdditionOfLeftChild()
		{
			Assert.IsTrue(tree.Search(4));
		}

		[Test]
		public void CorrectAdditionOfRightChild()
		{
			Assert.IsTrue(tree.Search(12));
		}

		[Test]
		public void CorrectAdditionOfLeftLeftChild()
		{
			Assert.IsTrue(tree.Search(2));
		}

		[Test]
		public void CorrectAdditionOfLeftRightChild()
		{
			Assert.IsTrue(tree.Search(6));
		}

		[Test]
		public void CorrectAdditionOfRightLeftChild()
		{
			Assert.IsTrue(tree.Search(10));
		}

		[Test]
		public void CorrectAdditionOfRightRightChild()
		{
			Assert.IsTrue(tree.Search(14));
		}

		[Test]
		public void CorrectAdditionOfLeftLeftLeftChild()
		{
			Assert.IsTrue(tree.Search(1));
		}

		[Test]
		public void CorrectAdditionOfLeftLeftRightChild()
		{
			Assert.IsTrue(tree.Search(3));
		}

		[Test]
		public void CorrectAdditionOfLeftRightLeftChild()
		{
			Assert.IsTrue(tree.Search(5));
		}

		[Test]
		public void CorrectAdditionOfLeftRightRightChild()
		{
			Assert.IsTrue(tree.Search(7));
		}

		[Test]
		public void CorrectAdditionOfRightLeftLeftChild()
		{
			Assert.IsTrue(tree.Search(9));
		}

		[Test]
		public void CorrectAdditionOfRightLeftRightChild()
		{
			Assert.IsTrue(tree.Search(11));
		}

		[Test]
		public void CorrectAdditionOfRightRightLeftChild()
		{
			Assert.IsTrue(tree.Search(13));
		}

		[Test]
		public void CorrectAdditionOfRightRightRightChild()
		{
			Assert.IsTrue(tree.Search(15));
		}

		private bool CorrectKeepingWhenDeleting(int except)
		{
			bool flag = true;
			for (int i = 1; i < 16 && flag; ++i)
			{
				if (i != except)
				{
					flag &= tree.Search(i);
				}
			}
			return flag;
		}

		[Test]
		public void CorrectDelitionOfRoot()
		{
			Assert.IsTrue(tree.Search(8));
			tree.Delete(8);
			Assert.IsFalse(tree.Search(8));
			Assert.IsTrue(CorrectKeepingWhenDeleting(8));
		}

		[Test]
		public void CorrectDelitionOfLeftChild()
		{
			Assert.IsTrue(tree.Search(4));
			tree.Delete(4);
			Assert.IsFalse(tree.Search(4));
			Assert.IsTrue(CorrectKeepingWhenDeleting(4));
		}

		[Test]
		public void CorrectDelitionOfRightChild()
		{
			Assert.IsTrue(tree.Search(12));
			tree.Delete(12);
			Assert.IsFalse(tree.Search(12));
			Assert.IsTrue(CorrectKeepingWhenDeleting(12));
		}

		[Test]
		public void CorrectDelitionOfLeftLeftChild()
		{
			Assert.IsTrue(tree.Search(2));
			tree.Delete(2);
			Assert.IsFalse(tree.Search(2));
			Assert.IsTrue(CorrectKeepingWhenDeleting(2));
		}

		[Test]
		public void CorrectDelitionOfLeftRightChild()
		{
			Assert.IsTrue(tree.Search(6));
			tree.Delete(6);
			Assert.IsFalse(tree.Search(6));
			Assert.IsTrue(CorrectKeepingWhenDeleting(6));
		}

		[Test]
		public void CorrectDelitionOfRightLeftChild()
		{
			Assert.IsTrue(tree.Search(10));
			tree.Delete(10);
			Assert.IsFalse(tree.Search(10));
			Assert.IsTrue(CorrectKeepingWhenDeleting(10));
		}

		[Test]
		public void CorrectDelitionOfRightRightChild()
		{
			Assert.IsTrue(tree.Search(14));
			tree.Delete(14);
			Assert.IsFalse(tree.Search(14));
			Assert.IsTrue(CorrectKeepingWhenDeleting(14));
		}

		[Test]
		public void CorrectDelitionOfLeftLeftLeftChild()
		{
			Assert.IsTrue(tree.Search(1));
			tree.Delete(1);
			Assert.IsFalse(tree.Search(1));
			Assert.IsTrue(CorrectKeepingWhenDeleting(1));
		}

		[Test]
		public void CorrectDelitionOfLeftLeftRightChild()
		{
			Assert.IsTrue(tree.Search(3));
			tree.Delete(3);
			Assert.IsFalse(tree.Search(3));
			Assert.IsTrue(CorrectKeepingWhenDeleting(3));
		}

		[Test]
		public void CorrectDelitionOfLeftRightLeftChild()
		{
			Assert.IsTrue(tree.Search(5));
			tree.Delete(5);
			Assert.IsFalse(tree.Search(5));
			Assert.IsTrue(CorrectKeepingWhenDeleting(5));
		}

		[Test]
		public void CorrectDelitionOfLeftRightRightChild()
		{
			Assert.IsTrue(tree.Search(7));
			tree.Delete(7);
			Assert.IsFalse(tree.Search(7));
			Assert.IsTrue(CorrectKeepingWhenDeleting(7));
		}

		[Test]
		public void CorrectDelitionOfRightLeftLeftChild()
		{
			Assert.IsTrue(tree.Search(9));
			tree.Delete(9);
			Assert.IsFalse(tree.Search(9));
			Assert.IsTrue(CorrectKeepingWhenDeleting(9));
		}

		[Test]
		public void CorrectDelitionOfRightLeftRightChild()
		{
			Assert.IsTrue(tree.Search(11));
			tree.Delete(11);
			Assert.IsFalse(tree.Search(11));
			Assert.IsTrue(CorrectKeepingWhenDeleting(11));
		}

		[Test]
		public void CorrectDelitionOfRightRightLeftChild()
		{
			Assert.IsTrue(tree.Search(13));
			tree.Delete(13);
			Assert.IsFalse(tree.Search(13));
			Assert.IsTrue(CorrectKeepingWhenDeleting(13));
		}

		[Test]
		public void CorrectDelitionOfRightRightRightChild()
		{
			Assert.IsTrue(tree.Search(15));
			tree.Delete(15);
			Assert.IsFalse(tree.Search(15));
			Assert.IsTrue(CorrectKeepingWhenDeleting(15));
		}

		[Test]
		public void TreeEnumeratorGetsAllValuesCorrectly()
		{
			var iterator = tree.GetBinaryTreeEnumerator();
			for (int i = 1; i < 16; ++i)
			{
				Assert.IsTrue(iterator.MoveNext());
				Assert.AreEqual(i, iterator.Current);
			}
			Assert.IsFalse(iterator.MoveNext());
		}

		private void CorrectDeletionChildTreeEnumerator(int elem)
		{
			var iterator = tree.GetBinaryTreeEnumerator();
			for (int i = 1; i < elem; ++i)
			{
				Assert.IsTrue(iterator.MoveNext());
				Assert.AreEqual(i, iterator.Current);
			}
			Assert.IsTrue(iterator.MoveNext());
			Assert.AreEqual(elem, iterator.Current);
			iterator.Remove();
			Assert.IsFalse(tree.Search(elem));
			CorrectKeepingWhenDeleting(elem);
			Assert.AreEqual(elem + 1, iterator.Current);
			for (int i = elem + 2; i < 16; ++i)
			{
				Assert.IsTrue(iterator.MoveNext());
				Assert.AreEqual(i, iterator.Current);
			}
			Assert.IsFalse(iterator.MoveNext());
		}

		[Test]
		public void CorrectDelitionOfRootTreeEnumerator()
		{
			CorrectDeletionChildTreeEnumerator(8);
		}

		[Test]
		public void CorrectDelitionOfLeftChildTreeEnumerator()
		{
			CorrectDeletionChildTreeEnumerator(4);
		}

		[Test]
		public void CorrectDelitionOfRightChildTreeEnumerator()
		{
			CorrectDeletionChildTreeEnumerator(12);
		}

		[Test]
		public void CorrectDelitionOfLeftLeftChildTreeEnumerator()
		{
			CorrectDeletionChildTreeEnumerator(2);
		}

		[Test]
		public void CorrectDelitionOfLeftRightChildTreeEnumerator()
		{
			CorrectDeletionChildTreeEnumerator(6);
		}

		[Test]
		public void CorrectDelitionOfLeftLeftLeftChildTreeEnumerator()
		{
			CorrectDeletionChildTreeEnumerator(1);
		}

		[Test]
		public void CorrectDelitionOfLeftLeftRightChildTreeEnumerator()
		{
			CorrectDeletionChildTreeEnumerator(3);
		}

		[Test]
		public void CorrectDelitionOfLeftRightLeftChildTreeEnumerator()
		{
			CorrectDeletionChildTreeEnumerator(5);
		}

		[Test]
		public void CorrectDelitionOfLeftRightRightChildTreeEnumerator()
		{
			CorrectDeletionChildTreeEnumerator(7);
		}

		[Test]
		public void CorrectDelitionOfRightLeftChildTreeEnumerator()
		{
			CorrectDeletionChildTreeEnumerator(10);
		}

		[Test]
		public void CorrectDelitionOfRightRightChildTreeEnumerator()
		{
			CorrectDeletionChildTreeEnumerator(14);
		}

		[Test]
		public void CorrectDelitionOfRightLeftLeftChildTreeEnumerator()
		{
			CorrectDeletionChildTreeEnumerator(9);
		}

		[Test]
		public void CorrectDelitionOfRightLeftRightChildTreeEnumerator()
		{
			CorrectDeletionChildTreeEnumerator(11);
		}

		[Test]
		public void CorrectDelitionOfRightRightLeftChildTreeEnumerator()
		{
			CorrectDeletionChildTreeEnumerator(13);
		}

		[Test]
		public void CorrectDelitionOfChildRightRightRightTreeEnumerator()
		{
			var iterator = tree.GetBinaryTreeEnumerator();
			for (int i = 1; i < 15; ++i)
			{
				Assert.IsTrue(iterator.MoveNext());
				Assert.AreEqual(i, iterator.Current);
			}
			Assert.IsTrue(iterator.MoveNext());
			Assert.AreEqual(15, iterator.Current);
			iterator.Remove();
			Assert.IsFalse(tree.Search(15));
			CorrectKeepingWhenDeleting(15);
			Assert.AreEqual(iterator.Current, 0);
		}

		private void CorrectDeletionChildTreeEnumeratorDouble(int elem)
		{
			var iterator = tree.GetBinaryTreeEnumerator();
			var iterator2 = tree.GetBinaryTreeEnumerator();
			for (int i = 1; i < elem; ++i)
			{
				Assert.IsTrue(iterator.MoveNext());
				Assert.AreEqual(i, iterator.Current);
				Assert.IsTrue(iterator2.MoveNext());
				Assert.AreEqual(i, iterator2.Current);
			}
			Assert.IsTrue(iterator.MoveNext());
			Assert.IsTrue(iterator2.MoveNext());
			Assert.AreEqual(elem, iterator.Current);
			Assert.AreEqual(elem, iterator2.Current);
			iterator.Remove();
			Assert.IsFalse(tree.Search(elem));
			CorrectKeepingWhenDeleting(elem);
			Assert.AreEqual(elem + 1, iterator.Current);
			for (int i = elem + 2; i < 16; ++i)
			{
				Assert.IsTrue(iterator.MoveNext());
				Assert.AreEqual(i, iterator.Current);
				Assert.IsTrue(iterator2.MoveNext());
				Assert.AreEqual(i, iterator2.Current);
			}
			Assert.IsFalse(iterator.MoveNext());
			Assert.IsFalse(iterator2.MoveNext());
		}

		[Test]
		public void CorrectDelitionOfRootTreeEnumeratorDouble()
		{
			CorrectDeletionChildTreeEnumeratorDouble(8);
		}

		[Test]
		public void CorrectDelitionOfLeftChildTreeEnumeratorDouble()
		{
			CorrectDeletionChildTreeEnumeratorDouble(4);
		}

		[Test]
		public void CorrectDelitionOfRightChildTreeEnumeratorDouble()
		{
			CorrectDeletionChildTreeEnumeratorDouble(12);
		}

		[Test]
		public void CorrectDelitionOfLeftLeftChildTreeEnumeratorDouble()
		{
			CorrectDeletionChildTreeEnumeratorDouble(2);
		}

		[Test]
		public void CorrectDelitionOfLeftRightChildTreeEnumeratorDouble()
		{
			CorrectDeletionChildTreeEnumeratorDouble(6);
		}

		[Test]
		public void CorrectDelitionOfLeftLeftLeftChildTreeEnumeratorDouble()
		{
			CorrectDeletionChildTreeEnumeratorDouble(1);
		}

		[Test]
		public void CorrectDelitionOfLeftLeftRightChildTreeEnumeratorDouble()
		{
			CorrectDeletionChildTreeEnumeratorDouble(3);
		}

		[Test]
		public void CorrectDelitionOfLeftRightLeftChildTreeEnumeratorDouble()
		{
			CorrectDeletionChildTreeEnumeratorDouble(5);
		}

		[Test]
		public void CorrectDelitionOfLeftRightRightChildTreeEnumeratorDouble()
		{
			CorrectDeletionChildTreeEnumeratorDouble(7);
		}

		[Test]
		public void CorrectDelitionOfRightLeftChildTreeEnumeratorDouble()
		{
			CorrectDeletionChildTreeEnumeratorDouble(10);
		}

		[Test]
		public void CorrectDelitionOfRightRightChildTreeEnumeratorDouble()
		{
			CorrectDeletionChildTreeEnumeratorDouble(14);
		}

		[Test]
		public void CorrectDelitionOfRightLeftLeftChildTreeEnumeratorDouble()
		{
			CorrectDeletionChildTreeEnumeratorDouble(9);
		}

		[Test]
		public void CorrectDelitionOfRightLeftRightChildTreeEnumeratorDouble()
		{
			CorrectDeletionChildTreeEnumeratorDouble(11);
		}

		[Test]
		public void CorrectDelitionOfRightRightLeftChildTreeEnumeratorDouble()
		{
			CorrectDeletionChildTreeEnumeratorDouble(13);
		}

		[Test]
		public void CorrectDelitionOfChildRightRightRightTreeEnumeratorDouble()
		{
			var iterator = tree.GetBinaryTreeEnumerator();
			var iterator2 = tree.GetBinaryTreeEnumerator();
			for (int i = 1; i < 15; ++i)
			{
				Assert.IsTrue(iterator.MoveNext());
				Assert.AreEqual(i, iterator.Current);
				Assert.IsTrue(iterator2.MoveNext());
				Assert.AreEqual(i, iterator2.Current);
			}
			Assert.IsTrue(iterator.MoveNext());
			Assert.IsTrue(iterator2.MoveNext());
			Assert.AreEqual(15, iterator.Current);
			Assert.AreEqual(iterator2.Current, 15);
			iterator.Remove();
			Assert.IsFalse(tree.Search(15));
			CorrectKeepingWhenDeleting(15);
			Assert.AreEqual(iterator.Current, 0);
			Assert.AreEqual(iterator2.Current, 0);
		}

		[Test]
		public void ForeachTest()
		{
			int i = 1;
			foreach (var elem in tree)
			{
				Assert.AreEqual(elem, i++);
			}
		}
	}
}