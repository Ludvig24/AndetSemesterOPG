using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    //Klasse der repræsentere kapacitetstatus for en camp
    internal class CampCapacityStatus // Tobias
    {
        //Enum der definerer de forskellige kapacitetstatusser for en camp
        public enum CapacityStatus
        {
            FiftyPercent,
            SeventyFivePercent,
            NinetyPercent,
            OneHundredPercent
        }
    }
}
