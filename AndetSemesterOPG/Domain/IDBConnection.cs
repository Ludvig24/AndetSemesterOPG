using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    //Interface der definerer en databaseforbindelse, og indeholder metoderne dertil
    internal interface IDBConnection
    {
        //Metoder der tilføjer til databasen
        void Insert(Attendee attendee);
        void InsertArtist(Artist artist);

        //Metode der opdaterer en artist i databasen
        void UpdateArtist (Artist artist);
        
        //Metode der fjerner en artist fra databasen
        void RemoveArtist(Artist artist);

        //Metode der nulstiller antallet af attendees i databasen til 104 for overskuelighed og lettere testning
        void ResetAttendeeAmount();

        //Metode der henter alle camps fra databasen og returnerer dem som en liste
        List<Camp> ReadAllCamps();

        //Metode der henter alle attendees fra databasen baseret på en given entranceId og returnerer dem som en liste
        List<Attendee> FindByEntranceId(int id);

        //Metode der henter alle attendees fra databasen baseret på en given campName og returnerer dem som en liste
        List<Attendee> FindByCampName(string campName);

        //Metode der henter alle attendees fra databasen og returnerer dem som en liste
        List<Attendee> ReadAll();

        //Metode der henter kapaciteten for en given camp fra databasen og returnerer den som en int
        int FindCampCapacity(string campName);

        //Metode der henter alle artists fra databasen og returnerer dem som en liste
        List<Artist> ReadAllArtist();
    }
}
