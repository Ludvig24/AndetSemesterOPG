<<<<<<< HEAD
﻿using System;
=======
﻿using AndetSemesterOPG.Domain;
using System;
>>>>>>> 7f26fa67b3a08424797822f6336829e6d016dc66
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    internal class TicketClient
    {
<<<<<<< HEAD
=======
        //Den her er til for at kunne stoppe produktionen af en bestem type billet senere
        bool makeTicket;
        //Her er en metode der laver en billet til camp A og en til camp B, den tager en ticketfactory som parameter så den kan lave de forskellige billetter
        public ITicket OrderTicketCampA(ITicketFactory ticketFactory)
        {
            ITicket ticketCampA = ticketFactory.CreateCampA();
            return ticketCampA;
        }

        public ITicket OrderTicketCampB(ITicketFactory ticketFactory)
        {
            ITicket ticketCampB = ticketFactory.CreateCampB();
            return ticketCampB;
        }
>>>>>>> 7f26fa67b3a08424797822f6336829e6d016dc66
    }
}
