using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface ITicketClient
    {
        ITicket OrderTicketCampA(ITicketFactory ticketFactory);

        ITicket OrderTicketCampB(ITicketFactory ticketFactory);

        int GetRandomNumber();

        ITicket CreateTicket();

        void SetUnlockedTickets(List<int> allowedTickets);

        List<int> GetUnlockedTickets();
    }
}
