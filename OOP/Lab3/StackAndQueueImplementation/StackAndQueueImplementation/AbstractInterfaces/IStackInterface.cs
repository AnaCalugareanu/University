namespace StackAndQueueImplementation.AbstractInterfaces
{
    public interface IStackInterface
    {
        public bool IsEmpty { get; }
        public int CountItems { get; }

        void Push(int item);

        int Pop();

        int Peek();
    }
}