using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface IAttendeeCreator
    {
        void SemaphoreStart();

        void SemaphoreCreateAttendee();

        void AutoCreateAttendee(object sender, EventArgs e);
    }
}
