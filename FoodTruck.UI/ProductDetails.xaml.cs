using FoodTruck.Core.Models;
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
    /// Logique d'interaction pour ProductDetails.xaml
    /// </summary>
    public partial class ProductDetails : Page
    {
        public ProductDetails(Produit p)
        {
            InitializeComponent();
            this.DataContext = p;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Souhaitez-vous ajouter ce produit au panier ?", $"{(DataContext as Produit).Name}", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Session.Instance().Panier.Add(DataContext as Produit);
                this.NavigationService.Navigate(new ShoppingCart());
            }
          
        }
    }
}
