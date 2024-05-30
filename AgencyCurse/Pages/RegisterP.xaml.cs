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

namespace AgencyCurse.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegisterP.xaml
    /// </summary>
    public partial class RegisterP : Page
    {
        users context;
        public RegisterP()
        {
            InitializeComponent();
            context = new users();
            DataContext = context;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }

        private void RegBT_Click(object sender, RoutedEventArgs e)
        {
            var tryRegister = App.DB.users.Where(a => a.login == context.login);
            if (tryRegister.Any())
            {
                MessageBox.Show("Данный логин уже занят");
            }
            else
            {
                context.idRole = 1;
                context.idDiscount = 1;
                context.balance = 0;
                try
                {
                    App.DB.users.Add(context);
                    App.DB.SaveChanges();
                    NavigationService.Navigate(new LoginP());
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так");
                }
            }
        }
    }
}
