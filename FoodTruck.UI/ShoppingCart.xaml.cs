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
    }
}
