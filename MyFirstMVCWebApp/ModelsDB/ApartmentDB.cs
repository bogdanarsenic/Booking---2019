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
    public class ApartmentDB
    {

        string connectionString = ConfigurationManager.ConnectionStrings["Baza"].ConnectionString;

        UserDB userDB = new UserDB();
        LocationDB locationDB = new LocationDB();

        public void UpdateFreeDates(Apartman apartment)
        {
            string Query = "UPDATE Apartments set RentedDates=@RentedDates " +
               "WHERE Id='" + apartment.Id + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    cmd.Parameters.Add("@RentedDates", SqlDbType.NVarChar).Value = apartment.RentedDates;
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Insert(Apartman apartment)
        {
            string Query = "INSERT INTO Apartments(Id, Type, RoomsCapacity, GuestCapacity, LocationId, RentedDates, UserId, Pictures, DailyPrice, EnteringTime, LeavingTime, IsActive,IsDeleted, Amenities) VALUES(@Id, @Type, @RoomsCapacity, @GuestCapacity, @LocationId, @RentedDates, @UserId, @Pictures, @DailyPrice, @EnteringTime, @LeavingTime, @IsActive,@IsDeleted, @Amenities)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();

                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = apartment.Id.ToString();
                    cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = apartment.Type;
                    cmd.Parameters.Add("@RoomsCapacity", SqlDbType.Int).Value = apartment.RoomsCapacity;
                    cmd.Parameters.Add("@GuestCapacity", SqlDbType.Int).Value = apartment.GuestCapacity;
                    cmd.Parameters.Add("@LocationId", SqlDbType.NVarChar).Value = apartment.LocationId;
                    cmd.Parameters.Add("@RentedDates", SqlDbType.NVarChar).Value = apartment.RentedDates;
                    cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = apartment.UserId;
                    cmd.Parameters.Add("@Pictures", SqlDbType.NVarChar).Value = apartment.Pictures;
                    cmd.Parameters.Add("@DailyPrice", SqlDbType.Int).Value = apartment.DailyPrice;
                    cmd.Parameters.Add("@EnteringTime", SqlDbType.NVarChar).Value = apartment.EnteringTime;
                    cmd.Parameters.Add("@LeavingTime", SqlDbType.NVarChar).Value = apartment.LeavingTime;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = apartment.IsActive;
                    cmd.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = apartment.IsDeleted;
                    cmd.Parameters.Add("@Amenities", SqlDbType.NVarChar).Value = apartment.Amenities;





                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Update(Apartman apartment)
        {
            string Query = "UPDATE Apartments set Id = @Id, Type = @Type, RoomsCapacity = @RoomsCapacity, GuestCapacity = @GuestCapacity, LocationId = @LocationId, RentedDates=@RentedDates, UserId=@UserId, Pictures=@Pictures, DailyPrice=@DailyPrice, EnteringTime=@EnteringTime, LeavingTime=@LeavingTime, IsActive=@IsActive, IsDeleted=@IsDeleted, Amenities=@Amenities  " +
               "WHERE Id = @id";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();

                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = apartment.Id.ToString();
                    cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = apartment.Type;
                    cmd.Parameters.Add("@RoomsCapacity", SqlDbType.Int).Value = apartment.RoomsCapacity;
                    cmd.Parameters.Add("@GuestCapacity", SqlDbType.Int).Value = apartment.GuestCapacity;
                    cmd.Parameters.Add("@LocationId", SqlDbType.NVarChar).Value = apartment.LocationId;
                    cmd.Parameters.Add("@RentedDates", SqlDbType.NVarChar).Value = apartment.RentedDates;
                    cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = apartment.UserId;
                    cmd.Parameters.Add("@Pictures", SqlDbType.NVarChar).Value = apartment.Pictures;
                    cmd.Parameters.Add("@DailyPrice", SqlDbType.Int).Value = apartment.DailyPrice;
                    cmd.Parameters.Add("@EnteringTime", SqlDbType.NVarChar).Value = apartment.EnteringTime;
                    cmd.Parameters.Add("@LeavingTime", SqlDbType.NVarChar).Value = apartment.LeavingTime;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = apartment.IsActive;
                    cmd.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = apartment.IsDeleted;
                    cmd.Parameters.Add("@Amenities", SqlDbType.NVarChar).Value = apartment.Amenities;

                    cmd.ExecuteNonQuery();
                }
            }
        }



        public List<Apartman> GetAllByUserId(string UserId)
        {

            List<Apartman> apartments = new List<Apartman>();

            string Query = "SELECT * FROM Apartments WHERE isDeleted='False' and UserId='" + UserId + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Apartman apartment = new Apartman();
                        apartment.Id = new Guid(reader["Id"].ToString());
                        apartment.Type = reader["Type"].ToString();
                        apartment.RoomsCapacity = Convert.ToInt32(reader["RoomsCapacity"].ToString());
                        apartment.GuestCapacity = Convert.ToInt32(reader["GuestCapacity"].ToString());
                        apartment.LocationId = reader["LocationId"].ToString();
                        apartment.RentedDates = reader["RentedDates"].ToString();
                        apartment.UserId = reader["UserId"].ToString();
                        apartment.Pictures = reader["Pictures"].ToString();
                        apartment.DailyPrice = Convert.ToInt32(reader["DailyPrice"].ToString());
                        apartment.EnteringTime = reader["EnteringTime"].ToString();
                        apartment.LeavingTime = reader["LeavingTime"].ToString();
                        apartment.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                        apartment.Amenities = reader["Amenities"].ToString();
                        apartment.User = userDB.GetOneByID(new Guid(apartment.UserId));
                        apartment.Host = apartment.User.Name + " " + apartment.User.Surname;
                        apartment.Location = locationDB.GetOne(new Guid(apartment.LocationId));
                        apartment.Address = apartment.Location.Adresa;
                        apartments.Add(apartment);
                    }
                }
            }

            return apartments;
        }

        public Apartman GetOneByUserId(string UserId)
        {
            string Query = "SELECT * FROM Apartments WHERE isDeleted='False' and UserId='" + UserId + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    Apartman apartment = null;
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        apartment = new Apartman()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            Type = reader["Type"].ToString(),
                            RoomsCapacity = Convert.ToInt32(reader["RoomsCapacity"].ToString()),
                            GuestCapacity = Convert.ToInt32(reader["GuestCapacity"].ToString()),
                            LocationId = reader["LocationId"].ToString(),
                            RentedDates = reader["RentedDates"].ToString(),
                            UserId = reader["UserId"].ToString(),
                            Pictures = reader["Pictures"].ToString(),
                            DailyPrice = Convert.ToInt32(reader["DailyPrice"].ToString()),
                            EnteringTime = reader["EnteringTime"].ToString(),
                            LeavingTime = reader["LeavingTime"].ToString(),
                            IsActive = Convert.ToBoolean(reader["FreeDates"].ToString()),
                            Amenities = reader["Amenities"].ToString(),

                        };
                    }
                    return apartment;
                }
                catch
                {
                    return null;
                }
            }
        }

        public Apartman GetOneById(string Id)
        {
            string Query = "SELECT * FROM Apartments WHERE isDeleted='False' and Id='" + Id + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    Apartman apartment = null;
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        apartment = new Apartman();
                        apartment.Id = new Guid(reader["Id"].ToString());
                        apartment.Type = reader["Type"].ToString();
                        apartment.RoomsCapacity = Convert.ToInt32(reader["RoomsCapacity"].ToString());
                        apartment.GuestCapacity = Convert.ToInt32(reader["GuestCapacity"].ToString());
                        apartment.LocationId = reader["LocationId"].ToString();
                        apartment.RentedDates = reader["RentedDates"].ToString();
                        apartment.UserId = reader["UserId"].ToString();
                        apartment.Pictures = reader["Pictures"].ToString();
                        apartment.DailyPrice = Convert.ToInt32(reader["DailyPrice"].ToString());
                        apartment.EnteringTime = reader["EnteringTime"].ToString();
                        apartment.LeavingTime = reader["LeavingTime"].ToString();
                        apartment.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                        apartment.Amenities = reader["Amenities"].ToString();
                        apartment.User = userDB.GetOneByID(new Guid(apartment.UserId));
                        apartment.Host = apartment.User.Name + " " + apartment.User.Surname;
                        apartment.Location = locationDB.GetOne(new Guid(apartment.LocationId));
                        apartment.Address = apartment.Location.Adresa;


                    }
                    return apartment;
                }
                catch
                {
                    return null;
                }
            }
        }

        public void Delete(string Id)
        {
            string Query = "Update Apartments SET isDeleted='True' WHERE Id='" + Id + "'";
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

        public List<Apartman> GetAll()
        {

            List<Apartman> apartments = new List<Apartman>();

            string Query = "SELECT * FROM Apartments WHERE isDeleted='False'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Apartman apartment = new Apartman();
                        apartment.Id = new Guid(reader["Id"].ToString());
                        apartment.Type = reader["Type"].ToString();
                        apartment.RoomsCapacity = Convert.ToInt32(reader["RoomsCapacity"].ToString());
                        apartment.GuestCapacity = Convert.ToInt32(reader["GuestCapacity"].ToString());
                        apartment.LocationId = reader["LocationId"].ToString();
                        apartment.RentedDates = reader["RentedDates"].ToString();
                        apartment.UserId = reader["UserId"].ToString();
                        apartment.Pictures = reader["Pictures"].ToString();
                        apartment.DailyPrice = Convert.ToInt32(reader["DailyPrice"].ToString());
                        apartment.EnteringTime = reader["EnteringTime"].ToString();
                        apartment.LeavingTime = reader["LeavingTime"].ToString();
                        apartment.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                        apartment.Amenities = reader["Amenities"].ToString();
                        apartment.User = userDB.GetOneByID(new Guid(apartment.UserId));
                        apartment.Host = apartment.User.Name + " " + apartment.User.Surname;
                        apartment.Location = locationDB.GetOne(new Guid(apartment.LocationId));
                        apartment.Address = apartment.Location.Adresa;
                        apartments.Add(apartment);

                    }
                }
            }

            return apartments;
        }


        public List<Apartman> GetAllGuest()
        {

            List<Apartman> apartments = new List<Apartman>();

            string Query = "SELECT * FROM Apartments WHERE isDeleted='False' and IsActive='True'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Apartman apartment = new Apartman();
                        apartment.Id = new Guid(reader["Id"].ToString());
                        apartment.Type = reader["Type"].ToString();
                        apartment.RoomsCapacity = Convert.ToInt32(reader["RoomsCapacity"].ToString());
                        apartment.GuestCapacity = Convert.ToInt32(reader["GuestCapacity"].ToString());
                        apartment.LocationId = reader["LocationId"].ToString();
                        apartment.RentedDates = reader["RentedDates"].ToString();
                        apartment.UserId = reader["UserId"].ToString();
                        apartment.Pictures = reader["Pictures"].ToString();
                        apartment.DailyPrice = Convert.ToInt32(reader["DailyPrice"].ToString());
                        apartment.EnteringTime = reader["EnteringTime"].ToString();
                        apartment.LeavingTime = reader["LeavingTime"].ToString();
                        apartment.IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                        apartment.Amenities = reader["Amenities"].ToString();
                        apartment.User = userDB.GetOneByID(new Guid(apartment.UserId));
                        apartment.Host = apartment.User.Name + " " + apartment.User.Surname;
                        apartment.Location = locationDB.GetOne(new Guid(apartment.LocationId));
                        apartment.Address = apartment.Location.Adresa;
                        apartments.Add(apartment);

                    }
                }
            }

            return apartments;
        }
    }
}
