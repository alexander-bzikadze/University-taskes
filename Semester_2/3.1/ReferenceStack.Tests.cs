using ReferenceStack;
using NUnit.Framework;

namespace ReferenceStack
{
    [TestFixture]
    public class ReferenceStackTests
    {
        private ReferenceStack stack;

        [SetUp]
        public void Initialization()
        {
            stack = new ReferenceStack();
        }

        [Test]
        public void TripplePushAndTop()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(3, stack.Top());
        }

        [Test]
        public void StandardPop()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Pop());
        }

        [Test]
        [ExpectedException(typeof(StackNullExeption))]
        public void StandardExeption()
        {
            stack.Pop();
        }

        [Test]
        public void HardTest()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();
            Assert.AreEqual(2, stack.Top());
            stack.Push(3);
            stack.Push(4);
            Assert.AreEqual(4, stack.Top());
            Assert.AreEqual(4, stack.Pop());
            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Top());
            Assert.AreEqual(1, stack.Pop());
        }

    }
}