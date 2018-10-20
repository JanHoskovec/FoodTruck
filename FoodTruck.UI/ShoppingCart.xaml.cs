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
    /// Logique d'interaction pour Panier.xaml
    /// </summary>
    public partial class ShoppingCart : Page
    {
        
        public ShoppingCart()
        {
            InitializeComponent();
            MyShoppingCart.ItemsSource = Session.Instance().Panier.Products;
            SumLabel.DataContext = Session.Instance().Panier;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return;

            Produit item = (Produit)MyShoppingCart.ItemContainerGenerator.ItemFromContainer(dep);
            MessageBoxResult messageBoxResult = MessageBox.Show($"Voulez-vous vraiment enlever {item.Name} de votre panier ?", "Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
                Session.Instance().Panier.Remove(item);
        }
    }
}
