using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibary
{
    public class Books
    {
        int bookID;
        string bookAuthor;
        string bookTitle;
        string bookPublisher;
        DateTime bookYear;
        int booksCount;
        string booksISBN;

        public Books(int bookID, string bookAuthor, string bookTitle, string bookPublisher, DateTime bookYear, int booksCount, string booksISBN)
        {
            this.bookID = bookID;
            this.bookAuthor = bookAuthor;
            this.bookTitle = bookTitle;
            this.bookPublisher = bookPublisher;
            this.bookYear = bookYear;
            this.booksCount = booksCount;
            this.booksISBN = booksISBN;
        }

        public int BookID { get => bookID; set => bookID = value; }
        public string BookAuthor { get => bookAuthor; set => bookAuthor = value; }
        public string BookTitle { get => bookTitle; set => bookTitle = value; }
        public string BookPublisher { get => bookPublisher; set => bookPublisher = value; }
        public DateTime BookYear { get => bookYear; set => bookYear = value; }
        public int BooksCount { get => booksCount; set => booksCount = value; }
        public string BooksISBN { get => booksISBN; set => booksISBN = value; }
    }
}
