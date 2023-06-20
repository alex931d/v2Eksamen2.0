using BookLibary.controllers;
using BookLibary.models;
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
    /// Interaction logic for ElevPage.xaml
    /// </summary>
    public partial class ElevPage : Page
    {
        database data = new database();
        controller CT = new controller();
        int userId = Global.UserId;
        public ElevPage()
        {
            InitializeComponent();
            greeting.Content = Global.name;
            CT.GetData<Books>(reservateBooks, data.getBooks);
            returnBooksData.ItemsSource = data.GetUserLendings(Global.UserId);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loginScreen productsApp = new loginScreen();
            productsApp.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Books selectedPitch = (Books)reservateBooks.SelectedItem;
            if ( selectedPitch != null)
            {
                int amount = int.Parse(amountBox.Text.ToString());
                lending newlending = new lending(0, DateTime.Now, Global.UserId, selectedPitch.BookTitle, amount);
                try
                {
                    if (CT.addlend(newlending, Global.UserId))
                    {
                        MessageBox.Show("sucessfully lended the book!" + " " + "you have 30 days to return the book");
                        returnBooksData.ItemsSource = data.GetUserLendings(Global.UserId);
                    }
                    else
                    {
                        MessageBox.Show("unsucessful something happened!");
                    }

                    selectedPitch = null;
                }
                catch (Exception)
                {

                    throw;
                }


            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            lending selectedLending = (lending)returnBooksData.SelectedItem;
            if (selectedLending != null)
            {
                data.deleteLending(selectedLending);
                returnBooksData.ItemsSource = data.GetUserLendings(Global.UserId);
                CT.GetData<Books>(reservateBooks, data.getBooks);
            }
        }
    }
}
