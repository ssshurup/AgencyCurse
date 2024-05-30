using AgencyCurse;
using AgencyCurse.Pages.AdminPages;
using AgencyCurse.Pages.UserPages;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для TourUserP.xaml
    /// </summary>
    public partial class TourUserP : Page
    {
        public TourUserP()
        {
            InitializeComponent();
            ToursDG.ItemsSource = App.DB.tours.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var selectedTour = ToursDG.SelectedItem as tours;
            if (selectedTour != null)
            {
                if (App.LoggedUser.balance < selectedTour.price)
                {
                    MessageBox.Show("Недостаточно средств");
                }
                else
                {
                    NavigationService.Navigate(new BuyTourP(selectedTour));
                }
            }
            else MessageBox.Show("Выберите тур");
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserP());
        }

        private void AboutBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedTour = ToursDG.SelectedItem as tours;
            if (selectedTour != null)
            {
                string message = "";

                message += "Страна: " + selectedTour.city.country.name;
                message += "\nГород: " + selectedTour.city.name;
                message += "\nКол-во ночей: " + selectedTour.nightsCount;
                message += "\nКол-во взрослых: " + selectedTour.adultsCount;
                message += "\nКол-во детей: " + selectedTour.childsCount;
                message += "\nОтель: " + selectedTour.hotels.name;
                message += "\nПоездка: " + selectedTour.travelMethod.name;
                message += "\nЦена: " + selectedTour.price;
                if (selectedTour.hotels.isAllinClusive == true)
                {
                    message += "\nВсё включено: дa ";
                }
                else message += "\nВсё включено: нет ";

                MessageBox.Show(message);
            }
            else MessageBox.Show("Выберите тур");
        }
    }
}
