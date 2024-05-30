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
    /// Логика взаимодействия для HotelP.xaml
    /// </summary>
    public partial class HotelP : Page
    {
        public HotelP()
        {
            InitializeComponent();
            HotelDG.ItemsSource = App.DB.hotels.ToList();
        }
        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminP());
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
           hotels hotel = new hotels();
            NavigationService.Navigate(new AddHotelP(hotel));

        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedHotel = HotelDG.SelectedItem as hotels;
            if (selectedHotel != null)
            {
                NavigationService.Navigate(new AddHotelP(selectedHotel));
            }
            else MessageBox.Show("Выберите отель");
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedHotel = HotelDG.SelectedItem as hotels;
            if (selectedHotel != null)
            {
                App.DB.hotels.Remove(selectedHotel);
                App.DB.SaveChanges();
                HotelDG.ItemsSource = App.DB.hotels.ToList();
            }
            else MessageBox.Show("Выберите отель");
        }
    }
}
