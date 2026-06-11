using AndetSemesterOPG.Domain;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Infrastructure
{
    //Klasse der implementerer IAttendeeRepository og bruger IDBConnection til at hente data om attendees fra databasen
    internal class AttendeeRepository : IAttendeeRepository // Ludvig
    {
        //IDBConnection bruges til at hente data om attendees fra databasen
        IDBConnection connection;

        //Konstruktor der tager en IDBConnection som parameter og gemmer den i en instansvariabel
        public AttendeeRepository(IDBConnection connection)
        {
            this.connection = connection;
        }

        //Metode der bruger IDBConnection til at tilføje en attendee til databasen
        public void AddAttendee(Attendee attendee)
        {
            
            connection.Insert(attendee);
            
        }

        //Metode der bruger IDBConnection til at hente alle attendees fra databasen og returnere dem som en liste
        public List<Attendee> GetAllAttendees() 
        {
            List<Attendee> attendees = connection.ReadAll();
            return attendees;
        }

        //Metode der bruger IDBConnection til at nulstille antallet af attendees i databasen til 104
        public void ResetAttendeeCount()
        {
            connection.ResetAttendeeAmount();
        }

        //Metode der bruger IDBConnection til at hente en liste over attendees baseret på en given entranceId og returnere dem som en liste
        public List<Attendee> GetAttendeesByEntranceId(int id)
        {
            List<Attendee> attendeesByEntranceId = connection.FindByEntranceId(id);
            return attendeesByEntranceId;
        }

        //Metode der bruger IDBConnection til at hente en liste over attendees baseret på en given campName og returnere dem som en liste
        public List<Attendee> GetAttendeesByCampName(string campName)
        {
            List<Attendee> attendeesByCampName = connection.FindByCampName(campName);
            return attendeesByCampName;
        }

    }
}
