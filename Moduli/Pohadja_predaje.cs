using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.Moduli
{
    class Pohadja_predaje
    {
        public int Id { get; set; }
        public Nastavnik Nastavnik { get; set; }
        public Ucenik Ucenik { get; set; }
        public Kurs Kurs { get; set; }

        public Pohadja_predaje(int id, Nastavnik nastavnik, Ucenik ucenik, Kurs kurs)
        {
            Id = id;
            Kurs = kurs;
            Nastavnik = nastavnik;
            Ucenik = ucenik;
        }
    }
}
