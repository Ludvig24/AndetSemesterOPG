using AndetSemesterOPG.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Infrastructure
{
    internal class DBConnection
    {
        //string connectionString = "Server=localhost\\SQLEXPRESS; Database=AndetSemester;Trusted_Connection=True;TrustServerCertificate=True";
        // her oprettes en SqlConnection objekt ved hjælp af connectionString, som vil blive brugt til at åbne en forbindelse til databasen
          


        //Create
        public void Insert(Attendee attendee)
        {
            using (SqlConnection dataBase = new SqlConnection("Server=localhost; Database=AndetSemester;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                dataBase.Open();
                SqlCommand command = new SqlCommand("INSERT INTO ATTENDEE(FirstName, LastName, CampName, EntranceId) VALUES (@FirstName, @LastName, @CampName, @EntranceId)", dataBase);
                command.Parameters.AddWithValue("@FirstName", attendee.AttendeeFirstName);
                command.Parameters.AddWithValue("@LastName", attendee.AttendeeLastName);
                command.Parameters.AddWithValue("@CampName", attendee.TicketType.DetermineCampName());
                command.Parameters.AddWithValue("@EntranceId", attendee.TicketType.DetermineEntranceType());
                command.ExecuteNonQuery();

            }

        }

        //Update
        public void Update(Attendee attendee)
        {

        }

        //Delete
        public void Delete(Attendee attendee)
        {

        }



        //READ
        public void FindByID(int id)
        {

        }

        public void ReadAll()
        {

        }
    }
}
