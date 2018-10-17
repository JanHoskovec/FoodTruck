using FoodTruck.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Core.DataLayers
{
    public class UserDataLayer
    {

        public User GetOne(string email)
        {
            User Utilisateur = new User();
            
            try
            {
                using (SqlConnection context = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    context.Open();

                    if (context.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand queryUser = context.CreateCommand())
                        {
                            queryUser.CommandText = "SELECT Id, Email, Password, Nom, Prenom, DateNaissance, Adresse, Societe, Genre "+
                                                    "FROM Utilisateur; " +
                                                    "Where Email = '" + email + "'";
                            
                            using (SqlDataReader ReaderUser = queryUser.ExecuteReader())
                            {
                                while (ReaderUser.Read())
                                {
                                    Utilisateur.Id = (decimal)ReaderUser["Id"];
                                    Utilisateur.Email = (string)ReaderUser["Email"];
                                    Utilisateur.PasswordHash = (string)ReaderUser["Password"];
                                    Utilisateur.LastName = (string)ReaderUser["Nom"];
                                    Utilisateur.FirstName = (string)ReaderUser["Prenom"];
                                    Utilisateur.BirthDate = (DateTime)ReaderUser["DateNaissance"];
                                    Utilisateur.Address = (string)ReaderUser["Adresse"];
                                    Utilisateur.Company = (string)ReaderUser["Societe"];
                                    Utilisateur.Gender = (TypeGender)ReaderUser["Genre"];
                                    
                                }

                            }
                        }

                    }
                }
            }
            catch (Exception eSql)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + eSql.Message);
            }


            return Utilisateur;
        }

        public void Create(User user)
        {
            try
            {
                using (SqlConnection context = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    context.Open();
                    if (context.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand queryUser = context.CreateCommand())
                        {
                            queryUser.CommandText = "INSERT INTO [dbo].[Utilisateur] " +
                                                    "([Email], [Password] ,[Nom] ,[Prenom] ,[DateNaissance] ,[Adresse],[Societe],[Genre]) " +
                                                    "VALUES " +
                                                    "('" + user.Email +
                                                    "','" + user.PasswordHash +
                                                    "','" + user.LastName +
                                                    "','" + user.FirstName +
                                                    "','" + user.BirthDate +
                                                    "','" + user.Address +
                                                    "','" + user.Company +
                                                    "'," + (int)user.Gender +
                                                    ")";
                            queryUser.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception eSql)
            {
                System.Diagnostics.Debug.WriteLine("Exception: " + eSql.Message);
            }
        }


}
}
