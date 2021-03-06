﻿using FoodTruck.Core.DataLayers;
using FoodTruck.Core.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FoodTruck.UI.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private User _user;
        public User user { get { return _user; } set { SetProperty(ref _user, value); } }

        public delegate void MyEventAction(object redirectTo);
        public event MyEventAction RedirectEvent;

        private DelegateCommand<PasswordBox> _command;
        public DelegateCommand<PasswordBox> Login
        {
            get { return _command; }
        }
        
        public LoginViewModel()
        {
            _user = new User();
            _command = new DelegateCommand<PasswordBox>(DoLogin);
        }

        protected void DoLogin(PasswordBox box)
        {
            UserDataLayer Layer = new UserDataLayer();
            User fromDb = Layer.GetOne(user.Email);
            if (fromDb.Email == null)
            {
                MessageBox.Show("L'adresse e-mail n'a pas été reconnue.");
            }
            else if (fromDb.PasswordHash != DefaultViewModel.GetHashString(box.Password))
            {
                MessageBox.Show("Mauvais mot de passe.");
            }
            else
            {
                _user = fromDb;
                Session.Instance().user = _user;
                RedirectEvent?.Invoke(new Acceuil());
            }
                
        }
    }
}
