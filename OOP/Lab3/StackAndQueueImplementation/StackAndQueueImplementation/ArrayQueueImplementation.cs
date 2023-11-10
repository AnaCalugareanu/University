using StackAndQueueImplementation.AbstractInterfaces;

namespace StackAndQueueImplementation
{
    public class ArrayQueueImplementation : IQueueInterface
    {
        public bool IsEmpty => queue.Count == 0;

        public int CountItems => queue.Count;

        private List<int> queue;

        public ArrayQueueImplementation()
        {
            queue = new List<int>();
        }

        public int Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            int frontElement = queue[0];
            queue.RemoveAt(0);
            return frontElement;
        }

        public void Enqueue(int item)
        {
            queue.Add(item);
        }

        public int Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return queue[0];
        }
    }
}