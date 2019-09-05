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
    public class CommentDB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Baza"].ConnectionString;
        UserDB userDB = new UserDB();

        public void Insert(Komentari comment)
        {
            string Query = "INSERT INTO Comments(Id, UserId, ApartmentId, Text, Rating) VALUES(@Id, @UserId, @ApartmentId, @Text, @Rating)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();

                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = comment.Id.ToString();
                    cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = comment.KorisnikId;
                    cmd.Parameters.Add("@ApartmentId", SqlDbType.NVarChar).Value = comment.ApartmanId;
                    cmd.Parameters.Add("@Text", SqlDbType.NVarChar).Value = comment.Komentar;
                    cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = comment.Ocena;
                    cmd.Parameters.Add("@IsApproved", SqlDbType.Bit).Value = comment.IsApproved;

                    if (GetOne(comment.Id) == null)
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }



        public Komentari GetOne(Guid Id)
        {
            string Query = "SELECT * FROM Comments WHERE Id='" + Id + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    Komentari comment = null;
                    //LibraryDAL library = new LibraryDAL();
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comment = new Komentari()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            KorisnikId = reader["UserId"].ToString(),
                            ApartmanId = reader["ApartmentId"].ToString(),
                            Komentar = reader["Text"].ToString(),
                            Ocena = Convert.ToInt32(reader["Rating"]),
                        };
                    }
                    return comment;
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<Komentari> GetAll(string UserId)
        {
            //LibraryDAL library = new LibraryDAL();
            List<Komentari> comments = new List<Komentari>();

            string Query = "SELECT * FROM Comments";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Komentari comment = new Komentari()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            KorisnikId = reader["UserId"].ToString(),
                            ApartmanId = reader["ApartmentId"].ToString(),
                            Komentar = reader["Text"].ToString(),
                            Ocena = Convert.ToInt32(reader["Rating"]),

                        };
                        comments.Add(comment);
                    }
                }
            }

            return comments;
        }

        public List<Komentari> GetAllByApartmentIdGuest(string ApartmentId)
        {

            List<Komentari> comments = new List<Komentari>();

            string Query = "SELECT * FROM Comments WHERE ApartmentId='" + ApartmentId + "' and IsApproved='True'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Komentari comment = new Komentari();
                        comment.Id = new Guid(reader["Id"].ToString());
                        comment.KorisnikId = reader["UserId"].ToString();
                        comment.ApartmanId = reader["ApartmentId"].ToString();
                        comment.User = userDB.GetOneByID(new Guid(comment.KorisnikId));
                        comment.Gost = comment.User.Name + " " + comment.User.Surname;
                        comment.Komentar = reader["Text"].ToString();
                        comment.Ocena = Convert.ToInt32(reader["Rating"]);


                        comments.Add(comment);
                    }
                }
            }

            return comments;
        }


        public List<Komentari> GetAllByApartmentId(string ApartmentId)
        {

            List<Komentari> comments = new List<Komentari>();

            string Query = "SELECT * FROM Comments WHERE ApartmentId='" + ApartmentId + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Komentari comment = new Komentari();
                        comment.Id = new Guid(reader["Id"].ToString());
                        comment.KorisnikId = reader["UserId"].ToString();
                        comment.ApartmanId = reader["ApartmentId"].ToString();
                        comment.User = userDB.GetOneByID(new Guid(comment.KorisnikId));
                        comment.Gost = comment.User.Name + " " + comment.User.Surname;
                        comment.Komentar = reader["Text"].ToString();
                        comment.Ocena = Convert.ToInt32(reader["Rating"]);


                        comments.Add(comment);
                    }
                }
                
            }

            return comments;
        }
        public void Approve(string Id)
        {
            string Query = "Update Comments SET isApproved='True' WHERE Id='" + Id + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {

                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                }
                catch
                {
                    return;
                }

            }
        }
    }
}