using System;

namespace Excercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, gcd;
            int[] arrayNumber;
            Console.WriteLine("Give number of array: ");
            n = int.Parse(Console.ReadLine());

            // Input a array with n elements
            arrayNumber = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"A[{i}] = ");
                arrayNumber[i] = int.Parse(Console.ReadLine());
            }

            // Find GCD
            gcd = findGcdOfArray(arrayNumber, n);

            // Print result to console
            Console.WriteLine($"GCD of array is: {gcd} ");
        }

        static int findGcdOfArray(int[] arr, int n)
        {
            /* we have an array = [2,4,6]
             * first, we find gcd two elemnts first of array. Here we have: 2,4 => gcd = findGCD(2,4) = 2;
             * next, we find gcd of first gcd with next element. We have gcd = findGCD(findGCD(2,4),6) or gcd = findGCD(2,6) = 2
             * Continue to last element of array, we''ll find gcd of array
            */

            int result = arr[0];
            for (int i = 1; i < n; i++)
            {
                result = findGcdOfTwoNumbers(arr[i], result);

                // If have one gcd = 1 => gcd of array = 1;
                if (result == 1)
                {
                    return 1;
                }
            }

            return result;
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
            return a; // return a or b because a right now actually equal b
        }
    }
}
