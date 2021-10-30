using System;

namespace Excercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, gcd;
            Console.WriteLine("Number a: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Number b: ");
            b = int.Parse(Console.ReadLine());

            // Find GCD using Repeated Subtraction
            gcd = findGcdOfTwoNumbers(a, b);
            
            // Print result to console
            Console.WriteLine($"GCD of {a} and {b} is: {gcd} ");
        }

        private static int findGcdOfTwoNumbers(int a, int b)
        {
            // if a = 0 => gcd = b
            // if b = 0 => gcd = a
            if (a == 0 || b == 0)
            {
                return a + b;
            }
            while (a != b)
            {
                if (a > b)
                {
                    a -= b; // a = a - b
                }
                else
                {
                    b -= a;
                }
            }
            return  a; // return a or b because a right now actually equal b
        }
    }
}
