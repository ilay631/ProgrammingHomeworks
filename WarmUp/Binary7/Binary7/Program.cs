using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Binary7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number N");
            if (!InputPosInt(out int N)) {
                return;
            }
            Console.WriteLine("Enter the number M");
            if (!InputPosInt(out int M)) {
                return;
            }

            if (!GenerateNumbers(N, M)) {
                Console.WriteLine("There is no such numbers");
            }

            Console.ReadLine();
        }


        static bool InputPosInt(out int value)
        {
            if (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("[ERROR]: Invalid input");
                Console.ReadLine();
                return false;
            }
            if (value < 0)
            {
                Console.WriteLine("[ERROR]: Invalid input");
                Console.ReadLine();
                return false;
            }
            return true;
        }

        static bool GenerateNumbers(int N, int M)
        {
            bool fl = false;
            for (int i = 0; i < N; i++) {
                string Binary = Convert.ToString(i, 2);
                if (Binary.Count(f => (f == '1')) >= M) {
                    fl = true;
                    Console.WriteLine("{0} - {1}", i, Binary);
                }
            }
            return fl;
        }
    }
}
