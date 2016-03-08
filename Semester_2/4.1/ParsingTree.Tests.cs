using NUnit.Framework;
using ParsingTree;

namespace ParsingTreeTests
{
    [TestFixture]
    class ParsingTreeTests
    {
        [Test]
        public void Example_1()
        {
            Assert.AreEqual(4, ParsingTree.ParsingTree.ParsingTreeCounter("(* (+ 1 1) 2)"));
        }

        [Test]
        public void Example_2()
        {
            Assert.AreEqual(1, ParsingTree.ParsingTree.ParsingTreeCounter("(- (+ (- (- (+ (+ 1 1) 1) 1) 1) 1) 1)"));
        }

        [Test]
        public void Example_3()
        {
            Assert.AreEqual(27, ParsingTree.ParsingTree.ParsingTreeCounter("(+ (* (/ (+ (/ (- 50 4) 2) 2) 5) 3) (* 4 3))"));
        }

        [Test]
        public void Example_4()
        {
            Assert.AreEqual(27, ParsingTree.ParsingTree.ParsingTreeCounter("27"));
        }

        [Test]
        [ExpectedException(typeof(WrongInputException))]
        public void CheckWentWrongThrowingExceptionTest_1()
        {
            ParsingTree.ParsingTree.ParsingTreeCounter("(27");
        }

        [Test]
        [ExpectedException(typeof(WrongInputException))]
        public void CheckWentWrongThrowingExceptionTest_2()
        {
            ParsingTree.ParsingTree.ParsingTreeCounter("(* (1");
        }
    }
}