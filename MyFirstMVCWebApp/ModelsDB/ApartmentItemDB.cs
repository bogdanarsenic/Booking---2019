using MyFirstMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        public void Insert(SadrzajApartman sa)
        {
            string Query = "INSERT INTO ApartmentItems(Id, Item) VALUES(@Id, @Item)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();

                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = sa.Id.ToString();
                    cmd.Parameters.Add("@Predmet", SqlDbType.NVarChar).Value = sa.Predmet;


                    if (GetOne(sa.Id) == null)
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}