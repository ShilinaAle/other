using System;
using System.Collections.Generic;

namespace testTask2
{
    class Program
    {
        
        public static DateTime date = DateTime.Now;
        public static int AccPer = date.Month;
        public static DateTime D1 = new DateTime(date.Year, date.Month, 1);
        public static DateTime D2 = new DateTime(date.Year, date.Month + 1, 1).AddDays(-1);

        static int HC(string a)
        {
            Dictionary<string, int> avans = new Dictionary<string, int>(){ { "AdvPrc", 30 },
                {"MinWDays", 10} };
            if (a == "MinWDays") return avans["MinWDays"];
            return avans["AdvPrc"];
        }

        static bool UseAdvDays = true;
        static double WorkDays(string name, ref DateTime first, ref DateTime second)
        {
            Dictionary<string, double> timeOfWork = new Dictionary<string, double>()
            { { " ", (second - first).Duration().TotalDays} };

            return (timeOfWork[name]);
        }
        static DateTime DE = new DateTime(2021, 4, 15, 0, 0, 0);

        public static int GetSalary()
        {
            return 1000;
        }

        public static double PlanDays(string name, ref DateTime first, ref DateTime second) {
            Dictionary<string, double> planWork = new Dictionary<string, double>()
                { { " ", (second - first).Duration().TotalDays} };

            return (planWork[name]);
        }
        public static int PlanDaysBySched = 20;
        
        public static DateTime Emp(string name)
        {
            DateTime DateBegin = new DateTime(1, 1, 1);
            DateTime DateEnd = new DateTime(1, 1, 1);

            Dictionary<string, DateTime> dEnd = new Dictionary<string, DateTime>()
                { { "DateBegin", DateBegin}, {"DateEnd", DateEnd} };

            if (name == "DateBegin") return dEnd["DateBegin"];
            return dEnd["DateEnd"];
        }

        static void Main(string[] args)
        {
            int Result = 0;
            int Prc = HC("AdvPrc");
            Console.WriteLine(Prc);
            if (Prc == 0) return;
            if (UseAdvDays == true) D2 = DE;
            DateTime aDE = Emp("DateEnd");
            if (aDE <= D2) return;
            var WD = WorkDays("", ref D1, ref D2);
            var MinWDays = HC("MinWDays");
            if (WD < MinWDays) return;
            double aSalary = GetSalary();
            double PD = PlanDays("", ref D1, ref D2);
            Result = (int) (aSalary / PD * WD * Prc / 100);
        }
    }
            
    

    


        
    
}
