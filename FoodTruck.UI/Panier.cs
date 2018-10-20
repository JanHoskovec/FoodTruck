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
        public ObservableCollection<Produit> Products = new ObservableCollection<Produit>();

        private decimal _total;
        public decimal Total
        {
            get
            {
                decimal result = 0;
                foreach (Produit p in Products)
                    result += p.Price;
                return result;
            }
            set {
                SetProperty(ref _total, value);
            }
            
        }

        public void Add(Produit p)
        {
            Products.Add(p);
            Total = Total;
        }
        public void Remove(Produit p)
        {
            Products.Remove(p);
            Total = Total;
        }
        
    }
}
