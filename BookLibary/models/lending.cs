using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibary
{
   public class lending
    {
       int Lendings_ID;
       DateTime Lendings_Date;
       int Lendings_User;
       string Lendings_Book;
       int Lendings_Count;

        public lending(int lendings_ID, DateTime lendings_Date, int lendings_User, string lendings_Book, int lendings_Count)
        {
            Lendings_ID = lendings_ID;
            Lendings_Date = lendings_Date;
            Lendings_User = lendings_User;
            Lendings_Book = lendings_Book;
            Lendings_Count = lendings_Count;
        }

        public int Lendings_ID1 { get => Lendings_ID; set => Lendings_ID = value; }
        public DateTime Lendings_Date1 { get => Lendings_Date; set => Lendings_Date = value; }
        public int Lendings_User1 { get => Lendings_User; set => Lendings_User = value; }
        public string Lendings_Book1 { get => Lendings_Book; set => Lendings_Book = value; }
        public int Lendings_Count1 { get => Lendings_Count; set => Lendings_Count = value; }
    }
}
