using System;
using System.Collections.Generic;
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

namespace AgencyCurse.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AddHotelP.xaml
    /// </summary>
    public partial class AddHotelP : Page
    {
        hotels context;
        public AddHotelP(hotels selectedHotel)
        {
            InitializeComponent(); 
            CityCB.ItemsSource = App.DB.city.ToList();
            CountryCB.ItemsSource = App.DB.country.ToList();
            context = selectedHotel;
            DataContext = context;
        }
        private void CountryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCountry = CountryCB.SelectedItem as country;
            CityCB.ItemsSource = App.DB.city.Where(a => a.idCountry == selectedCountry.id).ToList();
        }

        private void CityCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedCity = CityCB.SelectedItem as city;
            CountryCB.ItemsSource = App.DB.country.Where(a => a.id == selectedCity.idCountry).ToList();
            CountryCB.SelectedIndex = 0;
        }
        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddHotelP(context));
        }
        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HotelP());
        }

        private void CompleteBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (context.id == 0) App.DB.hotels.Add(context);
                App.DB.SaveChanges();
                NavigationService.Navigate(new HotelP());
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }
    }
}
