using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BookLibary
{
    public class UserCount
    {
        string username;
        int count;

        public UserCount(string username, int count)
        {
            this.username = username;
            this.count = count;
        }

        public string Username { get => username; set => username = value; }
        public int Count { get => count; set => count = value; }  
       public bool Test(int value)
       {
        if (value > 10)
        {
            return true;
        }
        return false;
       }
    }
  
}
