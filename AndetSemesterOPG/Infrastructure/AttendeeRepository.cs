using AndetSemesterOPG.Domain;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Infrastructure
{
    internal class AttendeeRepository : IAttendeeRepository
    {
        IDBConnection connection;
        public AttendeeRepository(IDBConnection connection)
        {
            this.connection = connection;
        }

        public void AddAttendee(Attendee attendee)
        {
            //Thread t = new Thread(() => connection.Insert(attendee));
            //t.Start();

            connection.Insert(attendee);
            //save to database på en eller anden måde
        }

        public List<Attendee> GetAllAttendees() 
        {
            //List<Attendee> attendees = new List<Attendee>();
            //Thread t = new Thread(() => attendees = connection.ReadAll());

            //t.Start();

            List<Attendee> attendees = connection.ReadAll();
            return attendees;
        }

        public List<Attendee> GetAttendeesByEntranceId(int id)
        {
            List<Attendee> attendeesByEntranceId = connection.FindByEntranceId(id);
            return attendeesByEntranceId;
        }

        public List<Attendee> GetAttendeesByCampName(string campName)
        {
            List<Attendee> attendeesByCampName = connection.FindByCampName(campName);
            return attendeesByCampName;
        }

    }
}
