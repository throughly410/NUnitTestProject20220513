using NUnit.Framework;

namespace NUnitTestProject20220513
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            int i = 0;
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}