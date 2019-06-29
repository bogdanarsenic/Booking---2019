using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstMVCWebApp.Models
{
    public class Korisnik
    {
        private Guid id;
        private string pol;
        private List<Apartman> apartmaniIzadavanje;
        private List<Apartman> apartmaniIzdati;
        private List<Rezervacija> rezervacije;
        private string username;
        private string lozinka;
        private string ime;
        private string prezime;
        private string uloga;


        public string Username { get => username; set => username = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Uloga { get => uloga; set => uloga = value; }
        public Guid Id { get => id; set => id = value; }
        public string Pol { get => pol; set => pol = value; }
        public List<Apartman> ApartmaniIzadavanje { get => apartmaniIzadavanje; set => apartmaniIzadavanje = value; }
        public List<Apartman> ApartmaniIzdati { get => apartmaniIzdati; set => apartmaniIzdati = value; }
        public List<Rezervacija> Rezervacije { get => rezervacije; set => rezervacije = value; }


        public Korisnik()
        { }

        public Korisnik(string username,string lozinka,string pol,string ime, string prezime,string uloga)

        {
            Id = Guid.NewGuid();
            Username = username;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            Uloga = uloga;
            if(uloga=="Domacin")
            {
                ApartmaniIzadavanje = new List<Apartman>();
            }

            else if(uloga=="Gost")
            {
                ApartmaniIzdati = new List<Apartman>();
                Rezervacije = new List<Rezervacija>();
            }

        }
      }
}