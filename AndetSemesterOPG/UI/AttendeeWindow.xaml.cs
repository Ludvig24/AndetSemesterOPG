using AndetSemesterOPG.Applications;
using AndetSemesterOPG.Domain;
using AndetSemesterOPG.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class AttendeeWindow : Window
    {
        //oprettelse af klasser og services der skal bruges i AttendeeWindow
        AttendeeService attendeeService;
        List<Attendee> attendees = new List<Attendee>();
        WindowNavigator windowNavigator;
        Sort sort;
        
        //Constructor for AttendeeWindow, hvor vi initialisere klasser og services, og sætter ItemSource for datagrid til listen af attendees. Vi har også en timer der opdaterer listen af attendees hvert sekund, så vi altid har den nyeste liste
        internal AttendeeWindow(WindowNavigator windowNavigator, AttendeeService attendeeService, Sort sort)
        {
            //Initialisering af komponenter og services
            InitializeComponent();
            this.windowNavigator = windowNavigator;
            this.sort = sort;
            this.attendeeService = attendeeService;
            this.attendees = attendeeService.RetrieveAllAttendees();
            AttendeesList.ItemsSource = attendees;

            //Opretter en timer der opdaterer listen af attendees hvert sekund
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Refresh);
            timer.Interval = new TimeSpan(0,0,1);
            timer.Start();
            
            /*Vi kan måske disable det der datagrid
              og implementere vores egne sorteringsmetoder
              der sorterer fx navne i alfabetisk rækkefølge,
              id fra mindst til størst, camp navn alfabetisk osv.
              så kan vi bare kalde sorterings metoderne på attendees
              altså selve listen der bruges som ItemSource.
              Så kan hver type sortering måske bruge hver deres 
              sorteringsalgoritme.
            */
        }

        //Metode der håndterer klik på "Back" knappen, hvor vi åbner MenuWindow og skjuler AttendeeWindow
        private void AttendeeBackButton_Click(object sender, RoutedEventArgs e)
        {
            windowNavigator.OpenMenuWindow();
            this.Hide();
        }

        //Metode der opdaterer listen af attendees ved at hente den nyeste liste
        private void Refresh(object sender, EventArgs e)
        {
            attendees = attendeeService.RetrieveAllAttendees();
            totalAttendees.Content = attendees.Count.ToString();
        }

        //Metode der håndterer klik på "Refresh" knappen, hvor vi opdaterer ItemSource for datagrid
        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            AttendeesList.ItemsSource = attendees;
        }

        //Metode der håndterer klik på "Sort by Name" knappen, hvor vi sorterer listen af attendees efter fornavn
        private void sortNamesButton_Click(object sender, RoutedEventArgs e)
        {
            AttendeesList.ItemsSource = sort.SortByFirstName(attendees,0,attendees.Count-1);
        }

        //Metode der håndterer klik på "Sort by Id" knappen, hvor vi sorterer listen af attendees efter id
        private void sortByEntranceIdButton_Click(object sender, RoutedEventArgs e)
        {
            AttendeesList.ItemsSource = sort.SortByEntranceId(attendees);
        }

        //Metode der håndterer klik på "Sort by Camp Name" knappen, hvor vi sorterer listen af attendees efter camp navn
        private void sortByCampNameButton_Click(object sender, RoutedEventArgs e)
        {
            AttendeesList.ItemsSource = sort.SortByCampName(attendees);
        }


        //Metode der håndterer klik på "Admin Reset" knappen, hvor vi kalder ResetAttendee metoden
        private void AdminResetButton_Click(object sender, RoutedEventArgs e)
        {
            attendeeService.ResetAttendee();
        }
    }
}
