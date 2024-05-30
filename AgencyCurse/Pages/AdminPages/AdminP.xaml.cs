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

namespace AgencyCurse.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminP.xaml
    /// </summary>
    public partial class AdminP : Page
    {
        public AdminP()
        {
            InitializeComponent();
            if (App.DB.notification.Where(a => a.isRead == false).Any())
            {
                NotBT.Background = Brushes.AliceBlue;
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }

        private void TuorsBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ToursP());
        }

        private void HotelsBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HotelP());

        }

        private void NotBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RequestP());
        }

        private void HystoryBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HystP());
        }
    }
}
