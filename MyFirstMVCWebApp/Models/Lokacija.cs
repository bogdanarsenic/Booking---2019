using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFirstMVCWebApp.Models
{
    public class Lokacija
    {
        private Guid id;
        private float geografskaSirina;
        private float geografskaDuzina;
        private string adresa;

        public float GeografskaSirina { get => geografskaSirina; set => geografskaSirina = value; }
        public float GeografskaDuzina { get => geografskaDuzina; set => geografskaDuzina = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public Guid Id { get => id; set => id = value; }

        public Lokacija()
        {
        }

        public Lokacija(float geografskasirina,float geografskaduzina,string adresa)
        {
            Id = Guid.NewGuid();
            GeografskaDuzina = geografskaduzina;
            GeografskaSirina = geografskaSirina;
            Adresa = adresa;
        }
    }
}