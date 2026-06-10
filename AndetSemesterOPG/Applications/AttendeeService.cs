using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    //Klasse som indeholder metoder der håndtere deltagere
    internal class AttendeeService : IAttendeeService // Tobias
    {
        //Variabler som skal bruges i klassen
        AttendeeTestData attendeeTestData; 
        public ITicketClient ticketClient { get; set; }
        IAttendeeRepository attendeeRepository;

        //Konstruktor der tager en IAttendeeRepository, AttendeeTestData og TicketClient som parametre og gemmer dem i instansvariabler
        public AttendeeService(IAttendeeRepository attendeeRepository, AttendeeTestData attendeeTestData, ITicketClient ticketClient)
        {
            this.attendeeRepository = attendeeRepository;
            this.attendeeTestData = attendeeTestData;
            this.ticketClient = ticketClient;
        }

        //Metode der opretter en ny deltager ved at kombinere et fornavn og efternavn fra AttendeeTestData, og derefter oprette en billet ved hjælp af TicketClient. Hvis billetten er gyldig, oprettes en ny Attendee med de relevante oplysninger og gemmes i databasen
        public Attendee CreateAttendee()
        {
            //Definere den nye deltagers variabler
            List<string> attendeeNames = attendeeTestData.NameCombiner();
            string firstName = attendeeNames[0];
            string lastName = attendeeNames[1];

            //Opret billet til deltageren
            ITicket ticket = ticketClient.CreateTicket();

            if(ticket == null)
            {
                return null;
            }

            //Opret en ny deltager med de relevante oplysninger og gemmer den i databasen
            Attendee attendee = new Attendee(firstName, lastName, ticket.DetermineCampName(), ticket.DetermineEntranceType());
            attendeeRepository.AddAttendee(attendee);
            return attendee;
        }

        //Metode der henter alle deltagere fra databasen og returnerer dem som en liste
        public List<Attendee> RetrieveAllAttendees()
        {
            List<Attendee> attendeesList = attendeeRepository.GetAllAttendees();
            return attendeesList;
        }

        //Metode der henter deltagere baseret på en given entranceId og returnerer dem som en liste
        public List<Attendee> RetrieveAttendeesByEntranceId(int id)
        {
            List<Attendee> attendeesByEntranceId = attendeeRepository.GetAttendeesByEntranceId(id);
            return attendeesByEntranceId;
        }

        //Metode der henter deltagere baseret på en given campName og returnerer dem som en liste
        public List<Attendee> RetriveAttendeesByCampName(string campName)
        {
            List<Attendee> attendeesByCampName = attendeeRepository.GetAttendeesByCampName(campName);
            return attendeesByCampName;
        }

        //Metode der nulstiller antallet af deltagere i databasen til 104 for overskuelighed og lettere testning
        public void ResetAttendee()
        {
            attendeeRepository.ResetAttendeeCount();
        }

    }
}
