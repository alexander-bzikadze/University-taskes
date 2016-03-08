using NUnit.Framework;
using ParsingTree;

namespace OperationTests
{
    [TestFixture]
    class OperationTestStandart
    {
        private Operation op;

        [Test]
        public void StandartAddTest()
        {
            op = new Operation('+');
            op.SetRight(new Operand(5));
            op.SetLeft(new Operand(5));
            Assert.AreEqual(10, op.Result());
        }

        [Test]
        public void StandartSubtractTest_1()
        {
            op = new Operation('-');
            op.SetRight(new Operand(5));
            op.SetLeft(new Operand(6));
            Assert.AreEqual(1, op.Result());
        }

        [Test]
        public void StandartSubtractTest_2()
        {
            op = new Operation('-');
            op.SetRight(new Operand(6));
            op.SetLeft(new Operand(5));
            Assert.AreEqual(-1, op.Result());
        }

        [Test]
        public void StandartMultiplyTest_1()
        {
            op = new Operation('*');
            op.SetRight(new Operand(5));
            op.SetLeft(new Operand(5));
            Assert.AreEqual(25, op.Result());
        }

        [Test]
        public void StandartMultiplyTest_2()
        {
            op = new Operation('*');
            op.SetRight(new Operand(0));
            op.SetLeft(new Operand(5));
            Assert.AreEqual(0, op.Result());
        }

        [Test]
        public void StandartDivideTest_1()
        {
            op = new Operation('/');
            op.SetRight(new Operand(5));
            op.SetLeft(new Operand(5));
            Assert.AreEqual(1, op.Result());
        }

        [Test]
        [ExpectedException(typeof(DivideByZeroException))]
        public void StandartDivideTest_2()
        {
            op = new Operation('/');
            op.SetRight(new Operand(0));
            op.SetLeft(new Operand(5));
            Assert.AreEqual(0, op.Result());
        }

        [Test]
        public void StandartDivideTest_3()
        {
            op = new Operation('/');
            op.SetRight(new Operand(5));
            op.SetLeft(new Operand(0));
            Assert.AreEqual(0, op.Result());
        }

        [Test]
        [ExpectedException(typeof(OperationNullException))]
        public void StandartNullTest_1()
        {
            op = new Operation('+');
            // op.SetRight(new Operand(5));
            op.SetLeft(new Operand(5));
            Assert.AreEqual(10, op.Result());
        }

        [Test]
        [ExpectedException(typeof(OperationNullException))]
        public void StandartNullTest_2()
        {
            op = new Operation('+');
            // op.SetRight(new Operand(5));
            op.SetLeft(new Operand(5));
            op.Print();
        }

        [Test]
        [ExpectedException(typeof(WrongCharInputException))]
        public void WrongCharInputExceptionTest()
        {
            op = new Operation('1');
        }
    }
}