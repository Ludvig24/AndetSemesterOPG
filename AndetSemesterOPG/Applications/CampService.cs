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
        public CampService(ICampRepository campRepository)
        {
            this.campRepository = campRepository;
            this.campObservers = new List<ICampObserver>();
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

            switch (percentageFilled)
            {
                case double n when (n > 1.7 && n < 75):
                    NotifyCampObservers(campName, CampCapacityStatus.CapacityStatus.FiftyPercent);
                    break;
                case double n when (n > 75 && n < 90):
                    NotifyCampObservers(campName, CampCapacityStatus.CapacityStatus.SeventyFivePercent);
                    break;
                case double n when (n > 90 && n < 100):
                    NotifyCampObservers(campName, CampCapacityStatus.CapacityStatus.NinetyPercent);
                    break;
                case double n when (n >= 100):
                    NotifyCampObservers(campName, CampCapacityStatus.CapacityStatus.OneHundredPercent);
                    break;
            }
        }

    }
}
