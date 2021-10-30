using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertToBinary();
        }

        static void ConvertToBinary()
        {
            int n, i;
            int[] a = new int[10];
            Console.Write("n: ");
            n = int.Parse(Console.ReadLine());
            for (i = 0; n > 0; i++)
            {
                a[i] = n % 2;
                n = n / 2;
            }
            Console.Write($"{n} to base 2: \n");
            for (i = i - 1; i >= 0; i--)
            {
                Console.Write(a[i]);
            }

            Console.ReadLine();
        }
    }
}
