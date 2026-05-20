using AndetSemesterOPG.Applications;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal class Attendee
    {
        public string AttendeeFirstName { get; set; }
        public string AttendeeLastName { get; set; }

        public ITicket TicketType { get; set; }
        public int AttendeeID { get; set; }

        public Attendee(string AttendeeFirstName, string AttendeeLastName, ITicket ticketType) 
        {
            this.AttendeeFirstName = AttendeeFirstName;
            this.AttendeeLastName = AttendeeLastName;
            this.TicketType = ticketType;
           
        }
    }
}
