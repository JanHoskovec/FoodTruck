using FoodTruck.Core.DataLayers;
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
    public class MenuViewModel : BindableBase
    {
        private Menu _menu;
        public Menu menu { get { return _menu; } set { SetProperty(ref _menu, value); } }

        public delegate void MyEventAction(object redirectTo);
        public event MyEventAction RedirectEvent;

        private DelegateCommand _command;
        public DelegateCommand AddToCart
        {
            get { return _command; }
        }

        public MenuViewModel()
        {
            _menu = new Menu();
            _command = new DelegateCommand(DoAddToCart);
        }

        private void DoAddToCart()
        {

            MenuDataLayer layer = new MenuDataLayer();
            Formule form = layer.GetOne(_menu.Type);
            Menu ChosenMenu = new Menu()
            {
                Boisson = _menu.Boisson,
                Dessert = _menu.Dessert,
                Plat = _menu.Plat,
                Price = form.Prix,
                Name = $"Formule {form.Label} à {form.Prix} euros"
            };
            Session.Instance().Panier.Add(ChosenMenu);
            RedirectEvent?.Invoke(new ChoixMenu());
        }
    }
}
