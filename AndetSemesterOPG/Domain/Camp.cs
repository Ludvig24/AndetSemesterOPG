using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal class Camp
    {
        int CampId { get; set; }
        int CampCapacity { get; set; }
        string CampName {  get; set; }

        CampCapacityStatus.CapacityStatus CampStatus { get; set; }

        public Camp(int campId, int campCapacity, string campName, CampCapacityStatus.CapacityStatus campStatus)
        {
            this.CampId = campId;
            this.CampCapacity = campCapacity;
            this.CampName = campName;
            this.CampStatus = campStatus;
        }


        
    }
}
