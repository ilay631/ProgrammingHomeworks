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

        static string InverseBinary(string s)
        {
            string InvStr = "";
            foreach (char c in s) {
                if (c == '1') { InvStr += '0'; }
                else { InvStr += '1'; }
            }
            return InvStr;
        }

        static string GenerateThueMorse(int N, string CurNum = "0")
        {
            if (N == 0) { return CurNum; }
            return GenerateThueMorse(N - 1, CurNum + InverseBinary(CurNum));
        }

        static StringBuilder InverseBinarySB(StringBuilder SB)
        {
            StringBuilder InvSB = new StringBuilder();
            for (int i = 0; i < SB.Length; i++)
            {
                if (SB[i] == '1') { InvSB.Append('0'); }
                else { InvSB.Append('1'); }
            }
            return InvSB;
        }

        static StringBuilder ThueMorseSB(int N, StringBuilder SB) 
        {
            if (N == 0) { return SB; }    
            SB.Append(InverseBinarySB(SB));
            return ThueMorseSB(N - 1, SB);
        }

        static string GenerateThueMorseSB(int N)
        {
            StringBuilder SB = new StringBuilder("0");
            return ThueMorseSB(N, SB).ToString();
        }
    }
}
