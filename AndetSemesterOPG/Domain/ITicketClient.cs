using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface ITicketClient
    {
        //Metode der laver en billet til camp A ved at bruge ticketFactory til at lave en billet til camp A og returnere den
        ITicket OrderTicketCampA(ITicketFactory ticketFactory);
        //Metode der laver en billet til camp B ved at bruge ticketFactory til at lave en billet til camp B og returnere den
        ITicket OrderTicketCampB(ITicketFactory ticketFactory);
        //Metode der laver et random nummer og retunere det
        int GetRandomNumber();
        // Metode der laver en billet ved at bruge GetRandomNumber til at bestemme hvilken type billet der skal produceres, og returnere den
        ITicket CreateTicket();
        // Metode der tager en liste af int som parameter og sætter den som de tilladte billetter
        void SetUnlockedTickets(List<int> allowedTickets);
        // Metode der returnere en liste af int som er de billetter der er låst op
        List<int> GetUnlockedTickets();
    }
}
