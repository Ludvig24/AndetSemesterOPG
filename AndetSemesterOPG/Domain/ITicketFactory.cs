using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    //Interface der definerer en factory til at oprette billetter til de forskellige camps
    internal interface ITicketFactory //Laura
    {
        //Metode der opretter en billet til Camp A og returnerer den som en ITicket
        public ITicket CreateCampA();

        //Metode der opretter en billet til Camp B og returnerer den som en ITicket
        public ITicket CreateCampB();


    }
    
}
