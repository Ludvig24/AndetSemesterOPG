using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface IAttendeeCreator //Emil
    {
        //anden ide til asynkron attende oprettelse
        // Metode der starter processen for at oprette en attendee
        //void SemaphoreStart();
        
        //anden ide til asynkron attende oprettelse
        // Metode der opretter en attendee med en semaphore
        //void SemaphoreCreateAttendee();

        // Metode der automatisk opretter en attendee
        void AutoCreateAttendee(object sender, EventArgs e);

        //Metode der skal starte oprettelse af attendees
        void StartAttendeeCreation();

        //Metode der opretter en mængde af attendees
        void CreateBulkAttendee();
    }
}
