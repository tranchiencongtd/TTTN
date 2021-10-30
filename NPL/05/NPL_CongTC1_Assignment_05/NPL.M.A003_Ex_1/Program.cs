using System;
using System.Globalization;

namespace NPL.M.A003_Ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValidDate = false;
            DateTime startDate;
            do
            {
                Console.Write("Enter DATE(day/month/year): ");
                
                isValidDate = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
                if (!isValidDate)
                    Console.WriteLine("Invalid date format");
            } while (!isValidDate);


            Console.WriteLine($"1st reminder: {Reminder(ref startDate, 7).ToString("dd/MM/yyyy")}");
            Console.WriteLine($"2nd reminder: {Reminder(ref startDate, 2).ToString("dd/MM/yyyy")}");
            Console.WriteLine($"3rd reminder: {Reminder(ref startDate, 1).ToString("dd/MM/yyyy")}");
            Console.WriteLine($"4th reminder: {Reminder(ref startDate, 1).ToString("dd/MM/yyyy")}");
            Console.WriteLine($"5th reminder: {Reminder(ref startDate, 1).ToString("dd/MM/yyyy")}");
        }

        static DateTime RemoveNotWoringDays(DateTime startDate)
        {
            switch(startDate.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return startDate.AddDays(2);
                case DayOfWeek.Sunday:
                    return startDate.AddDays(1);
            }
            return startDate;
        }

        static DateTime Reminder(ref DateTime startDay, int day)
        {
            for(int i=1;i<=day;i++)
            {
                startDay = RemoveNotWoringDays(startDay.AddDays(1));
            }
            return startDay;
        }
    }
}
