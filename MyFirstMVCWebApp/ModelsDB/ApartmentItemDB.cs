using MyFirstMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyFirstMVCWebApp.ModelsDB
{
    public class ApartmentItemDB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Baza"].ConnectionString;

        public SadrzajApartman GetOne(Guid Id)
        {
            string Query = "SELECT * FROM ApartmentItems WHERE Id='" + Id + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SadrzajApartman apartmentItem = null;
                    //LibraryDAL library = new LibraryDAL();
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        apartmentItem = new SadrzajApartman()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            Predmet = reader["Item"].ToString(),


                        };
                    }
                    return apartmentItem;
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<SadrzajApartman> GetAll()
        {

            List<SadrzajApartman> apartmentItems = new List<SadrzajApartman>();

            string Query = "SELECT * FROM ApartmentItems";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SadrzajApartman book = new SadrzajApartman()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            Predmet = reader["Item"].ToString(),


                        };
                        apartmentItems.Add(book);
                    }
                }
            }

            return apartmentItems;
        }
    }
}