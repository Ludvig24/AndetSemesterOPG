using System;
using System.Collections.Generic;
using System.Text;
using AndetSemesterOPG.Domain;

namespace AndetSemesterOPG.Applications
{
    //Klasse der implementere ITicketFactory interfacet, og indeholder metoder der opretter billetter til camp A og camp B for indgang øst
    internal class EntranceEastFactory : ITicketFactory
    {
        
        //Metode der opretter en billet til Camp A ved indgang øst
        public ITicket CreateCampA()
        {
            EntranceEastCampA entranceEastCampA = new EntranceEastCampA();
            return entranceEastCampA;
        }

        //Metode der opretter en billet til Camp B ved indgang øst
        public ITicket CreateCampB() 
        {
            EntranceEastCampB entranceEastCampB = new EntranceEastCampB();
            return entranceEastCampB;
        }
    }
}
