namespace StackAndQueueImplementation.AbstractInterfaces
{
    public interface IQueueInterface
    {
        public bool IsEmpty { get; }
        public int CountItems { get; }

        bool Peek();

        int Dequeue();

        void Enqueue();
    }
}