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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektniZadatakA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(SportingDirector sd in SportingDirectorDAO.getDirectors()){
                if(sd.username==usernameBox.Text && sd.password == passwordBox.Password)
                {
                    infoLabel.Content = "Prijava uspjesna - dis";
                    SDirectorMenu sdm = new SDirectorMenu();
                    sdm.scoutsHeader.Visibility = Visibility.Visible;
                    //sdm.addScoutsHeader.Visibility = Visibility.Visible;
                    sdm.matchesHeader.Visibility = Visibility.Visible;
                    //sdm.addMatchHeader.Visibility = Visibility.Visible;
                    sdm.playersHeader.Visibility = Visibility.Visible;
                    sdm.makeReviewHeader.Visibility = Visibility.Collapsed;
                    sdm.Show();
                    this.Close();
                    return;
                }
            }
            foreach(Scout s in ScoutDAO.getScouts())
            {
                if(s.username==usernameBox.Text && s.password == passwordBox.Password)
                {
                    infoLabel.Content = "Prijava uspjesna - skaut";
                    SDirectorMenu sdm = new SDirectorMenu();
                    SDirectorMenu.loggedScout = s;
                    sdm.scoutsHeader.Visibility = Visibility.Collapsed;
                  //  sdm.addScoutsHeader.Visibility = Visibility.Collapsed;
                    sdm.matchesHeader.Visibility = Visibility.Visible;
                    sdm.matchesHeader.IsSelected = true;
                    //sdm.addMatchHeader.Visibility = Visibility.Collapsed;
                    sdm.playersHeader.Visibility = Visibility.Visible;
                    sdm.makeReviewHeader.Visibility = Visibility.Visible;
                    sdm.Show();
                    this.Close();
                    return;
                }
            }
            infoLabel.Content = "Prijava neuspjesna";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb.SelectedIndex == 0)
            {
                Properties.Settings.Default.language = "en-US";
            }
            else
            {
                Properties.Settings.Default.language = "sr-Latn-RS";
            }
            Properties.Settings.Default.Save();
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
            //this.Close();
        }
    }
}
