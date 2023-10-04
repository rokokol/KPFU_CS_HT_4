using System;

namespace TymakovLab
{
    class MainClass
    {
        static int number = 1;

        static void Message(string message)
        {
            Console.WriteLine("\nLet's check problem #{0}\nThis program {1}\nPress any to continue...", number++, message);
            Console.ReadKey();
        }

        static int ReadInt()
        {
            int result = 1;
            bool term = true;
            while (term)
            {
                bool convert = int.TryParse(Console.ReadLine(), out result);
                bool biggerThanZero = result > 0;
                if (convert && biggerThanZero)
                {
                    term = false;
                }
                else if (!biggerThanZero)
                {
                    Console.WriteLine("The input must be bigger than 0. Please, try again:");
                }
                else
                {
                    Console.WriteLine("Incorrect input. Please, try again:");
                }
            }
            return result;
        }

        static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void Main(string[] args)
        {
            void Problem5_1()
            {
                Message("retusns the biggest number");
                Console.WriteLine("Please, enter two numbers:");
                Console.WriteLine($"The biggest number is: {Max(ReadInt(), ReadInt())}");
            }

            void Problem5_2()
            {
                Message("swaps to numbers via their references");
                Console.WriteLine("Please, enter two numbers:");
                int a = ReadInt();
                int b = ReadInt();
                Console.WriteLine($"a: {a}, b: {b}");
                Swap(ref a, ref b);
                Console.WriteLine("Swap...");
                Console.WriteLine($"a: {a}, b: {b}");
            }

            //Problem5_1();
            Problem5_2();
            Console.WriteLine("That is all. Press any key to continue...");
            Console.ReadKey();
        }
    }
}
