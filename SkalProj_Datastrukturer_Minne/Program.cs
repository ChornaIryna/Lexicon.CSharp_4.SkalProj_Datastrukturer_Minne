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
            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 6, 7, 0) of your choice"
                + "\n1. Examine a List"
                + "\n2. Examine a Queue"
                + "\n3. Examine a Stack"
                + "\n4. CheckParenthesis"
                + "\n5. ReverseText"
                + "\n6. RecursiveEven"
                + "\n7. IterativeEven"
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
                case '6':
                    RecursiveEven();
                    break;
                case '7':
                    IterativeEven();
                    break;
                /*
                 * Extend the menu to include the recursive 
                 * and iterative exercises.
                 */
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5, 6, 7)");
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


        List<string> theList = new();
        char nav;
        string value;

        while (true)
        {
            Console.Write($"{Environment.NewLine}Examine List: Enter '+' and 'value' to add the value, '-' and 'value' to remove the value, or 'back' to return to main menu:");
            string input = Console.ReadLine()?.Trim() ?? string.Empty;

            if (input.Equals("back", StringComparison.OrdinalIgnoreCase))
                break; // Exit the loop and return to the main menu

            if (string.IsNullOrEmpty(input) || input.Length < 2)
            {
                Console.WriteLine("Please enter a valid input ('+value' or '-value').");
                continue;
            }
            nav = input[0];
            value = input[1..].Trim();

            switch (nav)
            {
                case '+':
                    theList.Add(value);
                    Console.WriteLine($"Added '{value}' to the list.");
                    Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");
                    break;
                case '-':
                    if (theList.Remove(value))
                        Console.WriteLine($"Removed '{value}' from the list.");
                    else
                        Console.WriteLine($"'{value}' not found in the list.");
                    Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");
                    break;
                default:
                    Console.WriteLine("Invalid input. Please use '+' to add or '-' to remove.");
                    break;
            }
        }
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

            if (input.Equals("back", StringComparison.OrdinalIgnoreCase))
                break;

            string[] parts = input.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
            {
                Console.WriteLine("Invalid input. Please use 'enqueue <value>' or 'dequeue'.");
                continue;
            }

            string command = parts[0].ToLower();

            switch (command)
            {
                case "enqueue":
                    if (parts.Length > 1)
                    {
                        theQueue.Enqueue(parts[1]);
                        Console.WriteLine($"Enqueued '{parts[1]}'. Current queue: {string.Join(", ", theQueue)}");
                    }
                    else
                        Console.WriteLine("Please provide a name to enqueue.");
                    break;
                case "dequeue":
                    if (theQueue.TryDequeue(out string dequeued))
                        Console.WriteLine($"Dequeued '{dequeued}'. Current queue: {string.Join(", ", theQueue)}");
                    else
                        Console.WriteLine("Queue is empty.");
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

            if (input.Equals("back", StringComparison.OrdinalIgnoreCase))
                break;

            string[] parts = input.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0)
            {
                Console.WriteLine("Invalid input. Please use 'push <value>' or 'pop'.");
                continue;
            }

            string command = parts[0].ToLower();

            switch (command)
            {
                case "push":
                    if (parts.Length > 1)
                    {
                        theStack.Push(parts[1]);
                        Console.WriteLine($"'Pushed {parts[1]}'. Current stack: {string.Join(", ", theStack)}.");
                    }
                    else
                        Console.WriteLine("Please provide a value to push.");
                    break;
                case "pop":
                    if (theStack.TryPop(out string popped))
                        Console.WriteLine($"Popped '{popped}'. Current stack: {string.Join(", ", theStack)}.");
                    else
                        Console.WriteLine("Stack is empty.");
                    break;
                default:
                    Console.WriteLine("Invalid input. Please use 'push <item>' or 'pop'.");
                    break;
            }
        }
    }

    /// <summary>
    /// Checks if the parentheses in a given string are balanced.
    /// </summary>
    static void CheckParanthesis()
    {
        /*
         * Use this method to check if the paranthesis in a string is Correct or incorrect.
         * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
         * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
         */
        Console.Write("Enter a string to check for balanced parentheses: ");
        string input = Console.ReadLine()!;

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine($"The string should not be empty.{Environment.NewLine}");
            return;
        }

        if (IsBalancedParentheses(input))
            Console.WriteLine($"The string has balanced parentheses.{Environment.NewLine}");
        else
            Console.WriteLine($"The string does not have balanced parentheses.{Environment.NewLine}");
    }

    /// <summary>
    /// Determines if a string has balanced parentheses.
    /// </summary>
    /// <param name="input">The input string to check.</param>
    /// <returns>True if the parentheses are balanced; otherwise, false.</returns>
    static bool IsBalancedParentheses(string input)
    {
        Stack<char> stack = new();
        Dictionary<char, char> matchingPairs = new()
        {
            { ')', '(' },
            { '}', '{' },
            { ']', '[' }
        };

        foreach (char c in input)
        {
            if (matchingPairs.ContainsValue(c)) // Opening brackets
                stack.Push(c);
            else if (matchingPairs.ContainsKey(c)) // Closing brackets
            {
                if (stack.Count == 0 || stack.Pop() != matchingPairs[c])
                    return false;
            }
        }
        return stack.Count == 0;// Ensure no unmatched opening brackets remain
    }

    /// <summary>
    /// Reverses a given string using a stack. 
    /// this method is a part of exercise 3: ExamineStack().
    /// </summary>
    private static void ReverseText()
    {
        Console.Write("Enter a text to reverse: ");
        string inputString = Console.ReadLine()?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(inputString))
        {
            Console.WriteLine($"Input cannot be empty.{Environment.NewLine}");
            return;
        }

        Stack<char> charStack = new(inputString);
        Console.WriteLine($"Reversed text: {new string([.. charStack])}{Environment.NewLine}");
    }

    /// <summary>
    /// Finds the nth even number using recursion.
    /// This method is a part of exercise 5: RecursiveEven()
    /// Checks input from the user and calls the RecursiveEven(int n) method
    /// </summary>
    static void RecursiveEven()
    {
        Console.Write("Enter a number to find the nth even number: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            Console.WriteLine($"The {n}th even number is: {RecursiveEven(n)}{Environment.NewLine}");
        else
            Console.WriteLine($"Please enter a valid positive integer.{Environment.NewLine}");
    }

    /// <summary>
    /// Recursively calculates the nth even number.
    /// </summary>
    /// <param name="n">The position of the even number to find.</param>
    /// <returns>The nth even number.</returns>
    static int RecursiveEven(int n) => n == 1 ? 2 : RecursiveEven(n - 1) + 2;

    /// <summary>
    /// This method is a part of exercise 5: RecursiveFibonacci()
    /// Returns the nth Fibonacci number using recursion
    /// </summary>
    /// <param name="n"></param>
    static int RecursiveFibonacci(int n) => n <= 1 ? n : RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);

    /// <summary>
    /// Finds the nth even number using iteration.
    /// This method is a part of exercise 6: IterativeEven()
    /// Checks input from the user and calls the IterativeEven(int n) method
    /// </summary>
    private static void IterativeEven()
    {
        Console.Write("Enter a number to find the nth even number: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            Console.WriteLine($"The {n}th even number is: {IterativeEven(n)}{Environment.NewLine}");
        else
            Console.WriteLine($"Please enter a valid positive integer.{Environment.NewLine}");
    }

    /// <summary>
    /// Iteratively calculates the nth even number using for loop.
    /// </summary>
    /// <param name="n">The position of the even number to find.</param>
    /// <returns>The nth even number.</returns>
    private static int IterativeEven(int n)
    {
        int evenNumber = 2;
        for (int i = 1; i < n; i++)
            evenNumber += 2;
        return evenNumber;
    }


    /// <summary>
    /// This method is a part of exercise 6: IterativeFibonacci()
    /// returns the nth Fibonacci number using iteration
    /// </summary>
    static int IterativeFibonacci(int n)
    {
        if (n <= 1) return n;
        int a = 0, b = 1, result = 0;
        for (int i = 2; i <= n; i++)
        {
            result = a + b;
            a = b;
            b = result;
        }
        return result;
    }
}
/// <summary>
/// Svar på frågorna
/// 
/// Under rubriken Frågor: 
///  1. Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion
///     Stacken: Fungerar som en stapel av lådor. Varje låda representerar en metod eller funktion. 
///     När en metod anropas, placeras den överst på stacken. När metoden är klar, tas den bort från stacken. 
///     Detta är ett snabbt och effektivt sätt att hantera minne för temporära variabler.
///     Heapen: Fungerar mer som ett stort lager där objekt lagras.
///     Till skillnad från stacken, har objekt i heapen ingen specifik ordning.
///     För att komma åt ett objekt i heapen, används en referens.Minneshantering i heapen är mer komplicerad och hanteras av Garbage Collector (GC).

