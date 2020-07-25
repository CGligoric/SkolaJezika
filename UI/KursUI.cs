using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;
using SkolaJezika.DAO;

namespace SkolaJezika.UI
{
    class KursUI
    {
        static List<Kurs> sviKursevi = new List<Kurs>();

        public static void IspisiMeniKursa()
        {
            Console.WriteLine("Rad sa kursevima opcije");
            Console.WriteLine("1 - Ispis svih kurseva");
            Console.WriteLine("2 - ispis kursa po ID");
            Console.WriteLine("3 - dodavanje novog kursa");
            Console.WriteLine("4 - osvezavanje podataka kursa");
            Console.WriteLine("5 - brisanje kursa");
        }

        public static void IspisiKompletMeniKursa()
        {
            bool nastavak = false;

            do
            {
                Console.Clear();
                IspisiMeniKursa();
                Console.WriteLine("Opcija: ");

                int izbor = Convert.ToInt32(Console.ReadLine());

                switch (izbor)
                {
                    case 1:
                        IspisiSveKurseve();
                        break;
                    case 2:
                        IspisiKursPoId();
                        break;
                    case 3:
                        DodajKurs();
                        break;
                    case 4:
                        UpdatujKurs();
                        break;
                    case 5:
                        ObrisiKurs();
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

        public static void IspisiSveKurseve()
        {
            sviKursevi = KursDAO.GetAll(Program.conn);
            foreach (Kurs kurs in sviKursevi)
            {
                Console.WriteLine(kurs.ToString());
            }
        }

        public static void IspisiKursPoId()
        {
            Console.WriteLine("Upisite id kursa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Kurs kurs = KursDAO.GetKursById(Program.conn, id);

            Console.WriteLine(kurs.ToString());
        }

        public static void DodajKurs()
        {
            Console.WriteLine("Upisite id novog kursa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Jezik: ");
            string jezik = Console.ReadLine();

            Console.WriteLine("Nivo id: ");
            int nivo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Cena: ");
            int cena = Convert.ToInt32(Console.ReadLine());

            Kurs kurs = new Kurs(id, nivo, jezik, cena);

            KursDAO.Add(Program.conn, kurs);
        }

        public static void UpdatujKurs()
        {
            Console.WriteLine("Upisite id kursa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Upisite nov jezik kursa: ");
            string novJezik = Console.ReadLine();

            Console.WriteLine("Nivo id: ");
            int novNivo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Cena: ");
            int novaCena = Convert.ToInt32(Console.ReadLine());

            Kurs kurs = new Kurs(id, novNivo, novJezik, novaCena);

            KursDAO.Update(Program.conn, kurs);
        }

        public static void ObrisiKurs()
        {
            Console.WriteLine("Upisite id kursa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            KursDAO.Delete(Program.conn, id);
        }
    }
}
