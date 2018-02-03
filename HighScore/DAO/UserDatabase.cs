using HighScore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighScore.DAO
{
    public class UserDatabase
    {

        private static List<User> users;
        private static int lastId;

        static UserDatabase()
        {
            if (users == null)
            {
                lastId = 0;
                // Random data
                users = new List<User>
                {
                    new User { UserID = lastId++, Name = "Player 1", Country = "US" },
                    new User { UserID = lastId++, Name = "Player 2", Country = "US" },
                    new User { UserID = lastId++, Name = "Player 3", Country = "US" },
                    new User { UserID = lastId++, Name = "Player 4", Country = "HR" },
                    new User { UserID = lastId++, Name = "Player 5", Country = "FR" },
                    new User { UserID = lastId++, Name = "Player 6", Country = "ES" },
                    new User { UserID = lastId++, Name = "Player 7", Country = "HR" }
                };
            }
        }

        public static User GetUser(int userID)
        {
            return users.Where(u => u.UserID == userID).FirstOrDefault();
        }

        public static IEnumerable<User> GetUserList()
        {
            return users;
        }

        public static IEnumerable<User> GetUserFromCountry(string country)
        {
            return users.Where(u => u.Country == country);
        }

        public static int AddUser(User user)
        {
            user.UserID = lastId++;
            users.Add(user);
            return user.UserID;
        }

        public static void RemoveUser(int userID)
        {
            users.Remove(new User { UserID = userID });
        }

    }
}
