namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        //Svar på frågor:
        //1.
        //Stacken har koll på anrop och metoder som körs, när metoden körts kastas den från stacken och nästa körs.Självunderhållande och behöver ingen hjälp med minnet. Fungerar enligt LIFO.
        // Heapen håller stor del av informationen men har ingen koll på exekveringsordning. Flexibel storlek men långsammare åtkomst än stacken.

        //2.
        //Value Types lagras där de deklareras vilket kan vara både på heap och stack. Value types är bool, int, char, enum osv
        //Reference Types lagras alltid på heapen. Reference types är klasser, interface, objekt, stringar

        //3. För att den första är en int som är en value type. Den sätter x = 3, sedan i y=x så tilldelar den y så den blir 3 men x är ju fortfarande 3 också. Därför returnar den 3.
        // I den andra metoden ReturnValue2 så är det ju objekt som är referenstyper och där skrivs värdet av x över till 4.

        // Utgå ifrån era nyvunna kunskaper om iteration, rekursion och minneshantering. Vilken av ovanstående funktioner är mest minnesvänlig och varför?
        // Iterativa funktionen är mest minnesvänlig då den inte använder extra stackutrymme för varje beräkning.

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 6, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Recursive"
                    + "\n6. Iterative"
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
                      RecursiveOdd(8);
                        break;
                    case '6':
                        IterativeFibonacci();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5, 6)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            //Varför ökar inte listans kapacitet i samma takt som element läggs till?
            // Skulle ta för mycket prestanda. 

            //När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
            // När man vet exakt hur många element man behöver är det bättre att använda en array. Array är även snabbare än listor.

            List<string> theList = new List<string>();
            while(true)
            {
                Console.WriteLine("Enter + and a name if you want to add something to the list. \nEnter - and the name to remove from list. \nTo go back to main manu press m ");

                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    //Capacity sätts till 4 när första objektet läggs till i listan, när sedan listan innehåller 5 objekt utökad capacity med 4 till och blir 8
                    case '+': theList.Add(value); Console.WriteLine($"You added {value} capacity is {theList.Capacity} and count is {theList.Count}"); break;

                    //När man tar bort objekt ur listan minskar count men capacity förblir densamma.
                    case '-': theList.Remove(value); Console.WriteLine($"You removed {value} capacity is {theList.Capacity} and count is {theList.Count}"); break;
                    case 'm': Main(); break;

                    default:
                        Console.WriteLine("Use only + or - or m");
                        break;
                }
            }
        }
        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Queue<string> customers = new Queue<string>();
            while (true) {
            
                Console.WriteLine("1. Add to queue \n2.Remove from queue \n3. Go back to mainmenu");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter value to add to queue: ");
                        string value = Console.ReadLine();
                        customers.Enqueue(value);
                        Console.WriteLine($"{value} added to queue");
                        break;

                    case "2":
                        var removed = customers.Dequeue();
                        Console.WriteLine($"{removed} is removed");
                        break;

                    case "3":
                        Main();
                        break;

                    default:
                        Console.WriteLine("Use only 1, 2 or 3");
                        break;
                }
            }
        }
        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            while (true)
            {
                Console.WriteLine("input word or type m for mainmenu: ");
                var input = Console.ReadLine();

                if(input =="m")
                {
                    Console.WriteLine("Returning to main menu");
                    Main();
                }
                ReverseText(input);
            }
        }
        static void ReverseText(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (var c in input)
                stack.Push(c);

            string reversedword = "";

            while (stack.Count > 0)
            {
                reversedword += stack.Pop();
            }
            Console.WriteLine(reversedword);
        }
        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.WriteLine("Skriv in en sträng:");
            var input = Console.ReadLine();

            bool ismatch = true;

            Stack<char> stack = new Stack<char>();

            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                    {
                        ismatch = false;
                        break;
                    }
                    char top = stack.Peek();

                    if (!(c == ')' && top == '(') ||
                           (c == '}' && top == '{') ||
                           (c == ']' && top == '['))
                    {
                        ismatch = false;
                        break;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }

            if (stack.Count != 0)
            {
                ismatch = false;
            }

            if (ismatch)
            {
                Console.WriteLine("Strängen är korrekt");
            }
            else { Console.WriteLine("Strängen är ej korrekt"); }
        }
        //Övning 5: Rekursion
        static int RecursiveOdd(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            return (RecursiveOdd(n - 1) + 2);
        }

        //RecursiveEven returnar en 2a istället för en 1a just för att 2 är första jämna talet.
        static int RecursiveEven(int n)
        {
            if (n == 1)
            {
                return 2;
            }
            return (RecursiveEven(n - 1) + 2);
        }
        static int Fibonnacci(int n)
        {
            //basfall 1: om n är 0, return 0
            if (n == 0)
                return 0;

            //basfall 2: om n är 1 returnera 1
            if (n == 1)
                return 1;

            return Fibonnacci(n - 1) + Fibonnacci(n - 2);
        }
        //Övning 6: Iteration
        //Iteration är en funktion som upprepar samma sak tills målet är uppnått
        static int IterativeOdd(int n)
        {
            //första udda talet
            int result = 1;

            for (int i = 0; i < n - 1; i++)
            {
                //adderar 2 till result = varje steg räknar vi upp till nästa udda tal
                result += 2;
            }
            return result;
        }
        static int IterateEven(int n)
        {
            //första jämna talet
            int result = 0;

            for (int i = 0; i <n-1; i++)
            {
                result += 2;
            }
            return result;
        }
        static void IterativeFibonacci()
        {
            int firstnumber = 0;
            int secondnumber = 1;
            Console.WriteLine(firstnumber);
            Console.WriteLine(secondnumber);

            //Sätter i = 2 för att det kommer efter 0 1
            for (int i = 2; i < 10; i++)
            {
                //beräknar summan av numren
                var sum = firstnumber + secondnumber;

                //flyttar secondnumber till firstnumber
                firstnumber = secondnumber;

                //Flyttar summan av talen till secondnummer
                secondnumber = sum;
                Console.WriteLine(sum);
            }
        }
    }
}

