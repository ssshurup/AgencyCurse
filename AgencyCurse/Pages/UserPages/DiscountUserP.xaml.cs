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
    /// Логика взаимодействия для DiscountUserP.xaml
    /// </summary>
    public partial class DiscountUserP : Page
    {
        notification context;
        public DiscountUserP()
        {
            InitializeComponent();
            DiscountCB.ItemsSource = App.DB.discount.ToList();
            context = new notification();
            DataContext = context;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserP());
        }

        private void BuyBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.isRead = false;
                context.idUser = App.LoggedUser.id;
               
                App.DB.notification.Add(context);
                App.DB.SaveChanges();
                NavigationService.Navigate(new UserP());
            }
            catch
            {
            MessageBox.Show("что-то пошло не так");

            }
        }
    }
}
