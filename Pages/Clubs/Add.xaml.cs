using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Kino_Kazakov.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        private Main Main { get; set; }

        private Models.Clubs Club { get; set; }

        public Add(Main main, Models.Clubs club = null)
        {
            InitializeComponent();
            Main = main;

            if (club != null)
            {
                LoadClubData(club);
            }
        }

        private void LoadClubData(Models.Clubs club)
        {
            Club = club;
            Name.Text = club.Name;
            Address.Text = club.Address;
            WorkTime.Text = club.WorkTime;
            BtnAdd.Content = "Изменить";
        }

        private void AddClub(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Club == null)
            {
                CreateNewClub();
            }
            else
            {
                UpdateExistingClub();
            }

            SaveChangesAndNavigate();
        }

        private void CreateNewClub()
        {
            Club = new Models.Clubs
            {
                Name = Name.Text,
                Address = Address.Text,
                WorkTime = WorkTime.Text
            };

            Main.AllClub.Clubs.Add(Club);
        }

        private void UpdateExistingClub()
        {
            Club.Name = Name.Text;
            Club.Address = Address.Text;
            Club.WorkTime = WorkTime.Text;
        }

        private void SaveChangesAndNavigate()
        {
            Main.AllClub.SaveChanges();
            MainWindow.init.OpenPages(new Pages.Clubs.Main());
        }
    }
}
