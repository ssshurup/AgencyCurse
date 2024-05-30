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
    /// Логика взаимодействия для ToursP.xaml
    /// </summary>
    public partial class ToursP : Page
    {
        public ToursP()
        {
            InitializeComponent();
            ToursDG.ItemsSource = App.DB.tours.ToList();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());

        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            tours tour = new tours();
            NavigationService.Navigate(new AddTourP(tour));
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedTour = ToursDG.SelectedItem as tours;
            if (selectedTour != null)
            {
                NavigationService.Navigate(new AddTourP(selectedTour));
            }
            else MessageBox.Show("Выберите тур");
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedTour = ToursDG.SelectedItem as tours;
            if (selectedTour != null)
            {
               App.DB.tours.Remove(selectedTour);
                App.DB.SaveChanges();
            ToursDG.ItemsSource = App.DB.tours.ToList();
            }
            else MessageBox.Show("Выберите тур");
        }

        private void AboutBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedTour = ToursDG.SelectedItem as tours;
            if (selectedTour != null)
            {
                string message = "";

                message += "Страна: " + selectedTour.city.country.name;
                message += "\nГород: " + selectedTour.city.name;
                message += "\nКол-во ночей: " +selectedTour.nightsCount;
                message += "\nКол-во взрослых: " +selectedTour.adultsCount;
                message += "\nКол-во детей: " + selectedTour.childsCount;
                message += "\nОтель: " + selectedTour.hotels.name ;
                message += "\nПоездка: " +selectedTour.travelMethod.name;
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
