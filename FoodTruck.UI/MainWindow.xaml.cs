using FoodTruck.UI.ViewModels;
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

namespace FoodTruck.UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            mainframe.Navigate(new Acceuil());
            this.DataContext = Session.Instance();
        }
        
        private void ClickOnLogo(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new Acceuil());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            switch (b.Content)
            {
                case ("Connexion"):
                    mainframe.Navigate(new Login());
                    break;

                case ("Menu"):
                    mainframe.Navigate(new ChoixMenu());
                    break;
            }
        }

        private void ClickOnCart(object sender, RoutedEventArgs e)
        {
            mainframe.Navigate(new ShoppingCart());
        }
        
        private void ClickOnLogout(object sender, RoutedEventArgs e)
        {
            Session.Instance().user = null;
        }
        
    }
}
