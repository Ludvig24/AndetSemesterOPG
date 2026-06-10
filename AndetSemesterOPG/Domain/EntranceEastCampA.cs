using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    //Klasse der implementerer ITicket interfacet og repræsentere en indgang til Camp A
    internal class EntranceEastCampA: ITicket // Emil
    {
        //Metode der bestemmer hvilken type billet det er, og returnerer den som en int
        public int DetermineEntranceType()
        {
            return 1;
        }

        //Metode der bestemmer hvilken camp billetten tilhører, og returnerer den som en string
        public string DetermineCampName()
        {
            return "Camp A"; 
        }
    }
}
