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
using System.Windows.Shapes;

namespace BookLibary
{
    /// <summary>
    /// Interaction logic for loginScreen.xaml
    /// </summary>
    public partial class loginScreen : Window
    {
        database data = new database();
        controller CT = new controller();
        public loginScreen()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = username.Text.ToString();
            string password = pasword.Text.ToString();
            if (CT.TryLogin(login, password))
            {
                Close();
            }
            else
            {
                MessageBox.Show("worng password or username try again!");
            }
            
        }
    }
}
