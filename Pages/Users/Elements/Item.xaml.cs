using Kino_Kazakov.Classes;
using Kino_Kazakov.Pages.Clubs;
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

namespace Kino_Kazakov.Pages.Users.Elements
{
    /// <summary>
    /// Логика взаимодействия для Elements.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public ClubsContext AllClub = new();

        Pages.Clubs.Main Main;

        Models.Users User;

        public Item(Main Main, Models.Users User) { 
            InitializeComponent();

            this.User = User;
            this.Main = Main;

            this.FIO.Text = User.FIO;
            this.RentStart.Text = User.RentStart.ToString("yyyy-MM-dd");
            this.RentTime.Text = User.RentStart.ToString("HH-mm");
            this.Duration.Text = User.Duration.ToString();
            this.Club.Text = AllClub.Clubs.Where(x => x.Id == User.IdClub).First().Name;
        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(new Pages.Users.Add(this.Main, this.User));
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            Main.AllUsers.User.Remove(User);
            Main.AllUser.SaveChanges();
            Main.Parent.Children.Remove(this);
        }
    }
}
