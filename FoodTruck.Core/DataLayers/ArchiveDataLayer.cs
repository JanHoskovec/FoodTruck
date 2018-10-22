using FoodTruck.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Core.DataLayers
{
    public class ArchiveDataLayer
    {
        public void AddTransaction(Produit p)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"insert into Historique ([ProduitId],[TimeStamp]) values ({p.Id},getdate())";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
