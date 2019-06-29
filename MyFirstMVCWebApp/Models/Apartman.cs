using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstMVCWebApp.Models
{
    public class Apartman
    {
        private Guid id;
        private string tip;
        private int brSoba;
        private int brGost;
        private Lokacija lokacija;
        private string lokacijaId;
        private string datum;
        private double cena;
        private List<Komentari> komentari;
        private string slike;
        private bool aktivan;
        private List<Rezervacija> rezervacije;
        private string sadrzaj;
        private string vremePrijave;
        private string vremeOdjave;
        private string korisnikId;
        private string slobodniDani;
        private string izadavanjeDani;

        

        public string Tip { get => tip; set => tip = value; }
        public int BrSoba { get => brSoba; set => brSoba = value; }
        public int BrGost { get => brGost; set => brGost = value; }
        public string LokacijaId { get => lokacijaId; set => lokacijaId = value; }
        public string Datum { get => datum; set => datum = value; }
        public double Cena { get => cena; set => cena = value; }
        public string VremePrijave { get => vremePrijave; set => vremePrijave = value; }
        public string VremeOdjave { get => vremeOdjave; set => vremeOdjave = value; }
        public Lokacija Lokacija { get => lokacija; set => lokacija = value; }
        public List<Komentari> Komentari { get => komentari; set => komentari = value; }
        public string Slike { get => slike; set => slike = value; }
        public bool Aktivan { get => aktivan; set => aktivan = value; }
        public List<Rezervacija> Rezervacije { get => rezervacije; set => rezervacije = value; }
        public string Sadrzaj { get => sadrzaj; set => sadrzaj = value; }
        public string KorisnikId { get => korisnikId; set => korisnikId = value; }
        public string SlobodniDani { get => slobodniDani; set => slobodniDani = value; }
        public string IzadavanjeDani { get => izadavanjeDani; set => izadavanjeDani = value; }
        public Guid Id { get => id; set => id = value; }


        public Apartman()
        { }

        public Apartman(string tip,int brSoba,int brGost,string lokacijaId, string datum,double cena,string vremePrijave,string vremeOdjave,string slike,bool aktivan,string sadrzaj,string korisnikId,string slobodniDani,string izdavanjeDani)
        {
            Rezervacije = new List<Rezervacija>();
            Komentari = new List<Komentari>();
            Id = Guid.NewGuid();
            VremePrijave = "11AM";
            VremeOdjave = "10PM";
            Aktivan = false;
            Tip = tip;
            BrSoba = brSoba;
            BrGost = brGost;
            LokacijaId = lokacijaId;
            SlobodniDani = slobodniDani;
            IzadavanjeDani = izadavanjeDani;
            Slike = slike;
            Cena = cena;
            Sadrzaj = sadrzaj;
           
        }
            
    }
}