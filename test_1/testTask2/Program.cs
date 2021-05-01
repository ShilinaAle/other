using System;
using System.Collections.Generic;

namespace testTask2
{
    class Program
    {
        /* Даты, значения и словари используются для тестов. Идеально, если
         * информация по сотрудникам размещена в БД, по значениям из которой
         * выполняется расчет.
         */
        
        public static DateTime date = new DateTime(2021, 4, 20); // текущий - DateTime.Now;

        public static int AccPer = date.Month;
        public static DateTime D1 = new DateTime(date.Year, date.Month, 1);
        public static DateTime D2 = new DateTime(date.Year, date.Month + 1, 1).AddDays(-1);

        private static int salary = 1000;

        static int HC(string a)
        {
            // 30 процентов аванс, 10 - минимальное количество отработанных дней
            Dictionary<string, int> avans = new Dictionary<string, int>(){ { "AdvPrc", 30 },
                {"MinWDays", 10} }; 
            if (a == "MinWDays") return avans["MinWDays"];
            return avans["AdvPrc"];
        }

        //есть ли у компании специально выделенный день аванса
        static bool UseAdvDays = true;

        //отработанное сотрудником количество дней
        static double WorkDays(string name, ref DateTime first, ref DateTime second)
        {
            DateTime firstReal = first;
            DateTime secReal = second;
            //если реальная работа сотрудника началась позже 
            //введенного периода - берем только количество реальных рабочих дней
            //вторая граница проверятся раньше в алгоритме
            if (first < Emp("DateBegin"))
            {
                firstReal = Emp("DateBegin");
            }
            Dictionary<string, double> timeOfWork = new Dictionary<string, double>()
            { { "", (secReal - firstReal).Duration().TotalDays} };

            return (timeOfWork[name]);
        }

        //день выплаты аванса
        static DateTime DE = new DateTime(2021, 4, 20, 0, 0, 0);

        //оклад сотрудника
        public static int GetSalary()
        {
            return salary;
        }

        //плановое рабочее по производственному календарю
        public static double PlanDays(string name, ref DateTime first, ref DateTime second) {
            Dictionary<string, double> planWork = new Dictionary<string, double>()
                { { "", (second - first).Duration().TotalDays} };

            return (planWork[name]);
        }

        //плановое рабочее по личному графику сотрудника (не используется)
        public static int PlanDaysBySched = 20;

        //данные о сотруднике 
        public static DateTime Emp(string needData)
        {
            Dictionary<string, DateTime> dictOfEmp = new Dictionary<string, DateTime>()
                { { "DateBegin", new DateTime(2021, 4, 10)}, {"DateEnd", new DateTime(2021, 4, 25)} };

            if (needData == "DateBegin") return dictOfEmp["DateBegin"];
            return dictOfEmp["DateEnd"];
        }

        static void Main(string[] args)
        {
            //инициализация переменных
            double Result = 0;

            //проверка процента аванса
            int Prc = HC("AdvPrc");

            //если процент равен 0, аванс не выплачивается
            if (Prc == 0)
            {
                Console.WriteLine("prs = 0");
                return;
            }
            
            //если есть выделенный день аванса, то аванс считается 
            //и выплачивается в день аванса
            //если нет - считается и выплачивается в конце месяца
            if (UseAdvDays == true) D2 = DE;
            
            //если дата увольнения раньше дня аванса - то аванс не выплачивается
            DateTime aDE = Emp("DateEnd");
            if (aDE <= D2)
            {
                Console.WriteLine("дата увольнения раньше дня аванса");
                return;
            }

            //если количество отработанное сотрудником время меньше
            //минимального, то аванс не выплачивается
            var WD = WorkDays("", ref D1, ref D2);
            var MinWDays = HC("MinWDays");
            if (WD < MinWDays)
            {
                Console.WriteLine("количество отработанное сотрудником время меньше минимального");
                return;
            }

            //запоминаем оклад сотрудника
            double aSalary = GetSalary();

            //запоминаем плановое время по календарю
            double PD = PlanDays("", ref D1, ref D2);

            //считаем аванс.Сначала вычисляется заработок в час,
            //затем умножается на фактическое значение времени работы сотрудника
            //и берется процент от получившегося числа.
            Result = aSalary / PD * WD * Prc / 100.0;
            Console.Write("result: " + Math.Round(Result, 2));
        }
    }
            
    

    


        
    
}
