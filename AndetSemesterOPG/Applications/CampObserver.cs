using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace AndetSemesterOPG.Applications
{
    internal class CampObserver : ICampObserver
    {

        public void Update(string campName, CampCapacityStatus.CapacityStatus campStatus)
        {
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
                    //lås camp
                    break;
                case CampCapacityStatus.CapacityStatus.OneHundredPercent:
                    MessageBox.Show($"{campName} er nu 100% fyldt. Campen er nu nået maks kapacitet.");
                    //lås camp
                    break;
            }
        }
    }
}
