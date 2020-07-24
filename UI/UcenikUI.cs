using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;
using SkolaJezika.DAO;
using System.Data.SqlClient;

namespace SkolaJezika.UI
{
    class UcenikUI
    {
        static List<Ucenik> sviUcenici = null;

        public static void IspisiSveUcenike()
        {
            sviUcenici = UcenikDAO.GetAll(Program.conn);
            foreach (Ucenik ucenik in sviUcenici)
            {
                Console.WriteLine(ucenik.ToString());
            }
        }
        
        public static void IspisiUcenikaPoId()
        {
            Console.WriteLine("Upisite id ucenika: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Ucenik uc = UcenikDAO.GetUcenikById(Program.conn, id);
            Console.WriteLine(uc.ToString());
        }

        public static void DodajUcenika()
        {
            Console.WriteLine("Upisite id novog ucenika: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Dajte mu ime: ");
            string ime = Console.ReadLine();

            Console.WriteLine("I prezime: ");
            string prezime = Console.ReadLine();

            Console.WriteLine("I broj telefona: ");
            int bTel = Convert.ToInt32(Console.ReadLine());

            Ucenik novUc = new Ucenik(id, ime, prezime, bTel);

            bool uspeh = UcenikDAO.Add(Program.conn, novUc);

            if (uspeh)
            {
                Console.WriteLine("Ucenik uspesno obrisan!");
            }
            else
            {
                Console.WriteLine("Nije pronadjen nijedan ucenik sa unetim id-jem");
            }
            Console.WriteLine("Nov ucenik je pridodat bazi podataka skole!");
        }

        public static void ObrisiUcenikaPoId()
        {
            Console.WriteLine("Upisite id ucenika: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool uspeh = UcenikDAO.Delete(Program.conn, id);
            if (uspeh)
            {
                Console.WriteLine("Ucenik uspesno obrisan!");
            }
            else
            {
                Console.WriteLine("Nije pronadjen nijedan ucenik sa unetim id-jem");
            }
        }

        public static void UpdatujUcenika()
        {
            Console.WriteLine("Upisite id ucenika: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Upisite novo ime ucenika: ");
            string novoIme = Console.ReadLine();

            Console.WriteLine("Upisite novo prezime ucenika: ");
            string novoPrezime = Console.ReadLine();

            Console.WriteLine("Dajte uceniku nov broj telefona: ");
            int brTel = Convert.ToInt32(Console.ReadLine());

            Ucenik uc = new Ucenik(id, novoIme, novoPrezime, brTel);

            bool uspeh = UcenikDAO.Update(Program.conn, uc);
            if (uspeh)
            {
                Console.WriteLine("Ucenik uspesno updatovan!");
            }
            else
            {
                Console.WriteLine("Nije pronadjen nijedan ucenik sa unetim id-jem");
            }
        }
    }
}
