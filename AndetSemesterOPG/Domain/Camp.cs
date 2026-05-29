using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal class Camp
    {
        public int CampId { get; set; }
        public int CampCapacity { get; set; }
        public string CampName {  get; set; }

        public bool IsLocked { get; set; }

        CampCapacityStatus.CapacityStatus CampStatus { get; set; }

        public Camp(int campId, int campCapacity, string campName, CampCapacityStatus.CapacityStatus campStatus)
        {
            this.CampId = campId;
            this.CampCapacity = campCapacity;
            this.CampName = campName;
            this.CampStatus = campStatus;
        }

        public Camp()
        {

        }


        
    }
}
