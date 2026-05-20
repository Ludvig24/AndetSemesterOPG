using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal class EntranceEastCampA: ITicket
    {

        public int DetermineEntranceType()
        {
            return 1;
        }
        public string DetermineCampName()
        {
            return "Camp A"; 
        }
    }
}
