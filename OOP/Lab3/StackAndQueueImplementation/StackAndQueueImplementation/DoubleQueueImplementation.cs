using StackAndQueueImplementation.AbstractInterfaces;

namespace StackAndQueueImplementation
{
    public class DoubleQueueImplementation : IQueueInterface
    {
        private List<int> queue;

        public DoubleQueueImplementation()
        {
            queue = new List<int>();
        }

        public bool IsEmpty => queue.Count == 0;

        public int CountItems => queue.Count;

        public int Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The double queue is empty.");
            }

            return queue[0];
        }

        public int Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The double queue is empty.");
            }

            int frontElement = queue[0];
            queue.RemoveAt(0);
            return frontElement;
        }

        public void Enqueue(int item)
        {
            queue.Add(item);
        }

        public int DequeueFromRear()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The double queue is empty.");
            }

            int rearElement = queue[queue.Count - 1];
            queue.RemoveAt(queue.Count - 1);
            return rearElement;
        }

        public void EnqueueToFront(int item)
        {
            queue.Insert(0, item);
        }
    }
}