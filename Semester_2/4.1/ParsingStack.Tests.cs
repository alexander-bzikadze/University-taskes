using ParsingTree;
using NUnit.Framework;

namespace ParsingStackTests
{
    [TestFixture]
    public class ParsingStackTests
    {
        private ParsingStack stack;

        [SetUp]
        public void Initialization()
        {
            stack = new ParsingStack();
        }

        [Test]
        public void TripplePushAndPops()
        {
            Operation op1 = new Operation('+');
            op1.SetLeft(new Operand(1));
            op1.SetRight(new Operand(1));
            Operation op2 = new Operation('-');
            op2.SetLeft(new Operand(1));
            op2.SetRight(new Operand(1));
            stack.Push(op1);
            stack.Push(op2);
            Assert.AreEqual(0, stack.Pop().GetValue().Result());
            Assert.AreEqual(2, stack.Pop().GetValue().Result());
        }

        [Test]
        [ExpectedException(typeof(StackNullExeption))]
        public void StandardExeption()
        {
            stack.Pop();
        }
    }
}