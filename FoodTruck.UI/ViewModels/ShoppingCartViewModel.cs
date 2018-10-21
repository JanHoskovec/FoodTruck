using FoodTruck.Core.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.UI.ViewModels
{
    public class ShoppingCartViewModel : BindableBase
    {
        private DelegateCommand<Produit> _command;
        public DelegateCommand<Produit> RemoveFromCart
        {
            get { return _command; }
        }

        public ShoppingCartViewModel()
        {
            _command = new DelegateCommand<Produit>(DoRemoveFromCart);
        }

        protected void DoRemoveFromCart(Produit p)
        {
            Session.Instance().Panier.Remove(p);
        }
    }
}
