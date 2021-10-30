using System;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Number of array full name: ");
            n = int.Parse(Console.ReadLine());
            string[] arr = new string[n];
                
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Name {i + 1}: ");
                arr[i] = NormalizeName(Console.ReadLine()); // Normalize name 
            }

            string[] arrSort = SortName(arr, n);
            foreach (var item in arrSort)
            {
                Console.WriteLine(item);
            }

        }

        private static string[] SortName(string[] arr, int n)
        {
            // Bubble sort
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //Console.WriteLine(compareTwoName(arr[i], arr[j]));
                    if(compareTwoName(arr[i],arr[j]))
                    {
                        (arr[i], arr[j]) = (arr[j], arr[i]); // swap 2 element in alphabet
                    }
                }
            }

            return arr;
        }

        private static bool compareTwoName(string name1, string name2)
        {
            name1 = name1.Trim();
            name2 = name2.Trim();
            string[] arrName1 = name1.Split(" ");
            string[] arrName2 = name2.Split(" "); 
            if (String.Compare(arrName1[arrName1.Length-1], arrName2[arrName2.Length - 1]) > 0)  {
                return false; // if the first string precedes the second string in the sort order.
            }

            return true; // if the first string follows the second string in the sort order.
        }

        // from ex_1
        private static string NormalizeName(string name)
        {
            char[] spearator = { ' ' };
            String[] strList = name.Split(spearator);
            var normalName = "";

            for (int i = 0; i < strList.Length; i++)
            {
                if (!string.IsNullOrEmpty(strList[i]))
                {
                    normalName += ToFirstLetterUpper(strList[i]) + " ";
                }

            }
            return normalName.Trim();
        }

        private static string ToFirstLetterUpper(string str)
        {
            return str[0].ToString().ToUpper() + str.Substring(1).ToLower();
        }
    }
}
