using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.Moduli
{
    class Nastavnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int BrojTel { get; set; }

        public Nastavnik(int id, string ime, string prezime, int brojTel)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            BrojTel = brojTel;
        }

        public override string ToString()
        {
            return String.Format("ID: {0} | Ime: {1} | Prezime: {2} | Telefon: {3}", Id, Ime, Prezime, BrojTel);
        }
    }
}
