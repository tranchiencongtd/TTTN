using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, min, max;
            int[] arrayNumber;
            Console.WriteLine("Give number of array: ");
            n = int.Parse(Console.ReadLine());
            
            // Input aa array with n elements
            arrayNumber = new int[n];
            for(int i=0;i<n;i++)
            {
                Console.Write($"A[{i}] = ");
                arrayNumber[i] = int.Parse(Console.ReadLine());
            }

            // Find min, max
            // Case array have one element
            if(n==1)
            {
                min = arrayNumber[0];
                max = arrayNumber[0];
            }

            // Case array have more than one elements 
            if(arrayNumber[0]>arrayNumber[1])
            {
                min = arrayNumber[1];
                max = arrayNumber[0];
            } else
            {
                min = arrayNumber[0];
                max = arrayNumber[1];
            }
  
            for (int i = 2; i < n; i++)
            {
                if (arrayNumber[i] > max)
                    max = arrayNumber[i];
                else if (arrayNumber[i] < min)
                    min = arrayNumber[i];
            }

            // Print result to console
            Console.WriteLine("========================");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Max: {max}");
        }
    }
}
