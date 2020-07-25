using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;
using SkolaJezika.DAO;

namespace SkolaJezika.UI
{
    class NivoUI
    {
        static List<Nivo> sviNivoi = new List<Nivo>();

        public static void IspisiMeniNivoa()
        {
            Console.WriteLine("Rad sa nivoima opcije");
            Console.WriteLine("1 - Ispis svih nivoa");
            Console.WriteLine("2 - ispis nivoa po ID");
            Console.WriteLine("3 - dodavanje novog nivoa");
            Console.WriteLine("4 - osvezavanje podataka nivoa");
            Console.WriteLine("5 - brisanje nivoa");
        }

        public static void IspisiKompletMeniNivoa()
        {
            bool nastavak = false;

            do
            {
                IspisiMeniNivoa();
                Console.WriteLine("Opcija: ");
                int izbor = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (izbor)
                {
                    case 1:
                        IspisiSveNivoe();
                        break;
                    case 2:
                        IspisiNivoPoId();
                        break;
                    case 3:
                        DodajNivo();
                        break;
                    case 4:
                        UpdatujNivo();
                        break;
                    case 5:
                        ObrisiNivo();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Zelite li da nastavite s radom nad podacima kurseva? y/n");
                string odg = Console.ReadLine();

                if (odg == "y")
                {
                    nastavak = true;
                }
            } while (nastavak);
        }

        public static void IspisiNivoPoId()
        {
            Console.WriteLine("Upisite id nivoa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Nivo nivo = NivoDAO.GetNivoById(Program.conn, id);

            Console.WriteLine(nivo.ToString());
        }

        public static void IspisiSveNivoe()
        {
            sviNivoi = NivoDAO.GetAll(Program.conn);
            foreach (Nivo nivo in sviNivoi)
            {
                Console.WriteLine(nivo.ToString());
            }
        }

        public static void DodajNivo()
        {
            Console.WriteLine("Upisite id novog kursa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Naziv: ");
            string naziv = Console.ReadLine();

            Nivo nivo = new Nivo(id, naziv);

            NivoDAO.Add(Program.conn, nivo);
        }

        public static void UpdatujNivo()
        {
            Console.WriteLine("Upisite id kursa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nov naziv: ");
            string naziv = Console.ReadLine();

            Nivo nivo = new Nivo(id, naziv);

            NivoDAO.Update(Program.conn, nivo);
        }

        public static void ObrisiNivo()
        {
            Console.WriteLine("Upisite id kursa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            NivoDAO.Delete(Program.conn, id);
        }
    }
}
