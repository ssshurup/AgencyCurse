using AgencyCurse.Pages.AdminPages;
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
    /// Логика взаимодействия для BuyTourP.xaml
    /// </summary>
    public partial class BuyTourP : Page
    {
        tours context;
        public BuyTourP(tours selectedTour)
        {
            InitializeComponent();
            context = selectedTour;
            DataContext = context;
        }

        private void StartDateDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime endDate = (DateTime)StartDateDP.SelectedDate;
            endDate = endDate.AddDays(Convert.ToInt32(context.nightsCount));
            if ((DateTime)StartDateDP.SelectedDate < DateTime.Now)
            {
                MessageBox.Show("Дата отправки уже прошла");
                return;
            }
            EndDateDP.SelectedDate = endDate;
        }

        private void EndDateDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime startDate = (DateTime)EndDateDP.SelectedDate;
            startDate = startDate.AddDays(-Convert.ToInt32(context.nightsCount)) ;
            if (startDate < DateTime.Now)
            {
                MessageBox.Show("Дата отправки уже прошла");
                return;
            }
            StartDateDP.SelectedDate = startDate;
            
        }
        private void BuyBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                    hystory buyTour = new hystory();
                    buyTour.idTour = context.id;
                    buyTour.idUser = App.LoggedUser.id;
                    buyTour.startDate = (DateTime)StartDateDP.SelectedDate;
                    buyTour.endDate = (DateTime)EndDateDP.SelectedDate;
                    int price = (int)context.price;
                    price = (int)(price - price / 100 * App.LoggedUser.discount.count);
                    App.LoggedUser.balance -= price;
                    App.DB.hystory.Add(buyTour);
                    App.DB.SaveChanges();
                    MessageBox.Show("Тур куплен");
               
               
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }
        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TourUserP());
        }

       
    }
}
