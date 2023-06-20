using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using OxyPlot;
using OxyPlot.Series;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OxyPlot.Axes;
using BookLibary.controllers;

namespace BookLibary
{
    /// <summary>
    /// Interaction logic for users.xaml
    /// </summary>
    public partial class overviewPage : Page
    {
        controller CT = new controller();
        database data = new database();
        public overviewPage()
        {
            InitializeComponent();
            var userData = data.GetUserCounts();
            var bookData = data.GetBookCounts();
     
            var plotModel = new PlotModel
            {
                Title = "Book and User Statistics"
            };
            var plotModel2 = new PlotModel
            {
                Title = "Book and User Statistics"
            };
            var userSeries = new BarSeries
            {
                Title = "Users",
                StrokeColor = OxyColors.Black,
                FillColor = OxyColors.LightGreen
            };
            var bookSeries = new BarSeries
            {
                Title = "Books",
                StrokeColor = OxyColors.Black,
                FillColor = OxyColors.LightGreen
            };
            foreach (var book in bookData)
            {
                bookSeries.Items.Add(new BarItem { Value = book.Count });
            }
            foreach (var user in userData)
            {
                userSeries.Items.Add(new BarItem { Value = user.Count });
            }

            plotModel.Series.Add(userSeries);
            plotModel2.Series.Add(bookSeries);

            usersGraph.Model = plotModel;
            booksGraph.Model = plotModel2;
        }




        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return; 

            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            if (selectedItem.Content == null)
                return; 

            string selectedOption = selectedItem.Content.ToString();
            switch (selectedOption)
            {
                case "users":
                    bool successUsers = CT.GetData<Users>(datagrid, data.getUsers);
                    numberBox.Visibility = Visibility.Hidden;
                    numberLbl.Visibility = Visibility.Hidden;
                    numberbtn.Visibility = Visibility.Hidden;
                    break;
                case "books":
                    bool successBooks = CT.GetData<Books>(datagrid, data.getBooks);
                    numberBox.Visibility = Visibility.Hidden;
                    numberLbl.Visibility = Visibility.Hidden;
                    numberbtn.Visibility = Visibility.Hidden;
                    break;
                case "lends":
                    List<lending> lendingData = CT.GetLendingData(3);
                    datagrid.ItemsSource = lendingData;
                    numberBox.Visibility = Visibility.Visible;
                    numberLbl.Visibility = Visibility.Visible;
                    numberbtn.Visibility = Visibility.Visible;
                    break;
                case "expired lends":
                    List<lending> lendingData1 = CT.GetLendingData(3);
                    numberBox.Visibility = Visibility.Visible;
                    numberLbl.Visibility = Visibility.Visible;
                    numberbtn.Visibility = Visibility.Visible;
                    List<lending> lendingPast = new List<lending>();
                    foreach (var lending in lendingData1)
                    {
                        if (CT.CheckIfUserCanLend(lending))
                        {
                            lendingPast.Add(lending);
                        }
                    }
                    datagrid.ItemsSource = lendingPast;
                    numberBox.Visibility = Visibility.Hidden;
                    numberLbl.Visibility = Visibility.Hidden;
                    numberbtn.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }
        }

        private void numberbtn_Click(object sender, RoutedEventArgs e)
        {
            if (numberBox.Text.Length > 0)
            {
                List<lending> lendingData = CT.GetLendingData(int.Parse(numberBox.Text));
                datagrid.ItemsSource = lendingData;
            }
           
        }
    }
}
