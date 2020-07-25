using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;
using SkolaJezika.DAO;
namespace SkolaJezika.UI
{
    class UplataUI
    {
        static List<Uplata> sveUplate = new List<Uplata>();

        public static void IspisiOpcijaUplata()
        {
            Console.WriteLine("Rad sa uplatama opcije");
            Console.WriteLine("1 - ispis svih uplata");
            Console.WriteLine("2 - ispis uplate po ID");
            Console.WriteLine("3 - dodavanje nove uplate");
            Console.WriteLine("4 - menjanje podataka postojece uplate");
            Console.WriteLine("5 - brisanje uplate");
        }

        public static void IspisiKompletMeniUplate()
        {
            bool nastavak = false;

            do
            {
                IspisiOpcijaUplata();
                Console.WriteLine("Opcija: ");
                Console.Clear();


                int izbor = Convert.ToInt32(Console.ReadLine());

                switch (izbor)
                {
                    case 1:
                        IspisiSveUplate();
                        break;
                    case 2:
                        IspisiUplatuPoId();
                        break;
                    case 3:
                        DodajUplatu();
                        break;
                    case 4:
                        UpdatujUplatu();
                        break;
                    case 5:
                        ObrisiUplatu();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Zelite li da nastavite s radom nad podacima uplata? y/n");
                string odg = Console.ReadLine();

                if (odg == "y")
                {
                    nastavak = true;
                }
            } while (nastavak);
        }

        public static void IspisiSveUplate()
        {
            sveUplate = UplataDAO.GetAll(Program.conn);
            foreach (Uplata uplata in sveUplate)
            {
                Console.WriteLine(uplata.ToString());
            }
        }

        public static void IspisiUplatuPoId()
        {
            Console.WriteLine("Upisite ID uplate: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Uplata uplata = UplataDAO.GetUplataById(Program.conn, id);

            Console.WriteLine(uplata.ToString());

        }

        public static void DodajUplatu()
        {
            Console.WriteLine("Upisite id nove uplate: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Upisite datum uplate: ");
            string datum = Console.ReadLine();

            Console.WriteLine("Upisite iznos: ");
            int iznos = Convert.ToInt32(Console.ReadLine());

            Uplata uplata = new Uplata(id, datum, iznos);

            UplataDAO.Add(Program.conn, uplata);
        }

        public static void UpdatujUplatu()
        {
            Console.WriteLine("Upisite id uplate koju zelite da izmenite: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Upisite nov datum uplate: ");
            string datum = Console.ReadLine();

            Console.WriteLine("Upisite nov iznos: ");
            int iznos = Convert.ToInt32(Console.ReadLine());

            Uplata uplata = new Uplata(id, datum, iznos);

            UplataDAO.Update(Program.conn, uplata);
        }

        public static void ObrisiUplatu()
        {
            Console.WriteLine("Upisite id uplate koju zelite da izmenite: ");
            int id = Convert.ToInt32(Console.ReadLine());

            UplataDAO.Delete(Program.conn, id);
        }
    }
}
