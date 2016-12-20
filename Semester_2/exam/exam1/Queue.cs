using System;

namespace Queue
{
    /// Queue that contains int values.
    /// Elements are added with input priority and are contained according to it.
    /// Element with the greatest priority can be dequeued.
    public class Queue
    {
        private static int N = 100;

        private QueueElement[] list = new QueueElement[N];

        public int size = 0;

        public Queue()
        {
            list = new QueueElement[N];
            this.size = 0;
        }

        /// Adds QueueElement according to its priority.
        public void enqueue(QueueElement added)
        {
            OverloadCheck();
            int i = 0;
            for (i = 0; i < size && list[i].Priority < added.Priority; ++i);
            for (int j = size - 1; j >= i; j--)
            {
                list[j + 1] = list[j];
            }
            list[i] = added;
            size++;
        }

        /// Overloaded version of enqueue(QueueElement).
        public void enqueue(int Value, int Priority)
        {
            enqueue(new QueueElement(Value, Priority));
        }

        /// Deletes last element (also with greatest priority) and returnes its value.
        /// If Queue is empty, throws exception.
        public int dequeue()
        {
            if (size == 0)
            {
                throw new QueueNullException("The Queue is empty!");
            }
            size--;
            return list[size].Value;
        }

        /// Prints the Queue.
        public void Print()
        {
            for (int i = 0; i < size; ++i)
            {
                Console.WriteLine("{0} - {1} - {2}", i, list[i].Value, list[i].Priority);
            }
        }

        private void OverloadCheck()
        {
            if (size == N)
            {
                throw new QueueOverloadedException("Queue is overloaded!");
            }
        }
    }
}