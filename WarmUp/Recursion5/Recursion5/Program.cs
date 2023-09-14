using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first move option");
            Console.WriteLine("Enter N1 (Black balls)");
            if (!InputPosInt(out int N1)) {
                return;
            }
            Console.WriteLine("Enter M1 (White balls)");
            if (!InputPosInt(out int M1))
            {
                return;
            }
            Console.WriteLine("Enter the second move option");
            Console.WriteLine("Enter N2 (Black balls)");
            if (!InputPosInt(out int N2))
            {
                return;
            }
            Console.WriteLine("Enter M2 (White balls)");
            if (!InputPosInt(out int M2))
            {
                return;
            }
            Console.WriteLine("Enter the desired outcome");
            Console.WriteLine("Enter N3 (Black balls)");
            if (!InputPosInt(out int N3))
            {
                return;
            }
            Console.WriteLine("Enter M3 (White balls)");
            if (!InputPosInt(out int M3))
            {
                return;
            }
            Console.WriteLine("Enter the number of moves");
            if (!InputPosInt(out int K))
            {
                return;
            }

            Console.WriteLine(Solution(N1, M1, N2, M2, N3, M3, K));

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

        static bool Solution(int N1, int M1, int N2, int M2, int N3, int M3, int K, int White = 0, int Black = 0)
        {
            if (K == 0)
            {
                return White == M3 && Black == N3;
            }
            return Solution(N1, M1, N2, M2, N3, M3, K - 1, White + M1, Black + N1) || Solution(N1, M1, N2, M2, N3, M3, K - 1, White + M2, Black + N2);
        }
    }
}
