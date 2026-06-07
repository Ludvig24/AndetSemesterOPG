using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface IAttendeeService
    {
        ITicketClient ticketClient { get; }
        public Attendee CreateAttendee();

        public List<Attendee> RetrieveAllAttendees();

        List<Attendee> RetrieveAttendeesByEntranceId(int id);

        List<Attendee> RetriveAttendeesByCampName(string campName);

        void ResetAttendee();


    }
}
