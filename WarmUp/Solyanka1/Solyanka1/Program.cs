using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solyanka1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number N");
            if (!InputPosInt(out int N)) { return; }

            Console.WriteLine(GenerateThueMorseSB(N));
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

        static StringBuilder ThueMorseSB(int N, StringBuilder SB)
        {
            while (N > SB.Length)
            {
                int len = SB.Length;
                for (int i = 0; i < len; i++)
                {
                    if (SB[i] == '1') { SB.Append('0'); }
                    else { SB.Append('1'); }
                    if (SB.Length == N) { break; }
                }
            }
            return SB;
        }

        static string GenerateThueMorseSB(int N)
        {
            StringBuilder SB = new StringBuilder("0");
            return ThueMorseSB(N, SB).ToString();
        }
    }
}
