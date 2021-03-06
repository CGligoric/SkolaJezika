﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.Moduli
{
    class Uplata
    {
        public int Id { get; set; }
        public string Datum { get; set; }
        public int Iznos { get; set; }

        public Uplata(int id, string datum, int iznos)
        {
            Id = id;
            Datum = datum;
            Iznos = iznos;
        }

        public override string ToString()
        {
            return String.Format("ID: {0} | Datum uplate: {1} | Iznos: {2:c}", Id, Datum, Iznos);
        }
    }
}
