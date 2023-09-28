using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using System.Globalization;

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
                        return "un";
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
                        return "veintiún";
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

        /// <summary>
        /// This constructor initializes the new Point to
        /// (<paramref name="xPosition"/>,<paramref name="yPosition"/>).
        /// </summary>
        public static string GetSpanish3Digit(uint num, Gender gen)
        {

            string[] spanishHundredsMale = { "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };
            string[] spanishHundredsFemale = { "ciento", "doscientas", "trescientas", "cuatrocientas", "quinientas", "seiscientas", "setecientas", "ochocientas", "novecientas" };
            if (num == 100)
                return "cien";

            uint hundred = num / 100;
            uint dozens = num % 100 / 10;
            uint units = num % 10;

            if (dozens == 0 && units == 0) { 
                if (gen == Gender.Feminine)
                    return spanishHundredsFemale[hundred - 1];
                else
                    return spanishHundredsMale[hundred - 1];
            }
            else if (dozens == 0) {
                if (gen == Gender.Feminine)
                    return spanishHundredsFemale[hundred - 1] + " " + GetSpanishDigit(units, gen);
                else
                    return spanishHundredsMale[hundred - 1] + " " + GetSpanishDigit(units, gen);
            }
            else
            {
                if (gen == Gender.Feminine)
                    return spanishHundredsFemale[hundred - 1] + " " + GetSpanish2Digit(num % 100, gen);
                else
                    return spanishHundredsMale[hundred - 1] + " " + GetSpanish2Digit(num % 100, gen);
            }
        }

        public static string GetSpanishNumber(uint num, Gender gen)
        {
            if (num >= 100)
                return GetSpanish3Digit(num, gen);
            else if (num >= 10 && num < 100)
                return GetSpanish2Digit(num, gen);
            else
                return GetSpanishDigit(num, gen);
        }

        public static string TranslateToSpanish(uint num, Gender gen)
        {
            if (num == 0)
                return "cero";

            uint millions = num / 1000000;
            uint thousands = num % 1000000 / 1000;
            uint units = num % 1000;

            string res = "";

            if (millions == 1)
                res += "un millón";
            else if (millions > 1)
                res += GetSpanishNumber(millions, Gender.Masculine) + " millones";

            if (millions != 0 && (thousands != 0 || units != 0))
                res += " ";

            if (thousands == 1)
                res += "mil";
            else if (thousands > 1)
                if (gen == Gender.Masculine || gen == Gender.Neuter)
                    res += GetSpanishNumber(thousands, Gender.Masculine) + " mil";
                else
                    res += GetSpanishNumber(thousands, gen) + " mil";

            if (thousands != 0 && units != 0)
                res += " ";

            if (units != 0)
                if (gen == Gender.Masculine)
                    res += GetSpanishNumber(units, Gender.Neuter);
                else
                    res += GetSpanishNumber(units, gen);
            return res;
        }
    }
}
