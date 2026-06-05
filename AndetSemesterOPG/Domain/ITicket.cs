using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    //Interface der definerer en billet, og indeholder metoder til at bestemme hvilken type billet det er, og hvilken camp den tilhører
    internal interface ITicket
    {
        //Metode der bestemmer hvilken type billet det er, og returnerer den som en int
        int DetermineEntranceType();

        //Metode der bestemmer hvilken camp billetten tilhører, og returnerer den som en string
        string DetermineCampName();

        
        
    }
}
