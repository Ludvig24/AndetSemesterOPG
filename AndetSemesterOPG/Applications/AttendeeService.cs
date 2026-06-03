using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    internal class AttendeeService
    {
        AttendeeTestData attendeeTestData; //Vil et interface være bedre kodeskik? 
        public TicketClient ticketClient { get; set; }
        IAttendeeRepository attendeeRepository;

        public AttendeeService(IAttendeeRepository attendeeRepository, AttendeeTestData attendeeTestData, TicketClient ticketClient)
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

            if(ticket == null)
            {
                return null;
            }

            Attendee attendee = new Attendee(firstName, lastName, ticket.DetermineCampName(), ticket.DetermineEntranceType());
            attendeeRepository.AddAttendee(attendee);
            return attendee;
        }

        public List<Attendee> RetrieveAllAttendees()
        {
            List<Attendee> attendeesList = attendeeRepository.GetAllAttendees();
            return attendeesList;
        }
        public List<Attendee> RetrieveAttendeesByEntranceId(int id)
        {
            List<Attendee> attendeesByEntranceId = attendeeRepository.GetAttendeesByEntranceId(id);
            return attendeesByEntranceId;
        }

        public List<Attendee> RetriveAttendeesByCampName(string campName)
        {
            List<Attendee> attendeesByCampName = attendeeRepository.GetAttendeesByCampName(campName);
            return attendeesByCampName;
        }

        public void ResetAttendee()
        {
            attendeeRepository.ResetAttendeeCount();
        }

    }
}
