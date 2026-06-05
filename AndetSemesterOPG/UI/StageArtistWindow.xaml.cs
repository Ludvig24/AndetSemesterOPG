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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace AndetSemesterOPG.UI
{
    /// <summary>
    /// Interaction logic for StageArtistWindow.xaml
    /// </summary>
    public partial class StageArtistWindow : Window
    {

        //Oprettelse af klasser og services der skal bruges i StageArtistWindow
        WindowNavigator windowNavigator;
        ArtistService artistService;
        List<Artist> artists;
        LineUp lineUp;
        List<Grid> stages;

        //Constructor for StageArtistWindow, hvor vi initialisere klasser og services, og sætter ItemSource for ArtistListBox til listen af artists
        internal StageArtistWindow(WindowNavigator windowNavigator, ArtistService artistService, LineUp lineUp)
        {
            InitializeComponent();

            //Initialisering af komponenter og services
            this.windowNavigator = windowNavigator;
            this.artistService = artistService;
            this.artists = this.artistService.RetrieveAllArtists();
            this.lineUp = lineUp;

            //Opretter en liste af Grid, som repræsenterer de forskellige scener, og tilføjer dem til LineUp klassen
            stages = new List<Grid>();
            stages.Add(Schedule_Orange);
            stages.Add(Schedule_Arena);

            //Kalder LineUp's metode til at tilføje artists til de forskellige scener
            lineUp.AddArtistToLineUp(stages);
            ArtistListBox.ItemsSource = artists;

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
            Artist artist = new Artist(ArtistNameTextBox.Text, ArtistTimeCombobox.Text, ArtistDateCombobox.Text, StageNameComboBox.SelectedIndex+1);

            if (artistService.IsSlotTaken(artist))
            {
                MessageBox.Show("Der er allerede en kunstner på denne scene, dato og tidspunkt.");
                return;
            }


            if (artist.ArtistName == "")
            {
                MessageBox.Show("Angiv Kunstnerens navn");
                return;
            }
            if (StageNameComboBox.Text == "")
            {
                MessageBox.Show("Angiv hvilkoen scene kunstneren skal spille på");
                return;
            }
            if (ArtistDateCombobox.Text == "")
            {
                MessageBox.Show("Angiv hvilken dag kunstneren skal spille");
                return;
            }

            if (ArtistTimeCombobox.Text == "")
            {
                MessageBox.Show("Angiv et tidspunkt kunstneren skal spille");
                return;
            }
            //Bør nok være en metode et eller andet sted (ArtistService?) der kaldes i stedet for at det bliver lavet herinde

            artistService.CreateArtist(artist);
            
            
            Refresh();
            
        }

        //Metode der opdaterer visuelle komponenter i vinduet, ved at rydde alle scener og derefter tilføje artists til de forskellige scener
        public void Refresh()
        {
            
            foreach (Grid grid in stages)
            {

                grid.Children.Clear();

            }
            lineUp.AddArtistToLineUp(stages);
            artists = artistService.RetrieveAllArtists();
            ArtistNameTextBox.Clear();
            ArtistListBox.ItemsSource = artists;

        }

        //Metode der håndterer klik på "Back" knappen, hvor vi åbner MenuWindow og skjuler StageArtistWindow
        private void BackButtoninStage_Click(object sender, RoutedEventArgs e)
        {
            windowNavigator.OpenMenuWindow();
            this.Hide();
        }

        //Metode der håndterer klik på "Remove Artist" knappen, hvor vi fjerner den valgte artist fra listen og opdaterer visuelle komponenter
        private void RemoveArtistButton_Click(object sender, RoutedEventArgs e)
        {
            Artist artist = ArtistListBox.SelectedItem as Artist;
            artistService.RemoveArtist(artist);
            artists = artistService.RetrieveAllArtists();
            Refresh();
        }

        //Metode der håndterer klik på "Update Artist" knappen, hvor vi opdaterer oplysningerne for den valgte artist
        private void UpdateArtistButton_Click(object sender, RoutedEventArgs e)
        {
            //if sætninger der tjekker om der er valgt en artist, og om de nødvendige oplysninger er angivet
            Artist artist = ArtistListBox.SelectedItem as Artist;
            if (artist == null)
            {
                MessageBox.Show("Vælg en kunstner du vil ændre på");
                return;
            }
            if (artist.ArtistName == "")
            {
                MessageBox.Show("Angiv Kunstnerens navn");
                return;
            }
            if (ArtistNameTextBox.Text == "")

            {
                MessageBox.Show("Angiv kunstnerens navn");
                return;
            }

            if (artistService.IsSlotTaken(artist))
            {
                MessageBox.Show("Der er allerede en kunstner på denne scene, dato og tidspunkt.");
                return;
            }
            artist.ArtistName = ArtistNameTextBox.Text;
            artist.ArtistTime = ArtistTimeCombobox.Text;
            artist.ArtistDate = ArtistDateCombobox.Text;
            artist.StageId = StageNameComboBox.SelectedIndex+1;
            if (artist.ArtistName == null)
            {
                MessageBox.Show("Angiv kunstnerens navn");
                return;
            }

            //artistService opdaterer artist i databasen
            artistService.ModifyArtist(artist);

            //Henter den opdaterede liste af artists og opdaterer visuelle komponenter
            artists = artistService.RetrieveAllArtists();
            Refresh();
        }

        //Metode der håndterer ændring af selection i ArtistListBox, hvor vi opdaterer tekstbokse og comboboxes med oplysningerne for den valgte artist
        private void ArtistListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Artist artist = ArtistListBox.SelectedItem as Artist;
            //måske dårligt solid
            if(artist == null) 
            {
                return;
            }
            ArtistNameTextBox.Text = artist.ArtistName;
            StageNameComboBox.SelectedIndex = artist.StageId -1;
            ArtistDateCombobox.Text = artist.ArtistDate;
            ArtistTimeCombobox.Text = artist.ArtistTime;

        }


       
    }
}
