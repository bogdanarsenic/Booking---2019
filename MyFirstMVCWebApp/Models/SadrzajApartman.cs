using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstMVCWebApp.Models
{
    public class SadrzajApartman
    {
        private Guid id;
        private string predmet;

        public Guid Id { get => id; set => id = value; }
        public string Predmet { get => predmet; set => predmet = value; }

        public SadrzajApartman()
        {

        }

        public SadrzajApartman(string predmet)
        {
            Id = Guid.NewGuid();
            Predmet = predmet;
        }
    }
}