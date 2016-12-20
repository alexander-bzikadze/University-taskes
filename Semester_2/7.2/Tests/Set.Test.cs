using NUnit.Framework;
using Set;

namespace SetTests
{
    [TestFixture]
    class SetTest
    {
    	private Set<int> set1;
    	private Set<int> set2;

        [SetUp]
        public void Initialization()
        {
            set1 = new Set<int>();
            set2 = new Set<int>();
        }

        [Test]
        public void SetTest_0()
        {
        	set1.Add(10);
        	set1.Add(5);
        	set1.Add(15);
        	set1.Add(2);
        	set1.Add(7);
        	set1.Add(13);
        	set1.Add(18);
        	for (int i = 0; i <= 20; ++i)
        	{
        		set1.Add(i);
        	}
        	for (int i = 0; i <= 20; ++i)
        	{
        		Assert.IsTrue(set1.Search(i));
        	}
        	set1.Delete(9);
        	set1.Delete(8);
        	set1.Delete(5);
        	set1.Delete(6);
        	set1.Delete(7);
        	set1.Delete(1);
        	set1.Delete(2);
        	set1.Delete(3);
        	set1.Delete(15);
        	set1.Delete(14);
        	set1.Delete(10);
    		Assert.IsTrue(set1.Search(13));
    		Assert.IsTrue(set1.Search(11));
    		Assert.IsTrue(set1.Search(12));
    		Assert.IsTrue(set1.Search(18));
    		Assert.IsTrue(set1.Search(16));
    		Assert.IsTrue(set1.Search(17));
    		Assert.IsTrue(set1.Search(19));
    		Assert.IsTrue(set1.Search(20));
        }

        [Test]
        public void SetTest_1()
        {
        	set1.Delete(1);
    	}

        [Test]
        public void SetTest_2()
        {
        	set1.Add(1);
        	set1.Add(2);
        	set1.Add(4);
        	set1.Add(5);
        	set2.Add(1);
        	set2.Add(3);
        	set2.Add(5);
        	var set3 = set1 + set2;
        	for (int i = 1; i <= 5; ++i)
        	{
        		Assert.IsTrue(set3.Search(i));
        	}
    	}

        [Test]
        public void SetTest_3()
        {
        	set1.Add(1);
        	set1.Add(2);
        	set1.Add(4);
        	set1.Add(5);
        	set2.Add(1);
        	set2.Add(3);
        	set2.Add(5);
        	var set3 = set1 * set2;
        	for (int i = 1; i <= 5; i += 4)
        	{
        		Assert.IsTrue(set3.Search(i));
        	}
    	}

    }
}