﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.Moduli
{
    class Ucenik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int BrojTel { get; set; }

        public Ucenik (int id, string ime, string prezime, int brojTel)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            BrojTel = brojTel;
        }

        public override string ToString()
        {
            return String.Format("Id Ucenika: " + Id + " | Ime: " + Ime + " | Prezime: " + Prezime + " Telefon: " + BrojTel);
        }
    }
}
