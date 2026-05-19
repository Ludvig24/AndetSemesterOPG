<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    internal class EntranceWestFactory
    {
=======
﻿using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using AndetSemesterOPG.Domain;


namespace AndetSemesterOPG.Applications
{
    internal class EntranceWestFactory : ITicketFactory
    {
        public ITicket CreateCampA()
        {
            EntranceWestCampA entranceWestCampA = new EntranceWestCampA();
            return (ITicket)entranceWestCampA;
        }

        public ITicket CreateCampB()
        {
            EntranceWestCampB entranceWestCampB = new EntranceWestCampB();
            //Vær lige ops på parantesen, Den virker ikke uden
            return (ITicket)entranceWestCampB;
        }
>>>>>>> 7f26fa67b3a08424797822f6336829e6d016dc66
    }
}
