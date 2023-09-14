using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to the file");
            string filePath = Console.ReadLine();
            if (!File.Exists(filePath)) {
                Console.WriteLine("Invalid filename");
                Console.ReadLine();
                return;
            }
            FileInfo info = new FileInfo(filePath);
            if (info.Extension != ".txt") {
                Console.WriteLine("Invalid filename");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Enter the string to replace");
            string oldStr = Console.ReadLine();
            Console.WriteLine("Enter a replacement");
            string newStr = Console.ReadLine();

            ReplaceInFile(filePath, oldStr, newStr);
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        static void ReplaceInFile(string filePath, string oldStr, string newStr)
        {
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++) {
                lines[i] = lines[i].Replace(oldStr, newStr);
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
