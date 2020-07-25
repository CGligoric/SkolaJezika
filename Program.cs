using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.UI;

namespace SkolaJezika
{
    class Program
    {
        public static SqlConnection conn;

        static void LoadConnection()
        {
            try
            {
                // Ostvarivanje konekcije
                string connectionStringZaPoKuci = "Data Source=.\\SQLEXPRESS;Initial Catalog=SkolaJezika;Integrated Security=True;MultipleActiveResultSets=True";

                // Parametar "MultipleActiveResultSets=True" je neophodan kada zelimo da imamo istovremeno
                // otvorena dva data readera ka bazi podataka. Zasto je u ovom programu to neophodno?
                conn = new SqlConnection(connectionStringZaPoKuci);
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void OsnovniMeni()
        {
            Console.WriteLine("Baza podataka skole jezika \"Aktuel\"");
            Console.WriteLine("1 - ucenici");
            Console.WriteLine("2 - nastavnici");
            Console.WriteLine("3 - uplate");
            Console.WriteLine("4 - kursevi");
            Console.WriteLine("5 - nivoi kurseva");
            Console.WriteLine("6 - uplate ucenika");
            Console.WriteLine("7 - podaci skole");
            Console.WriteLine("8 - pohadjanja i predavanja");
        }

        static void Main(string[] args)
        {
            LoadConnection();

            OsnovniMeni();

            int izbor = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (izbor)
            {
                case 1:
                    UcenikUI.IspisiKompletMeniUcenik();
                    break;
                case 2:
                    NastavnikUI.IspisiKompletMeniNastavnika();
                    break;
                case 3:
                    UplataUI.IspisiKompletMeniUplate();
                    break;
                case 4:
                    KursUI.IspisiKompletMeniKursa();
                    break;
                case 5:
                    NivoUI.IspisiKompletMeniNivoa();
                    break;
                case 6:
                    UplataUcenikaUI.IspisiKompletMeniUU();
                    break;
                case 7:
                    SkolaUI.IspisiKompletMeniSkole();
                    break;
                case 8:
                    PohadjaPredajeUI.IspisiKompletMeniPP();
                    break;
                default:
                    break;
            }
        }
    }
}
