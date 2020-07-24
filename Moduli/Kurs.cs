using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.Moduli
{
    class Kurs
    {
        public int Id { get; set; }
        public Nivo Nivo { get; set; }
        public string Jezik { get; set;}
        public int Cena { get; set; }


        public Kurs(int id, string jezik, int cena)
        {
            Nivo = new Nivo();

            Id = id;
            Jezik = jezik;
            Cena = cena;
        }
    }
}
