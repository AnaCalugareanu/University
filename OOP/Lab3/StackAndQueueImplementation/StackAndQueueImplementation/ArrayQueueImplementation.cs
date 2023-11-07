using StackAndQueueImplementation.AbstractInterfaces;

namespace StackAndQueueImplementation
{
    public class QueueImplementation : IQueueInterface
    {
        public bool IsEmpty => throw new NotImplementedException();

        public int CountItems => throw new NotImplementedException();

        public int Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(int item)
        {
            throw new NotImplementedException();
        }

        int IQueueInterface.Peek()
        {
            throw new NotImplementedException();
        }
    }
}