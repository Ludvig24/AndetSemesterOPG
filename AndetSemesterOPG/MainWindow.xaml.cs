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

namespace AndetSemesterOPG
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
                InitializeComponent();
            //Her er connectionstring til databasen, den skal bruges til at åbne en forbindelse til databasen
            //string connectionString = "Server=localhost\\SQLEXPRESS; Database=AndetSemester;Trusted_Connection=True;TrustServerCertificate=True";
            // her oprettes en SqlConnection objekt ved hjælp af connectionString, som vil blive brugt til at åbne en forbindelse til databasen
            //SqlConnection dataBase = new SqlConnection(connectionString);



            //TEST FACTORY
            TicketClient tClient = new TicketClient();
            EntranceEastFactory en = new EntranceEastFactory();
            ITicket a = tClient.OrderTicketCampA(en);
            camp.Content = a.DetermineCampName();
            entrance.Content = a.DetermineEntranceType();

            //ReadAll
            DBConnection dbConnection = new DBConnection();
            

            List<Attendee> allAttendees = dbConnection.ReadAll();

            //Test Create and ADD to database

            //Her Laver vi kun en attendee og tilføjer den til databasen
            //AttendeeService attendeeCreator = new AttendeeService(new AttendeeRepository(new DBConnection()), new AttendeeTestData(), new TicketClient());
            //Attendee attendee = attendeeCreator.CreateAttendee();

            //Attendee attendese = attendeeCreator.CreateAttendee();
            //for (int i = 0; i < 10; i++)
            //{
            //    Attendee attendees = attendeeCreator.CreateAttendee();
            //}

            // Her åbnes forbindelsen og den vil automatisk lukke forbindelsen da der bruges using
            /*using (dataBase)
            {
                dataBase.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Attendee", dataBase);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string Name = reader.GetString(reader.GetOrdinal("FirstName"));
                    EksempelNavn.Content = Name;


                }
            }*/
        }

        private void AttendeeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            AttendeeWindow attendeeWindow = new AttendeeWindow(this);
            attendeeWindow.Show();
            this.Hide();
        }
    }
}