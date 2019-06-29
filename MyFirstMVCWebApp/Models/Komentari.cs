using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstMVCWebApp.Models
{
    public class Komentari
    {
        private Guid id;
        private string korisnikId;
        private string komentar;
        private int ocena;
        private string apartmanId;

        public Guid Id { get => id; set => id = value; }
        public string KorisnikId { get => korisnikId; set => korisnikId = value; }
        public string Komentar { get => komentar; set => komentar = value; }
        public int Ocena { get => ocena; set => ocena = value; }
        public string ApartmanId { get => apartmanId; set => apartmanId = value; }

        public Komentari()
        {

        }

        public Komentari(string korisnikId,string apartmanId,string text,int ocena)
        {
            Id = Guid.NewGuid();
            KorisnikId = korisnikId;
            ApartmanId = apartmanId;
            Komentar = komentar;
            Ocena = ocena;
        }
    }
}