using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dates2
{
    internal class Program
    {
        enum MonthCode
        {
            January = 1,
            February = 4,
            March = 4,
            April = 0,
            May = 2,
            June = 5,
            July = 0,
            August = 3,
            September = 6,
            October = 1,
            November = 4,
            December = 6
        }

        static Dictionary<int, MonthCode> numToMonth = new Dictionary<int, MonthCode>()
        {
            {1, MonthCode.January },
            {2, MonthCode.February },
            {3, MonthCode.March },
            {4, MonthCode.April },
            {5, MonthCode.May },
            {6, MonthCode.June },
            {7, MonthCode.July },
            {8, MonthCode.August },
            {9, MonthCode.September },
            {10, MonthCode.October },
            {11, MonthCode.November },
            {12, MonthCode.December },
        };

        enum MyDayOfWeek
        {
            Saturday,
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
        }

        static Dictionary<int, MyDayOfWeek> numToDayOfWeek = new Dictionary<int, MyDayOfWeek>()
        {
            {0, MyDayOfWeek.Saturday },
            {1, MyDayOfWeek.Sunday },
            {2, MyDayOfWeek.Monday },
            {3, MyDayOfWeek.Tuesday },
            {4, MyDayOfWeek.Wednesday },
            {5, MyDayOfWeek.Thursday },
            {6, MyDayOfWeek.Friday }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Enter first date (dd.mm.yyyy)");
            if (!InputDate(out DateTime date1)) { return; }
            Console.WriteLine("Enter second date (dd.mm.yyyy)");
            if (!InputDate(out DateTime date2)) { return; }

            if (date1 > date2) {
                Console.WriteLine("[ERROR]: Invalid input");
                Console.ReadLine();
                return; 
            }
            
            Console.WriteLine(CountFullWeeks(date1, date2));
            Console.ReadLine();
        }

        static bool InputDate(out DateTime date)
        {
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, DateTimeStyles.None, out date))
            {
                Console.WriteLine("[ERROR]: Invalid input");
                Console.ReadLine();
                return false;
            }
            return true;
        }

        static MyDayOfWeek FindDayOfWeek(DateTime date)
        {
            int yearCode = (6 + (date.Year % 100) + (date.Year % 100) / 4) % 7;
            int monthCode = (int)numToMonth[date.Month];
            int dayOfWeek = (date.Day + monthCode + yearCode) % 7;
            return numToDayOfWeek[dayOfWeek];
            
        }

        static int CountFullWeeks(DateTime date1, DateTime date2)
        {
            MyDayOfWeek dayOfWeek1 = FindDayOfWeek(date1);
            MyDayOfWeek dayOfWeek2 = FindDayOfWeek(date2);
            Console.WriteLine(dayOfWeek1);
            Console.WriteLine(dayOfWeek2);

            return 0;
        }
    }
}
