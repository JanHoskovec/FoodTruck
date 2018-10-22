using FoodTruck.Core.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.UI
{
    public class Session : BindableBase
    {
        #region singleton props
        private static Session _instance = null;

        private Session()
        {

        }

        public static Session Instance()
        {
            if (_instance == null)
                _instance = new Session();
            return _instance;
        }
        #endregion

        #region public fields
        private User _user = null;
        public User user { get { return _user; } set {SetProperty(ref _user, value) ; } }
        private Panier _panier = new Panier();
        public Panier Panier { get { return _panier; } }
        
        public bool IsLoggedIn { get { return _user != null; } }
        public bool HasItems { get { return _panier.Products.Count > 0; } }
        public bool CanCommand { get { return IsLoggedIn && HasItems; } }
        #endregion
        
    }
}
