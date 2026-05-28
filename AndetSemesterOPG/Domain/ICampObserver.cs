using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface ICampObserver
    {
        void Update(string campName, CampCapacityStatus.CapacityStatus campStatus);

    }
}
