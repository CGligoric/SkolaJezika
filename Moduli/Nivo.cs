using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.Moduli
{
    class Nivo
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public Nivo() { }

        public Nivo(int id, string naziv)
        {
            Id = id;
            Naziv = naziv;
        }

        public override string ToString()
        {
            return String.Format("ID: {0} | Naziv: {1}", Id, Naziv);
        }
    }
}
