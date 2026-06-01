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
    /// <summary>
    /// Interaction logic for AttendeeWindow.xaml
    /// </summary>
    public partial class AttendeeWindow : Window
    {
        AttendeeService attendeeService;
        List<Attendee> attendees = new List<Attendee>();
        WindowNavigator windowNavigator;
        Sort sort;
        
        internal AttendeeWindow(WindowNavigator windowNavigator, AttendeeService attendeeService, Sort sort)
        {
            InitializeComponent();
            this.windowNavigator = windowNavigator;
            this.sort = sort;
            this.attendeeService = attendeeService;
            this.attendees = attendeeService.RetrieveAllAttendees();
            AttendeesList.ItemsSource = attendees;


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

        private void AttendeeBackButton_Click(object sender, RoutedEventArgs e)
        {
            windowNavigator.OpenMenuWindow();
            this.Hide();
        }

        private void Refresh(object sender, EventArgs e)
        {
            attendees = attendeeService.RetrieveAllAttendees();
            totalAttendees.Content = attendees.Count.ToString();
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            AttendeesList.ItemsSource = attendees;
            

        }

        private void sortNamesButton_Click(object sender, RoutedEventArgs e)
        {

            //AttendeesList.ItemsSource = sort.SortByEntranceId(attendees);

            //AttendeesList.ItemsSource = sort.SortByCampName(attendees);

            AttendeesList.ItemsSource = sort.SortByFirstName(attendees,0,attendees.Count-1);
        }
    }
}
