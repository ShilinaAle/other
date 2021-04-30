using System;

namespace testTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int year = 2020;
            int month = 4;
            DateTime date = new DateTime(year, month, 3);

            int sum = 0;

            while (true)
            {
                if (date.Month > month)
                {
                    break;
                }
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday ||
                    date.Day >= 6 && date.Day <= 12)
                {
                    date = date.AddDays(1.0);
                    continue;
                }
                if (date.Day >= 20)
                {
                    sum += 300;
                    date = date.AddDays(1.0);
                    continue;
                }
                sum += 200;
                date = date.AddDays(1.0);
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}