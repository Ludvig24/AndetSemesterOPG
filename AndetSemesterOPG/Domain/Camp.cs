using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    //Klasse der repræsentere en camp, og indeholder information om campen
    internal class Camp //Ludvig
    {
        //get og set metoder for campens id, kapacitet, navn, låst status og kapacitetsstatus
        public int CampId { get; set; }
        public int CampCapacity { get; set; }
        public string CampName {  get; set; }

        public bool IsLocked { get; set; }

        public CampCapacityStatus.CapacityStatus CampStatus { get; set; }

        //Konstruktor der tager imod campens id, kapacitet, navn og kapacitetsstatus som parametre, og initialisere campen med disse værdier
        /*public Camp(int campId, int campCapacity, string campName, CampCapacityStatus.CapacityStatus campStatus)
        {
            this.CampId = campId;
            this.CampCapacity = campCapacity;
            this.CampName = campName;
            this.CampStatus = campStatus;
        }*/

        // konstruktor der tager imod campens id, kapacitet og navn som parametre, og initialisere campen med disse værdier
        public Camp(int campId, int campCapacity, string campName)
        {
            this.CampId = campId;
            this.CampCapacity = campCapacity;
            this.CampName = campName;
            
        }



    }
}
