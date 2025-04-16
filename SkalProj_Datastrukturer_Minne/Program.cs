namespace SkalProj_Datastrukturer_Minne;

class Program
{
    /// <summary>
    /// The main method, vill handle the menues for the program
    /// </summary>
    /// <param name="args"></param>
    static void Main()
    {

        while (true)
        {
            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 0) of your choice"
                + "\n1. Examine a List"
                + "\n2. Examine a Queue"
                + "\n3. Examine a Stack"
                + "\n4. CheckParenthesis"
                + "\n5. ReverseText"
                + "\n0. Exit the application");
            char input = ' '; //Creates the character input to be used with the switch-case below.
            try
            {
                input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }
            switch (input)
            {
                case '1':
                    ExamineList();
                    break;
                case '2':
                    ExamineQueue();
                    break;
                case '3':
                    ExamineStack();
                    break;
                case '4':
                    CheckParanthesis();
                    break;
                case '5':
                    ReverseText();
                    break;
                /*
                 * Extend the menu to include the recursive 
                 * and iterative exercises.
                 */
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5)");
                    break;
            }
        }
    }

    /// <summary>
    /// Examines the datastructure List
    /// </summary>
    static void ExamineList()
    {
        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch statement with cases '+' and '-'
         * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
         * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
         * In both cases, look at the count and capacity of the list
         * As a default case, tell them to use only + or -
         * Below you can see some inspirational code to begin working.
        */

        //List<string> theList = new List<string>();
        //string input = Console.ReadLine();
        //char nav = input[0];
        //string value = input.substring(1);

        //switch(nav){...}


        List<string> theList = new List<string>();
        string input;
        char nav;
        string value;

        while (true)
        {
            Console.WriteLine($"{Environment.NewLine}Examine List: Enter '+' and 'value' to add the value, '-' and 'value' to remove the value, or 'back' to return to main menu:");
            input = Console.ReadLine()!;

            if (input.Trim().ToLower() == "back")
            {
                break; // Exit the loop and return to the main menu
            }

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter a valid input (+value or -value).");
                continue;
            }
            nav = input[0];
            value = input.Substring(1);

            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Please provide a value after the '+' or '-'.");
                continue;
            }

            switch (nav)
            {
                case '+':
                    theList.Add(value);
                    Console.WriteLine($"Added '{value}' to the list.");
                    Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");
                    break;
                case '-':
                    if (theList.Remove(value))
                    {
                        Console.WriteLine($"Removed '{value}' from the list.");
                    }
                    else
                    {
                        Console.WriteLine($"'{value}' not found in the list.");
                    }
                    Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");
                    break;
                default:
                    Console.WriteLine("Invalid input. Please use '+' to add or '-' to remove.");
                    break;
            }
        }

        //Answers to the questions:
        // 2. The capacity of the List<string> increases automatically when the number of elements in the list exceeds the current capacity.

        // 3. The capacity doubles when it needs to increase.

        // 4. Increasing the capacity every time an element is added would lead to frequent and expensive memory reallocations.
        //    Doubling the capacity is a compromise: it avoids excessive reallocations while still ensuring that adding elements remains an O(1) operation on average.

        // 5. The capacity of a List<string> does NOT decrease when elements are removed. The capacity remains the same until the List<string> object is destroyed or explicitly changed.

        // 6. It is advantageous to use an array instead of a list when:
        //   - The size of the collection is known and fixed.
        //   - Performance is critical, and the overhead of dynamic resizing is unacceptable.
        //   - Memory usage needs to be strictly controlled.
    }

    /// <summary>
    /// Examines the datastructure Queue
    /// </summary>
    static void ExamineQueue()
    {
        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch with cases to enqueue items or dequeue items
         * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
        */

        Queue<string> theQueue = new();
        string input;

        // Simulate ICA queue
        theQueue.Enqueue("Kalle");
        theQueue.Enqueue("Greta");
        theQueue.Dequeue(); // Kalle leaves
        theQueue.Enqueue("Stina");
        theQueue.Dequeue(); // Greta leaves
        theQueue.Enqueue("Olle");

        Console.WriteLine("Simulated ICA Queue:");
        foreach (var person in theQueue)
        {
            Console.WriteLine(person);
        }


        while (true)
        {
            Console.WriteLine($"{Environment.NewLine}Examine Queue: Enter 'enqueue <name>' to add to queue, 'dequeue' to remove, or 'back' to return to main menu:");
            input = Console.ReadLine()!;

            if (input.Trim().ToLower() == "back")
            {
                break;
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a valid input (enqueue <name> or dequeue).");
                continue;
            }

            string[] parts = input.Split(' ');
            string command = parts[0].Trim().ToLower();

            switch (command)
            {
                case "enqueue":
                    if (parts.Length > 1)
                    {
                        string name = string.Join(" ", parts.Skip(1)); //handles names with spaces
                        theQueue.Enqueue(name);
                        Console.WriteLine($"'{name}' added to the queue.");
                        Console.WriteLine($"Current queue: {string.Join(", ", theQueue)}");
                    }
                    else
                    {
                        Console.WriteLine("Please provide a name to enqueue.");
                    }
                    break;
                case "dequeue":
                    if (theQueue.Count > 0)
                    {
                        string dequeuedName = theQueue.Dequeue();
                        Console.WriteLine($"'{dequeuedName}' removed from the queue.");
                        Console.WriteLine($"Current queue: {string.Join(", ", theQueue)}");
                    }
                    else
                    {
                        Console.WriteLine("Queue is empty.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input. Please use 'enqueue <name>' or 'dequeue'.");
                    break;
            }
        }
    }

    /// <summary>
    /// Examines the datastructure Stack
    /// </summary>
    static void ExamineStack()
    {
        /*
         * Loop this method until the user inputs something to exit to main menue.
         * Create a switch with cases to push or pop items
         * Make sure to look at the stack after pushing and and poping to see how it behaves
        */

        Stack<string> theStack = new();
        string input;

        while (true)
        {
            Console.WriteLine($"{Environment.NewLine}Examine Stack: Enter 'push <item>' to add to stack, 'pop' to remove, or 'back' to return to main menu:");
            input = Console.ReadLine()!;

            if (input.ToLower() == "back")
            {
                break;
            }

            string[] parts = input.Split(' ');
            string command = parts[0].ToLower();

            switch (command)
            {
                case "push":
                    if (parts.Length > 1)
                    {
                        string item = string.Join(" ", parts.Skip(1));
                        theStack.Push(item);
                        Console.WriteLine($"'{item}' pushed to the stack.");
                        Console.WriteLine($"Current stack: {string.Join(", ", theStack)}");
                    }
                    else
                    {
                        Console.WriteLine("Please provide an item to push.");
                    }
                    break;
                case "pop":
                    if (theStack.Count > 0)
                    {
                        string poppedItem = theStack.Pop();
                        Console.WriteLine($"'{poppedItem}' popped from the stack.");
                        Console.WriteLine($"Current stack: {string.Join(", ", theStack)}");
                    }
                    else
                    {
                        Console.WriteLine("Stack is empty.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input. Please use 'push <item>' or 'pop'.");
                    break;
            }
        }

        //Answer to the question:
        // 1. A stack works according to the principle "First in, last out" (FILO). In an ICA queue, we want to serve customers in the order they arrive ("First in, first out" - FIFO).
        // In the example above in the method ExamineQueue(), Olle would be served before Stina, and Stina before Greta, which is wrong. This makes a stack unsuitable for simulating a real queue.
    }

    static void CheckParanthesis()
    {
        /*
         * Use this method to check if the paranthesis in a string is Correct or incorrect.
         * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
         * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
         */

    }

    /// <summary>
    /// Reverses the text using a stack
    /// 
    /// this method is a part of exercise 3: ExamineStack().
    /// </summary>
    private static void ReverseText()
    {
        Stack<char> charStack = new();
        string inputString;

        while (true)
        {
            Console.WriteLine($"{Environment.NewLine}Reverse Text: Enter a text to reverse or 'back' to return to main menu:");
            inputString = Console.ReadLine()!;
            if (inputString.Trim().ToLower() == "back")
            {
                break;
            }
            if (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Please enter a valid text.");
                continue;
            }

            foreach (char c in inputString)
            {
                charStack.Push(c);
            }

            string reversedString = "";
            while (charStack.Count > 0)
            {
                reversedString += charStack.Pop();
            }

            Console.WriteLine($"The reversed string: {reversedString}");
        }
    }


}

