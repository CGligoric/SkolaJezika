using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkolaJezika.Moduli;

namespace SkolaJezika.DAO
{
    class SkolaDAO
    {
        public static Skola GetData(SqlConnection conn)
        {
            Skola skola = null;

            try
            {
                string query = "SELECT *" +
                               "FROM skola";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    int id = (int)r["id"];
                    string naziv = (string)r["naziv"];
                    string adresa = (string)r["adresa"];
                    int telefon = (int)r["telefon"];
                    string email = (string)r["email"];
                    string adresaSajta = (string)r["sajt"];
                    int pib = (int)r["pib"];
                    int mb = (int)r["maticni_broj"];
                    int ziroRacun = (int)r["ziro_racun"];

                    skola = new Skola(id, naziv, adresa, telefon, email, adresaSajta, pib, mb, ziroRacun);
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return skola;

        }
        public static bool Update(SqlConnection conn, Skola skola)
        {
            bool retVal = false;

            try
            {
                string query = "UPDATE skola " +
                               "SET naziv=@naziv,adresa=@adresa,email=@email,telefon=@telefon,sajt=@sajt,pib=@pib,maticni_broj=@maticni+broj,ziro_racun=@ziro_racun " +
                               "WHERE id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@naziv", skola.Naziv);
                cmd.Parameters.AddWithValue("@adresa", skola.Adresa);
                cmd.Parameters.AddWithValue("@email", skola.Email);
                cmd.Parameters.AddWithValue("@telefon", skola.Telefon);
                cmd.Parameters.AddWithValue("@sajt", skola.AdresaSajta);
                cmd.Parameters.AddWithValue("@pib", skola.PIB);
                cmd.Parameters.AddWithValue("@maticni_broj", skola.MatBroj);
                cmd.Parameters.AddWithValue("@ziro_racun", skola.BrZiroRac);

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
