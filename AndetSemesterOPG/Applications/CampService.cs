using AndetSemesterOPG.Domain;
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

        public void CheckCampCapacity(string campName, int attendeeAmount)
        {
            int capacity = RetrieveCampCapacity(campName);
            double percentageFilled = (double)attendeeAmount / capacity * 100;
            percentageFilled = Double.Round(percentageFilled);
            switch (percentageFilled)
            {
                case double n when (n <= 50 && n < 75 && lockNumber <1):
                    NotifyCampObservers(campName, CampCapacityStatus.CapacityStatus.FiftyPercent);
                    lockNumber = 1;
                    break;
                case double n when (n > 75 && n < 90 && lockNumber <2):
                    NotifyCampObservers(campName, CampCapacityStatus.CapacityStatus.SeventyFivePercent);
                    lockNumber = 2;
                    break;
                case double n when (n > 90 && n < 100 && lockNumber <3):
                    NotifyCampObservers(campName, CampCapacityStatus.CapacityStatus.NinetyPercent);
                    lockNumber = 3;
                    //Metode til at låse produktion af billetter
                    break;
                case double n when (n >= 100 && lockNumber <4):
                    NotifyCampObservers(campName, CampCapacityStatus.CapacityStatus.OneHundredPercent);
                    //Også her
                    lockNumber = 4;
                    break;
            }
        }

    }
}
