using FoodTruck.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.UI
{
    public class Session
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
        public User user { get; set; }
        #endregion
    }
}
