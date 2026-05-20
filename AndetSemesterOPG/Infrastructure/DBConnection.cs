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
          string connectionString = "Server=localhost; Database=AndetSemester;Trusted_Connection=True;TrustServerCertificate=True";


        //Create
        public void Insert(Attendee attendee)
        {
            using (SqlConnection dataBase = new SqlConnection(connectionString))
            {
                dataBase.Open();
                SqlCommand command = new SqlCommand("INSERT INTO ATTENDEE(FirstName, LastName, CampName, EntranceId) VALUES (@FirstName, @LastName, @CampName, @EntranceId)", dataBase);
                command.Parameters.AddWithValue("@FirstName", attendee.AttendeeFirstName);
                command.Parameters.AddWithValue("@LastName", attendee.AttendeeLastName);
                command.Parameters.AddWithValue("@CampName", attendee.CampName);
                command.Parameters.AddWithValue("@EntranceId", attendee.EntranceId);
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

        public List<Attendee> ReadAll()
        {
                    List<Attendee> allAttendeesList = new List<Attendee>();

            using (SqlConnection dataBase = new SqlConnection(connectionString))
            {
                dataBase.Open();
                
                SqlCommand command = new SqlCommand("SELECT * FROM Attendee", dataBase);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) 
                {
                    string FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    string LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    string CampName = reader.GetString(reader.GetOrdinal("CampName"));
                    int EntranceId = reader.GetInt32(reader.GetOrdinal("EntranceId"));

                    Attendee attendee = new Attendee(FirstName, LastName, CampName, EntranceId);

                    allAttendeesList.Add(attendee);

                }
                return allAttendeesList;
            }
        }
    }
}
