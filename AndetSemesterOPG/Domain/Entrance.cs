using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    //Klasse der repræsentere en indgang til festivalen, og indeholder information om indgangen og de deltagere der har benyttet den
    internal class Entrance
    {
        //Variabler der giver betydning til klassen
        int entranceID;
        string entranceName;
        List<Attendee> entranceAttendees;
        int entranceCounter;

        //Konstruktor der tager en entranceID og entranceName som parameter og gemmer dem i instansvariabler
        Entrance(int entranceID, string entranceName)
        {
            this.entranceID = entranceID;
            this.entranceName = entranceName;
            this.entranceAttendees = new List<Attendee>();
            this.entranceCounter = 0;
        }

    }
}
