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
        AttendeeCreator attendeeCreator;
        FestivalWindow festival;
        AttendeeWindow attendeeWindow;
        StageArtistWindow stageArtist;
        

        public MainWindow() //MainWindow fungerer nu som Composition Root - vi bør lave et separat menu vindue så MainWindow fra nu KUN er Composition Root - intet UI
        {
            InitializeComponent();

            IDBConnection connection = new DBConnection();
            IAttendeeRepository attendeeRepository = new AttendeeRepository(connection);
            IArtistRepository artistRepository = new ArtistRepository(connection);
            ICampRepository campRepository = new CampRepository(connection);

            attendeeService = new AttendeeService(attendeeRepository, new AttendeeTestData(), new TicketClient());
            campService = new CampService(campRepository);
            attendeeCreator = new AttendeeCreator(new DispatcherTimer(), attendeeService);

            festival = new FestivalWindow(this, attendeeService);
            attendeeWindow = new AttendeeWindow(this);
            stageArtist = new StageArtistWindow();





            
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