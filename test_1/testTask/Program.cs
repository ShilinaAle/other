using System;

namespace testTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int year = 2021;
            int month = 0;
            DateTime date = new DateTime();
            Console.WriteLine("Please, choose ordinal number of mount");
            
            try
            {
                month = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Not number of mount");
                Console.ReadKey();
                Environment.Exit(1);
            }
            try
            {            
                date = new DateTime(year, month, 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Wrong number of mount");
                Console.ReadKey();
                Environment.Exit(1);
            }
            int sum = 0;

            while (true)
            {
                if (date.Month > month)
                {
                    break;
                }
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
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