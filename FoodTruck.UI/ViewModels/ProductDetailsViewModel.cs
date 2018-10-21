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
    public class ProductDetailsViewModel : BindableBase
    {
        private Produit _product;
        public Produit Product { get { return _product; } set { SetProperty(ref _product, value); } }

        private DelegateCommand _command;
        public DelegateCommand Show { get { return _command; } }

        public ProductDetailsViewModel()
        {
            _command = new DelegateCommand(DoShow);
        }

        private void DoShow()
        {

        }
    }
}