///  2. Vad är Value Types respektive Reference Types och vad skiljer dem åt? 
///     - Value Types: Lagrar själva datan direkt i minnet. Exempel inkluderar int, bool, och char. 
///     När man tilldelar en value type till en annan, kopieras datan.
///     - Reference Types: Lagrar en referens(en adress) till platsen i minnet där datan finns.
///     Exempel inkluderar class, string, och List.När man tilldelar en reference type till en annan, kopieras referensen, inte datan. 
///     Båda variablerna pekar då på samma data i minnet.
/// 
///  3. Följande metoder(se bild nedan) genererar olika svar.Den första returnerar 3, den andra returnerar 4, varför?
///     - I den första metoden (ReturnValue) är x och y av typen int, vilket är en value type. 
///     När y tilldelas värdet av x, kopieras värdet (3). Ändringen av y påverkar inte x.
///     - I den andra metoden(ReturnValue2) är x och y av typen MyInt, vilket är en klass(en reference type). 
///     När y tilldelas x, kopieras referensen. Både x och y pekar nu på samma MyInt-objekt i heapen.
///     Ändringen av y.MyValue ändrar värdet i detta gemensamma objekt, och därför ser vi ändringen även när vi läser av x.MyValue.
/// 
/// Under övning 1:
///  När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
///  - Svar: List<string> ökar sin kapacitet automatiskt när antalet element i listan överskrider den nuvarande kapaciteten.
/// 
///  Med hur mycket ökar kapaciteten?
///  - Svar: Kapaciteten ökar ungefär dubbelt så mycket när den behöver öka.
///  
///  Varför ökar inte listans kapacitet i samma takt som element läggs till?
///  - Svar: Kapaciteten ökar inte i samma takt som element läggs till för att det skulle leda till frekventa och dyra minnesomallokeringar. 
/// 
///  Minskar kapaciteten när element tas bort ur listan?
///  - Svar: Nej, kapaciteten för en List<string> minskar inte när element tas bort. Kapaciteten förblir densamma tills List<string>-objektet ändras explicit.
///  
///  När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
///  - Svar: Det är fördelaktigt att använda en array istället för en lista när:
///  - Storleken på arrayen är känd och fast.
///  - Prestanda är kritisk och overhead för dynamisk ändring av storlek är oacceptabel.
///  - Minnesanvändning behöver strikt kontrolleras.
///  Answer: It is advantageous to use an array instead of a list when:
///   - The size of the collection is known and fixed.
///   - Performance is critical, and the overhead of dynamic resizing is unacceptable.
///   - Memory usage needs to be strictly controlled.
///    
///
/// Under övning 3:
/// Simulera ännu en gång ICA-kön på papper.Denna gång med en stack.Varför är det inte så smart att använda en stack i det här fallet?
/// - Svar: En stack fungerar enligt principen "Först in, sist ut" (FILO). I en ICA-kö vill vi betjäna kunder i den ordning de anländer ("Först in, först ut" - FIFO).
///   I exemplet ovan skulle Olle bli betjänad före Stina, och Stina före Greta, vilket är fel.  Detta gör en stack olämplig för att simulera en verklig kö.
///   
/// 
/// Under övning 6:
/// Utgå ifrån era nyvunna kunskaper om iteration, rekursion och minneshantering.Vilken av ovanstående funktioner är mest minnesvänlig och varför?
/// - Svar: Iteration är generellt mer minnesvänlig än rekursion.
///   Rekursion innebär att man skickar en ny stackram för varje funktionsanrop, vilket förbrukar minne.Djup rekursion kan leda till ett stackoverflow-fel.
///   Iteration använder en fast mängd minne eftersom den inte innebär att nya stackramar skapas för varje repetition.Den uppdaterar värdena på variabler inom samma minnesutrymme.
///   Därför föredras iterativa lösningar vanligtvis för prestanda och minneseffektivitet, särskilt för problem som involverar ett stort antal repetitioner.
///  
/// </summary>
