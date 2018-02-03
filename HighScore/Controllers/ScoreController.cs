using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HighScore.DAO;
using HighScore.Helper;
using HighScore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighScore.Controllers
{
    [Produces("application/json")]
    [Route("api/score")]
    public class ScoreController : Controller
    {
        // GET: api/score
        [HttpGet]
        public IEnumerable<Score> Get()
        {
            // Global
            return ScoreDatabase.GetScores().OrderByDescending(s => s.Value);
        }

        // GET: api/score/hr
        [HttpGet("{country}")]
        public IEnumerable<Score> Get(string country)
        {
            // Local
            return ScoreDatabase.GetScoreByCountry(country).OrderByDescending(s => s.Value);
        }
        
        // POST: api/score
        [HttpPost]
        public void Post([FromForm] int score, [FromForm] int userID)
        {
            Score s = new Score();
            s.Value = score;

            // Get user data form User microservice
            s.User = RequestHelper.GetUserFromUrl("http://localhost:55555/api/user/" + userID.ToString());

            ScoreDatabase.AddScore(s);
        }

        [HttpGet]
        [Route("position/{id}")]
        public JsonResult Position(int id)
        {
            var scores = ScoreDatabase.GetScores().OrderByDescending(s => s.Value);
            int position = 0;

            foreach(var score in scores)
            {
                position++;
                if(score.User.UserID == id)
                {
                    break;
                }
            }

            return Json(new { userPosition = position });
        }

        [HttpGet]
        [Route("position/{id}/{country}")]
        public JsonResult Position(int id, string country)
        {
            var scores = ScoreDatabase.GetScoreByCountry(country).OrderByDescending(s => s.Value);
            int position = 0;

            foreach (var score in scores)
            {
                position++;
                if (score.User.UserID == id)
                {
                    break;
                }
            }

            return Json(new { userPosition = position });
        }

    }
}
