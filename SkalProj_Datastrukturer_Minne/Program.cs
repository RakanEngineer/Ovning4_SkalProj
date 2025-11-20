using System;

namespace SkalProj_Datastrukturer_Minne
{
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
                    + "\n5. Recursive functions"
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
                        RecursiveMenu();
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

            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine("Please input +item to add an item or -item to remove an item. Input 0 to exit to main menue: ");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                if (input == "0")
                    break;

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"Added {value} to the list.");
                        break;
                    case '-':
                        theList.Remove(value);
                        Console.WriteLine($"Removed {value} from the list.");
                        break;
                    default:
                        Console.WriteLine("Please use only + or - ");
                        break;
                }
                Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");
                Console.WriteLine("---------------------------------------");

                // Frågor:
                // 2. När ökar listans kapacitet? - Kapaciteten ökar när antalet överstiger den aktuella kapaciteten.
                // 3. Med hur mycket ökar kapaciteten? - Oftast dubblas (t.ex. 4 → 8 → 16 → 32).
                // 4. Varför ökar inte kapaciteten i samma takt som element läggs till? - För att undvika omallokering varje gång
                // 5. Minskar kapaciteten när element tas bort?  - Nej
                // 6. När är array bättre än lista? - När storleken är känd i förväg och ska vara fast.
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
            Queue<string> theQueue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("\n Queue Menu:");
                Console.WriteLine("1 = Add person to queue (Enqueue)");
                Console.WriteLine("2 = Remove first person from queue (Dequeue)");
                Console.WriteLine("0 = Exit to menu");
                Console.Write("Please input 1 to enqueue an item or 2 to dequeue an item. Input 0 to exit to main menue: ");

                string input = Console.ReadLine();
                if (input == "0")
                    break;

                switch (input)
                {

                    case "1":
                        Console.Write("Enter name to add: ");
                        string name = Console.ReadLine();
                        theQueue.Enqueue(name);
                        Console.WriteLine($"{name} has entered the queue.");
                        break;

                    case "2":
                        if (theQueue.Count > 0)
                        {
                            string removed = theQueue.Dequeue();
                            Console.WriteLine($"{removed} has been served and left the queue.");
                        }
                        else
                        {
                            Console.WriteLine("The queue is empty.");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid input. Use 1, 2 or 0.");
                        break;
                }
                Console.WriteLine("n Current  queue: ");
                foreach (var person in theQueue)
                {
                    Console.Write(person + " ");
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            Stack<string> theStack = new Stack<string>();

            while (true)
            {
                Console.WriteLine("\n Stack Menu:");
                Console.WriteLine("1 = Push item onto stack");
                Console.WriteLine("2 = Pop item from stack");
                Console.WriteLine("3 = Reverse a text");
                Console.WriteLine("0 = Exit to menu");
                Console.Write("Please input 1 to push an item or 2 to pop an item. Input 0 to exit to main menue: ");

                string input = Console.ReadLine();
                if (input == "0")
                    break;

                switch (input)
                {
                    case "1":
                        Console.Write("Enter item to push onto stack: ");
                        string itemToPush = Console.ReadLine();
                        theStack.Push(itemToPush);
                        Console.WriteLine($"{itemToPush} has been pushed onto the stack.");
                        PrintStack(theStack);
                        break;
                    case "2":
                        if (theStack.Count > 0)
                        {
                            string poppedItem = theStack.Pop();
                            Console.WriteLine($"{poppedItem} has been popped from the stack.");
                        }
                        else
                        {
                            Console.WriteLine("The stack is empty.");
                        }
                        PrintStack(theStack);
                        break;
                    case "3":
                        ReverseText();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Use 1, 2 or 0.");
                        break;
                }

            }
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        private static void ReverseText()
        {
            Console.WriteLine("Enter text to reverse: ");
            string text = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            foreach (var c in text)
            {
                stack.Push(c);
            }
            string reversed = "";
            while (stack.Count > 0)
            {
                reversed += stack.Pop();
            }
            Console.WriteLine("Reversed text: " + reversed);
        }

        private static void PrintStack(Stack<string> stack)
        {
            Console.WriteLine("Current stack content:");
            foreach (var item in stack)
                Console.Write(item + " ");
        }

        static void CheckParanthesis()
        {
            Console.WriteLine("Enter text to check parentheses: ");
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                    stack.Push(c);
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("Incorrect");
                        Console.WriteLine("---------------------------------------");
                        return;
                    }

                    char last = stack.Pop();
                    if ((c == ')' && last != '(') ||
                                    (c == '}' && last != '{') ||
                                    (c == ']' && last != '['))
                    {
                        Console.WriteLine("Incorrect");
                        Console.WriteLine("---------------------------------------");
                        return;
                    }
                }
            }
            Console.WriteLine(stack.Count == 0 ? "Correct" : "Incorrect");
            Console.WriteLine("---------------------------------------");
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            //Fråga: Vilken datastruktur använder du?
            // Jag använder en Stack<char> för att kontrollera om en sträng är välformad.
            // Anledningen är att en stack följer FILO - principen(First In Last Out),
            // vilket gör den perfekt för att hantera parenteser som måste stängas
            // i omvänd ordning mot hur de öppnades. När vi ser en parentes som öppnas
            // pushas den på stacken, och när vi ser en stängande parentes poppar vi
            // och kontrollerar att den matchar.
        }
        static void RecursiveMenu()
        {
            //Implement the recursive functions here.
            //RecursiveOdd(1)
            //→ n = 1 → return 1
            //RecursiveOdd(3)
            //→ RecursiveOdd(2) + 2
            //→ RecursiveOdd(1) + 2 + 2
            //→ 1 + 4 = 5
            //RecursiveOdd(5)
            //→ RecursiveOdd(4) + 2
            //→ RecursiveOdd(3) + 2 + 2
            //→ RecursiveOdd(2) + 2 + 2 + 2
            //→ RecursiveOdd(1) + 2 + 2 + 2 + 2
            //→ 1 + 8 = 9

            Console.WriteLine("Enter a number for recursive even or fibonacci:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine($"RecursiveEven({n}) = {RecursiveEven(n)}");
            Console.WriteLine($"Fibonacci({n}) = {Fibonacci(n)}");
        }        
        private static int RecursiveEven(int n)
        {
            if (n == 1)
                return 2;

            return RecursiveEven(n - 1) + 2;
        }
        private static int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}

