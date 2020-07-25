using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;

namespace SkolaJezika.DAO
{
    class UplataUcenikaDAO
    {
        public static UplataUcenika GetUplataByUcenikId(SqlConnection conn, int id)
        {
            UplataUcenika uplUc = null;

            try
            {
                string query = "SELECT uplata_id, ucenik_id " +
                               "FROM uplata_ucenika " +
                               "WHERE id=" + id;
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    int uplataId = (int)r["uplata_id"];
                    int ucenikId = (int)r["ucenik_id"];

                    Uplata uplata = UplataDAO.GetUplataById(Program.conn, uplataId);
                    Ucenik ucenik = UcenikDAO.GetUcenikById(Program.conn, ucenikId);

                    uplUc = new UplataUcenika(id, uplata, ucenik);
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return uplUc;
        }

        public static List<UplataUcenika> GetAll(SqlConnection conn)
        {
            List<UplataUcenika> sveUplateIUcenici = new List<UplataUcenika>();

            try
            {
                string query = "SELECT id, ucenik_id, uplata_id " +
                               "FROM uplata_ucenika";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int id = (int)r["id"];
                    int uplataId = (int)r["uplata_id"];
                    int ucenikId = (int)r["ucenik_id"];

                    Uplata uplata = UplataDAO.GetUplataById(Program.conn, uplataId);
                    Ucenik ucenik = UcenikDAO.GetUcenikById(Program.conn, ucenikId);

                    sveUplateIUcenici.Add(new UplataUcenika(id, uplata, ucenik));
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sveUplateIUcenici;
        }
    }
}
