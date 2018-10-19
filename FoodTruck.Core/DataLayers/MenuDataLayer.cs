using FoodTruck.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTruck.Core.DataLayers
{
    public class MenuDataLayer
    {
        public Formule GetOne(TypeFormule type)
        {
            Formule res = null;
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select Prix, Label from Menu where Number = " + (int)type;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        res = new Formule();
                        while(reader.Read())
                        {
                            res.Label = (string)reader["Label"];
                            res.Prix = (decimal)reader["Prix"];
                        }
                    }
                }
            }
            return res;
        }
    }
}
