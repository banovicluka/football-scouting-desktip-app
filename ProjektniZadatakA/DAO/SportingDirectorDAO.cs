using MySql.Data.MySqlClient;
using Mysqlx.Sql;
using ProjektniZadatakA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektniZadatakA.DAO
{
    internal static class SportingDirectorDAO
    {
    
        public static string connectionString = "Server=127.0.0.1; Port=3306; Database=mydb;UserId = root; Password = root; ";
        public static List<SportingDirector> getDirectors()
        {
            List<SportingDirector> list = new List<SportingDirector>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from mydb.sportski_direktor sd inner join mjesto m on sd.mjesto_idmjesto = m.idmjesto";
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new SportingDirector()
                {
                    id = reader.GetInt32(0),
                    name = reader.GetString(1),
                    surname = reader.GetString(2),
                    username = reader.GetString(3),
                    password = reader.GetString(4),
                    city = new City()
                    {
                        id = reader.GetInt32(6),
                        name = reader.GetString(7),
                        country = reader.GetString(8)
                    }
                }) ;
            }
            reader.Close();
            conn.Close();
            return list;
        }
    }
}
