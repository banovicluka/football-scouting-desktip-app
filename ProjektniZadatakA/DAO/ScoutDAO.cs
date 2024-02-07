using MySql.Data.MySqlClient;
using ProjektniZadatakA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektniZadatakA.DAO
{
    internal class ScoutDAO
    {
        public static string connectionString = "Server=127.0.0.1; Port=3306; Database=mydb;UserId = root; Password = root; ";
        public static List<Scout> getScouts()
        {
            List<Scout> list = new List<Scout>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM mydb.skaut s inner join mjesto m on s.mjesto_idmjesto=m.idmjesto";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Scout()
                {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    surname = reader.GetString(2),
                    licence = reader.GetString(3),
                    username = reader.GetString(4),
                    password = reader.GetString(5),
                    registered = reader.GetBoolean(6),

                    city = new City()
                    {
                        id = reader.GetInt32(9),
                        name = reader.GetString(10),
                        country = reader.GetString(11)
                    }
                });
            };
            reader.Close();
            conn.Close();
            return list;
        }

        public static void insertScout(Scout scout)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO mydb.skaut
                                (`ime`, `prezime`, `licenca`, `korisnicko_ime`, `sifra`, `registrovan`, `mjesto_idmjesto`, `sportskiDirektor_idsportski direktor`)
                                VALUES (@name,@surname,@licence,@username,@password,'1',@idPlace,'1')";
            cmd.Parameters.AddWithValue("@name", scout.name);
            cmd.Parameters.AddWithValue("@surname", scout.surname);
            cmd.Parameters.AddWithValue("@licence", scout.licence);
            cmd.Parameters.AddWithValue("@username", scout.username);
            cmd.Parameters.AddWithValue("@password", scout.password);
            cmd.Parameters.AddWithValue("@idPlace", scout.city.id);
            cmd.ExecuteNonQuery();
            scout.id = (int)cmd.LastInsertedId;
            conn.Close();
        }

        public static void deleteScoutById(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"DELETE FROM `mydb`.`skaut` WHERE (`idskaut` = @idMatch);";
            cmd.Parameters.AddWithValue("@idMatch", id);
            try
            {
                cmd.ExecuteNonQuery();
            }catch(Exception e){
                // ako skaut ima zaduzenja
            };
            conn.Close();
        }
    }
}

