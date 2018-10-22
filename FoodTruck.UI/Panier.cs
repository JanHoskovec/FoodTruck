using FoodTruck.Core.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.UI
{
    public class Panier : BindableBase
    {
        public ObservableCollection<CartItem> Products = new ObservableCollection<CartItem>();

        private decimal _total;
        public decimal Total
        {
            get
            {
                decimal result = 0;
                foreach (CartItem c in Products)
                    result += c.Produit.Price * c.Count;
                return result;
            }
            set {
                SetProperty(ref _total, value);
            }
            
        }

        public void Add(Produit p)
        {
            CartItem c = WhichContains(p);
            if(c == null)
            {
                Products.Add(new CartItem { Produit = p, Count = 1 });
            }
            else
            {
                c.Count++;
            }
            RecomputeTotal();
        }
        public void Remove(Produit p)
        {
            CartItem c = WhichContains(p);
            if (c.Count == 1)
                Products.Remove(c);
            else
                c.Count--;
            RecomputeTotal();

        }

        public void Empty()
        {
            Products.Clear();
            Total = 0;
        }

        public string Invoice()
        {
            string result = "Récapitulatif de votre commande : \n\n";
            foreach (CartItem c in Products)
                result += $"{c.Count}x {c.Produit.Name}\t {c.Produit.Quantity} {c.Produit.Unity}\tà {c.Produit.Price} € : {c.Produit.Price*c.Count} €\n";
            result += $"\nTotal : {Total} €";
            return result;
        }
        
        private void RecomputeTotal()
        {
            Total = 0;
            foreach (CartItem c in Products)
                Total += c.Produit.Price * c.Count;
        }

        private CartItem WhichContains(Produit p)
        {
            return Products.SingleOrDefault(c => c.Produit.Id == p.Id);
        }

    }
}
