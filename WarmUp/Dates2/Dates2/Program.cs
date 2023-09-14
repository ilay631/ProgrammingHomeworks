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

        static int CountFullWeeks(DateTime date1, DateTime date2)
        {
            while (date1.DayOfWeek != DayOfWeek.Monday) { date1 = date1.AddDays(1); }
            while (date2.DayOfWeek != DayOfWeek.Monday) { date2 = date2.AddDays(-1); }
            if (date1 >= date2) { return 0; }
            return (date2 - date1).Days / 7;
        }
    }
}
