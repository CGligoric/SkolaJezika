using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;

namespace SkolaJezika.DAO
{
    class PohadjaPredajeDAO
    {
        public static PohadjaPredaje GetPPByID(SqlConnection conn, int id)
        {
            PohadjaPredaje pp = null;

            try
            {
                string query = "SELECT kurs_id, nastavnik_id, ucenik_id " +
                               "FROM pohadja_predaje " +
                               "WHERE id = " + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    int kursId = (int)r["kurs_id"];
                    int nastId = (int)r["nastavnik_id"];
                    int ucId = (int)r["ucenik_id"];

                    Kurs kurs = KursDAO.GetKursById(Program.conn, kursId);
                    Nastavnik nast = NastavnikDAO.GetNastavnikById(Program.conn, nastId);
                    Ucenik uc = UcenikDAO.GetUcenikById(Program.conn, ucId);

                    pp = new PohadjaPredaje(id, nast, uc, kurs);
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return pp;
        }

        public static List<PohadjaPredaje> GetAll(SqlConnection conn)
        {
            List<PohadjaPredaje> sviPp = new List<PohadjaPredaje>();

            try
            {
                string query = "SELECT id, kurs_id, ucenik_id, nastavnik_id " +
                               "FROM pohadja_predaje";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int id = (int)r["id"];
                    int kursId = (int)r["kurs_id"];
                    int nastId = (int)r["nastavnik_id"];
                    int ucId = (int)r["ucenik_id"];

                    Kurs kurs = KursDAO.GetKursById(Program.conn, kursId);
                    Nastavnik nast = NastavnikDAO.GetNastavnikById(Program.conn, nastId);
                    Ucenik uc = UcenikDAO.GetUcenikById(Program.conn, ucId);

                    sviPp.Add(new PohadjaPredaje(id, nast, uc, kurs));
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sviPp;
        }
    }
}
