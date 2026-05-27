using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace AndetSemesterOPG.Applications
{
    internal class EntranceWestFactory : ITicketFactory
    {
        public ITicket CreateCampA()
        {
            EntranceWestCampA entranceWestCampA = new EntranceWestCampA();
            return entranceWestCampA;
        }

        public ITicket CreateCampB()
        {
            EntranceWestCampB entranceWestCampB = new EntranceWestCampB();
            return entranceWestCampB;
        }
    }
}
