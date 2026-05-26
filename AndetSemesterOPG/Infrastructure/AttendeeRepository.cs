using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Infrastructure
{
    internal class AttendeeRepository : IAttendeeRepository
    {
        DBConnection connection;
        public AttendeeRepository(DBConnection connection)
        {
            this.connection = connection;
        }

        public void AddAttendee(Attendee attendee)
        {
            connection.Insert(attendee);
            //save to database på en eller anden måde
        }

        public List<Attendee> GetAllAttendees() 
        {
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
