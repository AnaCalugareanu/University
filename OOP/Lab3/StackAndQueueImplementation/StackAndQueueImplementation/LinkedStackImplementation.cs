using StackAndQueueImplementation.AbstractInterfaces;

namespace StackAndQueueImplementation
{
    public class LinkedStackImplementation : IStackInterface
    {
        private class Node
        {
            public int Value { get; }
            public Node Next { get; set; }

            public Node(int value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node top;

        public LinkedStackImplementation()
        {
            top = null;
        }

        public bool IsEmpty => top == null;

        public int CountItems
        {
            get
            {
                int count = 0;
                Node current = top;

                while (current != null)
                {
                    count++;
                    current = current.Next;
                }

                return count;
            }
        }

        public int Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The linked stack is empty.");
            }

            return top.Value;
        }

        public int Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The linked stack is empty.");
            }

            int topValue = top.Value;
            top = top.Next;

            return topValue;
        }

        public void Push(int item)
        {
            Node newNode = new Node(item);
            newNode.Next = top;
            top = newNode;
        }
    }
}