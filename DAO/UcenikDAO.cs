using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;

namespace SkolaJezika.DAO
{
    class UcenikDAO
    {
        public static Ucenik GetUcenikById(SqlConnection conn, int id)
        {
            Ucenik uc = null;

            try
            {
                string query = "SELECT ime, prezime, telefon " +
                               "FROM Ucenik WHERE id = " + id;
                
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader r = cmd.ExecuteReader();

                if (r.Read())
                {
                    string ime = (string)r["ime"];
                    string prezime = (string)r["prezime"];
                    int brojTel = (int)r["telefon"];

                    uc = new Ucenik(id, ime, prezime, brojTel);
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return uc;
        }

        public static List<Ucenik> GetAll(SqlConnection conn)
        {
            List<Ucenik> sviUcenici = new List<Ucenik>();
            try
            {
                string query = "SELECT id, ime, prezime, telefon FROM ucenici ";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())    // Doklegod reader moze da iscitava redove tabele, tj. dok reader ne stigne do dna tabele
                {
                    int id = (int)r["id"];
                    string ime = (string)r["ime"];
                    string prezime = (string)r["prezime"];
                    int brojTel = (int)r["telefon"];

                    sviUcenici.Add(new Ucenik(id, ime, prezime, brojTel));
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return sviUcenici;
        }

        public static bool Add(SqlConnection conn, Ucenik uc)
        {
            bool retVal = false;

            try
            {
                string query = "INSERT INTO ucenik (ime, prezime, telefon) " +
                               "VALUES (@ime, @prezime, @telefon)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ime", uc.Ime);
                cmd.Parameters.AddWithValue("@prezime", uc.Prezime);
                cmd.Parameters.AddWithValue("@telefon", uc.BrojTel);

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

        public static bool Update(SqlConnection conn, Ucenik uc)
        {
            bool retVal = false;

            try
            {
                string query = "UPDATE ucenik " +
                               "SET ime=@ime, prezime=@prezime, telefon=@telefon" +
                               "WHERE id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ime", uc.Ime);
                cmd.Parameters.AddWithValue("@prezime", uc.Prezime);
                cmd.Parameters.AddWithValue("@telefon", uc.BrojTel);

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

        public static bool Delete(SqlConnection conn, int id)
        {
            bool retVal = false;
            try
            {
                string query = "DELETE FROM ucenik" +
                               "WHERE id=" + id;
                SqlCommand cmd = new SqlCommand(query, conn);

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
    }
}
