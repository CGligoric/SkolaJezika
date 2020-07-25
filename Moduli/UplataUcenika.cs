using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.Moduli
{
    class UplataUcenika
    {
        public int Id { get; set; }
        public Uplata Uplata { get; set; }
        public Ucenik Ucenik { get; set; }

        public UplataUcenika(int id, Uplata uplata, Ucenik ucenik)
        {
            Id = id;
            Uplata = uplata;
            Ucenik = ucenik;
        }

        public override string ToString()
        {
            return String.Format("Datum uplate: {0} | Ime i prezime ucenika: {1} | Iznos: {2:c}", Uplata.Datum, Ucenik.Ime + " " + Ucenik.Prezime, Uplata.Iznos);
        }
    }
}
