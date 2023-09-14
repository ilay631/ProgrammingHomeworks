using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stack1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the length of stack");
            if (!InputPosInt(out int length)) { return; }
            CreateStack(length, out int[] stack, out int count);
            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("Commands: push, pop, exit");
                string com = Console.ReadLine();
                switch (com) {
                    case "push":
                        Console.WriteLine("Enter value");
                        if (!int.TryParse(Console.ReadLine(), out int value))
                        {
                            Console.WriteLine("[ERROR]: Invalid input");
                        }
                        else
                        {
                            if (Push(ref stack, ref count, value))
                            {
                                Console.WriteLine("Pushed");
                            }
                            else { Console.WriteLine("[ERROR]: Stack is full"); }
                        }
                        break;
                    case "pop":
                        int? res = Pop(ref stack, ref count);
                        if (res == null) 
                        {
                            Console.WriteLine("[ERROR]: Stack is empty");
                        }
                        else
                        {
                            Console.WriteLine("Pop: {0}", res);
                        }
                        break;
                    case "exit":
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Wrong command");
                        break;
                }
            }
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

        static void CreateStack(int length, out int[] stack, out int count)
        {
            stack = new int[length];
            count = 0;
        }

        static bool Push(ref int[] stack, ref int count, int value)
        {
            if (stack.Length == count) { return false; }
            stack[count] = value;
            count++;
            return true;
        }

        static int? Pop(ref int[] stack, ref int count)
        {
            if (count == 0) { return null; }
            count--;
            return stack[count];
        }
    }
}
