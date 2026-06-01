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
        int lockNumber;
        
        public CampService(ICampRepository campRepository)
        {
            this.campRepository = campRepository;
            this.campObservers = new List<ICampObserver>();
            lockNumber = 0;
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

            int capacity = RetrieveCampCapacity(camp.CampName);
            double percentageFilled = (double)attendeeAmount / capacity * 100;
            percentageFilled = Double.Round(percentageFilled);
            switch (percentageFilled)
            {
                case double n when (n >= 50 && n < 75 && lockNumber < 1):
                    NotifyCampObservers(camp.CampName, CampCapacityStatus.CapacityStatus.FiftyPercent);
                    lockNumber = 1;
                    break;
                case double n when (n > 75 && n < 90 && lockNumber < 2):
                    NotifyCampObservers(camp.CampName, CampCapacityStatus.CapacityStatus.SeventyFivePercent);
                    lockNumber = 2;
                    break;
                case double n when (n >= 90 && n < 100 && lockNumber <3):
                    NotifyCampObservers(camp.CampName, CampCapacityStatus.CapacityStatus.NinetyPercent);
                    lockNumber = 3;
                    LockCamp(camp, attendeeService);

                    break;
                case double n when (n >= 100 && lockNumber <4):
                    NotifyCampObservers(camp.CampName, CampCapacityStatus.CapacityStatus.OneHundredPercent);
                    lockNumber = 4;
                    LockCamp(camp, attendeeService);
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
