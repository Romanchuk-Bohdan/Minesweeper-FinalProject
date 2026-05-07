using System;
using System.Collections.Generic;

namespace WindowsFormsApp1.Core
{
    public class Profile
    {
        public string Name { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int TotalTimePlayedSeconds { get; set; }
        public Dictionary<Difficulty, int> BestTimes { get; set; }

        public Profile() { }

        public Profile(string name)
        {
            Name = name;
            GamesPlayed = 0;
            GamesWon = 0;
            TotalTimePlayedSeconds = 0;
            BestTimes = new Dictionary<Difficulty, int>
            {
                { Difficulty.Easy, int.MaxValue },
                { Difficulty.Medium, int.MaxValue },
                { Difficulty.Hard, int.MaxValue }
            };
        }

        public double GetWinRate()
        {
            if (GamesPlayed == 0) return 0;
            return Math.Round((double)GamesWon / GamesPlayed * 100, 2);
        }
    }
}