using AndetSemesterOPG.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;

namespace AndetSemesterOPG.Infrastructure
{
    internal class DBConnection : IDBConnection //implementerer IDBConnection interface - medfører vi nemt kan skifte til en anden type database
    {
        //string connectionString = "Server=localhost\\SQLEXPRESS; Database=AndetSemester;Trusted_Connection=True;TrustServerCertificate=True";
        // her oprettes en SqlConnection objekt ved hjælp af connectionString, som vil blive brugt til at åbne en forbindelse til databasen
          string connectionString = "Server=localhost\\SQLEXPRESS; Database=AndetSemester;Trusted_Connection=True;TrustServerCertificate=True";
        //Vi har ikke alle den sammen connectionstring
        //Ludvig: LOCALHOST
        //Tobias:
        //Laura: LAPTOP-KHAURJ1B
        //Emil:

        //Insert metode, der indsætter Attendee i databasen
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

        public void InsertArtist(Artist artist)
        {
            using (SqlConnection dataBase = new SqlConnection(connectionString))
            {
                dataBase.Open();
                SqlCommand command = new SqlCommand("INSERT INTO ARTIST(ArtistName, ArtistTime, ArtistDate, StageId) VALUES (@ArtistName, @ArtistTime, @ArtistDate, @StageId)", dataBase);
                command.Parameters.AddWithValue("@ArtistName", artist.ArtistName);
                command.Parameters.AddWithValue("ArtistTime", artist.ArtistTime);
                command.Parameters.AddWithValue("ArtistDate", artist.ArtistDate);
                command.Parameters.AddWithValue("StageId", artist.StageId);
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

        public void RemoveArtist (Artist artist)
        {
            using(SqlConnection dataBase = new SqlConnection(connectionString))
            {
                dataBase.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Artist WHERE ArtistName = @ArtistName", dataBase);
                command.Parameters.AddWithValue("@ArtistName", artist.ArtistName);
                command.ExecuteNonQuery();
            }
        }



        //READ
        public void FindByID(int id)
        {

        }

        //FindByEntranceId metode, som finder Attendees Entrance id i databbasen
        public List<Attendee> FindByEntranceId(int id)
        {
            List<Attendee> attendeesByEntranceId = new List<Attendee>();
                using (SqlConnection dataBase = new SqlConnection(connectionString))
                {
                    dataBase.Open();
                    
                    SqlCommand command = new SqlCommand("SELECT * FROM Attendee WHERE EntranceId = @EntranceId", dataBase);
                    command.Parameters.AddWithValue("@EntranceId", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int attendeeId = reader.GetInt32(reader.GetOrdinal("AttendeeId"));
                        string FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        string LastName = reader.GetString(reader.GetOrdinal("LastName"));
                        string CampName = reader.GetString(reader.GetOrdinal("CampName"));
                        int EntranceId = reader.GetInt32(reader.GetOrdinal("EntranceId"));
    
                        Attendee attendee = new Attendee(FirstName, LastName, CampName, EntranceId);
                        attendee.AttendeeID = attendeeId; //måske fix ift constructor
    
                        attendeesByEntranceId.Add(attendee);
    

                    }
                return attendeesByEntranceId;
            }
        }

        //FindByCampName metode, som finder Attendees CampName i databasen
        public List<Attendee> FindByCampName(string campName)
        {
            List<Attendee> attendeesByCampName = new List<Attendee>();
            using (SqlConnection dataBase = new SqlConnection(connectionString))
            {
                dataBase.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Attendee WHERE CampName = @CampName", dataBase);
                command.Parameters.AddWithValue("@CampName", campName);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int attendeeId = reader.GetInt32(reader.GetOrdinal("AttendeeId"));
                    string FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    string LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    string CampName = reader.GetString(reader.GetOrdinal("CampName"));
                    int EntranceId = reader.GetInt32(reader.GetOrdinal("EntranceId"));

                    Attendee attendee = new Attendee(FirstName, LastName, CampName, EntranceId);
                    attendee.AttendeeID = attendeeId; //måske fix ift constructor

                    attendeesByCampName.Add(attendee);


                }
                return attendeesByCampName;
            }
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
                    int attendeeId = reader.GetInt32(reader.GetOrdinal("AttendeeId"));
                    string FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    string LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    string CampName = reader.GetString(reader.GetOrdinal("CampName"));
                    int EntranceId = reader.GetInt32(reader.GetOrdinal("EntranceId"));

                    Attendee attendee = new Attendee(FirstName, LastName, CampName, EntranceId);
                    attendee.AttendeeID = attendeeId; //måske fix ift constructor

                    allAttendeesList.Add(attendee);

                }
                return allAttendeesList;
            }
        }


        public int FindCampCapacity(string campName)
        {
            int capacity = 0;

            using (SqlConnection database = new SqlConnection(connectionString))
            {
                database.Open();
                SqlCommand command = new SqlCommand("SELECT CampCapacity FROM Camp WHERE CampName = @CampName", database);
                command.Parameters.AddWithValue("@CampName", campName);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    capacity = reader.GetInt32(reader.GetOrdinal("CampCapacity"));
                }

                return capacity;
            }
        }

        public List<Artist> ReadAllArtist() 
        {
            List<Artist> allArtistsList = new List<Artist>();

            using (SqlConnection dataBase = new SqlConnection(connectionString))
            {
                dataBase.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Artist", dataBase);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string ArtistName = reader.GetString(reader.GetOrdinal("ArtistName"));
                    string ArtistTime = reader.GetString(reader.GetOrdinal("ArtistTime"));
                    string ArtistDate = reader.GetString(reader.GetOrdinal("ArtistDate"));
                    int StageId = reader.GetInt32(reader.GetOrdinal("StageId"));

                    Artist artist = new Artist(ArtistName, ArtistTime, ArtistDate, StageId);

                    allArtistsList.Add(artist);

                }
                return allArtistsList;
            }


        }

    }


}
