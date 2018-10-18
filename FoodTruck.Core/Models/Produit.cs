using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Core.Models
{
    public class Produit : BindableBase
    {
        private decimal _id;
        public decimal Id { get { return _id; } set { SetProperty(ref _id, value); } }
        private string _Name;
        public string Name { get { return _Name; } set { SetProperty(ref _Name, value); } }
        private decimal _Price;
        public decimal Price { get { return _Price; } set { SetProperty(ref _Price, value); } }
        private string _Image;
        public string Image { get { return _Image; } set { SetProperty(ref _Image, value); } }
        private decimal _Quantity;
        public decimal Quantity { get { return _Quantity; } set { SetProperty(ref _Quantity, value); } }
        private string _Unity;
        public string Unity { get { return _Unity; } set { SetProperty(ref _Unity, value); } }

        private TypeMenu _TypeMenu;
        public TypeMenu TypeMenu { get { return _TypeMenu; } set { SetProperty(ref _TypeMenu, value); } }
    }
}
