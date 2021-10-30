using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NPL.M.A003_Ex_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"Created at 28 / 02 / 2018 10:15:35 AM by Andy.
                            Updated at 03 / 03 / 2018 02:45:10 PM by Mark
                            Clear name at 02 / 03 / 2018 11:34:05 AM by Andy";
            var inputs = input.Split("\n");
            
            var dic = new Dictionary<string, DateTime>();

            try
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    int startIndex = inputs[i].IndexOf(" at ") + 4;
                    int length = inputs[i].IndexOf(" by ") - startIndex;
                    string dateString = inputs[i].Substring(startIndex, length);
                    dic.Add(inputs[i].Trim(), ToDateTime(dateString));
                }
                foreach (var item in dic.OrderBy(x => x.Value))
                {
                    Console.WriteLine(item.Key);
                }
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static DateTime ToDateTime(string stringDate)
        {
            var formats = new[] { "dd/MM/yyyy", "dd/MM/yyyy hh:mm:ss tt", "dd/MMM/yyyy" };
            for (int i = 0; i < formats.Length; i++)
            {
                bool isValidDate = DateTime.TryParseExact(stringDate, formats[i],
                                                 CultureInfo.InvariantCulture,
                                                 DateTimeStyles.AllowWhiteSpaces, out DateTime result);
                if (isValidDate) return result;
            }
            throw new ArgumentException($"{stringDate} is invalid format date");
        }
    }
}
