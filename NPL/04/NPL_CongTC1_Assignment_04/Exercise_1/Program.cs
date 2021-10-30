using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            do
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) break;
                else Console.WriteLine("You must type input");
            } while (true);
          
            name = NormalizeName(name);
            Console.WriteLine(name);
        }

        private static string NormalizeName(string name)
        {
            char[] spearator = {' '};
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
