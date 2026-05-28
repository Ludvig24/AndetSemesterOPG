using AndetSemesterOPG.Applications;
using AndetSemesterOPG.Domain;
using AndetSemesterOPG.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AndetSemesterOPG.UI
{
    /// <summary>
    /// Interaction logic for FestivalWindow.xaml
    /// </summary>
    public partial class FestivalWindow : Window
    {

        
        MainWindow main;
        AttendeeService attendeeService = new AttendeeService(new AttendeeRepository(new DBConnection()), new AttendeeTestData(), new TicketClient());
        CampService campService = new CampService(new CampRepository(new DBConnection()));
        public FestivalWindow(MainWindow main)
        {
            InitializeComponent();
            this.main = main;

            TotalAttendeeEast.Content = attendeeService.RetrieveAttendeesByEntranceId(1).Count;

            TotalAttendeeWest.Content = attendeeService.RetrieveAttendeesByEntranceId(2).Count;

            TotalAttendeeCampA.Content = attendeeService.RetriveAttendeesByCampName("Camp A").Count;

            TotalAttendeeCampB.Content = attendeeService.RetriveAttendeesByCampName("Camp B").Count;

            CampACapacity.Content = campService.RetrieveCampCapacity("Camp A");

            CampBCapacity.Content = campService.RetrieveCampCapacity("Camp B");

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(autoRefresh);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
            campService.CheckCampCapacity("Camp A", attendeeService.RetriveAttendeesByCampName("Camp A").Count);
            campService.CheckCampCapacity("Camp B", attendeeService.RetriveAttendeesByCampName("Camp B").Count);
        }


        public void autoRefresh(object sender, EventArgs e)
        {
            TotalAttendeeEast.Content = attendeeService.RetrieveAttendeesByEntranceId(1).Count;
            TotalAttendeeWest.Content = attendeeService.RetrieveAttendeesByEntranceId(2).Count;

            TotalAttendeeCampA.Content = attendeeService.RetriveAttendeesByCampName("Camp A").Count;
            TotalAttendeeCampB.Content = attendeeService.RetriveAttendeesByCampName("Camp B").Count;

            CampACapacity.Content = campService.RetrieveCampCapacity("Camp A");
            CampBCapacity.Content = campService.RetrieveCampCapacity("Camp B");
        }

        private void backButtonFestivalWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            main.Show();
        }

    }
    
}
