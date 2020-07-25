using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.Moduli
{
    class PohadjaPredaje
    {
        public int Id { get; set; }
        public Nastavnik Nastavnik { get; set; }
        public Ucenik Ucenik { get; set; }
        public Kurs Kurs { get; set; }

        public PohadjaPredaje(int id, Nastavnik nastavnik, Ucenik ucenik, Kurs kurs)
        {
            Id = id;
            Kurs = kurs;
            Nastavnik = nastavnik;
            Ucenik = ucenik;
        }

        public override string ToString()
        {
            return String.Format("ID kursa: {0} | Ime i prezime nastavnika: {1} | Ime i prezime ucenika: {2}",
                Kurs.Id, Nastavnik.Ime + " " + Nastavnik.Prezime, Ucenik.Ime + " " + Ucenik.Prezime);
        }
    }
}
