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
    public class UserDB
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["Baza"].ConnectionString;


        public Korisnik GetOne(string Username)
        {
            string Query = "SELECT * FROM Users WHERE Username='" + Username + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    Korisnik user = null;
                    //LibraryDAL library = new LibraryDAL();
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new Korisnik()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            Username = reader["Username"].ToString(),
                            Lozinka = reader["Password"].ToString(),
                            Ime = reader["Name"].ToString(),
                            Prezime = reader["Surname"].ToString(),
                            Pol = reader["Gender"].ToString(),
                            Uloga = reader["Role"].ToString(),
                            //RentableApartmans
                            //RentedApartmans
                            //Reservations
                            //Library = library.GetOne(new Guid(reader["Id_Library"].ToString()))

                        };
                    }
                    return user;
                }
                catch
                {
                    return null;
                }
            }
        }

        public void Insert(Korisnik user)
        {
            string Query = "INSERT INTO Users(Id, Username, Password, Name, Surname,Gender,Role) VALUES(@Id, @Username, @Password, @Name, @Surname, @Gender, @Role)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();

                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = user.Id.ToString();
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.NChar).Value = user.Lozinka;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = user.Ime;
                    cmd.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = user.Prezime;
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = user.Pol;
                    cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = user.Uloga;

                    //cmd.Parameters.Add("@surname", SqlDbType.NVarChar).Value = book.Library.Id.ToString();

                    if (GetOne(user.Username) == null)
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<Korisnik> GetAllByRole(string Role)
        {
            //LibraryDAL library = new LibraryDAL();
            List<Korisnik> users = new List<Korisnik>();

            string Query = "SELECT * FROM Users WHERE Role='" + Role + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Korisnik user = new Korisnik()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            Username = reader["Username"].ToString(),
                            Lozinka = reader["Password"].ToString(),
                            Ime = reader["Name"].ToString(),
                            Prezime = reader["Surname"].ToString(),
                            Pol = reader["Gender"].ToString(),
                            Uloga = reader["Role"].ToString(),
                            //RentableApartmans
                            //RentedApartmans
                            //Reservations
                            //Library = library.GetOne(new Guid(reader["Id_Library"].ToString()))

                        };
                        users.Add(user);
                    }
                }
            }

            return users;
        }


        public List<Korisnik> GetAllByGender(string Gender)
        {
            //LibraryDAL library = new LibraryDAL();
            List<Korisnik> users = new List<Korisnik>();

            string Query = "SELECT * FROM Users WHERE Gender='" + Gender + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Korisnik user = new Korisnik()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            Username = reader["Username"].ToString(),
                            Lozinka = reader["Password"].ToString(),
                            Ime = reader["Name"].ToString(),
                            Prezime = reader["Surname"].ToString(),
                            Pol = reader["Gender"].ToString(),
                            Uloga = reader["Role"].ToString(),
                            //RentableApartmans
                            //RentedApartmans
                            //Reservations
                            //Library = library.GetOne(new Guid(reader["Id_Library"].ToString()))

                        };
                        users.Add(user);
                    }
                }
            }

            return users;
        }



        public List<Korisnik> GetAll()
        {
            //LibraryDAL library = new LibraryDAL();
            List<Korisnik> users = new List<Korisnik>();

            string Query = "SELECT * FROM Users";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Korisnik user = new Korisnik()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            Username = reader["Username"].ToString(),
                            Lozinka = reader["Password"].ToString(),
                            Ime = reader["Name"].ToString(),
                            Prezime = reader["Surname"].ToString(),
                            Pol = reader["Gender"].ToString(),
                            Uloga = reader["Role"].ToString(),
                            //RentableApartmans
                            //RentedApartmans
                            //Reservations
                            //Library = library.GetOne(new Guid(reader["Id_Library"].ToString()))

                        };
                        users.Add(user);
                    }
                }
            }

            return users;
        }
    }
}