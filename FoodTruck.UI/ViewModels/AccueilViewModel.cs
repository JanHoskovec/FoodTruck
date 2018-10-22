using FoodTruck.Core.DataLayers;
using FoodTruck.Core.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.UI.ViewModels
{
    public class AccueilViewModel : BindableBase
    {
        private ObservableCollection<Produit> _topThree;
        public ObservableCollection<Produit> TopThree { get { return _topThree; } set { SetProperty(ref _topThree, value); } }

        public AccueilViewModel()
        {
            ProductDataLayer layer = new ProductDataLayer();
            _topThree = layer.GetTop3();
        }
    }
}
