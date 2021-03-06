﻿using FoodTruck.UI.ViewModels;
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

namespace FoodTruck.UI.Views
{
    /// <summary>
    /// Logique d'interaction pour Signup.xaml
    /// </summary>
    public partial class Signup : UserControl
    {
        public Signup()
        {
            InitializeComponent();
            this.DataContext = new SignupViewModel();
            GenderBox.ItemsSource = Enum.GetValues(typeof(TypeGender)).Cast<TypeGender>();
        }

       

        private void PwdVerifPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Pwd.Password != PwdVerif.Password)
            {
                statusText.Text = "Les mots de passe ne correspondent pas.";
                ButtonSignup.IsEnabled = false;
            }
            else
            {
                statusText.Text = "";
                ButtonSignup.IsEnabled = true;

            }
        }
    }
}
