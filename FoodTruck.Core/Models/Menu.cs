using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Core.Models
{
    public class Menu : Produit
    {
        private Produit _boisson;
        private Produit _plat;
        private Produit _dessert;
        public Produit Boisson
        {
            get { return _boisson; }
            set { if (value.TypeMenu == TypeMenu.Boisson) SetProperty(ref _boisson, value); }
        }
        public Produit Plat
        {
            get { return _plat; }
            set { if (value.TypeMenu == TypeMenu.Plat) SetProperty(ref _plat, value); }
        }
        public Produit Dessert
        {
            get { return _dessert; }
            set { if (value.TypeMenu == TypeMenu.Dessert) SetProperty(ref _dessert, value); }
        }

        public Menu()
        {
            this.TypeMenu = TypeMenu.Formule;
        }

    }

}
