using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace AndetSemesterOPG.Applications
{
    //Klasse der er ansvarlig for at oprette deltagere til festivalen, både automatisk og manuelt
    internal class AttendeeCreator : IAttendeeCreator //Emil
    {
        //Properties for klassen - DispatcherTimer og attendeeService instans
        DispatcherTimer timer;
        IAttendeeService attendeeService;
        
        //Semaphore der blev brugt til en tidligere løsning på et synkroniseringsproblem
        //static Semaphore CreateAttendeeSemaphore = new Semaphore(10, 10); // Starter med 10 tilladelser, og maks er også 10
        
        private readonly object lockObject = new object();

        //Konstruktor der tager en DispatcherTimer og AttendeeService som parameter, og sætter timeren til at kalde AutoCreateAttendee metoden hvert sekund
        public AttendeeCreator(DispatcherTimer timer, IAttendeeService attendeeService)
        {
            //Tildeler variabler fra constructor til properties
            this.timer = timer;
            this.attendeeService = attendeeService;

            //Hver gang tick eventen sker kaldes AutoCreateAttendee metoden
            this.timer.Tick += new EventHandler(AutoCreateAttendee);
            this.timer.Interval = new TimeSpan(0, 0, 1); // Her sættes intervallet for timeren - hvert sekund starter tick eventet
            
            //starter timeren
            this.timer.Start();
            

            
        }

        //Metode som starter Attendee oprettelsen via Threads
        public void StartAttendeeCreation()
        {
            //opretter 2 threads og giver dem metoden CreateBulkAttendee
            Thread thread1 = new Thread(CreateBulkAttendee);
            Thread thread2 = new Thread(CreateBulkAttendee);

            
            thread1.IsBackground = true;
            thread2.IsBackground = true;

            thread1.Start();
            thread2.Start();
        }

        //Metode der opretter deltagere
        public void CreateBulkAttendee()
        {
            
            //loop kører 25 gange - hver iteration tager en tråd locken, kalder CreateAttendee og slipper den igen
                for (int i = 0; i < 25; i++)
                {
                    lock (lockObject)
                    {
                        //MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());
                        attendeeService.CreateAttendee();
                    }
                }
        }

        
        
        //Anden ide til asynkron attende oprettelse
        //Metode der starter processen med at oprette deltagere ved at kalde SemaphoreCreateAttendee metoden 50 gange
        /*
        public void SemaphoreStart()
        {
            for (int i = 0; i < 50; i++) 
            {
                Thread t = new Thread(SemaphoreCreateAttendee);
                t.Start();
                
            }
            
        } */

        //Anden ide til asynkron attendee oprettelse
        //Metode der bruger en semaphore til at sikre, at kun et bestemt antal tråde kan oprette deltagere samtidigt, og kalder CreateAttendee metoden i AttendeeService for at oprette en deltager
        /*
        public void SemaphoreCreateAttendee()
        {
            CreateAttendeeSemaphore.WaitOne();
            
            attendeeService.CreateAttendee();

            CreateAttendeeSemaphore.Release();
                
        }*/
        

        //Metode der automatisk opretter deltagere ved at kalde CreateAttendee metoden
        public void AutoCreateAttendee(object sender, EventArgs e)
        {
            attendeeService.CreateAttendee();
        }
    }
}
