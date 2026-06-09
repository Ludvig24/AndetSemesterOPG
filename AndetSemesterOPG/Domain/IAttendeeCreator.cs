using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface IAttendeeCreator
    {
        // Metode der starter processen for at oprette en attendee
        void SemaphoreStart();
        // Metode der opretter en attendee med en semaphore
        void SemaphoreCreateAttendee();
        // Metode der automatisk opretter en attendee
        void AutoCreateAttendee(object sender, EventArgs e);
    }
}
