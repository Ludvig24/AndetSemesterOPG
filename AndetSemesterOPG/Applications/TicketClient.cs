using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    //Klasse der repræsentere en ticket client, og indeholder metoder til at definere billetter til de forskellige camps
    internal class TicketClient : ITicketClient
    {

        //Denne liste indeholder de billetter der er låst op, og det er det tal der kommer ud af GetRandomNumber der bestemmer hvilken billet der skal producer
        private List<int> unlockedTickets = new List<int>() { 1, 2, 3, 4 };

        //Metode der laver en billet til camp A ved at bruge ticketFactory til at lave en billet til camp A og returnere den
        public ITicket OrderTicketCampA(ITicketFactory ticketFactory)
        {
            ITicket ticketCampA = ticketFactory.CreateCampA();
            return ticketCampA;
        }

        //Metode der laver en billet til camp B ved at bruge ticketFactory til at lave en billet til camp B og returnere den
        public ITicket OrderTicketCampB(ITicketFactory ticketFactory)
        {
            ITicket ticketCampB = ticketFactory.CreateCampB();
            return ticketCampB;
        }

        //Metode der laver en random number generator der vælger et tilfældigt tal mellem 1 og 4, og returnere det, det er det tal der bestemmer hvilken billet der skal produceres
        public int GetRandomNumber()
        {
            if(unlockedTickets.Count == 0)
            {
                return 0;
            }

            Random randomiser = new Random();
            

            return unlockedTickets[randomiser.Next(0, unlockedTickets.Count)];

        }

        //Metode der laver en billet ved at bruge GetRandomNumber til at bestemme hvilken type billet der skal produceres, og returnere den
        public ITicket CreateTicket()
        {
            ITicketFactory ticketFactory;
            int randomNumber = GetRandomNumber();

            //switch statement der bestemmer hvilken type billet der skal produceres ud fra det tilfældige tal, og returnere den billet. Hvis det tilfældige tal ikke er mellem 1 og 4 bliver der lavet en anden billet
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
                    return null;

            }
        }


        //Metode der sætter hvilke billetter der er låst op ved at tage en liste af tal som parameter, og sætte unlockedTickets til den liste
        public void SetUnlockedTickets(List<int> allowedTickets)
        {
            unlockedTickets = allowedTickets;
        }
        //Metode der returnere hvilke billetter der er låst op ved at returnere unlockedTickets
        public List<int> GetUnlockedTickets()
        {
            return unlockedTickets;
        }
    }
}
