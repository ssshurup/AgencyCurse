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
    /// Логика взаимодействия для AddTourP.xaml
    /// </summary>
    public partial class AddTourP : Page
    {
        tours context;
        public AddTourP(tours selectedTour)
        {
            InitializeComponent();
            CityCB.ItemsSource = App.DB.city.ToList();
            CountryCB.ItemsSource = App.DB.country.ToList();
            HotelCB.ItemsSource = App.DB.hotels.ToList();
            TravelMethodCB.ItemsSource = App.DB.travelMethod.ToList();
            context = selectedTour;
            DataContext = context;

        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ToursP());
        }

        private void CompleteBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (context.id == 0) App.DB.tours.Add(context);
                App.DB.SaveChanges();
                NavigationService.Navigate(new ToursP());
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void CountryCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCountry = CountryCB.SelectedItem as country;
            CityCB.ItemsSource = App.DB.city.Where(a => a.idCountry == selectedCountry.id).ToList();
            HotelCB.ItemsSource = App.DB.hotels.Where(a => a.city.idCountry == selectedCountry.id).ToList();
        }

        private void CityCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selectedCity = CityCB.SelectedItem as city;
            CountryCB.ItemsSource = App.DB.country.Where(a => a.id == selectedCity.idCountry).ToList();
            CountryCB.SelectedIndex = 0;
            HotelCB.ItemsSource = App.DB.hotels.Where(a => a.idCity == selectedCity.id).ToList();

        }

        private void HotelCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var selecedHotel = HotelCB.SelectedItem as hotels;
            CountryCB.ItemsSource = App.DB.country.Where(a => a.id == selecedHotel.city.idCountry).ToList();
            CountryCB.SelectedIndex = 0;
            CityCB.ItemsSource = App.DB.city.Where(a => a.id == selecedHotel.idCity).ToList();
            CityCB.SelectedIndex = 0;
        }

        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTourP(context));
        }
    }
}
