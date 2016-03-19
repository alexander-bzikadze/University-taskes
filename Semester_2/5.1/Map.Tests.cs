using NUnit.Framework;
using Map;
using System.Collections.Generic;

namespace MapTests
{
    [TestFixture]
    class MapTests
    {
        [Test]
        public void MapTest_1()
        {
            Assert.AreEqual(Map.MapClass.Map(new List<int>() {1, 2, 3}, x => x * 2), new List<int>() {2, 4, 6});
        }

        [Test]
        public void MapTest_2()
        {
            Assert.AreEqual(Map.MapClass.Map(new List<int>() {1, 2, 3}, x => x * 0), new List<int>() {0, 0, 0});
        }

        [Test]
        public void MapTest_3()
        {
            Assert.AreEqual(Map.MapClass.Map(new List<int>() {1, 2, 3}, x => x * x), new List<int>() {1, 4, 9});
        }
    }
}