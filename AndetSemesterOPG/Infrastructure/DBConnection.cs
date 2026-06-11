using AndetSemesterOPG.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;

namespace AndetSemesterOPG.Infrastructure
{
    //Alle har været med over denne klasse
    internal class DBConnection : IDBConnection //Implementerer IDBConnection interface - medfører vi nemt kan skifte til en anden type database
    {
        //Her oprettes en SqlConnection objekt ved hjælp af connectionString, som vil blive brugt til at åbne en forbindelse til databasen
          string connectionString = "Server=localhost\\SQLEXPRESS; Database=AndetSemester;Trusted_Connection=True;TrustServerCertificate=True";
        //Ludvig: LOCALHOST
        //Tobias: localhost\\SQLEXPRESS
        //Laura: LAPTOP-KHAURJ1B
        //Emil: localhost\\SQLEXPRESS02

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

        //Insert metode, der indsætter Artist i databasen
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

        //Update metode, der opdaterer en Artist i databasen
        public void UpdateArtist(Artist artist)
        {
            //Opretter forbindelsen til databasen
            using (SqlConnection dataBase = new SqlConnection(connectionString)) 
            {
                //Åbner forbindelsen til databasen
                dataBase.Open();
                //Opretter et command objekt der indeholder den SQL query vi gerne vil sende til databasen
                //Querien opdaterer en artist i tabellen ARTIST i databasen ud fra et ArtistId
                SqlCommand command = new SqlCommand(@"UPDATE ARTIST SET ArtistName = @ArtistName, ArtistTime = @ArtistTime, ArtistDate = @ArtistDate, StageId = @StageId WHERE ArtistId = @ArtistId", dataBase);

                //Tilføjer værdierne gemt i Artist objektet til vores SQLCommand objekt
                command.Parameters.AddWithValue("@ArtistName", artist.ArtistName);
                command.Parameters.AddWithValue("ArtistTime", artist.ArtistTime);
                command.Parameters.AddWithValue("ArtistDate", artist.ArtistDate);
                command.Parameters.AddWithValue("StageId", artist.StageId);
                command.Parameters.AddWithValue("ArtistId", artist.ArtistId);
                //Eksekverer kommandoen
                command.ExecuteNonQuery();
            }
        }

        //Delete metode, der fjerner en Artist fra databasen
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

        //ResetAttendeeAmount metode, der fjerner alle Attendees med id større end 104 fra databasen
        public void ResetAttendeeAmount()
        {
            using (SqlConnection dataBase = new SqlConnection(connectionString))
            {
                //Åbner forbindelsen til databasen
                dataBase.Open();
                //Opretter et command objekt der indeholder den SQL query vi gerne vil sende til databasen
                //Querien fjerner alle Attendees med id større end 104
                //Vi fjerner fra id 105 og opefter, da de den første attendee starter med id 4 og så tæller den op ad. Det gør at når vi kalder metoden så har vi 100 attendees
                SqlCommand command = new SqlCommand("DELETE FROM Attendee WHERE AttendeeId > 104", dataBase);
                //Kører commanden
                command.ExecuteNonQuery();
            }
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
                        attendee.AttendeeID = attendeeId;
    
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
                //Tilføjer parameteret
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
                    attendee.AttendeeID = attendeeId;

                    attendeesByCampName.Add(attendee);


                }
                return attendeesByCampName;
            }
        }


        //ReadAll metode, som henter alle Attendees i databasen
        public List<Attendee> ReadAll()
        {
            //Opretter en liste af Attendees der skal udfyldes med alle Attendees i databasen
            List<Attendee> allAttendeesList = new List<Attendee>();

            //Opretter forbindelse til databasen
            using (SqlConnection dataBase = new SqlConnection(connectionString))
            {
                dataBase.Open();

                //SqlCommand objekt med query der henter alle attendees fra ATTENDEE tabellen
                SqlCommand command = new SqlCommand("SELECT * FROM Attendee", dataBase);
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
                    attendee.AttendeeID = attendeeId;

                    //Attendee objekt tilføjes til listen
                    allAttendeesList.Add(attendee);

                }
                return allAttendeesList;
            }
        }

        //FindCampCapacity metode, som finder kapaciteten for en camp
        public int FindCampCapacity(string campName)
        {
            //Opretter en variabel der skal gemme kapaciteten for campen
            int capacity = 0;

            //Opretter forbindelse til databasen
            using (SqlConnection database = new SqlConnection(connectionString))
            {
                database.Open();
                //SqlCommand objekt med query der henter CampCapacity fra Camp tabellen
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

        //ReadAllCamps metode, som henter alle camps i databasen
        public List<Camp> ReadAllCamps()
        {
            //Opretter en liste af Camps der skal udfyldes med alle Camps i databasen
            List<Camp> allCampsList = new List<Camp>();

            //Opretter forbindelse til databasen
            using (SqlConnection dataBase = new SqlConnection(connectionString))
            {
                dataBase.Open();

                //SqlCommand objekt med query der henter alle camps fra Camp tabellen
                SqlCommand command = new SqlCommand("SELECT * FROM Camp", dataBase);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int CampId = reader.GetInt32(reader.GetOrdinal("CampId"));
                    string CampName = reader.GetString(reader.GetOrdinal("CampName"));
                    int CampCapacity = reader.GetInt32(reader.GetOrdinal("CampCapacity"));
                    Camp camp = new Camp(CampId, CampCapacity, CampName);

                    //Camp objekt tilføjes til listen
                    allCampsList.Add(camp);
                }
                return allCampsList;
            }
        }

        //ReadAllArtist metode, som henter alle artists i databasen
        public List<Artist> ReadAllArtist() 
        {
            //Opretter en liste af Artists der skal udfyldes med alle Artists i databasen
            List<Artist> allArtistsList = new List<Artist>();

            //Opretter forbindelse til databasen
            using (SqlConnection dataBase = new SqlConnection(connectionString))
            {
                dataBase.Open();

                //SqlCommand objekt med query der henter alle artists fra Artist tabellen
                SqlCommand command = new SqlCommand("SELECT * FROM Artist", dataBase);
                SqlDataReader reader = command.ExecuteReader();

                //Vi læser hver række der bliver returneret med reader objektet og gemmer hver oplysning i variabler der bruges til at oprette en artist
                while (reader.Read())
                {
                    int ArtistId = reader.GetInt32(reader.GetOrdinal("ArtistId"));
                    string ArtistName = reader.GetString(reader.GetOrdinal("ArtistName"));
                    string ArtistTime = reader.GetString(reader.GetOrdinal("ArtistTime"));
                    string ArtistDate = reader.GetString(reader.GetOrdinal("ArtistDate"));
                    int StageId = reader.GetInt32(reader.GetOrdinal("StageId"));

                    //Artist objekt oprettes
                    Artist artist = new Artist(ArtistName, ArtistTime, ArtistDate, StageId);
                    artist.ArtistId = ArtistId;

                    //Artist objekt tilføjes til listen
                    allArtistsList.Add(artist);

                }
                return allArtistsList;
            }


        }

    }


}
