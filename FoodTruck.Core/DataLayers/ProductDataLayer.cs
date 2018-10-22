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
                connection.Open();
                string commandText = "select Id, Designation, Prix, Image, Quantite, Unite, TypeMenu from produit";
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
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
            }

            return result;
        }

        public ObservableCollection<Produit> GetAllOneType(TypeMenu typeItem, TypeFormule typeRepas)
        {
            ObservableCollection<Produit> result = new ObservableCollection<Produit>();

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                connection.Open();
                string commandText = "select Id, Designation, Prix, Image, Quantite, Unite, TypeMenu from Produit " +
                    "join Contenir on Contenir.ProduitId = Produit.Id " +
                    "where Contenir.MenuId = " + (int)typeRepas +
                    " and Produit.TypeMenu = " + (int)typeItem +
                    " order by Prix";
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
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
            }

            return result;
        }

        public ObservableCollection<Produit> GetAllButMenus()
        {
            ObservableCollection<Produit> result = new ObservableCollection<Produit>();

            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                connection.Open();
                string commandText = $"select Id, Designation, Prix, Image, Quantite, Unite, TypeMenu from produit where TypeMenu != {(int)TypeMenu.Formule}";
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
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
            }

            return result;
        }

        public Produit GetOneById(int Id)
        {
            Produit result = new Produit();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = $"select Id, Designation, Prix, Image, Quantite, Unite, TypeMenu from produit where Id = {Id}";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Id = (decimal)reader["Id"];
                            result.Name = (string)reader["Designation"];
                            result.Price = (decimal)reader["Prix"];
                            result.Image = (string)reader["Image"];
                            result.Quantity = (decimal)reader["Quantite"];
                            result.Unity = (string)reader["Unite"];
                            result.TypeMenu = (TypeMenu)reader["TypeMenu"];
                        }
                    }
                }
            }
            return result;
        }

        public ObservableCollection<Produit> GetTop3()
        {
            ObservableCollection<Produit> result = new ObservableCollection<Produit>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select top 3 ProduitId from Historique group by ProduitId order by count(ProduitId) desc";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            result.Add(GetOneById((int)(decimal)reader["ProduitId"]));
                        }
                    }
                }
            }
            return result;
        }

    }
}
