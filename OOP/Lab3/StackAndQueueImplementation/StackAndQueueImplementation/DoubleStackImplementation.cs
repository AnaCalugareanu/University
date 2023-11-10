using StackAndQueueImplementation.AbstractInterfaces;

namespace StackAndQueueImplementation
{
    public class DoubleStackImplementation : IStackInterface
    {
        private List<int> stack;

        public DoubleStackImplementation()
        {
            stack = new List<int>();
        }

        public bool IsEmpty => stack.Count == 0;

        public int CountItems => stack.Count;

        public int Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The double stack is empty.");
            }

            return stack[stack.Count - 1];
        }

        public int Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The double stack is empty.");
            }

            int topElement = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return topElement;
        }

        public void Push(int item)
        {
            stack.Add(item);
        }

        public int PopFromBottom()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The double stack is empty.");
            }

            int bottomElement = stack[0];
            stack.RemoveAt(0);
            return bottomElement;
        }

        public void PushToBottom(int item)
        {
            stack.Insert(0, item);
        }
    }
}