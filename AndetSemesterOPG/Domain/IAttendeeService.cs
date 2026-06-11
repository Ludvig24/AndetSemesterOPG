using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface IAttendeeService // Tobias
    {
        ITicketClient ticketClient { get; }
        // Metode der opretter en attendee, og returnerer den oprettede attendee
        public Attendee CreateAttendee();
        // moetode der henter alle attendees og returnerer dem i en liste
        public List<Attendee> RetrieveAllAttendees();
        // metode der henter en attendee ud fra id, og returnerer dem i en liste
        List<Attendee> RetrieveAttendeesByEntranceId(int id);
        // metode der henter en attendee ud fra camp name, og returnerer dem i en liste
        List<Attendee> RetriveAttendeesByCampName(string campName);
        // metode der skal nulstille antallet af attendees i databasen
        void ResetAttendee();


    }
}
