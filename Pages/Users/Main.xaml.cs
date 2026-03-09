using Kino_Kazakov.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Kino_Kazakov.Pages.Users
{
    public partial class Main : Page
    {
        public ClubsContext AllUsers = new();

        public Main()
        {
            InitializeComponent();
            LoadFilterData();
            UpdateList();
        }

        private void LoadFilterData()
        {
            CBoxFilter.Items.Add("Все клубы");
            foreach (var club in AllUsers.Clubs)
            {
                CBoxFilter.Items.Add(club.Name);
            }
            CBoxFilter.SelectedIndex = 0;
            CBoxSort.SelectedIndex = 0;
        }

        public void UpdateList()
        {
            if (ParentView == null) return;
            ParentView.Children.Clear();

            var query = AllUsers.Users.ToList();

            if (!string.IsNullOrWhiteSpace(TBoxSearch.Text))
            {
                query = query.Where(x => x.FIO.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            }

            if (CBoxFilter.SelectedIndex > 0)
            {
                string selectedClub = CBoxFilter.SelectedItem.ToString();
                int clubId = AllUsers.Clubs.FirstOrDefault(c => c.Name == selectedClub)?.Id ?? -1;
                query = query.Where(x => x.IdClub == clubId).ToList();
            }

            switch (CBoxSort.SelectedIndex)
            {
                case 1: // А-Я
                    query = query.OrderBy(x => x.FIO).ToList();
                    break;
                case 2: // Я-А
                    query = query.OrderByDescending(x => x.FIO).ToList();
                    break;
            }

            foreach (Models.Users user in query)
            {
                ParentView.Children.Add(new Elements.Item(this, user));
            }
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void AddClub(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(new Pages.Users.Add(this));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateList(); 
        }
    }
}