using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibary
{
    public class BookCount
    {
        string book;
        int count;

        public BookCount(string book, int count)
        {
            this.book = book;
            this.count = count;
        }

        public string Book { get => book; set => book = value; }
        public int Count { get => count; set => count = value; }
    }
}
