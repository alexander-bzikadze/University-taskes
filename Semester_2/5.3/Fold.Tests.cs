using NUnit.Framework;
using Fold;
using System.Collections.Generic;

namespace FoldTests
{
    [TestFixture]
    class FoldTests
    {
        [Test]
        public void FoldTest_1()
        {
            Assert.AreEqual(Fold.FoldClass.Fold(new List<int>(){1, 2, 3}, 1, (acc, elem) => acc * elem), 6);
        }

        [Test]
        public void FoldTest_2()
        {
            Assert.AreEqual(Fold.FoldClass.Fold(new List<int>(){0, 2, 3}, 1, (acc, elem) => acc * elem), 0);
        }
    }
}