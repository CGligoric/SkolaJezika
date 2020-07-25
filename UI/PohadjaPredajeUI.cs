using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;
using SkolaJezika.DAO;

namespace SkolaJezika.UI
{
    class PohadjaPredajeUI
    {
        static List<PohadjaPredaje> sviPp = new List<PohadjaPredaje>();

        public static void IspisiMeni()
        {
            // Nisam znao kako pametnije da nazovem ove opcije.. :D

            Console.WriteLine("Rad sa pohadjanjima/predavanjima opcije: ");
            Console.WriteLine("1 - ispis svih podataka");
            Console.WriteLine("2 - ispis pohadjanja/predavanja po ID");
            Console.WriteLine("Opcija: ");
        }

        public static void IspisiKompletMeniPP()
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
                        IspisiPpPoId();
                        break;
                }
                Console.WriteLine("Zelite li da nastavite s radom nad podacima o predavanjem nastavnika i pohadjanem ucenika? y/n");
                string odg = Console.ReadLine();

                if (odg == "y")
                {
                    nastavak = true;
                }
            } while (nastavak);
        }

        public static void IspisiPpPoId()
        {
            Console.WriteLine("Upisite id pohadjanja-predavanja:");
            int id = Convert.ToInt32(Console.ReadLine());

            PohadjaPredaje pp = PohadjaPredajeDAO.GetPPByID(Program.conn, id);

            Console.WriteLine(pp.ToString());
        }

        public static void IspisiSve()
        {
            sviPp = PohadjaPredajeDAO.GetAll(Program.conn);

            foreach (PohadjaPredaje pp in sviPp)
            {
                Console.WriteLine(pp.ToString());
            }
        }
    }
}
