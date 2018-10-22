using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Core.Models
{
    public class CartItem : BindableBase
    {
        private Produit _produit;
        private int _count;
        public Produit Produit { get { return _produit; } set { SetProperty(ref _produit, value); } }
        public int Count { get { return _count; } set { SetProperty(ref _count, value); } }



    }
}
