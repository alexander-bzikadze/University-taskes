using NUnit.Framework;
using Filter;
using System.Collections.Generic;

namespace FilterTests
{
    [TestFixture]
    class FilterTests
    {
        [Test]
        public void FilterTest_1()
        {
            Assert.AreEqual(Filter.FilterClass.Filter(new List<int>() {1, 2, 3}, x => {return x % 2 == 0;}), new List<int>() {2});
        }

        [Test]
        public void FilterTest_2()
        {
            Assert.AreEqual(Filter.FilterClass.Filter(new List<int>() {1, 2, 3}, x => {return x > 1;}), new List<int>() {2, 3});
        }
    }
}