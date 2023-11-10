using StackAndQueueImplementation;

var arrayQueue = new ArrayQueueImplementation();
var arrayStack = new ArrayStackImplementation();
var doubleQueue = new DoubleQueueImplementation();
var doubleStack = new DoubleStackImplementation();
var linkedQueue = new LinkedQueueImplementation();
var linkedStack = new LinkedStackImplementation();

Console.WriteLine("Hi, this is Stack and Queue Implementation Application ");

while (true)
{
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
    Console.Write("What can we do for you?\n" +
                  "1 - Stack Implementation.\n" +
                  "2 - Queue Implementation.\n" +
                  "9 - Quit program.\n" +
                  "Choose a number : ");
    var user = Console.ReadLine();
    int.TryParse(user, out int number);

    switch (number)
    {
        case 1:
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.Write("Stack Implementation:\n" +
                          "1 - Array.\n" +
                          "2 - Double.\n" +
                          "3 - Linked.\n" +
                          "8 - Go Back.\n" +
                          "9 - Quit program.\n" +
                          "Choose a number : ");
            user = Console.ReadLine();
            int.TryParse(user, out int chosenNumber);
            switch (chosenNumber)
            {
                case 1:
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("1. Array Stack Implementation");

                    arrayStack.Push(1);
                    arrayStack.Push(2);
                    arrayStack.Push(3);

                    Console.WriteLine(arrayStack.CountItems + " elements added to stack - 1 2 3");
                    Console.WriteLine("Peek() returned: " + arrayStack.Peek());
                    Console.WriteLine("Pop() returned: " + arrayStack.Pop());
                    Console.WriteLine("Now stack size is: " + arrayStack.CountItems);
                    break;

                case 2:
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("2. Double Stack Implementation");

                    doubleStack.Push(1);
                    doubleStack.Push(2);
                    doubleStack.Push(3);

                    Console.WriteLine(doubleStack.CountItems + " elements added to double stack - 1 2 3");
                    Console.WriteLine("Peek() returned: " + doubleStack.Peek());
                    Console.WriteLine("Pop() returned: " + doubleStack.Pop());
                    Console.WriteLine("Now double stack size is: " + doubleStack.CountItems);

                    doubleStack.PushToBottom(4);
                    doubleStack.PushToBottom(5);

                    Console.WriteLine(doubleStack.CountItems + " elements added to the bottom of double stack - 4 5");
                    Console.WriteLine("PopFromBottom() returned: " + doubleStack.PopFromBottom());
                    Console.WriteLine("Now double stack size is: " + doubleStack.CountItems);

                    break;

                case 3:
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("3. Linked Stack Implementation");

                    linkedStack.Push(1);
                    linkedStack.Push(2);
                    linkedStack.Push(3);

                    Console.WriteLine(linkedStack.CountItems + " elements added to linked stack - 1 2 3");
                    Console.WriteLine("Peek() returned: " + linkedStack.Peek());
                    Console.WriteLine("Pop() returned: " + linkedStack.Pop());
                    Console.WriteLine("Now linked stack size is: " + linkedStack.CountItems);

                    break;

                case 8:
                    continue;
                case 9:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("The number you entered is not on the list.");
                    break;
            }
            break;

        case 2:
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.Write("Queue Implementation:\n" +
                          "1 - Array. \n" +
                          "2 - Double.\n" +
                          "3 - Linked.\n" +
                          "8 - Go Back.\n" +
                          "9 - Quit program.\n" +
                          "Choose a number : ");
            user = Console.ReadLine();
            int.TryParse(user, out int userInput);
            switch (userInput)
            {
                case 1:
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("1. Array Queue Implementation");
                    arrayQueue.Enqueue(1);
                    arrayQueue.Enqueue(2);
                    arrayQueue.Enqueue(3);
                    Console.WriteLine(arrayQueue.CountItems + " elements added to queue - 1 2 3");
                    Console.WriteLine("Peek() returned: " + arrayQueue.Peek());
                    Console.WriteLine("Dequeue() returned: " + arrayQueue.Dequeue());
                    Console.WriteLine("Now queue size is: " + arrayQueue.CountItems);
                    break;

                case 2:
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("2. Double Queue Implementation");

                    doubleQueue.Enqueue(1);
                    doubleQueue.Enqueue(2);
                    doubleQueue.Enqueue(3);

                    Console.WriteLine(doubleQueue.CountItems + " elements added to double queue - 1 2 3");
                    Console.WriteLine("Peek() returned: " + doubleQueue.Peek());
                    Console.WriteLine("Dequeue() returned: " + doubleQueue.Dequeue());
                    Console.WriteLine("Now double queue size is: " + doubleQueue.CountItems);

                    doubleQueue.EnqueueToFront(4);
                    doubleQueue.EnqueueToFront(5);

                    Console.WriteLine(doubleQueue.CountItems + " elements added to the back of double queue - 4 5");
                    Console.WriteLine("DequeueFromFront() returned: " + doubleQueue.DequeueFromRear());
                    Console.WriteLine("Now double queue size is: " + doubleQueue.CountItems);

                    break;

                case 3:
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("3. Linked Queue Implementation");

                    linkedQueue.Enqueue(1);
                    linkedQueue.Enqueue(2);
                    linkedQueue.Enqueue(3);

                    Console.WriteLine(linkedQueue.CountItems + " elements added to linked queue - 1 2 3");
                    Console.WriteLine("Peek() returned: " + linkedQueue.Peek());
                    Console.WriteLine("Dequeue() returned: " + linkedQueue.Dequeue());
                    Console.WriteLine("Now linked queue size is: " + linkedQueue.CountItems);

                    linkedQueue.Enqueue(4);
                    linkedQueue.Enqueue(5);

                    Console.WriteLine(linkedQueue.CountItems + " elements added to linked queue - 4 5");
                    Console.WriteLine("Dequeue() returned: " + linkedQueue.Dequeue());
                    Console.WriteLine("Now linked queue size is: " + linkedQueue.CountItems);

                    break;

                case 8:
                    continue;
                case 9:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("The number you entered is not on the list.");
                    break;
            }
            break;

        case 9:
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("The number you entered is not on the list.");
            break;
    }
}