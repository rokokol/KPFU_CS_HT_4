using System;
using System.Threading;

namespace HT
{
    class MainClass
    {
        static string ZERO =
            " ## \n" +
            "#  #\n" +
            "#  #\n" +
            " ## ";
        static string ONE =
            "  # \n" +
            " ## \n" +
            "  # \n" +
            "  # ";
        static string TWO =
            " ## \n" +
            "#  #\n" +
            "  # \n" +
            "####";
        static string THREE =
            " ## \n" +
            "#  #\n" +
            "  # \n" +
            "#  #\n" +
            " ## ";
        static string FOUR =
            "  ##\n" +
            " # #\n" +
            "####\n" +
            "   #";
        static string FIVE =
            "####\n" +
            "#   \n" +
            "### \n" +
            "   #\n" +
            "##  ";
        static string SIX =
            " ## \n" +
            "#   \n" +
            "### \n" +
            "#  #\n" +
            " ## ";
        static string SEVEN =
            "### \n" +
            "  # \n" +
            " #  \n" +
            "#   ";
        static string EIGHT =
            " ## \n" +
            "#  #\n" +
            " ## \n" +
            "#  #\n" +
            " ## ";
        static string NINE =
            " ## \n" +
            "#  #\n" +
            " ###\n" +
            "   #\n" +
            " ## \n";
           
        static void Message(string message, int number)
        {
            Console.WriteLine("\nLet's check problem #{0}\nThis program {1}\nPress any to continue...", number, message);
            Console.ReadKey();
        }

        // if positive flag is true input must be positive
        static int ReadInt(bool positiveFlag)
        {
            int result = 1;
            bool term = true;
            while (term)
            {
                Offer();
                bool convert = int.TryParse(Console.ReadLine(), out result);
                bool positive = (result >= 0) || !positiveFlag; // if positiveFlag = true it is also true
                if (convert && positive)
                {
                    term = false;
                }
                else if (!positive)
                {
                    Console.WriteLine("The input must be positive. Please, try again:");
                }
                else
                {
                    Console.WriteLine("Incorrect input. Please, try again:");
                }
            }
            return result;
        }

        static void PrintArray(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write($"{i} ");
            }
        }

        static int ArrayTools(ref int multiply, out double average, params int[] array)
        {
            multiply = 1;
            int sum = 0;
            foreach (int i in array)
            {
                multiply *= i;
                sum += i;
            }
            average = (double) sum / array.Length;
            return sum;
        }

        static void Wrong(string input)
        {
            foreach (char ch in input)
            {
                if (char.IsLetter(ch))
                {
                    throw new InvalidOperationException("There is no such case!");
                }

            }
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                void Count(object obj)
                {
                    Console.Write('.');
                }
                Timer timer = new Timer(Count, null, 0, 1000);
                Thread.Sleep(3000);
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                Console.WriteLine();
                Console.WriteLine("!!!WRONG NUMBER OR COMMAND!!!");
                Thread.Sleep(1500);
                Console.ResetColor();
                Console.Clear();
        }

        static void Offer()
        {
            Console.Write("> ");
        }

        public static void Main(string[] args)
        {
           void Problem1()
           {
                Message("shows array of 20 random elements and swaps two of them on user's choice", 1);
                Random rnd = new Random();
                int[] ints = new int[20];
                for (int i = 0; i < 20; i++)
                {
                    ints[i] = rnd.Next() % 100 * (rnd.Next() % 2 == 0 ? 1 : -1); // 50% to negative number
                }
                ints[0] = ints[1] + 1; // To not we a cahnce to have 20 eequals elements
                 
                Console.WriteLine("The array:");
                PrintArray(ints);
                Console.WriteLine('\n');
                Console.WriteLine("Input two elements to swap");
                Console.WriteLine("First:");

                bool term = true;
                int first = 0;
                int firstNumb = 0;
                while (term)
                {
                    first = ReadInt(false);
                    for (int i = 0; i < ints.Length; i++)
                    {
                        if (ints[i] == first)
                        {
                            term = false;
                            firstNumb = i;
                            break;
                        }
                    }

                    if (term)
                    {
                        Console.WriteLine("There is no such element. Please, try again:");
                    }
                }

                Console.WriteLine("Second:");
                term = true;
                int second = 0;
                while (term)
                {
                    second = ReadInt(false);
                    for (int i = 0; i < ints.Length; i++)
                    {
                        if (ints[i] == second && ints[i] != first)
                        {
                            term = false;
                            second = i;
                            break;
                        }
                    }

                    if (term)
                    {
                        Console.WriteLine("There is no such element or you have already chosen it. Please, try again:");
                    }
                }

                ints[firstNumb] = ints[second];
                ints[second] = first;
                Console.WriteLine("The result array is:");
                PrintArray(ints);
                Console.WriteLine();
            }

            void Problem2()
            {
                Message("tests a function, that returns sum of array, returns (fer) its multiply" +
                	"\nand returns (out) its average", 1);
                int multiply = 1;
                Console.WriteLine($"The sum: {ArrayTools(ref multiply, out double average, 1, 2, 3, 4, 5, 6, 7, 8, 9)}, " +
                    $"multiply: {multiply}, average: {average}");
            }

            void Problem3()
            {
                Message("shows ASCII art of input digit", 1);
                bool term = true;
                while (term)
                {
                    Console.WriteLine("Type a digit or \"exit\" |" +
                    	" \"закрыть\" to stop");
                    Offer();
                    string input = Console.ReadLine().ToLower();
                    switch (input)
                    {
                        case "0": Console.WriteLine(ZERO); break;
                        case "1": Console.WriteLine(ONE); break;
                        case "2": Console.WriteLine(TWO); break;
                        case "3": Console.WriteLine(THREE); break;
                        case "4": Console.WriteLine(FOUR); break;
                        case "5": Console.WriteLine(FIVE); break;
                        case "6": Console.WriteLine(SIX); break;
                        case "7": Console.WriteLine(SEVEN); break;
                        case "8": Console.WriteLine(EIGHT); break;
                        case "9": Console.WriteLine(NINE); break;
                        case "закрыть": goto case "exit";
                        case "exit": term = false; break;
                        default: Wrong(input); break;
                    }
                }
                Environment.Exit(0);
            }

            bool run = true;
            while (run)
            {
                Console.WriteLine();
                Console.WriteLine("||===========================<\\\\>===========================||");
                Console.WriteLine("Please, input a number of a task (1-4) or type \"exit\" to stop:");
                Offer();
                switch(Console.ReadLine())
                {
                    case "1": Problem1(); break;
                    case "2": Problem2(); break;
                    case "3": Problem3(); break;
                    //case "4": Problem4(); break;
                    case "exit": run = false; break;
                    default: Console.WriteLine("This is not a command or a number of task"); break;
                }
            }
        }
    }
}
