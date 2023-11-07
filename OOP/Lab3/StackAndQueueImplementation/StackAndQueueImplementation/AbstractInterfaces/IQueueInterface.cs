namespace StackAndQueueImplementation.AbstractInterfaces
{
    public interface IQueueInterface
    {
        public bool IsEmpty { get; }
        public int CountItems { get; }

        bool Push();

        int Pop();

        void Peek();
    }
}