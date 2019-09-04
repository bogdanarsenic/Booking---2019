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


        public User GetOne(string Username)
        {
            string Query = "SELECT * FROM Users WHERE Username='" + Username + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    User user = null;
                    //LibraryDAL library = new LibraryDAL();
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Role = reader["Role"].ToString(),
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

        public User GetOneByID(Guid Id)
        {
            string Query = "SELECT * FROM Users WHERE Id='" + Id + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    User user = null;
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Role = reader["Role"].ToString(),
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

        public void Insert(User user)
        {
            string Query = "INSERT INTO Users(Id, Username, Password, Name, Surname, Gender,Role) VALUES(@Id, @Username, @Password, @Name, @Surname, @Gender, @Role)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();

                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = user.Id.ToString();
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.NChar).Value = user.Password;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = user.Name;
                    cmd.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = user.Surname;
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = user.Gender;
                    cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = user.Role;

                    //cmd.Parameters.Add("@surname", SqlDbType.NVarChar).Value = book.Library.Id.ToString();

                    if (GetOne(user.Username) == null)
                    {
                        cmd.ExecuteNonQuery();
                    }


                }
            }
        }

        public List<User> GetAllByRole(string Role)
        {
            //LibraryDAL library = new LibraryDAL();
            List<User> users = new List<User>();

            string Query = "SELECT * FROM Users WHERE Role='" + Role + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Role = reader["Role"].ToString(),
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


        public List<User> GetAllByGender(string Gender)
        {
            //LibraryDAL library = new LibraryDAL();
            List<User> users = new List<User>();

            string Query = "SELECT * FROM Users WHERE Gender='" + Gender + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Role = reader["Role"].ToString(),
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

        public void Update(User user)
        {
            string Query = "UPDATE Users set Id = @Id, Username = @Username, Password = @Password, Name = @Name, Surname = @Surname, Gender=@Gender, Role=@Role  " +
               "WHERE Id = @id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();

                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = user.Id.ToString();
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.NChar).Value = user.Password;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = user.Name;
                    cmd.Parameters.Add("@Surname", SqlDbType.NVarChar).Value = user.Surname;
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = user.Gender;
                    cmd.Parameters.Add("@Role", SqlDbType.NVarChar).Value = user.Role;

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<User> GetAll()
        {
            //LibraryDAL library = new LibraryDAL();
            List<User> users = new List<User>();

            string Query = "SELECT * FROM Users";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User()
                        {
                         //   Id = new Guid(reader["Id"].ToString()),
                            Username = reader["Username"].ToString(),
                            Password = reader["Password"].ToString(),
                            Name = reader["Name"].ToString(),
                            Surname = reader["Surname"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Role = reader["Role"].ToString(),
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