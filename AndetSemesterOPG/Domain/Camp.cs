using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal class Camp
    {
        int campId;
        int campCapacity;
        string campName;
        CampCapacityStatus.CapacityStatus campStatus;

        public Camp(int campId, int campCapacity, string campName, CampCapacityStatus.CapacityStatus campStatus)
        {
            this.campId = campId;
            this.campCapacity = campCapacity;
            this.campName = campName;
            this.campStatus = campStatus;
        }

        
    }
}
