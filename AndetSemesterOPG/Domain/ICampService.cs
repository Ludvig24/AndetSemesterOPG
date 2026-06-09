using AndetSemesterOPG.Applications;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface ICampService
    {
        // Metode der henter kapaciteten for en given camp ved at kalde repository'et, og returnerer den som en int
        int RetrieveCampCapacity(string campName);
        // Metode der henter den totale kapacitet for alle camps ved at kalde repository'et, og returnerer den som en int
        int RetriveTotalCampCapacity();
        // Metode der henter alle camps ved at kalde repository'et, og returnerer dem som en liste
        List<Camp> RetrieveAllCamps();
        // en metode som subscriber en observer til camp observer listen, så den kan blive notificeret når der sker ændringer i camp kapaciteten
        void SubscribeCampObserver(ICampObserver observer);
        // en metode som unsubscribes en observer fra camp observer listen, så den ikke længere bliver notificeret når der sker ændringer i camp kapaciteten
        void UnsubscribeCampObserver(ICampObserver observer);
        // en metode som notifies alle observers i camp observer listen, når der sker ændringer i camp kapaciteten, og sender den relevante information om camp navnet og den nye kapacitet status
        void NotifyCampObservers(string campName, CampCapacityStatus.CapacityStatus campStatus);
        // en metode som tjekker om en given camp har kapacitet til at rumme et givent antal deltagere, ved at hente camp kapaciteten og sammenligne den med det givne antal deltagere, og kaster en exception hvis campen ikke har kapacitet
        void CheckCampCapacity(Camp camp, int attendeeAmount, IAttendeeService attendeeService);
        // en metode som låser en given camp, ved at sætte dens IsLocked property til true
        void LockCamp(Camp camp, IAttendeeService attendeeService);
        // en metode som åbner en given camp, ved at sætte dens IsLocked property til false
        void UnlockCamp(Camp camp, IAttendeeService attendeeService);


    }
}
