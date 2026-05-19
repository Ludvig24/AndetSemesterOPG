<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Text;

<<<<<<<< HEAD:AndetSemesterOPG/Applications/AttendeeCreator.cs
namespace AndetSemesterOPG.Applications
========
namespace AndetSemesterOPG.Infrastructure
>>>>>>>> 7f26fa67b3a08424797822f6336829e6d016dc66:AndetSemesterOPG/Infrastructure/AttendeeRepository.cs
{
    internal class AttendeeRepository
    {
=======
﻿using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    internal class AttendeeCreator
    {
        AttendeeTestData attendeetestdata = new AttendeeTestData();


        public Attendee CreateAttendee()
        {
            List<string> attendeeNames = attendeetestdata.NameCombiner();
            string firstName = attendeeNames[0];
            string lastName = attendeeNames[1];


            Attendee attendee = new Attendee(firstName, lastName);
            return attendee;
        }

        
>>>>>>> 7f26fa67b3a08424797822f6336829e6d016dc66

    }
}
