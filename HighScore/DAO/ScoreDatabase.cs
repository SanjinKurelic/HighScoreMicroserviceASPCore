using HighScore.Helper;
using HighScore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighScore.DAO
{
    public class ScoreDatabase
    {

        private static List<Score> scores;

        static ScoreDatabase()
        {
            if (scores == null)
            {
                // Random data
                scores = new List<Score>
                {
                    new Score {
                        Value = 15,
                        User = RequestHelper.GetUserFromUrl("http://localhost:55555/api/user/0")
                    },
                    new Score {
                        Value = 7,
                        User = RequestHelper.GetUserFromUrl("http://localhost:55555/api/user/1")
                    },
                    new Score {
                        Value = 23,
                        User = RequestHelper.GetUserFromUrl("http://localhost:55555/api/user/2")
                    },
                    new Score {
                        Value = 22,
                        User = RequestHelper.GetUserFromUrl("http://localhost:55555/api/user/3")
                    },
                    new Score {
                        Value = 18,
                        User = RequestHelper.GetUserFromUrl("http://localhost:55555/api/user/4")
                    },
                    new Score {
                        Value = 5,
                        User = RequestHelper.GetUserFromUrl("http://localhost:55555/api/user/5")
                    },
                };
            }
        }

        public static IEnumerable<Score> GetScores()
        {
            return scores;
        }

        public static IEnumerable<Score> GetScoreByCountry(string country)
        {
            return scores.Where(s => s.User.Country.ToLower() == country.ToLower());
        }

        public static void AddScore(Score score)
        {
            scores.Add(score);
        }

    }
}
