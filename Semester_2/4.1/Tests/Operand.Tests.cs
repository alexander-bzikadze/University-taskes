using NUnit.Framework;
using ParsingTree;

namespace OperandTests
{
    [TestFixture]
    class OperandTestStandart
    {
        private Operand op;

        [Test]
        public void StandartConstuctorTest()
        {
            op = new Operand();
            Assert.AreEqual(0, op.Result());
        }

        [Test]
        public void ConstructorByValueTest()
        {
            op = new Operand(10);
            Assert.AreEqual(10, op.Result());
        }
    }
}