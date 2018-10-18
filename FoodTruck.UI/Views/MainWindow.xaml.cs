using FoodTruck.UI.ViewModels;
using Microsoft.Practices.Unity;
using Prism.Regions;
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
using System.Windows.Shapes;

namespace FoodTruck.UI.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRegionManager _regionManager;

        private readonly IUnityContainer _container;

        public MainWindow(IRegionManager regionManager, IUnityContainer container)
        {
            InitializeComponent();
            if (regionManager == null)
            {
                throw new ArgumentNullException(nameof(regionManager));
            }
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            _regionManager = regionManager;
            _container = container;
            
            _regionManager.RegisterViewWithRegion("Mainframe", typeof(Acceuil));
        }

        private void ClickOnLogo(object sender, RoutedEventArgs e)
        {
            _regionManager.RegisterViewWithRegion("Mainframe", typeof(Acceuil));
        }

        private void ClickOnLogin(object sender, RoutedEventArgs e)
        {
            //_regionManager.Regions["Mainframe"].RemoveAll();
            //_regionManager.RegisterViewWithRegion("Mainframe", typeof(Login));
            _regionManager.Regions["Mainframe"].RequestNavigate(new Uri("Login", UriKind.Relative));
        }
    }
}
