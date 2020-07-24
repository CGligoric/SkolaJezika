using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;


namespace SkolaJezika.DAO
{
    class KursDAO
    {
        public static Kurs GetKursById(SqlConnection conn, int id)
        {
            Kurs kurs = null;

            try
            {
                string query = "SELECT id, jezik, nivo_id, cena " +
                               "FROM kurs " +
                               "WHERE id=" + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    string jezik = (string)r["jezik"];
                    int nivoId = (int)r["nivo_id"];
                    int cena = (int)r["cena"];

                    kurs = new Kurs(id, jezik, cena);
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return kurs;
        }

        public static List<Kurs> GetAll(SqlConnection conn) // TODO
        {
            List<Kurs> sviKursevi = new List<Kurs>();

            try
            {
                string query = "SELECT id, jezik, cena " +
                               "FROM kurs";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int id = (int)r["id"];
                    string jezik = (string)r["jezik"];
                    int cena = (int)r["cena"];

                    sviKursevi.Add(new Kurs(id, jezik, cena));
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sviKursevi;
        }

        public static bool Add(SqlConnection conn, Kurs kurs)
        {
            bool retVal = false;

            try
            {
                string query = "INSERT INTO kurs (jezik, cena, nivo_id,id)" +
                               "VALUES (@jezik,@cena,@nivo_id,@id)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@jezik", kurs.Jezik);
                cmd.Parameters.AddWithValue("@cena", kurs.Cena);
                cmd.Parameters.AddWithValue("@nivo_id", kurs.Nivo.Id);
                cmd.Parameters.AddWithValue("@id", kurs.Id);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    retVal = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return retVal;
        }

        public static bool Update(SqlConnection conn, Kurs kurs)
        {
            bool retVal = false;

            try
            {
                string query = "UPDATE kurs " +
                               "SET jezik=@jezik,cena=@cena,nivo_id=@nivo_id" +
                               "WHERE id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@jezik", kurs.Jezik);
                cmd.Parameters.AddWithValue("@cena", kurs.Cena);
                cmd.Parameters.AddWithValue("@nivo_id", kurs.Nivo.Id);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    retVal = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return retVal;
        }

        public static bool Delete(SqlConnection conn, int id)
        {
            bool retVal = false;

            try
            {
                string query = "DELETE FROM kurs" +
                               "WHERE id=" + id;
                SqlCommand cmd = new SqlCommand(query, conn);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    retVal = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return retVal;
        }
    }
}
