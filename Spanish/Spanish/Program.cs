using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spanish
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number [0; 10^9]");
            if (!InputNumber(out int num)) { return; }

            Console.WriteLine(TranslateToSpanish(num));

            Console.ReadLine();
        }

        static bool InputNumber(out int value)
        {
            if (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("[ERROR]: Invalid input");
                Console.ReadLine();
                return false;
            }
            if (!(0 <= value && value <= Math.Pow(10, 9)))
            {
                Console.WriteLine("[ERROR]: Invalid input");
                Console.ReadLine();
                return false;
            }
            return true;
        }

        static string TranslateToSpanish(int num)
        {
            return "";
        }
    }
}
