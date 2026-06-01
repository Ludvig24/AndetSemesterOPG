using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace AndetSemesterOPG.Applications
{
    internal class AttendeeCreator //Flyt til festival?
    {
        private int totalCampCapacity;
        private int currentAttendeeCount;
        CampService campService;
        DispatcherTimer timer;
        AttendeeService attendeeService;
        static Semaphore CreateAttendeeSemaphore = new Semaphore(10, 10); // Starter med 10 tilladelser, og maks er også 10

        public AttendeeCreator(DispatcherTimer timer, AttendeeService attendeeService, CampService campService)
        {

            this.timer = timer;
            this.attendeeService = attendeeService;

            this.timer.Tick += new EventHandler(AutoCreateAttendee);
            this.timer.Interval = new TimeSpan(0, 0, 1); // Her sættes intervallet for timeren til 5 sekunder
            this.timer.Start();



            this.campService = campService;
            totalCampCapacity = campService.RetriveTotalCampCapacity();
            currentAttendeeCount = attendeeService.RetrieveAllAttendees().Count;

            

        }
       


        public void SemaphoreStart()
        {
            for (int i = 0; i < 50; i++) 
            {
                SemaphoreCreateAttendee();
            }
            
        }


        public void SemaphoreCreateAttendee()
        {
            CreateAttendeeSemaphore.WaitOne();

            attendeeService.CreateAttendee();

            CreateAttendeeSemaphore.Release();
                
        }


        
        public void AutoCreateAttendee(object sender, EventArgs e)
        {
            attendeeService.CreateAttendee();
        }
    }
}
