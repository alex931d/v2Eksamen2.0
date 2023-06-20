using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibary
{
    public class Users
    {
        int userId;
        string username;
        string password;

        public Users(int userId, string username, string password)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
        }

        public int UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
