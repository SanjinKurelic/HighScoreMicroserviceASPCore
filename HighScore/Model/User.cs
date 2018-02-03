using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighScore.Model
{
    public class User
    {
        [JsonProperty("id")]
        public int UserID { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("country")]
        public String Country { get; set; }

        public override bool Equals(object obj)
        {
            if(obj.GetType() != typeof(User))
            {
                return false;
            }
            return ((User) obj).UserID == UserID;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
