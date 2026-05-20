using System;
using System.Collections.Generic;
using System.Text;
using AndetSemesterOPG.Domain;

namespace AndetSemesterOPG.Applications
{
    internal class EntranceEastFactory : ITicketFactory
    {
        
        public ITicket CreateCampA()
        {
            EntranceEastCampA entranceEastCampA = new EntranceEastCampA();
            return entranceEastCampA;
        }
        public ITicket CreateCampB() 
        {
            EntranceEastCampB entranceEastCampB = new EntranceEastCampB();
            return entranceEastCampB;
        }
    }
}
