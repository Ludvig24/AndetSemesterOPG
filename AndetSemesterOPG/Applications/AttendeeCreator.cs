using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    internal class AttendeeCreator
    {
        AttendeeTestData attendeeTestData; //Vil et interface være bedre kodeskik? 
        TicketClient ticketClient;
        IAttendeeRepository attendeeRepository;

        public AttendeeCreator(IAttendeeRepository attendeeRepository, AttendeeTestData attendeeTestData, TicketClient ticketClient)
        {
            this.attendeeRepository = attendeeRepository;
            this.attendeeTestData = attendeeTestData;
            this.ticketClient = ticketClient;
        }

        public Attendee CreateAttendee()
        {
            List<string> attendeeNames = attendeeTestData.NameCombiner();
            string firstName = attendeeNames[0];
            string lastName = attendeeNames[1];

            ITicket ticket = ticketClient.CreateTicket();
            Attendee attendee = new Attendee(firstName, lastName, ticket.DetermineCampName(), ticket.DetermineEntranceType());
            attendeeRepository.AddAttendee(attendee);
            return attendee;
        }

        

    }
}
