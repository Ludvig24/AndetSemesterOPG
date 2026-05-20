using AndetSemesterOPG.Applications;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal class Attendee
    {
        public int AttendeeID { get; set; }
        public string AttendeeFirstName { get; set; }
        public string AttendeeLastName { get; set; }

        //public ITicket TicketType { get; set; }

        public string CampName { get; set; }
        public int EntranceId { get; set; }


        //måske ekstra constructor der også tager attendeeID så når vi trækker dataet op bliver Attendee oprettet med deres id fra DB
        public Attendee(string AttendeeFirstName, string AttendeeLastName, string CampName, int EntranceId)
        {
            this.AttendeeFirstName = AttendeeFirstName;
            this.AttendeeLastName = AttendeeLastName;
            this.CampName = CampName;
            this.EntranceId = EntranceId;

        }
    }
}
