using StackAndQueueImplementation.AbstractInterfaces;

namespace StackAndQueueImplementation
{
    public class LinkedQueueImplementation : IQueueInterface
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

        private Node front;
        private Node rear;

        public LinkedQueueImplementation()
        {
            front = null;
            rear = null;
        }

        public bool IsEmpty => front == null;

        public int CountItems
        {
            get
            {
                int count = 0;
                Node current = front;

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
                throw new InvalidOperationException("The linked queue is empty.");
            }

            return front.Value;
        }

        public int Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("The linked queue is empty.");
            }

            int frontValue = front.Value;
            front = front.Next;

            if (front == null)
            {
                rear = null;
            }

            return frontValue;
        }

        public void Enqueue(int item)
        {
            Node newNode = new Node(item);

            if (rear == null)
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }
        }
    }
}