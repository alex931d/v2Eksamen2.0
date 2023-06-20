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
    /// Interaction logic for returnsPage.xaml
    /// </summary>
    public partial class returnsPage : Page
    {
        controller CT = new controller();
        database data = new database();
        public returnsPage()
        {
            InitializeComponent();
            datagridUsers.SelectionChanged += DataGrid_SelectionChanged;
            updateUi();
        }
        public void updateUi()
        {

            CT.GetData<Users>(datagridUsers, data.getUsers);
        }
        


           private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
           {
      
            if (datagridUsers.SelectedItem != null)
            {
  
                OnRowSelected();
            }

           }

     
        private void OnRowSelected()
        {
            Users selectedUser = (Users)datagridUsers.SelectedItem;
            CT.GetLendingData(datagridLendings, selectedUser.UserId);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            lending selectedLending = (lending)datagridLendings.SelectedItem;
            if (selectedLending != null)
            {
                data.deleteLending(selectedLending);
                Users selectedUser = (Users)datagridUsers.SelectedItem;
                CT.GetLendingData(datagridLendings, selectedUser.UserId);
                MessageBox.Show("the current lending has been returned!");
            }
            else
            {
                MessageBox.Show("no lendings to return");
            }
        }
    }
}
