using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace AndetSemesterOPG.Applications
{
    //Klasse der implementere ICampObserver, og indeholder en metode der opdatere campens kapacitetstatus, og viser en besked til brugeren når campen når en bestemt kapacitetstatus
    internal class CampObserver : ICampObserver // Laura
    {
        //Metode der tager imod en camps navn og dens kapacitet som parametre, og opdaterer observeren med denne information, og viser en besked til brugeren hvis campen når en bestemt kapacitetstatus
        public void Update(string campName, CampCapacityStatus.CapacityStatus campStatus)
        {
            //Opdater campens kapacitetstatus, og viser en besked til brugeren hvis campen når en bestemt kapacitetstatus
            switch (campStatus)
            {
                case CampCapacityStatus.CapacityStatus.FiftyPercent:
                    MessageBox.Show($"{campName} er nu over 50% fyldt.");
                    break;
                case CampCapacityStatus.CapacityStatus.SeventyFivePercent:
                    MessageBox.Show($"{campName} er nu over 75% fyldt.");
                    break;
                case CampCapacityStatus.CapacityStatus.NinetyPercent:
                    MessageBox.Show($"{campName} er nu over 90% fyldt. Campen er låst og kan blive åbnet på festival vinduet");
                    break;
                case CampCapacityStatus.CapacityStatus.OneHundredPercent:
                    MessageBox.Show($"{campName} er nu 100% fyldt. Campen er nu nået maks kapacitet.");
                    break;
            }
        }
    }
}
