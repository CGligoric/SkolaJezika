using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;

namespace SkolaJezika.DAO
{
    class NastavnikDAO
    {
        public static Nastavnik GetNastavnikById(SqlConnection conn, int id)
        {
            Nastavnik nastavnik = null;

            try
            {
                string query = "SELECT ime, prezime, telefon " +
                               "FROM nastavnik " +
                               "WHERE id=" + id;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    string ime = (string)r["ime"];
                    string prezime = (string)r["prezime"];
                    int telefon = (int)r["telefon"];

                    nastavnik = new Nastavnik(id, ime, prezime, telefon);
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return nastavnik;
        }

        public static List<Nastavnik> GetAll(SqlConnection conn)
        {
            List<Nastavnik> sviNastavnici = new List<Nastavnik>();

            try
            {
                string query = "SELECT id, ime, prezime, telefon " +
                               "FROM nastavnik";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int id = (int)r["id"];
                    string ime = (string)r["ime"];
                    string prezime = (string)r["prezime"];
                    int telefon = (int)r["telefon"];

                    sviNastavnici.Add(new Nastavnik(id, ime, prezime, telefon));
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return sviNastavnici;
        }

        public static bool Add(SqlConnection conn, Nastavnik nastavnik)
        {
            bool retVal = false;

            try
            {
                string query = "INSERT INTO nastavnik (id, ime, prezime, telefon) VALUES" +
                               "(@id,@ime,@prezime,@telefon)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", nastavnik.Id);
                cmd.Parameters.AddWithValue("@ime", nastavnik.Ime);
                cmd.Parameters.AddWithValue("@prezime", nastavnik.Prezime);
                cmd.Parameters.AddWithValue("@telefon", nastavnik.BrojTel);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    retVal = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return retVal;
        }

        public static bool Update(SqlConnection conn, Nastavnik nastavnik)
        {
            bool retVal = false;
            try
            {
                string query = "UPDATE nastavnik " +
                               "SET ime=@ime, prezime=@prezime, telefon=@telefon" +
                               "WHERE id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ime", nastavnik.Ime);
                cmd.Parameters.AddWithValue("@prezime", nastavnik.Prezime);
                cmd.Parameters.AddWithValue("@telefon", nastavnik.BrojTel);

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
                string query = "DELETE FROM nastavnik WHERE id=" + id;

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
