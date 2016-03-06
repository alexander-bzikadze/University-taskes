using ReferenceStack;
using NUnit.Framework;

namespace ReferenceStack
{
    [TestFixture]
    public class ReferenceStackTests
    {
        private ReferenceStack stack;

        [Test]
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
    }
}