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
    /// Логика взаимодействия для RequestP.xaml
    /// </summary>
    public partial class RequestP : Page
    {
        public RequestP()
        {
            InitializeComponent();
            RequestsDG.ItemsSource = App.DB.notification.Where(a => a.isRead == false).ToList();
        }

        private void ApproveBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedNot = RequestsDG.SelectedItem as notification;
            if (selectedNot != null)
            {
                selectedNot.users.idDiscount = selectedNot.idDiscout;
                selectedNot.isRead = true;
                App.DB.SaveChanges();
                RequestsDG.ItemsSource = App.DB.notification.Where(a => a.isRead == false).ToList();
                MessageBox.Show("Одобрено");
            }
            else MessageBox.Show("Выберите запрос");
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP()) ;
        }

        private void RefuseBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedNot = RequestsDG.SelectedItem as notification;
            if (selectedNot != null)
            {
                selectedNot.isRead = true;
                App.DB.SaveChanges();
                RequestsDG.ItemsSource = App.DB.notification.Where(a => a.isRead == false).ToList();
                MessageBox.Show("Отказано");
            }
            else MessageBox.Show("Выберите запрос");
        }
    }
}
