using BookLibary.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookLibary
{
    /// <summary>
    /// Interaction logic for booksPage.xaml
    /// </summary>
    public partial class booksPage : Page
    {
        controller CT = new controller();
        database data = new database();
        public booksPage()
        {
            InitializeComponent();
            updateUi();
        }
        public void updateUi()
        {
            CT.GetData<Books>(BooksGrid, data.getBooks);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Books selectedBook = (Books)BooksGrid.SelectedItem;
            if (selectedBook != null)
            {
                data.deleteBook(selectedBook);
                updateUi();
            }
            else
            {
                MessageBox.Show("no selected row");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DateTime? date = datepickerYear.SelectedDate;
            string author = authorBox.Text.ToString();
            string title = titleBox.Text.ToString();
            string publisher = publisherBox.Text.ToString();
            DateTime year = date.Value;
   
            int count = int.Parse(countBox.Text.ToString());
            string ISBN = ISBNBox.Text.ToString();
            Books newuser = new Books(0,author,title,publisher,year,count,ISBN);
            data.addBooks(newuser);
            updateUi();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Books selectedBook = (Books)BooksGrid.SelectedItem;
            DateTime? date = datepickerYear.SelectedDate;
            if (selectedBook != null)
            {

                string author = authorBox.Text.ToString();
                string title = titleBox.Text.ToString();
                string publisher = publisherBox.Text.ToString();
                DateTime year = date.Value;
                int count = int.Parse(countBox.Text.ToString());
                string ISBN = ISBNBox.Text.ToString();
                data.updateBook(selectedBook,author,title,publisher,year,count,ISBN);
                updateUi();
            }
            else
            {
                MessageBox.Show("no selected row");
            }
        }
    }
}
