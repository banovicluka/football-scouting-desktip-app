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
    /// Interaction logic for AddScoutWin.xaml
    /// </summary>
    public partial class AddScoutWin : Window
    {
        public AddScoutWin()
        {
            InitializeComponent();
        }


        void fillCities()
        {
            cityMenu.Items.Clear();
            foreach(City city in CityDAO.getCities())
            {
                cityMenu.Items.Add(city.name);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text == "" || surnameBox.Text == "" || usernameBox.Text == "" || passwordBox.Password == "" || cityMenu == null || licenceBox.Text == "")
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
                    password = passwordBox.Password,
                    licence = licenceBox.Text,
                    registered = true,
                    city = CityDAO.getCityByName(cityMenu.SelectedItem.ToString())
                };
                ScoutDAO.insertScout(scout);
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fillCities();
        }
    }
}
