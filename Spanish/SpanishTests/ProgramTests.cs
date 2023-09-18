using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spanish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using System.Globalization;

namespace Spanish.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetSpanishDigitMasculineTest()
        {
            // Arrange
            string[] expected = new string[10];
            for (int i = 0; i < expected.Length; i++)
                expected[i] = i.ToWords(GrammaticalGender.Masculine, new CultureInfo("es-SP"));

            // Act
            string[] res = new string[10];
            for (uint i = 0; i < res.Length; i++)
                res[i] = Program.GetSpanishDigit(i, Program.Gender.Masculine);

            // Assert
            CollectionAssert.AreEqual(expected, res);
        }

        [TestMethod()]
        public void GetSpanishDigitFeminineTest()
        {
            // Arrange
            string[] expected = new string[10];
            for (int i = 0; i < expected.Length; i++)
                expected[i] = i.ToWords(GrammaticalGender.Feminine, new CultureInfo("es-SP"));

            // Act
            string[] res = new string[10];
            for (uint i = 0; i < res.Length; i++)
                res[i] = Program.GetSpanishDigit(i, Program.Gender.Feminine);

            // Assert
            CollectionAssert.AreEqual(expected, res);
        }

        [TestMethod()]
        public void GetSpanishDigitNeuterTest()
        {
            // Arrange
            string[] expected = new string[10];
            for (int i = 0; i < expected.Length; i++)
                expected[i] = i.ToWords(GrammaticalGender.Neuter, new CultureInfo("es-SP"));

            // Act
            string[] res = new string[10];
            for (uint i = 0; i < res.Length; i++)
                res[i] = Program.GetSpanishDigit(i, Program.Gender.Neuter);

            // Assert
            CollectionAssert.AreEqual(expected, res);
        }

        [TestMethod()]
        public void GetSpanish2DigitMasculineTest()
        {
            // Arrange
            string[] expected = new string[90];
            for (int i = 0; i < expected.Length; i++)
                expected[i] = (i + 10).ToWords(GrammaticalGender.Masculine, new CultureInfo("es-SP"));

            // Act
            string[] res = new string[90];
            for (uint i = 0; i < res.Length; i++)
                res[i] = Program.GetSpanish2Digit(i + 10, Program.Gender.Masculine);

            for (int i = 0; i < res.Length; i++)
            {
                Console.WriteLine("{0} - {1} - {2}", i + 10, expected[i], res[i]);
            }

            // Assert
            CollectionAssert.AreEqual(expected, res);
        }

        [TestMethod()]
        public void GetSpanish2DigitNeuterTest()
        {
            // Arrange
            string[] expected = new string[90];
            for (int i = 0; i < expected.Length; i++)
                expected[i] = (i + 10).ToWords(GrammaticalGender.Neuter, new CultureInfo("es-SP"));

            // Act
            string[] res = new string[90];
            for (uint i = 0; i < res.Length; i++)
                res[i] = Program.GetSpanish2Digit(i + 10, Program.Gender.Neuter);

            // Assert
            CollectionAssert.AreEqual(expected, res);
        }

        [TestMethod()]
        public void GetSpanish2DigitFeminineTest()
        {
            // Arrange
            string[] expected = new string[90];
            for (int i = 0; i < expected.Length; i++)
                expected[i] = (i + 10).ToWords(GrammaticalGender.Feminine, new CultureInfo("es-SP"));

            // Act
            string[] res = new string[90];
            for (uint i = 0; i < res.Length; i++)
                res[i] = Program.GetSpanish2Digit(i + 10, Program.Gender.Feminine);

            // Assert
            CollectionAssert.AreEqual(expected, res);
        }
    }
}