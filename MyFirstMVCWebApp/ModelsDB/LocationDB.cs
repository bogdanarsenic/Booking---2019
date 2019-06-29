using MyFirstMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MyFirstMVCWebApp.ModelsDB
{
    public class LocationDB
    {

        string connectionString = ConfigurationManager.ConnectionStrings["Baza"].ConnectionString;

        public Lokacija GetOne(Guid Id)
        {
            string Query = "SELECT * FROM Locations WHERE Id='" + Id + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    Lokacija location = null;
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        location = new Lokacija()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            GeografskaSirina = float.Parse(reader["Lattitude"].ToString(), CultureInfo.InvariantCulture.NumberFormat),
                            GeografskaDuzina = float.Parse(reader["Longitude"].ToString(), CultureInfo.InvariantCulture.NumberFormat),
                            Adresa = reader["Address"].ToString(),
                        };
                    }
                    return location;
                }
                catch
                {
                    return null;
                }
            }
        }


        public void Insert(Lokacija location)
        {
            string Query = "INSERT INTO Locations(Id, Lattitude, Longitude, Address) VALUES(@Id, @Lattitude, @Longitude, @Address)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();

                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = location.Id.ToString();
                    cmd.Parameters.Add("@Lattitude", SqlDbType.Float).Value = location.GeografskaSirina;
                    cmd.Parameters.Add("@Longitude", SqlDbType.Float).Value = location.GeografskaDuzina;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = location.Adresa;

                    if (GetOne(location.Id) == null)
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}