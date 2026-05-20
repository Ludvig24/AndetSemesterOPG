using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface IAttendeeRepository
    {

        void AddAttendee(Attendee attendee);

        List<Attendee> GetAllAttendees();


    }
}
