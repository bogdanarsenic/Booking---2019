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
        public bool IsApproved { get; set; }
        public User User { get; set; }
        public string Gost { get; set; }

        public Komentari()
        {

        }

        public Komentari(string korisnikId,string apartmanId,string text,int ocena,bool isApproved)
        {
            Id = Guid.NewGuid();
            KorisnikId = korisnikId;
            ApartmanId = apartmanId;
            Komentar = komentar;
            Ocena = ocena;
            IsApproved = isApproved;
        }
    }
}