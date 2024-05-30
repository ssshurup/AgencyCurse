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

namespace AgencyCurse.Pages.UserPages
{
    /// <summary>
    /// Логика взаимодействия для UserP.xaml
    /// </summary>
    public partial class UserP : Page
    {
        public UserP()
        {
            InitializeComponent();
            BalTB.Text += App.LoggedUser.balance;
        }

        private void TuorsBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TourUserP());
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }

        private void MyToursBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MyToursP());
        }

        private void DiscBT_Click(object sender, RoutedEventArgs e)
        {
            if(App.LoggedUser.idDiscount != 1)
            {
                MessageBox.Show("У вас уже действует " + App.LoggedUser.discount.description);
            }else NavigationService.Navigate(new DiscountUserP());

        }

        private void ИфдфтсуИЕ_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BalanceP());
        }
    }
}
