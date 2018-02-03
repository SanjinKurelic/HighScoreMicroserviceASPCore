using HighScore.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HighScore.Helper
{
    public class RequestHelper
    {

        public static string ReadUrl(string url)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString(url);

            client.Dispose();
            return json;
        }

        public static User GetUserFromUrl(string url)
        {
            string json = ReadUrl(url);
            return JsonConvert.DeserializeObject<User>(json);
        }

    }
}
