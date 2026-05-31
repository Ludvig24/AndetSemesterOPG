using AndetSemesterOPG.Applications;
using AndetSemesterOPG.Domain;
using AndetSemesterOPG.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AndetSemesterOPG.UI
{
    /// <summary>
    /// Interaction logic for StageArtistWindow.xaml
    /// </summary>
    public partial class StageArtistWindow : Window
    {
        WindowNavigator windowNavigator;
        ArtistService artistService;
        List<Artist> artists;
        LineUp lineUp = new LineUp();
        internal StageArtistWindow(WindowNavigator windowNavigator, ArtistService artistService, LineUp lineUp)
        {
            InitializeComponent();

            this.windowNavigator = windowNavigator;
            this.artistService = artistService;
            this.artists = this.artistService.RetrieveAllArtists();
            this.lineUp = lineUp;

            foreach(Artist artist in artists)
            {
                
                lineUp.AddArtistToLineUp(artist, Schedule_Orange);

            }


            /*
            artistService.RetrieveAllArtists().ForEach(artist =>
            {
                LineUp lineUp = new LineUp();
                lineUp.AddArtistToLineUp(artist, Schedule_Orange);
            });
            */




        }

        //Vi kan nu med en knap også tilføje artists til schedule, men måske er det lidt for møj for en ui klasse. Vi kan heller ikke endnu styre hvilken scene de ender på.
        private void AddArtistButton_Click(object sender, RoutedEventArgs e)
        {
            //Bør nok være en metode et eller andet sted (ArtistService?) der kaldes i stedet for at det bliver lavet herinde
            Artist artist = new Artist(ArtistNameTextBox.Text, ArtistTimeCombobox.Text, ArtistDateCombobox.Text, StageNameComboBox.SelectedIndex+1);
            lineUp.AddArtistToLineUp(artist, Schedule_Orange);
        }

        private void BackButtoninStage_Click(object sender, RoutedEventArgs e)
        {
            windowNavigator.OpenMenuWindow();
            this.Hide();
        }
    }
}
