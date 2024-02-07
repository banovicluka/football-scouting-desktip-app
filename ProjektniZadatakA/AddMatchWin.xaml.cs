using ProjektniZadatakA.DAO;
using ProjektniZadatakA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektniZadatakA
{
    /// <summary>
    /// Interaction logic for AddMatchWin.xaml
    /// </summary>
    public partial class AddMatchWin : Window
    {
        public AddMatchWin()
        {
            InitializeComponent();
        }

        private void fillStadiums()
        {
            stadiumBox.Items.Clear();
            foreach (Stadium s in StadiumDAO.getStadiums())
            {
                stadiumBox.Items.Add(s.name);
            }
        }

        private void fillTeams()
        {
            hostTeams.Items.Clear();
            guestTeams.Items.Clear();
            //teamsBox.Items.Clear();
            foreach (Team team in TeamDAO.getTeams())
            {
                hostTeams.Items.Add(team.name);
                guestTeams.Items.Add(team.name);
               // teamsBox.Items.Add(team.name);
            }
        }

        private void addMatchButton_Click(object sender, RoutedEventArgs e)
        {
            int result;
            if (datePicker.SelectedDate == null || priceBox.Text == "" || !Int32.TryParse(priceBox.Text, out result) || hostTeams == null || guestTeams == null || stadiumBox == null)
            {
                infoLabel2.Text = "Neuspjesno dodavanje nove utakmice. Popunite sva polja na pravi nacin";
            }
            else
            {
                Match match = new Match()
                {
                    date = datePicker.SelectedDate,
                    ticketPrice = result,
                    host = TeamDAO.getTeamByName(hostTeams.SelectedItem.ToString()),
                    guest = TeamDAO.getTeamByName(guestTeams.SelectedItem.ToString()),
                    stadium = StadiumDAO.getStadiumByName(stadiumBox.SelectedItem.ToString())
                };
                MatchDAO.insertMatch(match);
                //fillMatches();
                //infoLabel2.Content = "Uspjesno ste dodali mec.";
                this.Close();

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fillStadiums();
            fillTeams();    
        }
    }
}
