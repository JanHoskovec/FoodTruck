﻿using FoodTruck.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.UI
{
    public class Panier
    {
        public ObservableCollection<Produit> Products = new ObservableCollection<Produit>();

        public decimal Total
        {
            get
            {
                decimal result = 0;
                foreach (Produit p in Products)
                    result += p.Price;
                return result;
            }
        }

        public void Add(Produit p)
        {
            Products.Add(p);
        }
        public void Remove(Produit p)
        {
            Products.Remove(p);
        }

        public Panier()
        {
            //Products.Add(new Menu()
            //{
            //    Boisson = new Produit() { TypeMenu = TypeMenu.Boisson },
            //    Plat = new Produit() { TypeMenu = TypeMenu.Plat },
            //    Dessert = new Produit() { TypeMenu = TypeMenu.Dessert },
            //    Name = "Formule déjeuner",
            //    Price = 15
            //});
            //Products.Add(new Produit()
            //{
            //    Name = "Barquette de frites",
            //    Price = 3
            //});
        }
    }
}
