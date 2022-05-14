using System.Text;
using NUnit.Framework;

namespace NUnitTestProject20220513
{
    public class TennisKata
    {
        private Tennis _tennis;

        [SetUp]
        public void Setup()
        {
            _tennis = new Tennis();
        }

        [Test]
        public void love_all()
        {
            ScoreShouldBe("love all");
        }

        [Test]
        public void fifteen_love()
        {
            GivenFirstPlayerScoreTimes(1);
            ScoreShouldBe("fifteen love");
        }


        [Test]
        public void thirty_love()
        {
            GivenFirstPlayerScoreTimes(2);
            ScoreShouldBe("thirty love");
        }

        [Test]
        public void forty_love()
        {
            GivenFirstPlayerScoreTimes(3);
            ScoreShouldBe("forty love");
        }

        [Test]
        public void love_fifteen()
        {
            GivenSecondPlayerScoreTimes(1);
            ScoreShouldBe("love fifteen");
        }

        [Test]
        public void love_thirty()
        {
            GivenSecondPlayerScoreTimes(2);
            ScoreShouldBe("love thirty");
        }

        private void GivenSecondPlayerScoreTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _tennis.SecondPlayerScore();
            }
        }

        [Test]
        public void love_forty()
        {
            GivenSecondPlayerScoreTimes(3);
            ScoreShouldBe("love forty");
        }

        [Test]
        public void fifteen_all()
        {
            GivenFirstPlayerScoreTimes(1);
            GivenSecondPlayerScoreTimes(1);
            ScoreShouldBe("fifteen all");
        }

        private void GivenFirstPlayerScoreTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _tennis.FirstPlayerScore();
            }
        }


        private void ScoreShouldBe(string expected)
        {
            Assert.AreEqual(expected, _tennis.Score());
        }
    }
}