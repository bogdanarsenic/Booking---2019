using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFirstMVCWebApp.Models
{
    public class Rezervacija
    {
       
        public DateTime? StartingDate { get; set; }
        public double Cena { get => cena; set => cena = value; }
        public string Status { get => status; set => status = value; }
        public int BrNoci { get => brNoci; set => brNoci = value; }
        public Guid Id { get => id; set => id = value; }
        public string UserId { get => userId; set => userId = value; }
        public Apartman Apartman { get => apartman; set => apartman = value; }
        public string ApartmanId { get => apartmanId; set => apartmanId = value; }

        private Guid id;
        private double cena;
        private string status;
        private int brNoci;

        private string userId;
        private Apartman apartman;
        private string apartmanId;

        public Rezervacija()
        { }

        public Rezervacija(string apartmanId,DateTime starting,double cena,string userId,string status)
        {
            Id = Guid.NewGuid();
            ApartmanId = apartmanId;
            StartingDate = starting;
            Cena = cena;
            brNoci = 1;
            UserId = userId;
            Status = status;
        }
    }
}