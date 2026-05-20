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

namespace AndetSemesterOPG.UI
{
    /// <summary>
    /// Interaction logic for AttendeeWindow.xaml
    /// </summary>
    public partial class AttendeeWindow : Window
    {
        MainWindow mainWindow = new MainWindow();
        AttendeeService attendeeService = new AttendeeService(new AttendeeRepository(new DBConnection()), new AttendeeTestData(), new TicketClient());
        List<Attendee> attendees;
        public AttendeeWindow()
        {
            InitializeComponent();
            attendees = attendeeService.RetrieveAllAttendees();
            AttendeesList.ItemsSource = attendees;
            totalAttendees.Content =attendees.Count.ToString();
        }

        private void AttendeeBackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }

      
    }
}
