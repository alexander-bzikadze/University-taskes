using HashTable;
using NUnit.Framework;

namespace HashTableTests
{
    [TestFixture]
    public class HashTableTests
    {
        private HashTable.HashTable hashTable;

        [Test]
        public void Initialization_1()
        {
            hashTable = new HashTable.HashTable(new Hash1());
        }

        [Test]
        public void Initialization_2()
        {
            hashTable = new HashTable.HashTable(new Hash2());
        }

        [Test]
        public void AddAndSearch_1()
        {
            hashTable = new HashTable.HashTable(new Hash1());
            hashTable.Add(1);
            hashTable.Add(2);
            Assert.AreEqual(true, hashTable.Search(1));
            Assert.AreEqual(true, hashTable.Search(2));
            Assert.AreEqual(false, hashTable.Search(3));
        }

        [Test]
        public void AddAndSearch_2()
        {
            hashTable = new HashTable.HashTable(new Hash1());
            hashTable.Add(1);
            hashTable.Add(2);
            Assert.AreEqual(true, hashTable.Search(1));
            Assert.AreEqual(true, hashTable.Search(2));
            Assert.AreEqual(false, hashTable.Search(3));
        }

        [Test]
        public void DeleteElement_1()
        {
            hashTable = new HashTable.HashTable(new Hash2());
            hashTable.DeleteElement(1);
            hashTable.Add(1);
            hashTable.DeleteElement(1);
            Assert.AreEqual(false, hashTable.Search(1));
        }

        [Test]
        public void DeleteElement_2()
        {
            hashTable = new HashTable.HashTable(new Hash2());
            hashTable.DeleteElement(1);
            hashTable.Add(1);
            hashTable.DeleteElement(1);
            Assert.AreEqual(false, hashTable.Search(1));
        }

        [Test]
        [ExpectedException(typeof(ListNullExeption))]
        public void StandardExeption()
        {
            BasicArrayList stack = new BasicArrayList();
            stack.GetIteratorValue();
        }
    }
}