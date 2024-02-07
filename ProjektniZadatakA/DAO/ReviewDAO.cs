using MySql.Data.MySqlClient;
using ProjektniZadatakA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektniZadatakA.DAO
{
    internal class ReviewDAO
    {
        public static string connectionString = "Server=127.0.0.1; Port=3306; Database=mydb;UserId = root; Password = root; ";
        public static List<Review> getReviews()
        {
            List<Review> list = new List<Review>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM mydb.recenzija r inner join skaut s on r.skaut_idskaut=s.idskaut inner join igrac i on r.igrac_idigrac=i.idigrac inner join ekipa e on i.ekipa_idekipa=e.idekipa;";
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Review()
                {
                    id = reader.GetInt32(0),
                    finalGrade = reader.GetInt32(1),
                    techniqueGrade= reader.GetInt32(2),
                    physicsGrade = reader.GetInt32(3),
                    tacticsGrade = reader.GetInt32(4),
                    mentalityGrade = reader.GetInt32(5),
                    physicsDescription = reader.GetString(6),
                    techniqueDescription = reader.GetString(7),
                    tacticsDescription = reader.GetString(8),
                    mentalityDescription = reader.GetString(9),
                    conclusion = reader.GetString(10),
                    scout = new Scout
                    {
                        id = reader.GetInt32(13),
                        name = reader.GetString(14),
                        surname = reader.GetString(15),
                        licence = reader.GetString(16),
                        username = reader.GetString(17),
                        password = reader.GetString(18),
                        registered = reader.GetBoolean(19),
                    },
                    player = new Player()
                    {
                        id = reader.GetInt32(22),
                        name = reader.GetString(23),
                        surname = reader.GetString(24),
                        age = reader.GetInt32(26),
                        height = reader.GetInt32(27),
                        nationality = reader.GetString(28),
                        foot = reader.GetString(30),
                        team = new Team()
                        {
                            name = reader.GetString(35),
                        }
                    }
                }) ;
            }
            reader.Close();
            conn.Close();
            return list;
        }

        public static void insertReview(Review review)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO `mydb`.`recenzija` (`ocjena`, `tehnika_ocjena`, `fizika_ocjena`, `taktika_ocjena`, `mentalitet_ocjena`, `fizicke_karakteristike`, `tehnicke_karakteristike`, `takticke_karakteristike`, `mentalne_karakteristike`, `zakljucak`, `skaut_idskaut`, `igrac_idigrac`) 
                                VALUES (@finalGrade, @techGrade, @physGrade, @tactGrade, @mentGrade, @physDesc, @techDesc, @tactDesc, @mentDesc, @conclusion, @scoutID, @playerID);";
            cmd.Parameters.AddWithValue("@finalGrade", review.finalGrade);
            cmd.Parameters.AddWithValue("@techGrade", review.techniqueGrade);
            cmd.Parameters.AddWithValue("@physGrade",review.physicsGrade);
            cmd.Parameters.AddWithValue("@tactGrade", review.tacticsGrade);
            cmd.Parameters.AddWithValue("@mentGrade", review.mentalityGrade);
            cmd.Parameters.AddWithValue("@physDesc", review.physicsDescription);
            cmd.Parameters.AddWithValue("@techDesc", review.techniqueDescription);
            cmd.Parameters.AddWithValue("@tactDesc", review.tacticsDescription);
            cmd.Parameters.AddWithValue("@mentDesc", review.mentalityDescription);
            cmd.Parameters.AddWithValue("@conclusion", review.conclusion);
            cmd.Parameters.AddWithValue("@scoutID", review.scout.id);
            cmd.Parameters.AddWithValue("@playerID", review.player.id);
            cmd.ExecuteNonQuery();
            review.id = (int)cmd.LastInsertedId;
            conn.Close();
        }
    }
}
