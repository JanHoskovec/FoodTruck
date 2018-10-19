using FoodTruck.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Core.DataLayers
{
    public class ProductDataLayer
    {
        public ObservableCollection<Produit> GetAll()
        {
            ObservableCollection<Produit> result = new ObservableCollection<Produit>();

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                string commandText = "select Id, Designation, Prix, Image, Quantite, Unite, TypeMenu from produit";
                using(SqlCommand command = new SqlCommand(commandText))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        result.Add(new Produit
                        {
                            Id = (decimal)reader["Id"],
                            Name = (string)reader["Designation"],
                            Price = (decimal)reader["Prix"],
                            Image = (string)reader["Image"],
                            Quantity = (decimal)reader["Quantite"],
                            Unity = (string)reader["Unite"],
                            TypeMenu = (TypeMenu)reader["TypeMenu"]
                        });
                    }
                }
            }

            return result;
        }

        public ObservableCollection<Produit> GetAllOneType(TypeMenu type)
        {
            ObservableCollection<Produit> result = new ObservableCollection<Produit>();

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                string commandText = "select Id, Designation, Prix, Image, Quantite, Unite, TypeMenu from produit where TypeMenu = " + (int)type;
                using (SqlCommand command = new SqlCommand(commandText))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Produit
                        {
                            Id = (decimal)reader["Id"],
                            Name = (string)reader["Designation"],
                            Price = (decimal)reader["Prix"],
                            Image = (string)reader["Image"],
                            Quantity = (decimal)reader["Quantite"],
                            Unity = (string)reader["Unite"],
                            TypeMenu = (TypeMenu)reader["TypeMenu"]
                        });
                    }
                }
            }

            return result;
        }
    }
}
