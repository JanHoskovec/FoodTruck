using FoodTruck.Core.Models;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodTruck.UI
{
    /// <summary>
    /// Logique d'interaction pour Acceuil.xaml
    /// </summary>
    public partial class Acceuil : Page
    { 
        public Acceuil()
        {
            InitializeComponent();
            var vm = new AccueilViewModel();
            this.DataContext = vm;
            //TopThree.ItemsSource = vm.TopThree;

        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    DependencyObject dep = (DependencyObject)e.OriginalSource;

        //    while ((dep != null) && !(dep is ListViewItem))
        //    {
        //        dep = VisualTreeHelper.GetParent(dep);
        //    }

        //    if (dep == null)
        //        return;

        //    Produit item = (Produit)TopThree.ItemContainerGenerator.ItemFromContainer(dep);

        //    this.NavigationService.Navigate(new ProductDetails(item));
        //}
    }
}
