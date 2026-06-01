using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace AndetSemesterOPG.Applications
{
    internal class AttendeeCreator //Flyt til festival?
    {
        private int totalCampCapacity;

        DispatcherTimer timer;
        AttendeeService attendeeService;
        static Semaphore CreateAttendeeSemaphore = new Semaphore(10, 10); // Starter med 10 tilladelser, og maks er også 10
        static Semaphore AutoCreateAttendeeSemaphore = new Semaphore(5, 5);
        private bool isRunning = true;

        public AttendeeCreator(DispatcherTimer timer, AttendeeService attendeeService)
        {

            this.timer = timer;
            this.attendeeService = attendeeService;

            this.timer.Tick += new EventHandler(AutoCreateAttendee);
            this.timer.Interval = new TimeSpan(0, 0, 5); // Her sættes intervallet for timeren til 5 sekunder
            this.timer.Start();

            //AutoCreateAttendeeStart();



        }
        public void AutoCreateAttendeeStart()
        {
            while (isRunning) 
            {
                new Thread(AutoCreateAttendee).Start();

            }
            AutoCreateAttendeeSemaphore.Release(5);

        }
        public void AutoCreateAttendee()
        {
            AutoCreateAttendeeSemaphore.WaitOne();
            attendeeService.CreateAttendee();
            AutoCreateAttendeeSemaphore.Release();
                Thread.Sleep(5000); // Simulerer en forsinkelse mellem oprettelserne af attendees
        }

        public void SemaphoreStart()
        {
            for (int i = 0; i < 50; i++) 
            {
                SemaphoreCreateAttendee();
            }
            CreateAttendeeSemaphore.Release(10);
        }


        public void SemaphoreCreateAttendee()
        {
            CreateAttendeeSemaphore.WaitOne();

            attendeeService.CreateAttendee();

            CreateAttendeeSemaphore.Release();
                Thread.Sleep(1000); // Simulerer en forsinkelse mellem oprettelserne af attendees
        }



        public void AutoCreateAttendee(object sender, EventArgs e)
        {
            attendeeService.CreateAttendee();
        }
    }
}
