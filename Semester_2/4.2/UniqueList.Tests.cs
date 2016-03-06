using UniqueList;
using NUnit.Framework;

namespace UniqueListTests
{
    [TestFixture]
    public class UniqueListTests
    {
        private UniqueList.UniqueList list;

        [SetUp]
        public void Initialization()
        {
            list = new UniqueList.UniqueList();
        }

        [Test]
        public void AddAndDeleteTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.DeleteElement(1);
            list.DeleteElement(3);
            Assert.AreEqual(2, list.Pop());
        }

        [Test]
        public void SearchTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(false, list.Search(4));
            Assert.AreEqual(true, list.Search(3));
        }

        [Test]
        [ExpectedException(typeof(ListNullException))]
        public void OverloadTest()
        {
            for (int i = 0; i < 101; ++i)
            {
                list.Add(1);
            }
        }

        [Test]
        [ExpectedException(typeof(ListNullException))]
        public void DoubleAddTest()
        {
            list.Add(1);
            list.Add(1);
        }

        [Test]
        [ExpectedException(typeof(ListNullException))]
        public void DeleteStangeTest()
        {
            list.DeleteElement(1);
        }
    }
}