using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;

namespace SkolaJezika.DAO
{
    class UplataDAO
    {
        public static Uplata GetUplataById(SqlConnection conn, int id)
        {
            Uplata uplata = null;

            try
            {
                string query = "SELECT id, datum, iznos " +
                               "FROM uplata " +
                               "WHERE id=" + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    string datum = (string)r["datum"];
                    int iznos = (int)r["iznos"];

                    uplata = new Uplata(id, datum, iznos);
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return uplata;
        }

        public static List<Uplata> GetAll(SqlConnection conn)
        {
            List<Uplata> sveUplate = new List<Uplata>();

            try
            {
                string query = "SELECT id, datum, iznos " +
                               "FROM uplata ";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int id = (int)r["id"];
                    string datum = (string)r["datum"];
                    int iznos = (int)r["iznos"];

                    sveUplate.Add(new Uplata(id, datum, iznos));
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sveUplate;
        }

        public static bool Add(SqlConnection conn, Uplata uplata)
        {
            bool retVal = false;

            try
            {
                string query = "INSERT INTO uplata (id,datum,iznos)" +
                               "VALUES (@id,@datum,@iznos)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", uplata.Id);
                cmd.Parameters.AddWithValue("@datum", uplata.Datum);
                cmd.Parameters.AddWithValue("@iznos", uplata.Iznos);

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

        public static bool Update(SqlConnection conn, Uplata uplata)
        {
            bool retVal = false;

            try
            {
                string query = "UPDATE uplata " +
                               "SET datum=@datum,iznos=@iznos " +
                               "WHERE id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@datum", uplata.Datum);
                cmd.Parameters.AddWithValue("@iznos", uplata.Iznos);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    retVal = true;
                }
            }
            catch(Exception e)
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
                string query = "DELETE FROM uplata WHERE id=" + id;

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
