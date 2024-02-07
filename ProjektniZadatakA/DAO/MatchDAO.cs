using MySql.Data.MySqlClient;
using ProjektniZadatakA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace ProjektniZadatakA.DAO
{
    internal class MatchDAO
    {
        public static string connectionString = "Server=127.0.0.1; Port=3306; Database=mydb;UserId = root; Password = root; ";
        public static List<Match> getMatches()
        {
            List<Match> list = new List<Match>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM mydb.utakmica u inner join ekipa d on u.domacin_idekipa = d.idekipa inner join liga l on d.liga_idliga = l.idliga inner join ekipa g on u.gost_idekipa = g.idekipa inner join liga lg on g.liga_idliga = lg.idliga inner join stadion s on u.stadion_idstadion = s.idstadion inner join mjesto m on s.mjesto_idmjesto=m.idmjesto;";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Match()
                {
                    id = reader.GetInt32(0),
                    date = reader.GetDateTime(1),
                    ticketPrice = reader.GetInt32(2),
                    host = new Team
                    {
                        id = reader.GetInt32(6),
                        name = reader.GetString(7),
                        jerseyColor = reader.GetString(8),
                        yearFounded = reader.GetInt32(9),
                        league = new League()
                        {
                            id = reader.GetInt32(11),
                            name = reader.GetString(12),
                            level = reader.GetInt32(13),
                            country = reader.GetString(14)
                        }

                    },
                    guest = new Team
                    {
                        id = reader.GetInt32(15),
                        name = reader.GetString(16),
                        jerseyColor = reader.GetString(17),
                        yearFounded = reader.GetInt32(18),
                        league = new League()
                        {
                            id = reader.GetInt32(20),
                            name = reader.GetString(21),
                            level = reader.GetInt32(22),
                            country = reader.GetString(23)
                        }
                    },
                    stadium = new Stadium()
                    {
                        id = reader.GetInt32(24),
                        name = reader.GetString(25),
                        yearContruction = reader.GetInt32(26),
                        capacity = reader.GetInt32(27),
                        city = new City()
                        {
                            id = reader.GetInt32(29),
                            name = reader.GetString(30),
                            country = reader.GetString(31)
                        }
                    }
                }) ;
            };
            reader.Close();
            cmd.CommandText = @"SELECT * FROM mydb.skaut_has_utakmica x inner join skaut s on x.skaut_idskaut=s.idskaut where utakmica_idutakmica=@matchID ";
            foreach (Match m in list)
            {
                m.scouts = new List<Scout>();
                cmd.Parameters.AddWithValue("@matchID", m.id);
                MySqlDataReader reader2 = cmd.ExecuteReader();
                while (reader2.Read())
                {
                    m.scouts.Add(new Scout()
                    {
                        name = reader2.GetString(3),
                        surname = reader2.GetString(4)
                    });
                }
                reader2.Close();
                cmd.Parameters.Clear();
            }
            
            
            //// DOHVATI I SKAUTE KOJI POSMATRAJU DATI MEC
            conn.Close();
            return list;
        }

        public static void insertMatch(Match match)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO `mydb`.`utakmica` (`datum`, `cijena_karte`, `domacin_idekipa`, `gost_idekipa`, `stadion_idstadion`) 
                                    VALUES (@date, @ticketPrice, @hostID , @guestID, @stadiumID);";
            cmd.Parameters.AddWithValue("@date",match.date);
            cmd.Parameters.AddWithValue("@ticketPrice", match.ticketPrice);
            cmd.Parameters.AddWithValue("@hostID", match.host.id);
            cmd.Parameters.AddWithValue("@guestID", match.guest.id);
            cmd.Parameters.AddWithValue("@stadiumID", match.stadium.id);
            cmd.ExecuteNonQuery();
            match.id = (int)cmd.LastInsertedId;
            conn.Close();
        }

       public static void deleteMatchById(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"DELETE FROM `mydb`.`skaut_has_utakmica` WHERE  (`utakmica_idutakmica` = @idMatch2);";
            cmd.Parameters.AddWithValue("idMatch2", id);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                
            }
            cmd.Parameters.Clear();
            cmd.CommandText = @"DELETE FROM `mydb`.`utakmica` WHERE (`idutakmica` = @idMatch);";
            cmd.Parameters.AddWithValue("@idMatch", id);
            try
            {
                cmd.ExecuteNonQuery();
            }catch(Exception e)
            {
                //
            }
            
            conn.Close();
        }

      

        public static void addScoutOnMatch(Scout scout,Match match)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO `mydb`.`skaut_has_utakmica` (`skaut_idskaut`, `utakmica_idutakmica`) VALUES (@idSkaut, @idUtakmica);";
            cmd.Parameters.AddWithValue("idSkaut", scout.id);
            cmd.Parameters.AddWithValue("idUtakmica", match.id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
