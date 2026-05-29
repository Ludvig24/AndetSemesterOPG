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
        TicketClient ticketClient = new TicketClient();
        FestivalWindow festival;
        AttendeeService attendeeService;
        public MainWindow()
        {
                InitializeComponent();
            this.attendeeService = new AttendeeService(new AttendeeRepository(new DBConnection()), new AttendeeTestData(), ticketClient);

            festival = new FestivalWindow(this, attendeeService);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(AutoCreateAttendee);
            timer.Interval = new TimeSpan(0, 0, 5); // Her sættes intervallet for timeren til 5 sekunder
            timer.Start();
        }


        private void AttendeeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            AttendeeWindow attendeeWindow = new AttendeeWindow(this);
            attendeeWindow.Show();
            this.Hide();
        }

        private void AutoCreateAttendee(object sender, EventArgs e)
        {
            attendeeService.CreateAttendee();
        }

        private void FestivalWindowButton_Click(object sender, RoutedEventArgs e)
        {
            //FestivalWindow festival = new FestivalWindow(this);
            
            festival.Show();
            this.Hide();
        }

        private void StageArtistWindowButton_Click(object sender, RoutedEventArgs e)
        {
            StageArtistWindow stageArtist = new StageArtistWindow();
            stageArtist.Show();
            this.Hide();
        }
    }
}