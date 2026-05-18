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
using Microsoft.Data.SqlClient;

namespace AndetSemesterOPG
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
                InitializeComponent();
            //Her er connectionstring til databasen, den skal bruges til at åbne en forbindelse til databasen
            string connectionString = "Server=localhost\\SQLEXPRESS; Database=AndetSemester;Trusted_Connection=True;TrustServerCertificate=True";
            // her oprettes en SqlConnection objekt ved hjælp af connectionString, som vil blive brugt til at åbne en forbindelse til databasen
            SqlConnection dataBase = new SqlConnection(connectionString);

            // Her åbnes forbindelsen og den vil automatisk lukke forbindelsen da der bruges using
            using (dataBase)
            {
                dataBase.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Attendee", dataBase);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                { 
                string Name = reader.GetString(reader.GetOrdinal("FirstName"));
                EksempelNavn.Content = Name;
                }
            }
        }
    }
}