﻿using FoodTruck.Core.DataLayers;
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
            UserDataLayer Layer = new UserDataLayer();
            User fromDb = Layer.GetOne(user.Email);
            if (fromDb.Email == null)
            {
                Layer.Create(user);
                MailMessage message = new MailMessage()
                {
                    Subject = "Bienvenue chez Bon App !",
                    Body = "Ceci est un message de test",
                    From = new MailAddress("bonapp69test@gmail.com")
                };
                message.To.Add(user.Email);
                SendMail(message);
                RedirectEvent?.Invoke(new Login());
            }
            else
            {
                MessageBox.Show("L'adresse e-mail spécifiée est déjà liée à un compte.");
            }
        }



        public static void SendMail(MailMessage Message)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.googlemail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("bonapp69test@gmail.com", "bonapp69");
            client.Send(Message);
        }

    }
}
