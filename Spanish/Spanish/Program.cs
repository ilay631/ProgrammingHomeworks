using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;


namespace Spanish
{
    public class Program
    {
        public enum Gender
        {
            Masculine,
            Feminine,
            Neuter
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter number [0; 10^9]");
            if (!InputNumber(out uint num)) { return; }
            Console.WriteLine("Enter gender (male, female, neutral)");
            switch (Console.ReadLine())
            {
                case "male":
                    Console.WriteLine(TranslateToSpanish(num, Gender.Masculine));
                    break;
                case "female":
                    Console.WriteLine(TranslateToSpanish(num, Gender.Feminine));
                    break;
                case "neutral":
                    Console.WriteLine(TranslateToSpanish(num, Gender.Neuter));
                    break;
                default:
                    Console.WriteLine("[ERROR] Invalid gender");
                    break;
            }

            Console.ReadLine();
        }

        static bool InputNumber(out uint value)
        {
            if (!uint.TryParse(Console.ReadLine(), out value))
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

        public static string GetSpanishDigit(uint digit, Gender gen)
        {
            string[] spanishDigits = { "cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
            if (digit == 1)
                switch(gen)
                {
                    case Gender.Masculine:
                        return "uno";
                    case Gender.Feminine:
                        return "una";
                    case Gender.Neuter:
                        return "uno";
                }
            return spanishDigits[digit];
        }

        public static string GetSpanish2Digit(uint num, Gender gen)
        {
            // From 10 to 29
            string[] spanish2Digits = { "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve", "veinte", "veintiuno", "veintidós", "veintitrés", "veinticuatro", "veinticinco", "veintiséis", "veintisiete", "veintiocho", "veintinueve" };
            string[] spanishDozens = { "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
            if (num == 21)
                switch (gen)
                {
                    case Gender.Masculine:
                        return "veintiuno";
                    case Gender.Feminine:
                        return "veintiuna";
                    case Gender.Neuter:
                        return "veintiuno";
                }
            if (num < 30)
                return spanish2Digits[num - 10];
            if (num % 10 == 0)
                return spanishDozens[num / 10 - 1];
            return spanishDozens[num / 10 - 1] + " y " + GetSpanishDigit(num % 10, gen);
        }

        static string TranslateToSpanish(uint num, Gender gen)
        {

            return "";
        }
    }
}
