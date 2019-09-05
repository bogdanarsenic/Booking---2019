using MyFirstMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstMVCWebApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public List<Apartman> RentableApartmans { get; set; }
        public List<Apartman> RentedApartmans { get; set; }
        public List<Rezervacija> Reservations { get; set; }

        public User()
        {


        }

        public User(string username,string password,string name,string surname,string gender,string role)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Gender = gender;
            Role = role;
            if(role=="Host")
            {
                RentableApartmans = new List<Apartman>();
            }
            else if(role=="Guest")
            {
                RentedApartmans = new List<Apartman>();
                Reservations = new List<Rezervacija>();
            }
        }

    }

    
}