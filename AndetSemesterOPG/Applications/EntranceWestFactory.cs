using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace AndetSemesterOPG.Applications
{
    //Factory klasse der implementere ITicketFactory, og indeholder metoder der opretter billetter til camp A og camp B for indgangen west
    internal class EntranceWestFactory : ITicketFactory // Laura
    {
        //Metode der opretter en billet til Camp A
        public ITicket CreateCampA()
        {
            EntranceWestCampA entranceWestCampA = new EntranceWestCampA();
            return entranceWestCampA;
        }

        //Metode der opretter en billet til Camp B
        public ITicket CreateCampB()
        {
            EntranceWestCampB entranceWestCampB = new EntranceWestCampB();
            return entranceWestCampB;
        }
    }
}
