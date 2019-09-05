using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstMVCWebApp.Models
{
    public class Apartman
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public int RoomsCapacity { get; set; }
        public int GuestCapacity { get; set; }
        public string LocationId { get; set; }
        public Lokacija Location { get; set; }
        public string RentableDates { get; set; }
        public string FreeDates { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Komentari> Comments { get; set; }
        public string Pictures { get; set; }
        public int DailyPrice { get; set; }
        public string EnteringTime { get; set; }
        public string LeavingTime { get; set; }
        public bool IsActive { get; set; }
        public string Amenities { get; set; }
        public List<Rezervacija> Reservations { get; set; }
        public string Host { get; set; }
        public string Address { get; set; }
        public string RentedDates { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public bool IsDeleted { get; set; }

        public Apartman()
        {

        }

        public Apartman(string type, int roomsCapacity, int guestCapacity, string locationId, string rentableDates, string freeDates, string userId, string comments, string pictures, int dailyPrice, string enteringTime, string leavingTime, bool isActive, string amenities, string host, string address, string rentedDates, float latitude, float longitude)
        {
            Id = Guid.NewGuid();
            EnteringTime = "2PM";
            LeavingTime = "10PM";
            IsActive = false;
            Type = type;
            RoomsCapacity = roomsCapacity;
            GuestCapacity = guestCapacity;
            LocationId = locationId;
            RentableDates = rentableDates;
            FreeDates = freeDates;
            UserId = userId;
            Comments = new List<Komentari>();
            Pictures = pictures;
            DailyPrice = dailyPrice;
            Amenities = amenities;
            Reservations = new List<Rezervacija>();
            Address = address;
            Host = host;
            RentedDates = rentedDates;
            Latitude = latitude;
            Longitude = longitude;
        }
    }

}
