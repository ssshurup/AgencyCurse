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
    /// Логика взаимодействия для MyToursP.xaml
    /// </summary>
    public partial class MyToursP : Page
    {
        public MyToursP()
        {
            InitializeComponent();
            ToursDG.ItemsSource = App.DB.hystory.Where(a => a.idUser == App.LoggedUser.id).ToList();
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserP());
        }

        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedTour = ToursDG.SelectedItem as hystory;
            if (selectedTour != null)
            {
                App.DB.hystory.Remove(selectedTour);
                App.DB.SaveChanges();
                ToursDG.ItemsSource = App.DB.hystory.Where(a => a.idUser == App.LoggedUser.id).ToList();
            }
            else MessageBox.Show("Выберите тур");
        }

        private void ReviewBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedTour = ToursDG.SelectedItem as hystory;
            if (selectedTour != null)
            {
                selectedTour.rewiew = ReviewTB.Text;
                App.DB.SaveChanges();
                MessageBox.Show("Отзыв оставлен");
            }
            else MessageBox.Show("Выберите тур");
        }
    }
}
