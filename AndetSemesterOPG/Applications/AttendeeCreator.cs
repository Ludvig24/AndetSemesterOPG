using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace AndetSemesterOPG.Applications
{
    //Klasse der er ansvarlig for at oprette deltagere til festivalen, både automatisk og manuelt
    internal class AttendeeCreator
    {
        //Variabler der giver betydning til klassen, herunder total kapacitet for alle camps, nuværende antal deltagere, og services til at håndtere camp og deltager data
        private int totalCampCapacity;
        private int currentAttendeeCount;
        ICampService campService;
        DispatcherTimer timer;
        IAttendeeService attendeeService;
        static Semaphore CreateAttendeeSemaphore = new Semaphore(10, 10); // Starter med 10 tilladelser, og maks er også 10

        //Konstruktor der tager en DispatcherTimer, AttendeeService og CampService som parameter, og sætter timeren til at kalde AutoCreateAttendee metoden hvert 5. sekund
        public AttendeeCreator(DispatcherTimer timer, IAttendeeService attendeeService, ICampService campService)
        {

            this.timer = timer;
            this.attendeeService = attendeeService;
            
            this.timer.Tick += new EventHandler(AutoCreateAttendee);
            this.timer.Interval = new TimeSpan(0, 0, 5); // Her sættes intervallet for timeren til 5 sekunder
            
            this.timer.Start();
            
            this.campService = campService;
            totalCampCapacity = campService.RetriveTotalCampCapacity();
            currentAttendeeCount = attendeeService.RetrieveAllAttendees().Count;
        }

        //Metode der starter processen med at oprette deltagere ved at kalde SemaphoreCreateAttendee metoden 50 gange
        public void SemaphoreStart()
        {
            for (int i = 0; i < 50; i++) 
            {
                SemaphoreCreateAttendee();
            }
            
        }

        //Metode der bruger en semaphore til at sikre, at kun et bestemt antal tråde kan oprette deltagere samtidigt, og kalder CreateAttendee metoden i AttendeeService for at oprette en deltager
        public void SemaphoreCreateAttendee()
        {
            CreateAttendeeSemaphore.WaitOne();

            attendeeService.CreateAttendee();

            CreateAttendeeSemaphore.Release();
                
        }
        
        //Metode der automatisk opretter deltagere ved at kalde CreateAttendee metoden
        public void AutoCreateAttendee(object sender, EventArgs e)
        {
            attendeeService.CreateAttendee();
        }
    }
}
