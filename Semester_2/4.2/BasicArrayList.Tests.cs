using UniqueList;
using NUnit.Framework;

namespace ArrayListTests
{
    [TestFixture]
    public class BasicArrayListTests
    {
        private BasicArrayList list;

        [SetUp]
        public void Initialization()
        {
            list = new BasicArrayList();
        }

        [Test]
        public void BasicArrayListTest_1()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.SetIteratorFirst();
            Assert.AreEqual(1, list.GetIteratorValue());
            list.MoveIteratorForward();
            list.MoveIteratorForward();
            Assert.AreEqual(3, list.GetIteratorValue());
        }

        [Test]
        [ExpectedException(typeof(ListOverloadException))]
        public void OverloadTest()
        {
            for (int i = 0; i < 101; ++i)
            {
                list.Add(1);
            }
        }

        [Test]
        [ExpectedException(typeof(ListNullException))]
        public void FailedMoveForwardTest()
        {
            list.SetIteratorFirst();
            list.MoveIteratorForward();
        }

        [Test]
        [ExpectedException(typeof(ListNullException))]
        public void FailedGettingOfValue()
        {
            list.SetIteratorFirst();
            list.GetIteratorValue();
        }

    }
}