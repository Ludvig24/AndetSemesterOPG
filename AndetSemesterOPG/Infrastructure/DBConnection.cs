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
        //Tobias: localhost\\SQLEXPRESS
        //Laura: LAPTOP-KHAURJ1B
        //Emil:

        // -------- CREATE ------------
        //Insert metode, der indsætter Attendee i databasen
        public void Insert(Attendee attendee)
        {
            //Opretter forbindelsen til databasen. Vi bruger en using block så forbindelsen automatisk lukkes ved slutningen af using blokken
            using (SqlConnection dataBase = new SqlConnection(connectionString))
            {
                //Åbner forbindelsen til databasen
                dataBase.Open();

                //Opretter et command objekt der indeholder den SQL query vi gerne vil sende til databasen
                //Querien gemmer en attendee i tabellen ATTENDEE i databasen.
                SqlCommand command = new SqlCommand("INSERT INTO ATTENDEE(FirstName, LastName, CampName, EntranceId) VALUES (@FirstName, @LastName, @CampName, @EntranceId)", dataBase);
                //Tilføjer værdierne gemt i Attendee objektet til vores SQLCommand objekt
                command.Parameters.AddWithValue("@FirstName", attendee.AttendeeFirstName);
                command.Parameters.AddWithValue("@LastName", attendee.AttendeeLastName);
                command.Parameters.AddWithValue("@CampName", attendee.CampName);
                command.Parameters.AddWithValue("@EntranceId", attendee.EntranceId);
                //Eksekverer kommandoen
                command.ExecuteNonQuery();
            }
        }

        public void InsertArtist(Artist artist)
        {
            //Opretter forbindelsen til databasen. Vi bruger en using block så forbindelsen automatisk lukkes ved slutningen af using blokken
            using (SqlConnection dataBase = new SqlConnection(connectionString))
            {
                //Åbner forbindelsen til databasen
                dataBase.Open();
                //Opretter et command objekt der indeholder den SQL query vi gerne vil sende til databasen
                //Querien gemmer en artist i tabellen ARTIST i databasen
                SqlCommand command = new SqlCommand("INSERT INTO ARTIST(ArtistName, ArtistTime, ArtistDate, StageId) VALUES (@ArtistName, @ArtistTime, @ArtistDate, @StageId)", dataBase);
                //Tilføjer værdierne gemt i Artist objektet til vores SQLCommand objekt
                command.Parameters.AddWithValue("@ArtistName", artist.ArtistName);
                command.Parameters.AddWithValue("ArtistTime", artist.ArtistTime);
                command.Parameters.AddWithValue("ArtistDate", artist.ArtistDate);
                command.Parameters.AddWithValue("StageId", artist.StageId);
                //Eksekverer kommandoen
                command.ExecuteNonQuery();
            }
        }

        //Update
        public void UpdateArtist(Artist artist)
        {
            using (SqlConnection dataBase = new SqlConnection(connectionString)) 
            {
                dataBase.Open();
                SqlCommand command = new SqlCommand(
    @"UPDATE ARTIST
      SET ArtistName = @ArtistName,
          ArtistTime = @ArtistTime,
          ArtistDate = @ArtistDate,
          StageId = @StageId
      WHERE ArtistId = @ArtistId",
    dataBase);

                //Tilføjer værdierne gemt i Artist objektet til vores SQLCommand objekt
                command.Parameters.AddWithValue("@ArtistName", artist.ArtistName);
               // command.Parameters.AddWithValue("@OldArtistName", oldArtistName);
                command.Parameters.AddWithValue("ArtistTime", artist.ArtistTime);
                command.Parameters.AddWithValue("ArtistDate", artist.ArtistDate);
                command.Parameters.AddWithValue("StageId", artist.StageId);
                //Eksekverer kommandoen
                command.ExecuteNonQuery();
            }
        }

        //Delete
       

        public void RemoveArtist (Artist artist)
        {
            //Opretter forbindelsen til databasen. Vi bruger en using block så forbindelsen automatisk lukkes ved slutningen af using blokken
            using (SqlConnection dataBase = new SqlConnection(connectionString))
            {
                //Åbner forbindelsen til databasen
                dataBase.Open();
                //Opretter et command objekt der indeholder den SQL query vi gerne vil sende til databasen
                //Querien fjerner en artist i tabellen Artist fra databasen ud fra et ArtistName
                SqlCommand command = new SqlCommand("DELETE FROM Artist WHERE ArtistId = @ArtistId", dataBase);
                //Tilføjer værdien ArtistName fra Artist objektet til vores SQLCommand objekt
                command.Parameters.AddWithValue("@ArtistId", artist.ArtistId);
                //Kører commanden
                command.ExecuteNonQuery();
            }
        }



        //READ
        public void FindByID(int id)
        {

        }

        //FindByEntranceId metode, som finder alle Attendees med et bestemt EntranceId i databbasen
        public List<Attendee> FindByEntranceId(int id)
        {
            //Opretter liste af attendees der skal udfyldes med Attendees hvis EntranceId svarer til id
            List<Attendee> attendeesByEntranceId = new List<Attendee>();
                //Opretter forbindelsen til databasen.
                using (SqlConnection dataBase = new SqlConnection(connectionString))
                {
                    dataBase.Open();

                    //Opretter SqlCommand. Querien henter alle Attendees hvis EntranceId property er lig parameteren EntranceId
                    SqlCommand command = new SqlCommand("SELECT * FROM Attendee WHERE EntranceId = @EntranceId", dataBase);
                    //Tilføjer parameteren EntranceId med værdien id
                    command.Parameters.AddWithValue("@EntranceId", id);
                    //Sender vores Sql query til databasen og der returneres en SqlDataReader
                    SqlDataReader reader = command.ExecuteReader();
                    //Vi læser hver række der bliver returneret med reader objektet og gemmer hver oplysning i variabler der bruges til at oprette en attendee
                    while (reader.Read())
                    {
                        int attendeeId = reader.GetInt32(reader.GetOrdinal("AttendeeId"));
                        string FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        string LastName = reader.GetString(reader.GetOrdinal("LastName"));
                        string CampName = reader.GetString(reader.GetOrdinal("CampName"));
                        int EntranceId = reader.GetInt32(reader.GetOrdinal("EntranceId"));
                        
                        //Attendee objekt oprettes
                        Attendee attendee = new Attendee(FirstName, LastName, CampName, EntranceId);
                        attendee.AttendeeID = attendeeId; //måske fix ift constructor
    
                        //Attendee objekt tilføjes til listen
                        attendeesByEntranceId.Add(attendee);
    

                    }
                    //Listen af Attendees returneres
                return attendeesByEntranceId;
            }
        }

        //FindByCampName metode, som finder alle Attendees med et bestemt CampName i databasen
        public List<Attendee> FindByCampName(string campName)
        {
            List<Attendee> attendeesByCampName = new List<Attendee>();
            //Opretter forbindelse til databasen
            using (SqlConnection dataBase = new SqlConnection(connectionString))
            {
                dataBase.Open();
                //SqlCommand objekt med query der henter alle attendees fra ATTENDEE tabellen hvor CampName er lig CampName i metodens parameter
                SqlCommand command = new SqlCommand("SELECT * FROM Attendee WHERE CampName = @CampName", dataBase);
                //
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

        public List<Camp> ReadAllCamps()
        {
            List<Camp> allCampsList = new List<Camp>();
            using (SqlConnection dataBase = new SqlConnection(connectionString))
            {
                dataBase.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Camp", dataBase);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int CampId = reader.GetInt32(reader.GetOrdinal("CampId"));
                    string CampName = reader.GetString(reader.GetOrdinal("CampName"));
                    int CampCapacity = reader.GetInt32(reader.GetOrdinal("CampCapacity"));
                    Camp camp = new Camp(CampId, CampCapacity, CampName);
                    allCampsList.Add(camp);
                }
                return allCampsList;
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
                    int ArtistId = reader.GetInt32(reader.GetOrdinal("ArtistId"));
                    string ArtistName = reader.GetString(reader.GetOrdinal("ArtistName"));
                    string ArtistTime = reader.GetString(reader.GetOrdinal("ArtistTime"));
                    string ArtistDate = reader.GetString(reader.GetOrdinal("ArtistDate"));
                    int StageId = reader.GetInt32(reader.GetOrdinal("StageId"));

                    Artist artist = new Artist(ArtistName, ArtistTime, ArtistDate, StageId);
                    artist.ArtistId = ArtistId;

                    allArtistsList.Add(artist);

                }
                return allArtistsList;
            }


        }

    }


}
