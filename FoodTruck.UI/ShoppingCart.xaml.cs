﻿using FoodTruck.Core.Models;
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
    /// Logique d'interaction pour Panier.xaml
    /// </summary>
    public partial class ShoppingCart : Page
    {
        
        public ShoppingCart()
        {
            InitializeComponent();
            var vm = new ShoppingCartViewModel();
            MyShoppingCart.ItemsSource = vm.ActiveSession.Panier.Products;
            this.DataContext = vm;
        }

        // Dette technique

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return;

            Produit item = ((CartItem)MyShoppingCart.ItemContainerGenerator.ItemFromContainer(dep)).Produit;

            switch((sender as Button).Content)
            {
                case ("+"):
                    Session.Instance().Panier.Add(item);
                    break;
                case ("-"):
                    Session.Instance().Panier.Remove(item);
                    break;
            }
            
        }
        

        private void Click_Empty(object sender, RoutedEventArgs e)
        {
            EmptyButton.IsEnabled = false;
        }

    }
}
