using AndetSemesterOPG.Applications;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface ICampService
    {
        int RetrieveCampCapacity(string campName);

        int RetriveTotalCampCapacity();

        List<Camp> RetrieveAllCamps();

        void SubscribeCampObserver(ICampObserver observer);

        void UnsubscribeCampObserver(ICampObserver observer);

        void NotifyCampObservers(string campName, CampCapacityStatus.CapacityStatus campStatus);

        void CheckCampCapacity(Camp camp, int attendeeAmount, IAttendeeService attendeeService);

        void LockCamp(Camp camp, IAttendeeService attendeeService);

        void UnlockCamp(Camp camp, IAttendeeService attendeeService);


    }
}
