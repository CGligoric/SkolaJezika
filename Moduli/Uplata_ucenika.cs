using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.Moduli
{
    class Uplata_ucenika
    {
        public int Id { get; set; }
        public Uplata Uplata { get; set; }
        public Ucenik Ucenik { get; set; }

        public Uplata_ucenika(int id, Uplata uplata, Ucenik ucenik)
        {
            Id = id;
            Uplata = uplata;
            Ucenik = ucenik;
        }
    }
}
