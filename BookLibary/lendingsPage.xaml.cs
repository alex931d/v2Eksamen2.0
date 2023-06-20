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
    /// Interaction logic for lendingsPage.xaml
    /// </summary>
    public partial class lendingsPage : Page
    {
        database data = new database();
        controller CT = new controller();
        public lendingsPage()
        {
            InitializeComponent();
            CT.GetData<Users>(datagridUsers, data.getUsers);
            CT.GetData<Books>(reservateBooks, data.getBooks);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Users selectedUser = (Users)datagridUsers.SelectedItem;
            Books selectedPitch = (Books)reservateBooks.SelectedItem;
            if (selectedUser != null && selectedPitch != null)
            {
            int amount = int.Parse(amountBox.Text.ToString());
            lending newlending = new lending(0,DateTime.Now,selectedUser.UserId,selectedPitch.BookTitle,amount);
                try
                {
                    if (CT.addlend(newlending, selectedUser.UserId))
                    {
                        MessageBox.Show("sucessfully lended the book!" +  " " + "you have 30 days to return the book");
                    }
                    else
                    {
                        MessageBox.Show("unsucessful something happened!");
                    }
                 
                    selectedUser = null;
                    selectedPitch = null;
                }
                catch (Exception)
                {

                    throw;
                }
          
            
            }
            
           
        }
    }
}
