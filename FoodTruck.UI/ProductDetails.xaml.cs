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
            this.NavigationService.Navigate(new Catalog());
        }
    }
}
