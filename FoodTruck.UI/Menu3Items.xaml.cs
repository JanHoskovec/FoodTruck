using FoodTruck.Core.DataLayers;
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
    /// Logique d'interaction pour Menu3Items.xaml
    /// </summary>
    public partial class Menu3Items : Page
    {
        public Menu3Items(TypeFormule type)
        {
           
            InitializeComponent();
            MenuViewModel vm = new MenuViewModel();
            this.DataContext = vm;
            vm.RedirectEvent += (redirectTo) => this.NavigationService.Navigate(redirectTo);
            vm.menu.Type = type;
            ProductDataLayer layer = new ProductDataLayer();
            this.ComboDrink.ItemsSource = layer.GetAllOneType(TypeMenu.Boisson, type);
            this.ComboPlat.ItemsSource = layer.GetAllOneType(TypeMenu.Plat, type);
            this.ComboDessert.ItemsSource = layer.GetAllOneType(TypeMenu.Dessert, type);
            
        }
    }
}
