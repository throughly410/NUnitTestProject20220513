using System.Collections.Generic;

namespace NUnitTestProject20220513
{
    public class Tennis
    {
        private int _firstPlayerScoreTimes = 0;
        private int _SecondPlayerScoreTimes = 0;

        private readonly Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
        {
            { 0, "love" },
            { 1, "fifteen" },
            { 2, "thirty" },
            { 3, "forty" },
        };

        public string Score()
        {
            if (_SecondPlayerScoreTimes != _firstPlayerScoreTimes)
            {
                return $"{_scoreLookup[_firstPlayerScoreTimes]} {_scoreLookup[_SecondPlayerScoreTimes]}";
            }

            if (_firstPlayerScoreTimes > 0)
            {
                return "fifteen all";
            }

            return "love all";
        }

        public void FirstPlayerScore()
        {
            _firstPlayerScoreTimes++;
        }

        public void SecondPlayerScore()
        {
            _SecondPlayerScoreTimes++;
        }
    }
}