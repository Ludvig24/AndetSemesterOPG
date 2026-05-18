using AndetSemesterOPG.Applications;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal class Attendee
    {
        string attendeeFirstName { get; set; }
        string attendeeLastName { get; set; }

        ITicket ticketType { get; set; }
        int attendeeID { get; set; }

        TicketClient ticketClient { get; set; }

        Attendee() 
        {

        }
    }
}
