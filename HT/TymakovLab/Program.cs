using System;
using System.Collections.Generic;
using System.Text;

namespace Tymakov
{
    class MainClass
    {
        static int number = 1;
        static Dictionary<int, ulong> CACHE = new Dictionary<int, ulong>();

        static void Message(string message)
        {
            Console.WriteLine("\nLet's check problem #{0}\nThis program {1}\nPress any to continue...", number++, message);
            Console.ReadKey();
        }

        // if positive flag is true input must be positive
        static int ReadInt(bool positiveFlag)
        {
            int result = 1;
            bool term = true;
            while (term)
            {
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

        static bool TryFactorial(int i, out long result)
        {
            result = 1;
            try
            {
                while (i > 1)
                {
                    result = checked(result * i);
                    i--;
                }
            } 
            catch (OverflowException)
            {
                return false;
            }

            return true;
        }

        static long FactorialRecursion(long a)
        {
            return a > 1 ? checked(FactorialRecursion(a - 1) * a) : 1;
        }

        // If a < 0 or b < 0 returns -1
        static int Gcd(int a, int b)
        {
            if (a < b)
            {
                Swap(ref a, ref b);
            }

            if (a < 0 || b < 0) // a or b cannot be negative
            {
                return -1;
            }

            if (b == 0)
            {
                return a;
            }

            return Gcd(b, a % b);
        }

        static int Gcd(int a, int b, int c)
        {
            return Gcd(a, Gcd(b, c));
        }

        static ulong Fibonacci(int n)
        {
            if (n < 0)
            {
                return 1;
            }
            if (n <= 2)
            {
                return 1;
            }

            if (!CACHE.ContainsKey(n))
            {
                // It uses a cache to work a way faster
                CACHE.Add(n, checked(Fibonacci(n - 1) + Fibonacci(n - 2)));
            }

            return CACHE[n];
        }

        public static void Main(string[] args)
        {
            void ProblemLab5_1()
            {
                Message("retusns the biggest number");
                Console.WriteLine("Please, enter two numbers. Separate them by ENTER key:");
                Console.WriteLine($"The biggest number is: {Max(ReadInt(false), ReadInt(false))}");
            }

            void ProblemLab5_2()
            {
                Message("swaps to numbers via their references");
                Console.WriteLine("Please, enter two numbers. Separate them by ENTER key:");
                int a = ReadInt(false);
                int b = ReadInt(false);
                Console.WriteLine($"a: {a}, b: {b}");
                Console.WriteLine("Swap...");
                Swap(ref a, ref b);
                Console.WriteLine($"a: {a}, b: {b}");
            }

            void ProblemLab5_3()
            {
                Message("counts a factorial of a number and uses checked keyword");
                Console.WriteLine("Please, input a number to find a factorial");
                if (TryFactorial(ReadInt(true), out long result))
                {
                    Console.WriteLine($"The factorial of this number is: {result}");
                }
                else
                {
                    Console.WriteLine("The input is too big to calculate it...");
                }
            }

            void ProblemLab5_4()
            {
                Message("counts a factorial via recursion function");
                Console.WriteLine("Please, input a number to find a factorial");
                try
                {
                    Console.WriteLine($"The factorial of this number is: {FactorialRecursion(ReadInt(true))}");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The input is too big to calculate it...");
                }   
            }

            void ProblemHT5_1()
            {
                Message("tests function to find a GCD of three numbers");
                Console.WriteLine("Please, enter three numbers. Separate them by ENTER key:");
                int a = ReadInt(true);
                int b = ReadInt(true);
                int c = ReadInt(true);
                Console.WriteLine($"The GCD of {a}, {b}, {c} is: {Gcd(a, b, c)}");
            }

            void ProblemHT5_2()
            {
                Message("calculates the n-th number of Fibonacci");
                Console.WriteLine("Please, input the n number:");
                try
                {
                    Console.WriteLine($"This is: {Fibonacci(ReadInt(true))}");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The input is too big..."); 
                }
            }

            Console.WriteLine("Please, input \"HT\", if you want to check the HT solutions");
            string input = "HT";

            if (input.Equals("HT") || input.Equals("НТ"))
            {
                ProblemHT5_1();
                ProblemHT5_2();
            } 
            else
            {
                ProblemLab5_1();
                ProblemLab5_2();
                ProblemLab5_3();
                ProblemLab5_4();
            }
            Console.WriteLine("That is all. Press any key to continue...");
            Console.ReadKey();
        }
    }
}
