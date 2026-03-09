using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kino_Kazakov.Classes;

namespace Kino_Kazakov.Pages.Clubs
{
    public partial class Main : Page
    {
        public ClubsContext AllClub = new();

        public Main()
        {
            InitializeComponent();
            CBoxSort.SelectedIndex = 0; 
            UpdateList();
        }


        public void UpdateList()
        {

            if (ParentView == null) return;

            ParentView.Children.Clear();

            var query = AllClub.Clubs.ToList();


            if (!string.IsNullOrWhiteSpace(TBoxSearch.Text))
            {
                query = query.Where(x => x.Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            }

            switch (CBoxSort.SelectedIndex)
            {
                case 1: // А-Я
                    query = query.OrderBy(x => x.Name).ToList();
                    break;
                case 2: // Я-А
                    query = query.OrderByDescending(x => x.Name).ToList();
                    break;
            }

            foreach (Models.Clubs Club in query)
            {
                ParentView.Children.Add(new Elements.Item(Club, this));
            }
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void AddClub(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(new Pages.Clubs.Add(this));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }
    }
}