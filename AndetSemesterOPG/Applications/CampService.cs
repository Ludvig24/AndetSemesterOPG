using AndetSemesterOPG.Domain;
using AndetSemesterOPG.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace AndetSemesterOPG.Applications
{
    //Klasse der repræsenterer service laget for camps, og indeholder metoder til at hente data om camps fra databasen, samt metoder til at håndtere observer patternet for camp kapacitet
    internal class CampService : ICampService // Ludvig & Emil
    {
        //Variabler til klassen
        List<ICampObserver> campObservers;
        ICampRepository campRepository;
        Dictionary<string, int> campCapacityStatuses;

        //Konstruktor der tager en ICampRepository som parameter og gemmer den i en instansvariabel, samt initialiserer listen over camp observers og dictionaryen til at holde styr på camp kapacitet status
        public CampService(ICampRepository campRepository)
        {
            this.campRepository = campRepository;
            this.campObservers = new List<ICampObserver>();
            this.campCapacityStatuses = new Dictionary<string, int>();
        }

        //Metode til at hente kapaciteten for en given camp
        public int RetrieveCampCapacity(string campName)
        {
            return campRepository.GetCampCapacity(campName);
        }


        //Metode til at hente en liste over alle camps ved at kalde GetAllCamps metoden på campRepository
        public List<Camp> RetrieveAllCamps()
        {
            return campRepository.GetAllCamps();
        }

        //Metode til at tilføje en observer til listen over camp observers
        public void SubscribeCampObserver(ICampObserver observer)
        {
            campObservers.Add(observer);
        }

        //Metode til at fjerne en observer fra listen over camp observers
        public void UnsubscribeCampObserver(ICampObserver observer)
        {
            campObservers.Remove(observer);
        }

        //Metode til at notificere alle observers i listen over camp observers om en ændring i camp kapacitet ved at kalde Update metoden på hver observer
        //og sende camp navnet og den nye kapacitet status som parametre
        public void NotifyCampObservers(Camp camp)
        {
            foreach (var observer in campObservers)
            {
                observer.Update(camp);
            }
        }

        //Metode til at tjekke kapaciteten for en given camp ved at hente antallet af attendees for campen og sammenligne det med campens kapacitet
        public void CheckCampCapacity(Camp camp, int attendeeAmount, IAttendeeService attendeeService)
        {
            //Hvis campen allerede er låst, skal der ikke gøres noget, da det ikke er nødvendigt at tjekke kapaciteten igen
            if (camp.IsLocked == true)
            {
                return;
            }

            //Hvis campen ikke allerede har en kapacitet status i dictionaryen, skal den initialiseres til 0
            if (!campCapacityStatuses.ContainsKey(camp.CampName))
            {
                campCapacityStatuses[camp.CampName] = 0;
            }

            //Hent den nuværende kapacitet status for campen fra dictionaryen
            int state = campCapacityStatuses[camp.CampName];

            //Hent kapaciteten for campen ved at kalde RetrieveCampCapacity metoden
            int capacity = RetrieveCampCapacity(camp.CampName);

            //Beregn procentdelen af campen der er fyldt
            double percentageFilled = (double)attendeeAmount / capacity * 100;

            // Brug en switch statement til at tjekke hvilken kapacitet status campen skal have baseret på procentdelen der er fyldt, og opdater dictionaryen og notificer observers hvis der er en ændring i kapacitet status
            switch (percentageFilled)
            {
                case double n when (n >= 50 && n < 75 && state < 1):
                    camp.CampStatus = CampCapacityStatus.CapacityStatus.FiftyPercent;
                    NotifyCampObservers(camp);
                    campCapacityStatuses[camp.CampName] = 1;
                    break;
                case double n when (n > 75 && n < 90 && state < 2):
                    camp.CampStatus = CampCapacityStatus.CapacityStatus.SeventyFivePercent;
                    NotifyCampObservers(camp); 
                    campCapacityStatuses[camp.CampName] = 2;
                    break;
                case double n when (n >= 90 && n < 100 && state <3):
                    camp.CampStatus = CampCapacityStatus.CapacityStatus.NinetyPercent;
                    LockCamp(camp, attendeeService);
                    campCapacityStatuses[camp.CampName] = 3;
                    NotifyCampObservers(camp);
                    break;
                case double n when (n >= 100 && state <4):
                    camp.CampStatus = CampCapacityStatus.CapacityStatus.OneHundredPercent;
                    LockCamp(camp, attendeeService);
                    campCapacityStatuses[camp.CampName] = 4;
                    NotifyCampObservers(camp);
                    break;
            }
        }

        //Metode til at låse en camp ved at fjerne de relevante billetter fra ticket clienten og sætte campens IsLocked property til true
        public void LockCamp(Camp camp, IAttendeeService attendeeService)
        {
            //Hvis campen er Camp A, skal billetterne med id 1 og 3 fjernes fra ticket clienten, og campens IsLocked property skal sættes til true
            if (camp.CampName == "Camp A")
            {
                List<int> currentTickets = attendeeService.ticketClient.GetUnlockedTickets();
                currentTickets.Remove(1);
                currentTickets.Remove(3);
                camp.IsLocked = true;
                attendeeService.ticketClient.SetUnlockedTickets(currentTickets);

            }
            //Hvis campen er Camp B, skal billetterne med id 2 og 4 fjernes fra ticket clienten, og campens IsLocked property skal sættes til true
            else if (camp.CampName == "Camp B")
            {
                List<int> currentTickets = attendeeService.ticketClient.GetUnlockedTickets();
                currentTickets.Remove(2);
                currentTickets.Remove(4);
                camp.IsLocked = true;
                attendeeService.ticketClient.SetUnlockedTickets(currentTickets);
            }
        }

        //Metode til at låse en camp ved at tilføje de relevante billetter til ticket clienten og sætte campens IsLocked property til false
        public void UnlockCamp(Camp camp, IAttendeeService attendeeService)
        {
            //Hvis campen er Camp A, skal billetterne med id 1 og 3 tilføjes til ticket clienten, og campens IsLocked property skal sættes til false
            if (camp.CampName == "Camp A")
            {
                
                List<int>currentTickets = attendeeService.ticketClient.GetUnlockedTickets();
                currentTickets.Add(1);
                currentTickets.Add(3);
                camp.IsLocked = false;
                attendeeService.ticketClient.SetUnlockedTickets(currentTickets);

            }
            //Hvis campen er Camp B, skal billetterne med id 2 og 4 tilføjes til ticket clienten, og campens IsLocked property skal sættes til false
            else if (camp.CampName == "Camp B")
            {
                List<int> currentTickets = attendeeService.ticketClient.GetUnlockedTickets();
                currentTickets.Add(2);
                currentTickets.Add(4);
                camp.IsLocked = false;
                attendeeService.ticketClient.SetUnlockedTickets(currentTickets);
            }
        }

    }
}
