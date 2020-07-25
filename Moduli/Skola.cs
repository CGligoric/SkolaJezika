using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.Moduli
{
    class Skola
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public string AdresaSajta { get; set; }
        public int PIB { get; set; }
        public int MatBroj { get; set; }
        public int BrZiroRac { get; set; }

        public Skola (int id, string naziv, string adresa, int telefon, string email, string adresaSajta, int pib, int matBroj, int brZirRac)
        {
            Id = id;
            Naziv = naziv;
            Adresa = adresa;
            Telefon = telefon;
            Email = email;
            AdresaSajta = adresaSajta;
            PIB = pib;
            MatBroj = matBroj;
            BrZiroRac = brZirRac;
        }

        public override string ToString()
        {
            return String.Format("Naziv: {0} | Adresa: {1} | Telefon {2} | E-mail: {3} | Sajt: {4} | PIB: {5} | Maticni broj: {6} | Ziro racun: {7}",
                Naziv, Adresa, Telefon, Email, AdresaSajta, PIB, MatBroj, BrZiroRac);
        }
    }
}
