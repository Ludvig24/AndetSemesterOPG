using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    //Interface der definerer et repository som skal håndtere alle interaktioner med databasen vedrørende attendees, og indeholder metoderne dertil
    internal interface IAttendeeRepository //Tobias
    {
        //Metode der tilføjer en attendee til databasen
        void AddAttendee(Attendee attendee);

        //Metode der henter alle attendees fra databasen
        List<Attendee> GetAllAttendees();

        //Metode der henter alle attendees fra databasen baseret på en given entranceId
        List<Attendee> GetAttendeesByEntranceId(int id);

        //Metode der henter alle attendees fra databasen baseret på en given campName
        List<Attendee> GetAttendeesByCampName(string campName);

        //Metode der nulstiller antallet af attendees i databasen til 104 for overskuelighed og lettere testning
        void ResetAttendeeCount();

    }
}
