/*
 * Fråga 1 -
 * På stacken läggs alla anropa till metoder och där lagras alla variabler som deklareras internt inuti metoden.
 * public void test(){
 *      int a = 4;
 *      test2();
 * }
 * public void test2(){
 *      int b = 3;
 * }
 * Här kommer stacken ser ut som följande
 * test2() - int b
 * test() - int a
 * När test2 har avslutats försvinner dess anropa från stacken och dess int b variabel
 * Likaså när test metoden avslutas
 *
 * På heapen lagras referensvariabler 
 *  * public void test(){
 *      int a = 4;
 *      Object object = new Object();
 *      test2();
 * }
 * public void test2(){
 *      Object object2 = new Object();
 *      int b = 3;
 * }
 * I det här fallet så ligger object och object2 kvar på heapen efter att funktionerna har avslutas.
 * De ligger kvar där tills garbage collection tar hand om dem.
 * Garbage Collection letar i minnet efter referens typer som det inte finns någon pekare till och när det finns en referenstyp utan någon pekare till så tar garbage collecions bort den då och då.
 * Det händer alltså inte på direkten efter att funktionen har avslutats.
 * 
 * 
 * Fråga 2
 * Values types är variabler där värdet lagras där den deklareras.
 * Values types kan alltså både lagras på stacken och heapen beroende på var de deklareras.
 * Till exempel:
 * int a = 3;
 * värder av a är 3, a innehåller talet 3.
 * 
 * Referens types lagras däremot alltid på heapen.
 * Object obejct = new Object();
 * new object() blir en referens typ som lagras på heapen, för att komma åt den behövs en pekare.
 * object är en pekare till det nya Object objektet, object innehåller således minnesadressen till new Object() och därmed inte själva objektet.
 * 
 * Fråga 3
 * Att den första returnerar 3 beror på att int x är en value type och som sedan tilldelas värdet 3 och som sedan returneras från funktionen.
 * I det andra exemplet är MyInt en referenstyp och MyInt x blir en pekare till new MyInt(), d.v.s. x håller minnesadressen till det nya objektet
 * MyInt y är på samma sätt en pekare som kan peka på ett MyInt objekt.
 * Därför blir resultatet av y = x att y kommer peka på samma objekt som x pekar på.
 * Eftersom de pekar på samma objekt så blir resultatet av y.MyValue = 4 att x.MyValue också får värdet 4 och därför returneras 4.
 * 
 * */





using System;
using System.Collections;
using System.Collections.Generic;

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
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
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
        /// Svar 2: Listans capacity ökar när count blir större än capacity, då ökas capacity automatiskt
        /// Svar 3: Capacity dubblerar sin längd varje gång count blir större än capacity
        /// Svar 4: Listan har en underliggande array och arrayer har alltid en fixerad storlek.
        /// Det blir väldigt ineffektivt för listan att skapa en ny array och kopiera alla nuvarande element till den underliggande arrayen varje gång ett nytt element läggs till i listan.
        /// Därför dubblerar den sin capacity bara ibland när count blir större än capacity.
        /// Svar 5: Nej, capacity håller sin längd hela tiden.
        /// Svar 6: När man vet exakt hur många element som man behöver är det bättre att skapa en array.
        /// Då behöver man bara skapa en array en gång. 
        /// Medan om man skapar en lista så skapas flera arrayer i bakgrunden som kopierar in de befintliga elementen allteftersom listan ökar.
        /// Array används också när man behöver multidimensionella arrayer.
        /// 
        /// </summary>
        static void ExamineList()
        {
            List<string> list = new List<string>();
            Examine(list, m => list.Add(m), m => list.Remove(m), "Wrong input, enter + or - following by characters");
        }

        private static void Examine(ICollection collection, Action<string> methodPlus, Action<string> methodMinus, string wrongMessage)
        {
            Console.WriteLine("Please enter some input! Press 0 to navigate to the main menu");

            //Loop this method untill the user inputs something to exit to main menue.
            while (true)
            {
                string input = "";

                try
                {
                    input = Console.ReadLine(); //Tries to set input to the first char in an input line
                    char command = input[0];
                    string stringToProcess = input.Substring(1);
                    // Create a switch statement with cases '+' and '-'
                    switch (command)
                    {
                        case '0':
                            return;
                        case '+':
                            //'+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
                            methodPlus(stringToProcess);  
                            break;
                        case '-':
                            //'-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
                            methodMinus(stringToProcess);
                            break;
                        default:
                            //As a default case, tell them to use only + or -
                            Console.WriteLine(wrongMessage);
                            break;
                    }
                    //look at the count and capacity of the list
                    if (collection is List<string> l)
                        Console.WriteLine($"Count: {l.Count} Capacity: {l.Capacity} ");
                    else if (collection is Queue<string> q)
                    {
                        Console.WriteLine($"Count: {q.Count}\nFirst element in queue is: {q?.Peek()}");
                        Console.Write("Queue Element: ");
                        foreach (var element in q)
                        {
                            Console.Write($"{element},");
                        }
                        Console.WriteLine("\n");
                    }   
                    else if (collection is Stack<string> s)
                    {
                        
                        Console.WriteLine($"Count: {s.Count}\nFirst element in stack is: {s?.Peek()}");
                        Console.Write("Stack Element: ");
                        foreach (var element in s)
                        {
                            Console.Write($"{element},");
                        }
                        Console.WriteLine("\n");
                    }
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.WriteLine("Please enter some input!");
                }

            }
        }







        /*Övning2  1.
         * a  {}
           b  {Kalle}
           c {Kalle, Greta}
           d {Greta}
           e {Greta, Stina}
           f {Stina}
           g {Stina, Olle}
        */

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Queue<string> queue = new Queue<string>();
            Examine(queue, m => queue.Enqueue(m), m => queue.Dequeue(), "Wrong input, enter + following by character to add to the queue or - to remove the first element in queue");

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
            /*Svar 3.1:
             * Det är inte så smart att använda sig av stack för att simulera en kö eftersom en stack beter sig helt annorlunda jämfört med en kö.
             * När man kör Pop på en stack så är det senaste elementet som har lagt till som tas bort från stacken, d.v.s. sist in först ut.
             * För att simulera ICA-kön med en stack så blir det alltså den som kom in i kön sist som får hjälp först.
             * En stack fungerar alltså i omvänd ordning jämfört med en kö och fungerar alltså inte för att simulera en kö.
             */
            Stack<string> stack = new Stack<string>();
            Examine(stack, m => stack.Push(m), m => stack.Pop(), "Wrong input, enter + following by character to add to the stack or - to remove the last insert element in stack");
        }

        static void CheckParanthesis()
        {
            Console.WriteLine("Please enter some input! Press 0 to navigate to the main menu");
            string input = Console.ReadLine();

            if (input == "0") return;
            else
            {
                Stack<char> parenthes = new Stack<char>();
                bool invalidString = true;

                foreach (var c in input)
                {
                    if (c == '(' || c == '{' || c == '[')
                        parenthes.Push(c);
                    else if (c == ')' || c == '}' || c == ']')
                    {
                        if (parenthes.Peek() == c)
                        {
                            parenthes.Pop();
                        }
                        else
                        {
                            invalidString = false;
                        }
                    }
                    else
                        continue;
                }

                if (parenthes.Count != 0)
                {
                    invalidString = false;
                }

                if (invalidString)
                    Console.WriteLine("String is valid");
                else
                    Console.WriteLine("String is not valid");


            }

            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

