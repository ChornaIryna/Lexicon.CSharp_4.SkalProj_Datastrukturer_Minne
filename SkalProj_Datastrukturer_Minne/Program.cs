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
            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                + "\n1. Examine a List"
                + "\n2. Examine a Queue"
                + "\n3. Examine a Stack"
                + "\n4. CheckParenthesis"
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
                /*
                 * Extend the menu to include the recursive 
                 * and iterative exercises.
                 */
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
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

            if (input.ToLower() == "back")
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
    }

    static void CheckParanthesis()
    {
        /*
         * Use this method to check if the paranthesis in a string is Correct or incorrect.
         * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
         * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
         */

    }

}

