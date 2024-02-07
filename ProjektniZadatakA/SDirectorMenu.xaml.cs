using ProjektniZadatakA.DAO;
using ProjektniZadatakA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;

namespace ProjektniZadatakA
{
    /// <summary>
    /// Interaction logic for SDirectorMenu.xaml
    /// </summary>
    public partial class SDirectorMenu : Window
    {
        public static Scout loggedScout = new Scout();
        public SDirectorMenu()
        {
            var langCode = Properties.Settings.Default.language;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(langCode);
            
            InitializeComponent();

            if (Properties.Settings.Default.ColorMode.Equals("Black"))
            {
                Theme1.IsChecked = true;
                Theme2.IsChecked = false;
                Theme3.IsChecked = false;
            }
            else if (Properties.Settings.Default.ColorMode.Equals("Dark"))
            {
                Theme1.IsChecked = false;
                Theme2.IsChecked = true;
                Theme3.IsChecked = false;
            }
            else
            {
                Theme1.IsChecked = false;
                Theme2.IsChecked = false;
                Theme3.IsChecked = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fillScouts();
           // fillCities();
            fillMatches();
            fillTeams();
            //fillStadiums();
            fillReviews();
            fillGrades();
        }

        private void fillTeams()
        {
            
            teamsBox.Items.Clear();
            foreach (Team team in TeamDAO.getTeams())
            {
                teamsBox.Items.Add(team.name);
            }
        }

        private void fillGrades()
        {
            mentalityGrades.Items.Clear();
            physicsGrades.Items.Clear();
            tacticsGrades.Items.Clear();
            techniqueGrades.Items.Clear();
            finalGrades.Items.Clear();
            for(int i = 1; i < 11; i++)
            {
                mentalityGrades.Items.Add(i);
                physicsGrades.Items.Add(i);
                tacticsGrades.Items.Add(i);
                techniqueGrades.Items.Add(i);
                finalGrades.Items.Add(i);
            }
        }

        private void fillReviews()
        {
            players.Items.Clear();
            foreach(Review review in ReviewDAO.getReviews())
            {
                players.Items.Add(review);
            }
        }

       
        private void fillMatches()
        {
            matches.Items.Clear();
            foreach(var match in MatchDAO.getMatches())
            {
                matches.Items.Add(match);
            }
            
        }

        
        private void fillScouts()
        {
            scoutsTable.Items.Clear();
            foreach(var s in ScoutDAO.getScouts())
            {
                scoutsTable.Items.Add(s); 
            }
            
                   
        }

     /*  private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text=="" || surnameBox.Text=="" || usernameBox.Text=="" || passwordBox.Text=="" || cityMenu==null || licenceBox.Text == "")
            {
                infoLabel.Content = "Neuspjesna dodavanje novog skauta. Popunite sva polja na pravi nacin.";
            }
            else
            {

                Scout scout = new Scout()
                {
                    name = nameBox.Text,
                    surname = surnameBox.Text,
                    username = usernameBox.Text,
                    password = passwordBox.Text,
                    licence = licenceBox.Text,
                    registered = true,
                    city = CityDAO.getCityByName(cityMenu.SelectedItem.ToString())
                };
                ScoutDAO.insertScout(scout);
                fillScouts();
                infoLabel.Content = "Uspjesno ste dodali skauta.";

            }
        }*/

        

    /*    private void addMatchButton_Click(object sender, RoutedEventArgs e)
        {
            int result;
            if(datePicker.SelectedDate ==null || priceBox.Text=="" || !Int32.TryParse(priceBox.Text, out result) || hostTeams==null || guestTeams == null || stadiumBox==null)
            {
                infoLabel2.Content = "Neuspjesno dodavanje nove utakmice. Popunite sva polja na pravi nacin";
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
                fillMatches();
                infoLabel2.Content = "Uspjesno ste dodali mec.";
                
            }
        }*/

        private void deleteMatchButton_Click(object sender, RoutedEventArgs e)
        {
            Match match = matches.SelectedItem as Match;
            MatchDAO.deleteMatchById(match.id);
            fillMatches();

        }

        private void deleteScoutButton_Click(object sender, RoutedEventArgs e)
        {
            Scout scout = scoutsTable.SelectedItem as Scout;
            ScoutDAO.deleteScoutById(scout.id);
            fillScouts();
        }

        private void addReviewButton_Click(object sender, RoutedEventArgs e)
        {
            int playerAge;
            int finalGrade;
            int techGrade;
            int tactGrade;
            int physGrade;
            int mentGrade;
            if(playerNameBox ==null || playerSurnameBox == null  || !Int32.TryParse(playerAgeBox.Text, out playerAge) ||
                !Int32.TryParse(finalGrades.Text,out finalGrade) || !Int32.TryParse(techniqueGrades.Text, out techGrade) || !Int32.TryParse(tacticsGrades.Text,out tactGrade)
                || !Int32.TryParse(mentalityGrades.Text,out mentGrade) || !Int32.TryParse(physicsGrades.Text,out physGrade) || teamsBox.SelectedItem==null)
            {
                infoLabel3.Text = "Neuspjesno dodavanje izvjestaja.";
            }
            else
            {
                Player player = new Player()
                {
                    name = playerNameBox.Text,
                    surname = playerSurnameBox.Text,
                    priceInThousandsOfEuros = 0,
                    age = playerAge,
                    height = 0,
                    nationality = playerNationalityBox.Text,
                    jerseyNumber = 0,
                    foot = playerFootBox.Text,
                    team = TeamDAO.getTeamByName(teamsBox.SelectedItem.ToString()),
                };
                PlayerDAO.insertPlayer(player);
                Review review = new Review()
                {
                    finalGrade = finalGrade,
                    techniqueGrade = techGrade,
                    tacticsGrade = tactGrade,
                    mentalityGrade = mentGrade,
                    physicsGrade = physGrade,
                    physicsDescription = physicsDescriptionBox.Text,
                    tacticsDescription = tacticsDescriptionBox.Text,
                    techniqueDescription = techniqueDescriptionBox.Text,
                    mentalityDescription = mentalityDescriptionBox.Text,
                    conclusion = conclusionBox.Text,
                    player = player,
                    scout = loggedScout
                };
                ReviewDAO.insertReview(review);
                fillReviews();
                infoLabel3.Text = "Uspjesno ste dodali skauta.";
            }
        }

        private void addScoutButton_Click(object sender, RoutedEventArgs e)
        {
            AddScoutWin window = new AddScoutWin();
            this.IsEnabled = false;
            window.ShowDialog();
            this.IsEnabled = true;
            fillScouts();
        }

        private void addMatchButt_Click(object sender, RoutedEventArgs e)
        {
            AddMatchWin window = new AddMatchWin();
            this.IsEnabled = false;
            window.ShowDialog();
            this.IsEnabled = true;
            fillMatches();

        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            loggedScout = null;
            MainWindow window = new MainWindow();
            this.Close();
            window.Show();
            
        }

        private void Theme1_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "Black";
            Properties.Settings.Default.Save();
            
        }

        private void Theme2_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "Dark";
            Properties.Settings.Default.Save();
        }

        private void Theme3_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "Light";
            Properties.Settings.Default.Save();
        }

        private void addMeButton_Click(object sender, RoutedEventArgs e)
        {
            Match match = matches.SelectedItem as Match;
            MatchDAO.addScoutOnMatch(loggedScout, match);
            fillMatches();
        }

        
    }
}
