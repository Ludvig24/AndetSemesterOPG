using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

<<<<<<<< HEAD:AndetSemesterOPG/Applications/AttendeeCreator.cs
namespace AndetSemesterOPG.Applications
========
namespace AndetSemesterOPG.Infrastructure
>>>>>>>> 7f26fa67b3a08424797822f6336829e6d016dc66:AndetSemesterOPG/Infrastructure/AttendeeRepository.cs
{
    internal class AttendeeRepository : IAttendeeRepository
    {
        DBConnection connection;
        public AttendeeRepository(DBConnection connection)
        {
            this.connection = connection;
        }

        public void AddAttendee(Attendee attendee)
        {

            //save to database på en eller anden måde
        }
    }
}
