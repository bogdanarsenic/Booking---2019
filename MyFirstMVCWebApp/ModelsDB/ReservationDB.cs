﻿using MyFirstMVCWebApp.Models;
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
        UserDB userDb = new UserDB();


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

                    //cmd.Parameters.Add("@surname", SqlDbType.NVarChar).Value = book.Library.Id.ToString();

                    if (GetOne(reservation.Id.ToString()) == null)
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        public Rezervacija GetOne(string Id)
        {
            string Query = "SELECT * FROM Reservations WHERE Id='" + Id + "'";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    Rezervacija reservation = null;
                    //LibraryDAL library = new LibraryDAL();
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        reservation = new Rezervacija()
                        {
                            Id = new Guid(reader["Id"].ToString()),
                            ApartmanId = reader["ApartmentId"].ToString(),
                            StartingDate = Convert.ToDateTime(reader["StartingDate"].ToString()),
                            BrNoci = Convert.ToInt32(reader["Name"].ToString()),
                            Cena = Convert.ToInt32(reader["Surname"].ToString()),
                            UserId = reader["Gender"].ToString(),
                            Status = reader["Role"].ToString(),
                        };
                    }
                    return reservation;
                }
                catch
                {
                    return null;
                }
            }
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
                     /*   reservation.Apartman = apartmentDB.GetOneById(reservation.ApartmentId);
                        reservation.Host = userDB.GetOneById(new Guid(reservation.Apartment.UserId)).Name + " " + userDB.GetOneById(new Guid(reservation.Apartment.UserId)).Surname;
                        reservation.Guest = userDB.GetOneById(new Guid(reservation.UserId)).Name + " " + userDB.GetOneById(new Guid(reservation.UserId)).Surname;
                        reservations.Add(reservation);
                        */
                    }
                }
            }

            return rez;
        }
    }
}