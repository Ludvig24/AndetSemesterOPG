using System;
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
using AndetSemesterOPG.Applications;
using Microsoft.Data.SqlClient;
using AndetSemesterOPG.Domain; //FJERN DENNE?!?!?
using AndetSemesterOPG.Infrastructure;
using AndetSemesterOPG.UI;
using System.Windows.Threading;

namespace AndetSemesterOPG
{
    public partial class MainWindow : Window
    {
        AttendeeService attendeeService;
        CampService campService;
        ArtistService artistService;
        AttendeeCreator attendeeCreator;
        FestivalWindow festival;
        AttendeeWindow attendeeWindow;
        StageArtistWindow stageArtist;
        CampObserver campObserver;
        Camp campA;
        Camp campB;
        Sort sort;

        public MainWindow() //MainWindow fungerer nu som Composition Root - vi bør lave et separat menu vindue så MainWindow fra nu KUN er Composition Root - intet UI
        {
            InitializeComponent();

            IDBConnection connection = new DBConnection();
            IAttendeeRepository attendeeRepository = new AttendeeRepository(connection);
            IArtistRepository artistRepository = new ArtistRepository(connection);
            ICampRepository campRepository = new CampRepository(connection);

            campObserver = new CampObserver();

            attendeeService = new AttendeeService(attendeeRepository, new AttendeeTestData(), new TicketClient());
            campService = new CampService(campRepository);
            artistService = new ArtistService(artistRepository);
            attendeeCreator = new AttendeeCreator(new DispatcherTimer(), attendeeService);
            sort = new Sort();


            //Flyt til en CampCreator? - klasse der henter oplysninger om camps fra db og laver x antal camps som svarer til antal i db måske? Så opret CampCreator i CompositionRoot og start den der.
            campA = new Camp();
            campA.CampId = 1;
            campA.CampName = "Camp A";
            campA.CampCapacity = campService.RetrieveCampCapacity(campA.CampName);

            campB = new Camp();
            campB.CampId = 2;
            campB.CampName = "Camp B";
            campB.CampCapacity = campService.RetrieveCampCapacity(campB.CampName);


            festival = new FestivalWindow(this, attendeeService, campService, campA, campA, campObserver);
            attendeeWindow = new AttendeeWindow(this, attendeeService, sort);
            stageArtist = new StageArtistWindow(this, artistService);




            campService.SubscribeCampObserver(campObserver);

        }


        private void AttendeeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            attendeeWindow.Show();
            this.Hide();
        }

       

        private void FestivalWindowButton_Click(object sender, RoutedEventArgs e)
        {            
            festival.Show();
            this.Hide();
        }

        private void StageArtistWindowButton_Click(object sender, RoutedEventArgs e)
        {
            stageArtist.Show();
            this.Hide();
        }
    }
}