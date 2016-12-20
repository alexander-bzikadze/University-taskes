using NUnit.Framework;
using Queue;

namespace QueueTests
{
    [TestFixture]
    class QueueTests
    {
        [Test]
        public void StandartTest_1()
        {
            Queue.Queue queue = new Queue.Queue();
            for (int i = 0; i < 100; ++i)
            {
                queue.enqueue(i, i);
            }
            for (int i = 100 - 1; i > 0; --i)
            {
                var a = queue.dequeue();
                Assert.AreEqual(i, a);
            }
        }

        [Test]
        public void StandartTest_2()
        {
            Queue.Queue queue = new Queue.Queue();
            for (int i = 0; i < 100; ++i)
            {
                queue.enqueue(99 - i, 99 - i);
            }
            for (int i = 100 - 1; i > 0; --i)
            {
                var a = queue.dequeue();
                Assert.AreEqual(i, a);
            }
        }
        
        [Test]
        public void StandartTest_3()
        {
            Queue.Queue queue = new Queue.Queue();
            queue.enqueue(6, 6);
            queue.enqueue(3, 3);
            queue.enqueue(2, 2);
            queue.enqueue(4, 4);
            queue.enqueue(5, 5);
            queue.enqueue(1, 1);
            for (int i = 6; i > 0; --i)
            {
                var a = queue.dequeue();
                Assert.AreEqual(i, a);
            }
        }
        
        [Test]
        public void StandartTest_4()
        {
            Queue.Queue queue = new Queue.Queue();
            queue.enqueue(1, 6);
            queue.enqueue(2, 3);
            queue.enqueue(3, 2);
            queue.enqueue(4, 5);
            queue.enqueue(5, 4);
            queue.enqueue(6, 1);
            Assert.AreEqual(1, queue.dequeue());
            Assert.AreEqual(4, queue.dequeue());
            Assert.AreEqual(5, queue.dequeue());
            Assert.AreEqual(2, queue.dequeue());
            Assert.AreEqual(3, queue.dequeue());
            Assert.AreEqual(6, queue.dequeue());
        }

        [Test]
        [ExpectedException(typeof(QueueNullException))]
        public void StandardExeption_1()
        {
            Queue.Queue queue = new Queue.Queue();
            queue.dequeue();
        }

        [Test]
        [ExpectedException(typeof(QueueOverloadedException))]
        public void StandardExeption_2()
        {
            Queue.Queue queue = new Queue.Queue();
            for (int i = 0; i < 101; ++i)
            {
                queue.enqueue(0, 0);
            }
        }
    }
}