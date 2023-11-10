using StackAndQueueImplementation.AbstractInterfaces;

namespace StackAndQueueImplementation
{
    public class ArrayStackImplementation : IStackInterface
    {
        public bool IsEmpty => stack.Count == 0;

        public int CountItems => stack.Count;

        private List<int> stack;

        public ArrayStackImplementation()
        {
            stack = new List<int>();
        }

        public int Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            return stack[stack.Count - 1]; // Return the top element
        }

        public int Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            int topElement = stack[stack.Count - 1]; // Get the top element
            stack.RemoveAt(stack.Count - 1); // Remove the top element from the list
            return topElement;
        }

        public void Push(int item)
        {
            stack.Add(item);
        }
    }
}