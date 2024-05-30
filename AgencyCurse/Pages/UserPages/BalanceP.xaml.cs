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
    /// Логика взаимодействия для BalanceP.xaml
    /// </summary>
    public partial class BalanceP : Page
    {
        public BalanceP()
        {
            InitializeComponent();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserP());
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(Convert.ToInt32(BalTB.Text) <= 0)
                {
                    MessageBox.Show("Введите сумму больше 0");
                    return;
                }
                App.LoggedUser.balance += Convert.ToInt32(BalTB.Text);
                App.DB.SaveChanges();
                NavigationService.Navigate(new UserP());
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }
    }
}
