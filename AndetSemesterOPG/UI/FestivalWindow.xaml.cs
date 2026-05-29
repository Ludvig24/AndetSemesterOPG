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
        AttendeeService attendeeService;
        CampService campService = new CampService(new CampRepository(new DBConnection()));
        Camp campA;
        Camp campB;
        CampObserver campObserver;
        internal FestivalWindow(MainWindow main, AttendeeService attendeeService)
        {
            InitializeComponent();
            this.main = main;
            this.attendeeService = attendeeService;
            campA = new Camp();
            campA.CampId = 1;
            campA.CampName = "Camp A";
            campA.CampCapacity = campService.RetrieveCampCapacity(campA.CampName);

            campB = new Camp();
            campB.CampId = 2;
            campB.CampName = "Camp B";
            campB.CampCapacity = campService.RetrieveCampCapacity(campB.CampName);

            TotalAttendeeEast.Content = attendeeService.RetrieveAttendeesByEntranceId(1).Count;

            TotalAttendeeWest.Content = attendeeService.RetrieveAttendeesByEntranceId(2).Count;

            TotalAttendeeCampA.Content = attendeeService.RetriveAttendeesByCampName("Camp A").Count;

            TotalAttendeeCampB.Content = attendeeService.RetriveAttendeesByCampName("Camp B").Count;

            CampACapacity.Content = campService.RetrieveCampCapacity("Camp A");

            CampBCapacity.Content = campService.RetrieveCampCapacity("Camp B");

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(autoRefresh);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            campObserver = new CampObserver();
            campService.SubscribeCampObserver(campObserver);

        }


        public void autoRefresh(object sender, EventArgs e)
        {
            TotalAttendeeEast.Content = attendeeService.RetrieveAttendeesByEntranceId(1).Count;
            TotalAttendeeWest.Content = attendeeService.RetrieveAttendeesByEntranceId(2).Count;

            TotalAttendeeCampA.Content = attendeeService.RetriveAttendeesByCampName("Camp A").Count;
            TotalAttendeeCampB.Content = attendeeService.RetriveAttendeesByCampName("Camp B").Count;
            
            campService.CheckCampCapacity(campA, attendeeService.RetriveAttendeesByCampName("Camp A").Count, attendeeService);
            campService.CheckCampCapacity(campB, attendeeService.RetriveAttendeesByCampName("Camp B").Count, attendeeService);

            

            CampACapacity.Content = campService.RetrieveCampCapacity("Camp A");
            CampBCapacity.Content = campService.RetrieveCampCapacity("Camp B");
        }

        private void backButtonFestivalWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            main.Show();
        }

        private void LockCampAButton_Click(object sender, RoutedEventArgs e)
        {
            campService.LockCamp(campA, attendeeService);
            LockCampAButton.IsEnabled = false;
            OpenCampAButton.IsEnabled = true;
        }

        private void OpenCampAButton_Click(object sender, RoutedEventArgs e)
        {
            campService.UnlockCamp(campA, attendeeService);
            LockCampAButton.IsEnabled = true;
            OpenCampAButton.IsEnabled = false;
        }

        private void LockCampBButton_Click(object sender, RoutedEventArgs e)
        {
            campService.LockCamp(campB, attendeeService);
            LockCampBButton.IsEnabled = false;
            OpenCampBButton.IsEnabled = true;
        }

        private void OpenCampBButton_Click(object sender, RoutedEventArgs e)
        {
            campService.UnlockCamp(campB, attendeeService);
            LockCampBButton.IsEnabled = true;
            OpenCampBButton.IsEnabled = false;
        }

        private void UnsubscribeFromCamps_Click(object sender, RoutedEventArgs e)
        {
            campService.UnsubscribeCampObserver(campObserver);
        }

        private void SubscribeToCamps_Click(object sender, RoutedEventArgs e)
        {
            campService.SubscribeCampObserver(campObserver);

        }
    }
    
}
