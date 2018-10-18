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
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel();
            var vm = (LoginViewModel)DataContext;
            vm.MyEvent += (redirectTo) => this.NavigationService.Navigate(redirectTo);
        }

        private void ClickOnSignup(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Signup());
        }
    }
}
