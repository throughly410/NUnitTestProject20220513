using System.Text;
using NUnit.Framework;

namespace NUnitTestProject20220513
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("a","A")]
        [TestCase("123","1-22-333")]
        [TestCase("aDb2","A-dd-BBB-2222")]
        [TestCase("","")]
        [TestCase("  "," -  ")]
        public void Test_a_To_A(string input, string expected)
        {
            var stringTransformer = new StringTransformer();
            string actual = stringTransformer.Transform(input);
            Assert.AreEqual(expected, actual);
        }

    }

    public class StringTransformer
    {
        public string Transform(string input)
        {
            if (input.Length == 0)
            {
                return string.Empty;
            }

            string pattern = "{0}-";
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                int charAmount = i + 1;
                bool isEnglishCase = IsEnglishCase(currentChar);
                if (isEnglishCase)
                {
                    if (IsLowerCase(currentChar))
                    {
                        for (int j = 0; j < charAmount; j++)
                        {
                            result.Append(char.ToUpper(currentChar));
                        }
                    }
                    else
                    {
                        for (int j = 0; j < charAmount; j++)
                        {
                            result.Append(char.ToLower(currentChar));
                        }
                        
                    }
                }
                else
                {
                    for (int j = 0; j < charAmount; j++)
                    {
                        result.Append(currentChar);
                    }
                }
                result.Append("-");
            }

            return result.ToString().TrimEnd('-');
        }

        private bool IsEnglishCase(char c)
        {
            return (IsLowerCase(c) || IsUpperCase(c));
        }

        private bool IsLowerCase(char c)
        {
            return (c >= 'a' && c <= 'z');
        }

        private bool IsUpperCase(char c)
        {
            return (c >= 'A' && c <= 'Z');
        }
    }
}