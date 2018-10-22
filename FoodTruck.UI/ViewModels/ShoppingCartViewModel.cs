using FoodTruck.Core.DataLayers;
using FoodTruck.Core.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FoodTruck.UI.ViewModels
{
    public class ShoppingCartViewModel : BindableBase
    {
        private DelegateCommand<Produit> _commandRemove;
        public DelegateCommand<Produit> RemoveFromCart
        {
            get { return _commandRemove; }
        }

        private DelegateCommand _commandPlaceOrder;
        public DelegateCommand PlaceOrder
        {
            get { return _commandPlaceOrder; }
        }

        private DelegateCommand _commandEmpty;
        public DelegateCommand Empty
        {
            get { return _commandEmpty; }
        }

        public Session ActiveSession { get { return Session.Instance(); } }

        public delegate void MyEventAction(object redirectTo);
        public event MyEventAction RedirectEvent;


        public ShoppingCartViewModel()
        {
            _commandRemove = new DelegateCommand<Produit>(DoRemoveFromCart);
            _commandPlaceOrder = new DelegateCommand(DoPlaceOrder);
            _commandEmpty = new DelegateCommand(DoEmpty);
        }

        protected void DoRemoveFromCart(Produit p)
        {
            Session.Instance().Panier.Remove(p);
        }

        protected void DoPlaceOrder()
        {
            // Write to the Database
            ArchiveDataLayer layer = new ArchiveDataLayer();
            foreach (Produit p in Session.Instance().Panier.Products)
                layer.AddTransaction(p);
            // Send an e-mail confirmation
            MailMessage message = new MailMessage()
            {
                Subject = "Votre commande chez Bon App !",
                Body = Session.Instance().Panier.Invoice(),
                From = new MailAddress("bonapp69test@gmail.com")
            };
            message.To.Add(Session.Instance().user.Email);
            DefaultViewModel.SendMail(message);
            MessageBox.Show("La commande a été prise en compte. Un e-mail de confirmation vous a été envoyé.");

            // Empty the cart
            Session.Instance().Panier.Empty();

            // Redirect back
            RedirectEvent?.Invoke(new Acceuil());
        }

        protected void DoEmpty()
        {
            Session.Instance().Panier.Empty();
        }
    }
}
