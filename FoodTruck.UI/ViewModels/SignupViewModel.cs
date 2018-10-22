using FoodTruck.Core.DataLayers;
using FoodTruck.Core.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public delegate void MyEventAction(object redirectTo);
        public event MyEventAction RedirectEvent;

        private DelegateCommand<PasswordBox> _command;
        public DelegateCommand<PasswordBox> SignUp
        {
            get { return _command; }
        }

        public SignupViewModel()
        {
            _user = new User();
            _command = new DelegateCommand<PasswordBox>(DoSignUp);
        }

        protected void DoSignUp(PasswordBox box)
        {

            user.PasswordHash = DefaultViewModel.GetHashString(box.Password);
            if (IsValidEmail(user.Email))
            {
                UserDataLayer Layer = new UserDataLayer();
                User fromDb = Layer.GetOne(user.Email);
                if (fromDb.Email == null)
                {
                    Layer.Create(user);
                    MailMessage message = new MailMessage()
                    {
                        Subject = "Bienvenue chez Bon App !",
                        Body = "Merci d'avoir créé votre compte BonApp !\n\n" +
                        "Vos identifiants :\n" +
                        $"\tE-mail : \t{user.Email}" +
                        $"\tMot de passe : \t{box.Password}",
                        From = new MailAddress("bonapp69test@gmail.com")
                    };
                    message.To.Add(user.Email);
                    DefaultViewModel.SendMail(message);
                    MessageBox.Show("Votre compte a bien été créé. Vous allez recevoir un e-mail de confirmation.");
                    RedirectEvent?.Invoke(new Login());
                }
                else
                {
                    MessageBox.Show("L'adresse e-mail spécifiée est déjà liée à un compte.");
                }
            }
            else
            {
                MessageBox.Show("L'adresse e-mail spécifiée n'est pas valide.");
            }
        }





        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
