using AndetSemesterOPG.Domain;
using AndetSemesterOPG.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    internal class CampService
    {
        List<ICampObserver> campObservers;
        ICampRepository campRepository;
        Dictionary<string, int> campCapacityStatuses;

        public CampService(ICampRepository campRepository)
        {
            this.campRepository = campRepository;
            this.campObservers = new List<ICampObserver>();
            this.campCapacityStatuses = new Dictionary<string, int>();
        }

        public int RetrieveCampCapacity(string campName)
        {
            return campRepository.GetCampCapacity(campName);
        }

        public int RetriveTotalCampCapacity()
        {
            int totalCapacity = 0;
            List<Camp> camps = campRepository.GetAllCamps();
            foreach ( Camp camp in camps)
            {
                totalCapacity += camp.CampCapacity;
            }
            return totalCapacity;
        }

        public List<Camp> RetrieveAllCamps()
        {
            return campRepository.GetAllCamps();
        }

        public void SubscribeCampObserver(ICampObserver observer)
        {
            campObservers.Add(observer);
        }

        public void UnsubscribeCampObserver(ICampObserver observer)
        {
            campObservers.Remove(observer);
        }

        public void NotifyCampObservers(string campName, CampCapacityStatus.CapacityStatus campStatus)
        {
            foreach (var observer in campObservers)
            {
                observer.Update(campName, campStatus);
            }
        }

        public void CheckCampCapacity(Camp camp, int attendeeAmount, AttendeeService attendeeService)
        {

            if (camp.IsLocked == true)
            {
                return;
            }
            if (!campCapacityStatuses.ContainsKey(camp.CampName))
            {
                campCapacityStatuses[camp.CampName] = 0;
            }

            int state = campCapacityStatuses[camp.CampName];

            int capacity = RetrieveCampCapacity(camp.CampName);
            double percentageFilled = (double)attendeeAmount / capacity * 100;
            switch (percentageFilled)
            {
                case double n when (n >= 50 && n < 75 && state < 1):
                    NotifyCampObservers(camp.CampName, CampCapacityStatus.CapacityStatus.FiftyPercent);
                    campCapacityStatuses[camp.CampName] = 1;
                    break;
                case double n when (n > 75 && n < 90 && state < 2):
                    NotifyCampObservers(camp.CampName, CampCapacityStatus.CapacityStatus.SeventyFivePercent); 
                    campCapacityStatuses[camp.CampName] = 2;
                    break;
                case double n when (n >= 90 && n < 100 && state <3):
                    LockCamp(camp, attendeeService);
                    campCapacityStatuses[camp.CampName] = 3;
                    NotifyCampObservers(camp.CampName, CampCapacityStatus.CapacityStatus.NinetyPercent);

                    break;
                case double n when (n >= 100 && state <4):
                    LockCamp(camp, attendeeService);
                    campCapacityStatuses[camp.CampName] = 4;
                    NotifyCampObservers(camp.CampName, CampCapacityStatus.CapacityStatus.OneHundredPercent);
                    break;
            }
        }

        public void LockCamp(Camp camp, AttendeeService attendeeService)
        {
            if (camp.CampName == "Camp A")
            {
                List<int> currentTickets = attendeeService.ticketClient.GetUnlockedTickets();
                currentTickets.Remove(1);
                currentTickets.Remove(3);
                camp.IsLocked = true;
                attendeeService.ticketClient.SetUnlockedTickets(currentTickets);

            }
            else if (camp.CampName == "Camp B")
            {
                List<int> currentTickets = attendeeService.ticketClient.GetUnlockedTickets();
                currentTickets.Remove(2);
                currentTickets.Remove(4);
                camp.IsLocked = true;
                attendeeService.ticketClient.SetUnlockedTickets(currentTickets);
            }
        }

        public void UnlockCamp(Camp camp, AttendeeService attendeeService)
        {
            if (camp.CampName == "Camp A")
            {
                
                List<int>currentTickets = attendeeService.ticketClient.GetUnlockedTickets();
                currentTickets.Add(1);
                currentTickets.Add(3);
                camp.IsLocked = false;
                attendeeService.ticketClient.SetUnlockedTickets(currentTickets);

            }
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
