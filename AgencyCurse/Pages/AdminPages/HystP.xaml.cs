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
    /// Логика взаимодействия для HystP.xaml
    /// </summary>
    public partial class HystP : Page
    {
        
        public HystP()
        {
            InitializeComponent();
            ToursDG.ItemsSource = App.DB.hystory.ToList();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());
        }

        private void ReviewBT_Click(object sender, RoutedEventArgs e)
        {
            
                var selectedTour = ToursDG.SelectedItem as hystory;
                if (selectedTour != null)
                {
                    string message = "";

                    message += "Страна: " + selectedTour.tours.city.country.name;
                    message += "\nГород: " + selectedTour.tours.city.name;
                    message += "\nКол-во ночей: " + selectedTour.tours.nightsCount;
                    message += "\nКол-во взрослых: " + selectedTour.tours.adultsCount;
                    message += "\nКол-во детей: " + selectedTour.tours.childsCount;
                    message += "\nОтель: " + selectedTour.tours.hotels.name;
                    message += "\nПоездка: " + selectedTour.tours.travelMethod.name;
                    message += "\nЦена: " + selectedTour.tours.price;
                    if (selectedTour.tours.hotels.isAllinClusive == true)
                    {
                        message += "\nВсё включено: дa ";
                    }
                    else message += "\nВсё включено: нет ";
                message += "\nОтзыв: " + selectedTour.rewiew;
                    MessageBox.Show(message);
                }
                else MessageBox.Show("Выберите тур");
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedTour = ToursDG.SelectedItem as hystory;
            if (selectedTour != null)
            {
                App.DB.hystory.Remove(selectedTour);
                App.DB.SaveChanges();
                ToursDG.ItemsSource = App.DB.hystory.ToList();
            }
            else MessageBox.Show("Выберите тур");
        }
    }
}
