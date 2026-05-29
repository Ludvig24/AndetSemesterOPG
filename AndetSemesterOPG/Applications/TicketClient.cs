using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    internal class TicketClient
    {
        //Den her er til for at kunne stoppe produktionen af en bestem type billet senere
        bool makeTicket;
        //Her er en metode der laver en billet til camp A og en til camp B, den tager en ticketfactory som parameter så den kan lave de forskellige billetter

        //Lav metode der måske tager en int (1,2,3 eller 4) - unlockedTickets erstattes med en liste uden det valgte tal - dermed begrænset ticketproduktion
        private List<int> unlockedTickets = new List<int>() { 1, 2, 3, 4 };
        
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


        public int GetRandomNumber()
        {
            Random randomiser = new Random();
            

            return unlockedTickets[randomiser.Next(0, unlockedTickets.Count)];

        }

        public ITicket CreateTicket()
        {
            ITicketFactory ticketFactory;
            int randomNumber = GetRandomNumber();

            switch (randomNumber)
            {
                case 1:
                    ticketFactory = new EntranceEastFactory();
                    return OrderTicketCampA(ticketFactory);
                case 2:
                    ticketFactory = new EntranceEastFactory();
                    return OrderTicketCampB(ticketFactory);
                case 3:
                    ticketFactory = new EntranceWestFactory();
                    return OrderTicketCampA(ticketFactory);
                case 4:
                    ticketFactory = new EntranceWestFactory();
                    return OrderTicketCampB(ticketFactory);
                default:
                    throw new Exception("Invalid random number");

            }
        }

        public void SetUnlockedTickets(List<int> allowedTickets)
        {
            unlockedTickets = allowedTickets;
        }

        public List<int> GetUnlockedTickets()
        {
            return unlockedTickets;
        }
    }
}
