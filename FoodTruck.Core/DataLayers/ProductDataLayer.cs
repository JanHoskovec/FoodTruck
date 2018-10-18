using FoodTruck.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Core.DataLayers
{
    public class ProductDataLayer
    {
        public List<Produit> GetAll()
        {
            List<Produit> result = new List<Produit>();

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

        public List<Produit> GetAllOneType(TypeMenu type)
        {
            List<Produit> result = new List<Produit>();

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                string commandText = "select Id, Designation, Prix, Image, Quantite, Unite, TypeMenu from produit where type = " + (int)type;
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
