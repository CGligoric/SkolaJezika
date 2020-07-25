using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.DAO;
using SkolaJezika.Moduli;

namespace SkolaJezika.UI
{
    class NastavnikUI
    {
        static List<Nastavnik> sviNastavnici = new List<Nastavnik>();

        public static void IspisiMeniNastavnika()
        {
            Console.WriteLine("Rad sa nastavnicima opcije ");
            Console.WriteLine("1 - ispis svih nastavnika");
            Console.WriteLine("2 - ispis nastavnika sa odredjenim id");
            Console.WriteLine("3 - dodavanje novog nastavnika");
            Console.WriteLine("4 - osvezavanje podataka nastavnika");
            Console.WriteLine("5 - brisanje nastavnika");
            Console.Write("Opcija: ");
        }

        public static void IspisiKompletMeniNastavnika()
        {
            bool nastavak = false;

            do
            {
                IspisiMeniNastavnika();
                int opcija = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (opcija)
                {
                    case 1:
                        IspisiSveNastavnike();
                        break;
                    case 2:
                        IspisiNastavnikaPoId();
                        break;
                    case 3:
                        DodajNastavnika();
                        break;
                    case 4:
                        UpdatujNastavnika();
                        break;
                    case 5:
                        ObrisiNastavnika();
                        break;
                    default:
                        Console.WriteLine("Nevazeca komanda!");
                        break;
                }
                Console.WriteLine("Zelite li da nastavite s radom nad podacima nastavnika? y/n");
                string odg = Console.ReadLine();

                if (odg == "y")
                {
                    nastavak = true;
                }
            } while (nastavak);
        }

        public static void IspisiSveNastavnike()
        {
            sviNastavnici = NastavnikDAO.GetAll(Program.conn);
            foreach (Nastavnik n in sviNastavnici)
            {
                Console.WriteLine(n.ToString());
            }
        }

        public static void IspisiNastavnikaPoId()
        {
            Console.WriteLine("Upisite ID nastavnika: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Nastavnik nastavnik = NastavnikDAO.GetNastavnikById(Program.conn, id);

            Console.WriteLine(nastavnik.ToString());
        }

        public static void DodajNastavnika()
        {
            Console.WriteLine("Upisite id novog nastavnika: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Upisite ime nastavnika: ");
            string ime = Console.ReadLine();

            Console.WriteLine("Upisite prezime: ");
            string prezime = Console.ReadLine();

            Console.WriteLine("Broj telefona: ");
            int brTel = Convert.ToInt32(Console.ReadLine());

            Nastavnik nastavnik = new Nastavnik(id, ime, prezime, brTel);

            NastavnikDAO.Add(Program.conn, nastavnik);
        }

        public static void UpdatujNastavnika()
        {
            Console.WriteLine("Upisite id nastavnika cije podatke zelite da izmenite: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Upisite novo ime nastavnika: ");
            string novoIme = Console.ReadLine();

            Console.WriteLine("Upisite novo prezime nastavnika: ");
            string novoPrezime = Console.ReadLine();

            Console.WriteLine("Dajte nastavniku nov broj telefona: ");
            int brTel = Convert.ToInt32(Console.ReadLine());

            Nastavnik nastavnik = new Nastavnik(id, novoIme, novoPrezime, brTel);

            NastavnikDAO.Update(Program.conn, nastavnik);

        }

        public static void ObrisiNastavnika()
        {
            Console.WriteLine("Upisite id nastavnika cije podatke zelite da obrisete:");
            int id = Convert.ToInt32(Console.ReadLine());

            NastavnikDAO.Delete(Program.conn, id);
        }
    }
}
