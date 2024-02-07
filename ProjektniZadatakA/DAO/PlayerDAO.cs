using MySql.Data.MySqlClient;
using ProjektniZadatakA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektniZadatakA.DAO
{
    internal class PlayerDAO
    {
        public static string connectionString = "Server=127.0.0.1; Port=3306; Database=mydb;UserId = root; Password = root; ";
        public static void insertPlayer(Player player)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO `mydb`.`igrac` (`ime`, `prezime`, `vrijednost`, `godine`, `visina`, `nacionalnost`, `broj_na_dresu`, `noga`, `ekipa_idekipa`, `agencija_idagencija`, `ugovor_idugovor`)
                    VALUES (@name, @surname, @price, @age, @height, @nationality, @jerseyNumber, @foot, @teamID, '1', '1');";
            cmd.Parameters.AddWithValue("@name", player.name);
            cmd.Parameters.AddWithValue("@surname", player.surname);
            cmd.Parameters.AddWithValue("@price", player.priceInThousandsOfEuros);
            cmd.Parameters.AddWithValue("@age", player.age);
            cmd.Parameters.AddWithValue("@height", player.height);
            cmd.Parameters.AddWithValue("@nationality", player.nationality);
            cmd.Parameters.AddWithValue("@jerseyNumber", player.jerseyNumber);
            cmd.Parameters.AddWithValue("@foot", player.foot);
            cmd.Parameters.AddWithValue("@teamID", player.team.id);
            cmd.ExecuteNonQuery();
            player.id = (int)cmd.LastInsertedId;
            conn.Close();
        }
    }
}
