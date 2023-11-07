namespace StackAndQueueImplementation.AbstractInterfaces
{
    public interface IQueueInterface
    {
        public bool IsEmpty { get; }
        public int CountItems { get; }

        int Peek();

        int Dequeue();

        void Enqueue(int item);
    }
}