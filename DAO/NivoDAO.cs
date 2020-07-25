using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;

namespace SkolaJezika.DAO
{
    class NivoDAO
    {
        public static Nivo GetNivoById(SqlConnection conn, int id)
        {
            Nivo nivo = null;

            try
            {
                string query = "SELECT id, naziv " +
                               "FROM nivo " +
                               "WHERE id = " + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    string naziv = (string)r["naziv"];

                    nivo = new Nivo(id, naziv);
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return nivo;
        }

        public static List<Nivo> GetAll(SqlConnection conn) // TODO
        {
            List<Nivo> sviNivoi = new List<Nivo>();

            try
            {
                string query = "SELECT id, naziv " +
                               "FROM nivo";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int id = (int)r["id"];
                    string naziv = (string)r["naziv"];

                    sviNivoi.Add(new Nivo(id, naziv));
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sviNivoi;
        }

        public static bool Add(SqlConnection conn, Nivo nivo)
        {
            bool retVal = false;

            try
            {
                string query = "INSERT INTO nivo (naziv,id) " +
                               "VALUES (@naziv,@id)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@naziv", nivo.Naziv);
                cmd.Parameters.AddWithValue("@id", nivo.Id);

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
        public static bool Update(SqlConnection conn, Nivo nivo)
        {
            bool retVal = false;

            try
            {
                string query = "UPDATE nivo " +
                               "SET naziv=@naziv " +
                               "WHERE id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@naziv", nivo.Naziv);
                cmd.Parameters.AddWithValue("@id", nivo.Id);

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
                string query = "DELETE FROM nivo " +
                               "WHERE id = " + id;
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
