using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal class EntranceWestCampB : ITicket
    {
        public int DetermineEntranceType()
        {
            return 2;
        }
        public string DetermineCampName()
        {
            return "Camp B";
        }
    }
}
