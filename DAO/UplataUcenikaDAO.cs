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
        public static List<Uplata> GetUplataByUcenikId(SqlConnection conn, int id)
        {
            List < Uplata > sveUplate = null;

            try
            {
                string query = "SELECT uplata_id,ucenik_id" +
                               "FROM uplata_ucenika" +
                               "WHERE ucenik_id=" + id;
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int uplata_id = (int)
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sveUplate;
        }
    }
}
