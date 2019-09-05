using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstMVCWebApp.Models
{
    public class Lokacija
    {
        

        public float Lattitude { get; set; }
        public float Longitude { get; set; }
        public string Adresa { get;set; }
        public Guid Id { get;set; }

        public Lokacija()
        {
        }

        public Lokacija(float geografskasirina,float geografskaduzina,string adresa)
        {
            Id = Guid.NewGuid();
            Longitude = geografskaduzina;
            Lattitude = geografskasirina;
            Adresa = adresa;
        }
    }
}