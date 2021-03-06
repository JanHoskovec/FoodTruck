﻿using System;
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

namespace FoodTruck.UI

{
    /// <summary>
    /// Logique d'interaction pour ChoixMenu.xaml
    /// </summary>
    public partial class ChoixMenu : Page
    {
        public ChoixMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            switch (b.Name)
            {
                case ("Button_D"):
                    Choix.Navigate(new Menu3Items(TypeFormule.Dejeuner));
                    break;

                case ("Button_Din"):
                    Choix.Navigate(new Menu3Items(TypeFormule.Diner));
                    break;

                case ("Button_PD"):
                    Choix.Navigate(new Menu2Items(TypeFormule.PetitDejeuner));
                    break;
                case ("Button_G"):
                    Choix.Navigate(new Menu2Items(TypeFormule.Gouter));
                    break;
                case ("Button_C"):
                   
                    this.NavigationService.Navigate(new Catalog());
                    break;
            }
        }
    }
}
