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
using AndetSemesterOPG.Domain;
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
        FestivalWindow festivalWindow;
        AttendeeWindow attendeeWindow;
        StageArtistWindow stageArtistWindow;
        MenuWindow menuWindow;
        CampObserver campObserver;
        WindowNavigator windowNavigator;
        LineUp lineUp;
        Camp campA;
        Camp campB;
        Sort sort;

        //Vi har valgt MainWindow som composition root da det er vinduet der starter som det første i programmet. <-- smid det et smart sted i rapport
        public MainWindow() //MainWindow fungerer nu som Composition Root - vi bør lave et separat menu vindue så MainWindow fra nu KUN er Composition Root - intet UI
        {
            InitializeComponent();
            this.Hide();

            IDBConnection connection = new DBConnection();
            IAttendeeRepository attendeeRepository = new AttendeeRepository(connection);
            IArtistRepository artistRepository = new ArtistRepository(connection);
            ICampRepository campRepository = new CampRepository(connection);

            campObserver = new CampObserver();

            attendeeService = new AttendeeService(attendeeRepository, new AttendeeTestData(), new TicketClient());
            campService = new CampService(campRepository);
            artistService = new ArtistService(artistRepository);
            sort = new Sort();
            lineUp = new LineUp(artistService);


            //Flyt til en CampCreator? - klasse der henter oplysninger om camps fra db og laver x antal camps som svarer til antal i db måske? Så opret CampCreator i CompositionRoot og start den der.
            campA = new Camp();
            campA.CampId = 1;
            campA.CampName = "Camp A";
            campA.CampCapacity = campService.RetrieveCampCapacity(campA.CampName);

            campB = new Camp();
            campB.CampId = 2;
            campB.CampName = "Camp B";
            campB.CampCapacity = campService.RetrieveCampCapacity(campB.CampName);

            windowNavigator = new WindowNavigator();

            attendeeWindow = new AttendeeWindow(windowNavigator, attendeeService, sort);
            festivalWindow = new FestivalWindow(windowNavigator, attendeeService, campService, campA, campB, campObserver, attendeeCreator);
            stageArtistWindow = new StageArtistWindow(windowNavigator, artistService, lineUp);
            menuWindow = new MenuWindow(windowNavigator);
            windowNavigator.SetWindows(attendeeWindow, festivalWindow, menuWindow, stageArtistWindow);
            


            campService.SubscribeCampObserver(campObserver);

            //Har flyttet AttendeeCreator ned under CampObserver så den ikke først laver en attendee og så ser om der er låst for så at låse. Det gjorde at selvom campen er fyldt, så ville den kunne nå at lave en attendee imens programet åbnede
            attendeeCreator = new AttendeeCreator(new DispatcherTimer(), attendeeService, campService);

            menuWindow.Show();

        }

    }
}