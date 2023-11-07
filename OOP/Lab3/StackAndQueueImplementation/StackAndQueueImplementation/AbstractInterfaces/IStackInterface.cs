namespace StackAndQueueImplementation.AbstractInterfaces
{
    public interface IStackInterface
    {
        public bool IsEmpty { get; }
        public int CountItems { get; }

        bool Push();

        int Pop();

        void Peek();
    }
}