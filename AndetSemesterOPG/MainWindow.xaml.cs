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
    //Hovedvinduet for applikationen, hvor vi opretter alle services, repositories, windows og andre klasser der skal bruges i applikationen. MainWindow fungerer som Composition Root, hvor vi samler alle afhængigheder og konfigurerer dem.
    //Vi har valgt at skjule MainWindow og starte med at vise MenuWindow, da det er det første vindue brugeren skal interagere med.
    public partial class MainWindow : Window
    {
        IAttendeeService attendeeService;
        ICampService campService;
        IArtistService artistService;
        AttendeeCreator attendeeCreator;
        AttendeeTestData attendeeTestData;
        ITicketClient ticketClient;
        FestivalWindow festivalWindow;
        AttendeeWindow attendeeWindow;
        StageArtistWindow stageArtistWindow;
        MenuWindow menuWindow;
        ICampObserver campObserver;
        WindowNavigator windowNavigator;
        IDBConnection connection;
        IAttendeeRepository attendeeRepository;
        IArtistRepository artistRepository;
        ICampRepository campRepository;
        LineUp lineUp;
        Camp campA;
        Camp campB;
        Sort sort;
        DispatcherTimer timer;

        //Vi har valgt MainWindow som composition root da det er vinduet der starter som det første i programmet
        public MainWindow() //MainWindow fungerer nu som Composition Root 
        {
            InitializeComponent();

            //Skjul MainWindow
            this.Hide();

            //Opret forbindelse til database og repositories
            
             connection = new DBConnection();
             attendeeRepository = new AttendeeRepository(connection);
             artistRepository = new ArtistRepository(connection);
             campRepository = new CampRepository(connection);

            //Opret services, windows og andre klasser der skal bruges i applikationen
            campObserver = new CampObserver();
            attendeeTestData = new AttendeeTestData();
            ticketClient = new TicketClient();
            timer = new DispatcherTimer();

            attendeeService = new AttendeeService(attendeeRepository, new AttendeeTestData(), new TicketClient());
            campService = new CampService(campRepository);
            attendeeCreator = new AttendeeCreator(timer, attendeeService, campService);
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

            //Opret WindowNavigator og windows, og sæt dem op i WindowNavigator
            windowNavigator = new WindowNavigator();

            attendeeWindow = new AttendeeWindow(windowNavigator, attendeeService, sort);
            festivalWindow = new FestivalWindow(windowNavigator, attendeeService, campService, campA, campB, campObserver, attendeeCreator);
            stageArtistWindow = new StageArtistWindow(windowNavigator, artistService, lineUp);
            menuWindow = new MenuWindow(windowNavigator);
            windowNavigator.SetWindows(attendeeWindow, festivalWindow, menuWindow, stageArtistWindow);


            //Subscribe CampObserver til CampService, så den kan modtage opdateringer om camp kapacitet
            campService.SubscribeCampObserver(campObserver);


            //Vis MenuWindow som det første vindue
            menuWindow.Show();

        }

    }
}