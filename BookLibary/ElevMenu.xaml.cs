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
    /// Interaction logic for ElevMenu.xaml
    /// </summary>
    public partial class ElevMenu : Window
    {
        public ElevMenu()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string buttonText = clickedButton.Content.ToString();


            switch (buttonText)
            {
                case "lending":
                    contentFrame.Navigate(new Uri("ElevPage.xaml", UriKind.Relative));
                    break;
                case "return":
                    contentFrame.Navigate(new Uri("ElevPage.xaml", UriKind.Relative));
                    break;

            }
        }
        private void contentFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

    }
}
