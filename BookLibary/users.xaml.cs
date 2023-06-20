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
    /// Interaction logic for users.xaml
    /// </summary>
    public partial class users : Page
    {
        database data = new database();
        public users()
        {
            InitializeComponent();
            updateUi();
        }
        public void updateUi()
        {
            usersGrid.ItemsSource = data.getUsers();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Users selectedUser = (Users)usersGrid.SelectedItem;
            if (selectedUser != null)
            {
                data.deleteUser(selectedUser);
                updateUi();
            }
            else
            {
                MessageBox.Show("no selected row");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string id = IdBox.Text.ToString();
            string password = passwordsBox.Text.ToString();
            Users newuser = new Users(0, id, password);
            data.AddUser(newuser);
            updateUi();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Users selectedUser = (Users)usersGrid.SelectedItem;
            if (selectedUser != null)
            {
                string id = IdBox.Text.ToString();
                string password = passwordsBox.Text.ToString();
                data.updateUser(selectedUser, id, password);
                updateUi();
            }
            else
            {
                MessageBox.Show("no selected row");
            }
        }
    }
}
