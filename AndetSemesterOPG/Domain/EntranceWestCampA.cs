using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal class EntranceWestCampA : ITicket
    {
        public int DetermineEntranceType()
        {
            return 2;
        }
        public string DetermineCampName()
        {
            return "Camp A";
        }
    }
}
