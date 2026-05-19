using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface ITicketFactory
    {
        public ITicket CreateCampA();

        public ITicket CreateCampB();


    }
    
}
