using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;
using SkolaJezika.DAO;

namespace SkolaJezika.UI
{
    class UplataUcenikaUI
    {
        static List<UplataUcenika> sveUplataIUcenici = new List<UplataUcenika>();

        public static void IspisiMeni()
        {
            Console.WriteLine("Rad sa uplatama ucenika opcije: ");
            Console.WriteLine("1 - ispis svih uplatat svih ucenika");
            Console.WriteLine("2 - ispis uplate ucenika po id");
            Console.WriteLine("Opcija: ");
        }

        public static void IspisiKompletMeniUU()
        {
            bool nastavak = false;

            do
            {
                IspisiMeni();
                Console.Clear();

                int izbor = Convert.ToInt32(Console.ReadLine());

                switch (izbor)
                {
                    case 1:
                        IspisiSve();
                        break;
                    case 2:
                        IspisiUplatuUcenikaPoId();
                        break;
                }
                Console.WriteLine("Zelite li da nastavite s radom nad podacima uplata ucenika? y/n");
                string odg = Console.ReadLine();

                if (odg == "y")
                {
                    nastavak = true;
                }
            } while (nastavak);
        }

        public static void IspisiUplatuUcenikaPoId()
        {
            Console.WriteLine("Upisite id uplate ucenika: ");
            int id = Convert.ToInt32(Console.ReadLine());

            UplataUcenika uu = UplataUcenikaDAO.GetUplataByUcenikId(Program.conn, id);

            Console.WriteLine(uu.ToString());
        }

        public static void IspisiSve()
        {
            sveUplataIUcenici = UplataUcenikaDAO.GetAll(Program.conn);
            foreach (UplataUcenika uplataUcenika in sveUplataIUcenici)
            {
                Console.WriteLine(uplataUcenika.ToString());
            }
        }
    }
}
