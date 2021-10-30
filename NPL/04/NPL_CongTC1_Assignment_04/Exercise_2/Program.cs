using System;
using System.Text.RegularExpressions;

namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string email;
            Console.WriteLine("Email: ");
            email = Console.ReadLine().Trim();

            if(IsEmail(email))
            {
                Console.WriteLine("Email valid");
            } else
            {
                Console.WriteLine("Email invalid");
            }
        }

        private static bool IsEmail(string email)
        {
            //Regex regex = new Regex(@"^([\w\.\-]+)
            //@([\w\-]+)
            //((\.(\w){2,3})+)$");
            //Match match = regex.Match(email);
            //if (match.Success)
            //{
            //    Console.WriteLine("OK");
            //    return true;
            //}


            //else
            //    return false;

            string pattern = @"^\w+(\.?\w+[!#$%&'*+\-/=?^_{|}~]*)*@\w+-*[\D]+[^-]$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
