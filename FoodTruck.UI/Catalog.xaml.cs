using FoodTruck.Core.Models;
using FoodTruck.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        public Catalog()
        {
            InitializeComponent();
            this.DataContext = new CatalogViewModel();
            List.ItemsSource = (DataContext as CatalogViewModel).Produits;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(List.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("TypeMenu");
            view.GroupDescriptions.Add(groupDescription);
            view.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));

        }



        private void List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return;

            Produit item = (Produit)List.ItemContainerGenerator.ItemFromContainer(dep);

            this.NavigationService.Navigate(new ProductDetails(item));
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

            Produit item = (Produit)List.ItemContainerGenerator.ItemFromContainer(dep);

            (DataContext as CatalogViewModel).AddToCart.Execute(item);
        }
    }
}
