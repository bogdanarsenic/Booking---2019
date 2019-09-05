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
    public class ReservationDB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Baza"].ConnectionString;
        ApartmentDB apartmentDB = new ApartmentDB();
        UserDB userDB = new UserDB();


        public void Insert(Rezervacija reservation)
        {
            string Query = "INSERT INTO Reservations(Id, ApartmentId, StartingDate, OvernightStaysNum, TotalPrice ,UserId ,Status) VALUES(@Id, @ApartmentId, @StartingDate, @OvernightStaysNum, @TotalPrice, @UserId, @Status)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();

                    cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = reservation.Id.ToString();
                    cmd.Parameters.Add("@ApartmentId", SqlDbType.NVarChar).Value = reservation.ApartmanId;
                    cmd.Parameters.Add("@StartingDate", SqlDbType.DateTime2).Value = reservation.StartingDate;
                    cmd.Parameters.Add("@OvernightStaysNum", SqlDbType.Int).Value = reservation.BrNoci;
                    cmd.Parameters.Add("@TotalPrice", SqlDbType.Int).Value = reservation.Cena;
                    cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = reservation.UserId;
                    cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = reservation.Status;

                    cmd.ExecuteNonQuery();
                    //cmd.Parameters.Add("@surname", SqlDbType.NVarChar).Value = book.Library.Id.ToString();

                    
                }
            }
        }


        public List<Rezervacija> GetAllByApId(string IdAp)
        {

            //LibraryDAL library = new LibraryDAL();
            List<Rezervacija> reservations = new List<Rezervacija>();

            string Query = "SELECT * FROM Reservations WHERE ApartmentId='" + IdAp + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Rezervacija reservation = new Rezervacija();
                        reservation.Id = new Guid(reader["Id"].ToString());
                        reservation.ApartmanId = reader["ApartmentId"].ToString();
                        reservation.StartingDate = Convert.ToDateTime(reader["StartingDate"].ToString());
                        reservation.BrNoci = Convert.ToInt32(reader["OvernightStaysNum"].ToString());
                        reservation.Cena = Convert.ToInt32(reader["TotalPrice"].ToString());
                        reservation.UserId = reader["UserId"].ToString();
                        reservation.Status = reader["Status"].ToString();
                        reservation.Apartman = apartmentDB.GetOneById(reservation.ApartmanId);
                        reservation.Host = userDB.GetOneByID(new Guid(reservation.Apartman.UserId)).Name + " " + userDB.GetOneByID(new Guid(reservation.Apartman.UserId)).Surname;
                        reservation.Gost = userDB.GetOneByID(new Guid(reservation.UserId)).Name + " " + userDB.GetOneByID(new Guid(reservation.UserId)).Surname;
                        reservations.Add(reservation);
                    }
                }
            }

            return reservations;
        }

        public List<Rezervacija> GetAll()
        {
            //LibraryDAL library = new LibraryDAL();
            List<Rezervacija> rez = new List<Rezervacija>();

            string Query = "SELECT * FROM Reservations";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Rezervacija reservation = new Rezervacija();
                        reservation.Id = new Guid(reader["Id"].ToString());
                        reservation.ApartmanId = reader["ApartmentId"].ToString();
                        reservation.StartingDate = Convert.ToDateTime(reader["StartingDate"].ToString());
                        reservation.BrNoci = Convert.ToInt32(reader["OvernightStaysNum"].ToString());
                        reservation.Cena = Convert.ToInt32(reader["TotalPrice"].ToString());
                        reservation.UserId = reader["UserId"].ToString();
                        reservation.Status = reader["Status"].ToString();
                        reservation.Apartman = apartmentDB.GetOneById(reservation.ApartmanId);
                        reservation.Host = userDB.GetOneByID(new Guid(reservation.Apartman.UserId)).Name + " " + userDB.GetOneByID(new Guid(reservation.Apartman.UserId)).Surname;
                        reservation.Gost = userDB.GetOneByID(new Guid(reservation.UserId)).Name + " " + userDB.GetOneByID(new Guid(reservation.UserId)).Surname;
                        rez.Add(reservation);
                        
                    }
                }
            }

            return rez;
        }
    }
}