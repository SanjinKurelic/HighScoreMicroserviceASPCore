using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighScore.Model
{
    public class Score
    {
        [JsonProperty("score")]
        public int Value { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

    }
}
