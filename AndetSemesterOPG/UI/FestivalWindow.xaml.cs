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

        
        WindowNavigator windowNavigator;
        AttendeeService attendeeService;
        AttendeeCreator attendeeCreator;
        CampService campService;
        Camp campA;
        Camp campB;
        CampObserver campObserver;
        internal FestivalWindow(WindowNavigator windowNavigator, AttendeeService attendeeService, CampService campService, Camp campA, Camp campB, CampObserver campObserver, AttendeeCreator attendeeCreator)
        {
            InitializeComponent();
            this.windowNavigator = windowNavigator;
            this.attendeeService = attendeeService;
            this.attendeeCreator = attendeeCreator;
            this.campA = campA;
            this.campB = campB;
            this.campObserver = campObserver;
            this.campService = campService;


            TotalAttendeeEast.Content = attendeeService.RetrieveAttendeesByEntranceId(1).Count;

            TotalAttendeeWest.Content = attendeeService.RetrieveAttendeesByEntranceId(2).Count;

            TotalAttendeeCampA.Content = attendeeService.RetriveAttendeesByCampName("Camp A").Count;

            TotalAttendeeCampB.Content = attendeeService.RetriveAttendeesByCampName("Camp B").Count;

            CampACapacity.Content = campService.RetrieveCampCapacity("Camp A");

            CampBCapacity.Content = campService.RetrieveCampCapacity("Camp B");

            SubscribeToCamps.IsEnabled = false;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(AutoRefresh);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            

        }


        public void AutoRefresh(object sender, EventArgs e)
        {
            TotalAttendeeEast.Content = attendeeService.RetrieveAttendeesByEntranceId(1).Count;
            TotalAttendeeWest.Content = attendeeService.RetrieveAttendeesByEntranceId(2).Count;

            TotalAttendeeCampA.Content = attendeeService.RetriveAttendeesByCampName("Camp A").Count;
            TotalAttendeeCampB.Content = attendeeService.RetriveAttendeesByCampName("Camp B").Count;
            
            //Dette bør være et andet sted - det andet med timeren er fint nok da det bare er UI gøgl
            campService.CheckCampCapacity(campA, attendeeService.RetriveAttendeesByCampName("Camp A").Count, attendeeService);
            campService.CheckCampCapacity(campB, attendeeService.RetriveAttendeesByCampName("Camp B").Count, attendeeService);

            //Her ændre Cam status labelsnee for at fortælle brugeren om en camp er låst eller ej
            switch(campA.IsLocked)
            {
                case true:
                    CampA_StatusLabel.Content = "Camp A er låst";
                    break;

                case false:
                    CampA_StatusLabel.Content = "Camp A er åben";
                    break;

            }
            switch (campB.IsLocked)
            {
                case true:
                    CampB_StatusLabel.Content = "Camp B er låst";
                    break;

                case false:
                    CampB_StatusLabel.Content = "Camp B er åben";
                    break;

            }


            //Her er Simulation knappen låst eller åben afhægig af om alle camps er låste eller ej
            if (campA.IsLocked == true && campB.IsLocked == true)
            {
                AttendeeSimulationButton.IsEnabled = false;
            }
            if (campA.IsLocked == false || campB.IsLocked == false)
            {
                AttendeeSimulationButton.IsEnabled = true;
            }
            //Knapper bliver låst elller åbnet afhængig af om pladserne er låste eller åbne
            
            LockCampAButton.IsEnabled = !campA.IsLocked;
            OpenCampAButton.IsEnabled = campA.IsLocked;

            LockCampBButton.IsEnabled = !campB.IsLocked;
            OpenCampBButton.IsEnabled = campB.IsLocked;

            //Her bliver knappen også låst hvis en camps kapasitet er fyldt
            if (attendeeService.RetriveAttendeesByCampName("Camp A").Count >= campA.CampCapacity)
            {
                OpenCampAButton.IsEnabled = false;
            }
            if (attendeeService.RetriveAttendeesByCampName("Camp B").Count >= campB.CampCapacity)
            {
                OpenCampBButton.IsEnabled = false;
            }


            CampACapacity.Content = campService.RetrieveCampCapacity("Camp A");
            CampBCapacity.Content = campService.RetrieveCampCapacity("Camp B");
        }

        private void backButtonFestivalWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            windowNavigator.OpenMenuWindow();
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
        private void SubscribeToCamps_Click(object sender, RoutedEventArgs e)
        {
            campService.SubscribeCampObserver(campObserver);
            SubscribeToCamps.IsEnabled = false;
            UnsubscribeFromCamps.IsEnabled = true;
            SubscribtionstatusLabel.Content = "Du er Subscribed";
            MessageBox.Show("Du er nu subscribed til at få beskeder om de forskellige camps");

        }

        private void UnsubscribeFromCamps_Click(object sender, RoutedEventArgs e)
        {
            campService.UnsubscribeCampObserver(campObserver);
            SubscribeToCamps.IsEnabled = true;
            UnsubscribeFromCamps.IsEnabled = false;
            SubscribtionstatusLabel.Content = "Du er Unsubscribed";
            MessageBox.Show("Du er nu unsubscribed, og vil ikke længere få beskeder om de forskellige camps");
        }


        private void AttendeeSimulationButton_Click(object sender, RoutedEventArgs e)
        {
            attendeeCreator.SemaphoreStart();
        }
    }
    
}
