using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    //Interface der definerer en observer til at modtage opdateringer om kapaciteten for de forskellige camps
    internal interface ICampObserver //Ludvig
    {
        //Metode der der tager imod en camps navn og dens kapacitet som parametre, og opdaterer observeren med denne information
        void Update(string campName, CampCapacityStatus.CapacityStatus campStatus);

    }
}
