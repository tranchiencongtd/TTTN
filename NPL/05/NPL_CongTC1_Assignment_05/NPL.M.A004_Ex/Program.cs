using System;
using System.Globalization;

namespace NPL.M.A004_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            DateTime dateConvert = ToDateTime(input);
            Console.WriteLine("Last day of month: " + GetLastDayOfMonth(dateConvert).ToString("MM/dd/yyyy"));
            Console.WriteLine("Count working day: " + CountWorkingDays(dateConvert));
        }

        private static int CountWorkingDays(DateTime date)
        {
            int count = 0;
            for (DateTime i = GetFirstDayOfMonth(date); i <= GetLastDayOfMonth(date); i = i.AddDays(1))
            {
                if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday)
                {
                    count++;
                }
            }
            return count;
        }

        private static DateTime GetFirstDayOfMonth(DateTime date )
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        private static DateTime GetLastDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month,DateTime.DaysInMonth(date.Year, date.Month));
        }

        private static DateTime ToDateTime(string stringDate)
        {
            var formats = new[] 
            {   
                "MM/dd/yyyy",
                "MM/dd/yyyy hh:mm:ss", 
                "M/d/yyyy h:mm:ss", 
                "M/d/yyyy hh:mm tt", 
                "M/d/yyyy hh tt", 
                "M/d/yyyy h:mm",
                "M/d/yyyy h:mm" 
            };

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
