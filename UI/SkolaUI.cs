using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;
using SkolaJezika.DAO;

namespace SkolaJezika.UI
{
    class SkolaUI
    {
        public static void IspisiMeniSkole()
        {
            Console.WriteLine("Rad sa podacima skole opcije");
            Console.WriteLine("1 - pregled podataka");
            Console.WriteLine("2 - izmena podataka");
            Console.WriteLine("Opcija: ");
        }

        public static void IspisiKompletMeniSkole()
        {
            bool nastavak = false;

            do
            {
                IspisiMeniSkole();
                int izbor = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (izbor)
                {
                    case 1:
                        IspisiPodatkeSkole();
                        break;
                    case 2:
                        OsveziPodatke();
                        break;
                }
                Console.WriteLine("Zelite li da nastavite s radom nad podacima skole? y/n");
                string odg = Console.ReadLine();

                if (odg == "y")
                {
                    nastavak = true;
                }
            } while (nastavak);
        }

        public static void IspisiPodatkeSkole()
        {
            Skola skola = SkolaDAO.GetData(Program.conn);

            Console.WriteLine(skola.ToString());
        }

        public static void OsveziPodatke()
        {
            Console.WriteLine("Upisite nov naziv skole: ");
            string naziv = Console.ReadLine();

            Console.WriteLine("Upisite novu adresu skole: ");
            string adresa = Console.ReadLine();

            Console.WriteLine("Upisite nov telefon skole: ");
            int broj = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Upisite novu adresu veb-sajta skole: ");
            string sajt = Console.ReadLine();

            Console.WriteLine("Upisite novu adresu e-poste skole: ");
            string email = Console.ReadLine();

            Console.WriteLine("Upisite nov PIB skole: ");
            int pib = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Upisite nov maticni broj skole: ");
            int mb = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Upisite nov ziro racun skole: ");
            int zr = Convert.ToInt32(Console.ReadLine());

            Skola skola = new Skola(1, naziv, adresa, broj, email, sajt, pib, mb, zr);
            SkolaDAO.Update(Program.conn, skola);
        }
    }
}
