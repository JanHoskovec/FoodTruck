using FoodTruck.Core.DataLayers;
using FoodTruck.Core.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FoodTruck.UI.ViewModels
{
    public class CatalogViewModel : BindableBase
    {
        private ObservableCollection<Produit> _produits;
        public ObservableCollection<Produit> Produits { get { return _produits; } set { SetProperty(ref _produits, value); } }
        public DelegateCommand<Produit> AddToCart { get; }

        public CatalogViewModel()
        {
            ProductDataLayer layer = new ProductDataLayer();
            _produits = layer.GetAll();
            AddToCart = new DelegateCommand<Produit>(DoAddToCart);
        }

        protected void DoAddToCart(Produit p)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Souhaitez-vous ajouter ce produit au panier ?", $"{p.Name}", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Session.Instance().Panier.Add(p);
            }
        }
    }
}
