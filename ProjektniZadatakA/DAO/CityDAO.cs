using MySql.Data.MySqlClient;
using ProjektniZadatakA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ProjektniZadatakA.DAO
{
    internal class CityDAO
    {
        public static string connectionString = "Server=127.0.0.1; Port=3306; Database=mydb;UserId = root; Password = root; ";
        public static List<City> getCities()
        {
            List<City> list = new List<City>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM mydb.mjesto;";
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new City()
                {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    country = reader.GetString(2)
                });
            }
            reader.Close();
            conn.Close();
            return list;
        }

        public static City getCityByName(String name)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT * FROM mydb.mjesto where naziv=@placeName;";
            cmd.Parameters.AddWithValue("@placeName", name);
            MySqlDataReader reader = cmd.ExecuteReader();
            City city = new City();
            while (reader.Read())
            {
                city.id = reader.GetInt32(0);
                city.name = reader.GetString(1);
                city.country = reader.GetString(2);
            }
            reader.Close();
            conn.Close();
            return city;
        }
    }
}
