using MySql.Data.MySqlClient;
using ProjektniZadatakA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektniZadatakA.DAO
{
    internal class TeamDAO
    {
        public static string connectionString = "Server=127.0.0.1; Port=3306; Database=mydb;UserId = root; Password = root; ";
        public static List<Team> getTeams()
        {
            List<Team> list = new List<Team>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM mydb.ekipa e inner join liga l on e.liga_idliga=l.idliga;";
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Team()
                {
                   id= reader.GetInt32(0),
                   name= reader.GetString(1),
                   jerseyColor= reader.GetString(2),
                   yearFounded= reader.GetInt32(3),
                   league= new League()
                   {
                       id=reader.GetInt32(4),
                       name= reader.GetString(6),
                       level=reader.GetInt32(7),
                       country=reader.GetString(8)
                   }
                });
            }
            reader.Close();
            conn.Close();
            return list;
        }

        public static Team getTeamByName(String name)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT * FROM mydb.ekipa e inner join liga l on e.liga_idliga=l.idliga where e.naziv=@teamName";
            cmd.Parameters.AddWithValue("@teamName", name);
            MySqlDataReader reader = cmd.ExecuteReader();
            Team team = new Team();
            while (reader.Read())
            {
                team.id = reader.GetInt32(0);
                team.name = reader.GetString(1);
                team.jerseyColor = reader.GetString(2);
                team.yearFounded = reader.GetInt32(3);
                   team.league = new League()
                   {
                       id = reader.GetInt32(4),
                       name = reader.GetString(6),
                       level = reader.GetInt32(7),
                       country = reader.GetString(8)
                   };
            }
            reader.Close();
            conn.Close();
            return team;
        }
    }
}
