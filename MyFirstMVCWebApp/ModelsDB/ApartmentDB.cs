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



        public void Insert(Apartman apartment)
        {
            string Query = "INSERT INTO Apartments(Id, Type, RoomsCapacity, GuestCapacity, LocationId,RentableDates,FreeDates,UserId,Pictures,DailyPrice,EnteringTime,LeavingTime,IsActive,Amenities) VALUES(@Id, @Type, @RoomsCapacity, @GuestCapacity, @LocationId, @RentableDates, @FreeDates, @UserId, @Pictures, @DailyPrice, @EnteringTime, @LeavingTime, @IsActive, @Amenities)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();

                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = apartment.Id.ToString();
                    cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = apartment.Tip;
                    cmd.Parameters.Add("@RoomsCapacity", SqlDbType.Int).Value = apartment.BrSoba;
                    cmd.Parameters.Add("@GuestCapacity", SqlDbType.Int).Value = apartment.BrGost;
                    cmd.Parameters.Add("@LocationId", SqlDbType.NVarChar).Value = apartment.LokacijaId;
                    cmd.Parameters.Add("@RentableDates", SqlDbType.NVarChar).Value = apartment.IzadavanjeDani;
                    cmd.Parameters.Add("@FreeDates", SqlDbType.NVarChar).Value = apartment.SlobodniDani;
                    cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = apartment.KorisnikId;
                    cmd.Parameters.Add("@Pictures", SqlDbType.NVarChar).Value = apartment.Slike;
                    cmd.Parameters.Add("@DailyPrice", SqlDbType.Int).Value = apartment.Cena;
                    cmd.Parameters.Add("@EnteringTime", SqlDbType.NVarChar).Value = apartment.VremePrijave;
                    cmd.Parameters.Add("@LeavingTime", SqlDbType.NVarChar).Value = apartment.VremeOdjave;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = apartment.Aktivan;
                    cmd.Parameters.Add("@Amenities", SqlDbType.NVarChar).Value = apartment.Sadrzaj;


                    //cmd.Parameters.Add("@surname", SqlDbType.NVarChar).Value = book.Library.Id.ToString();

                    if (GetOneApartmanById(apartment.Id) == null)
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public Apartman GetOneApartmanById(Guid id)
        {
            string query = "SELECT * FROM Apartments WHERE Id='" + id + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    Apartman apartment = null;
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        apartment = new Apartman()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            Tip = reader["Type"].ToString(),
                            BrSoba = Convert.ToInt32(reader["RoomsCapacity"].ToString()),
                            BrGost = Convert.ToInt32(reader["GuestCapacity"].ToString()),
                            LokacijaId = reader["LocationId"].ToString(),
                            IzadavanjeDani = reader["RentableDates"].ToString(),
                            SlobodniDani = reader["FreeDates"].ToString(),
                            KorisnikId = reader["UserId"].ToString(),
                            Slike = reader["Pictures"].ToString(),
                            Cena = Convert.ToInt32(reader["DailyPrice"].ToString()),
                            VremePrijave = reader["EnteringTime"].ToString(),
                            VremeOdjave = reader["LeavingTime"].ToString(),
                            Aktivan = Convert.ToBoolean(reader["FreeDates"].ToString()),
                            Sadrzaj = reader["Amenities"].ToString(),

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



        public List<Apartman> GetAllByUserId(string UserId)
        {

            List<Apartman> apartments = new List<Apartman>();

            string Query = "SELECT * FROM Apartments WHERE UserId='" + UserId + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Apartman apartment = new Apartman()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            Tip = reader["Type"].ToString(),
                            BrSoba = Convert.ToInt32(reader["RoomsCapacity"].ToString()),
                            BrGost = Convert.ToInt32(reader["GuestCapacity"].ToString()),
                            LokacijaId = reader["LocationId"].ToString(),
                            IzadavanjeDani = reader["RentableDates"].ToString(),
                            SlobodniDani = reader["FreeDates"].ToString(),
                            KorisnikId = reader["UserId"].ToString(),
                            Slike = reader["Pictures"].ToString(),
                            Cena = Convert.ToInt32(reader["DailyPrice"].ToString()),
                            VremePrijave = reader["EnteringTime"].ToString(),
                            VremeOdjave = reader["LeavingTime"].ToString(),
                            Aktivan = Convert.ToBoolean(reader["FreeDates"].ToString()),
                            Sadrzaj = reader["Amenities"].ToString(),
                        };
                        apartments.Add(apartment);
                    }
                }
            }

            return apartments;
        }

        public Apartman GetOneByUserId(string UserId)
        {
            string Query = "SELECT * FROM Apartments WHERE UserId='" + UserId + "'";
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
                            Tip = reader["Type"].ToString(),
                            BrSoba = Convert.ToInt32(reader["RoomsCapacity"].ToString()),
                            BrGost = Convert.ToInt32(reader["GuestCapacity"].ToString()),
                            LokacijaId = reader["LocationId"].ToString(),
                            IzadavanjeDani = reader["RentableDates"].ToString(),
                            SlobodniDani = reader["FreeDates"].ToString(),
                            KorisnikId = reader["UserId"].ToString(),
                            Slike = reader["Pictures"].ToString(),
                            Cena = Convert.ToInt32(reader["DailyPrice"].ToString()),
                            VremePrijave = reader["EnteringTime"].ToString(),
                            VremeOdjave = reader["LeavingTime"].ToString(),
                            Aktivan = Convert.ToBoolean(reader["FreeDates"].ToString()),
                            Sadrzaj = reader["Amenities"].ToString(),

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
    }
}
