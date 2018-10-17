using FoodTruck.Core.DataLayers;
using FoodTruck.Core.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FoodTruck.UI.ViewModels
{
    public class SignupViewModel : BindableBase
    {
        private User _user;
        public User user { get { return _user; } set { SetProperty(ref _user, value); } }
        private DelegateCommand<PasswordBox> _command;
        public DelegateCommand<PasswordBox> SignUp
        {
            get { return _command; }
        }

        public SignupViewModel()
        {
            user = new User();
            _command = new DelegateCommand<PasswordBox>(DoSignUp);
        }

        protected void DoSignUp(PasswordBox box)
        {
            
            user.PasswordHash = GetHashString(box.Password);
            UserDataLayer Layer = new UserDataLayer();
            User fromDb = Layer.GetOne(user.Email);
            if (fromDb.Email == null)
            { 
                Layer.Create(user);
            }
            else
            {
                MessageBox.Show("L'adresse e-mail spécifiée est déjà liée à un compte.");
            }
        }

        public byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
    }
}
