using MySql.Data.MySqlClient;
using ProjektniZadatakA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektniZadatakA.DAO
{
    internal class StadiumDAO
    {
        public static string connectionString = "Server=127.0.0.1; Port=3306; Database=mydb;UserId = root; Password = root; ";
        public static List<Stadium> getStadiums()
        {
            List<Stadium> list = new List<Stadium>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM mydb.stadion s inner join mjesto m on s.mjesto_idmjesto=m.idmjesto ;";
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Stadium()
                {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    yearContruction = reader.GetInt32(2),
                    capacity = reader.GetInt32(3),
                    city = new City()
                    {
                        id = reader.GetInt32(5),
                        name = reader.GetString(6),
                        country = reader.GetString(7)
                    }
                }) ; ;
            }
            reader.Close();
            conn.Close();
            return list;
        }

        public static Stadium getStadiumByName(String name)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT * FROM mydb.stadion s inner join mjesto m on s.mjesto_idmjesto=m.idmjesto where s.naziv=@stadiumName;";
            cmd.Parameters.AddWithValue("@stadiumName", name);
            MySqlDataReader reader = cmd.ExecuteReader();
            Stadium stadium = new Stadium();
            while (reader.Read())
            {
                    stadium.id = reader.GetInt32(0);
                    stadium.name = reader.GetString(1);
                    stadium.yearContruction = reader.GetInt32(2);
                    stadium.capacity = reader.GetInt32(3);
                    stadium.city = new City()
                    {
                        id = reader.GetInt32(5),
                        name = reader.GetString(6),
                        country = reader.GetString(7)
                    };
            }
            reader.Close();
            conn.Close();
            return stadium;
        }
    }
}
