using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the dimension of the matrix (rows, columns)");
            int[] Dim = new int[2];
            if (!InputFewIntFromStr(2, out Dim)) { return; }
            int N = Dim[0], M = Dim[1];
            if (N <= 0 || M <= 0 || N % 2 != 0 || M % 2 != 0) {
                Console.WriteLine("[ERROR] Invalid input");
                Console.ReadLine();
                return; 
            }
            int[,] Matrix = new int[N, M];
            if (!InputMatrix(N, M, out Matrix)) { return; }

            Console.WriteLine(Solution(Matrix));

            Console.ReadLine();
        }

        static bool InputMatrix(int N, int M, out int[,] Matrix)
        {
            Matrix = new int[N, M];
            for (int i = 0; i < N; i++) {
                int[] row = new int[M];
                if (!InputFewIntFromStr(M, out row)) { return false; }
                for (int j = 0; j < M; j++) {
                    Matrix[i, j] = row[j];
                }
            }
            return true;
        }

        static bool InputFewIntFromStr(int n, out int[] values)
        {
            values = new int[n];
            string[] strings = Console.ReadLine().Split();
            if (strings.Length != n) {
                Console.WriteLine("[ERROR] Invalid input");
                Console.ReadLine();
                return false;
            }
            for (int i = 0; i < n; i++) { 
                if (!int.TryParse(strings[i], out values[i])) {
                    Console.WriteLine("[ERROR]: Invalid input");
                    Console.ReadLine();
                    return false;
                }
            }
            return true;
        }

        static int Solution(int[,] Matrix) 
        {
            int LeftUpQuarterSum = 0;
            for (int i = 0; i < Matrix.GetLength(0) / 2; i++)
            {
                for (int j = 0; j < Matrix.GetLength(1) / 2; j++)
                {
                    LeftUpQuarterSum += Matrix[i, j];
                }
            }
            int RightDownQuarterSum = 0;
            for (int i = Matrix.GetLength(0) / 2; i < Matrix.GetLength(0); i++)
            {
                for (int j = Matrix.GetLength(1) / 2; j < Matrix.GetLength(1); j++)
                {
                    RightDownQuarterSum += Matrix[i, j];
                }
            }
            return LeftUpQuarterSum - RightDownQuarterSum;
        }
    }
}
