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
        public int NivoId { get; set; }
        public string Jezik { get; set;}
        public int Cena { get; set; }


        public Kurs(int id, int nivoId, string jezik, int cena)
        {
            Nivo = new Nivo();

            Id = id;
            NivoId = nivoId;
            Jezik = jezik;
            Cena = cena;
        }

        public override string ToString()
        {
            return String.Format("ID: {0} | Nivo: {1} | Jezik: {2} | Cena: {3:c}", Id, Nivo.Naziv, Jezik, Cena);
        }
    }
}
