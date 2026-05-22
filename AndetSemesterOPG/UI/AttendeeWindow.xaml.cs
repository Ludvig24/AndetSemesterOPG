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
        AttendeeService attendeeService = new AttendeeService(new AttendeeRepository(new DBConnection()), new AttendeeTestData(), new TicketClient());
        List<Attendee> attendees = new List<Attendee>();
        MainWindow mainWindow;
        
        public AttendeeWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            attendees = attendeeService.RetrieveAllAttendees();
            AttendeesList.ItemsSource = attendees;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Refresh);
            timer.Interval = new TimeSpan(0,0,1);
            timer.Start();
            

        }

        private void AttendeeBackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
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
    }
}
