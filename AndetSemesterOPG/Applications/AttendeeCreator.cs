<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Text;

<<<<<<<< HEAD:AndetSemesterOPG/Applications/AttendeeCreator.cs
namespace AndetSemesterOPG.Applications
========
namespace AndetSemesterOPG.Infrastructure
<<<<<<< Updated upstream
>>>>>>>> 7f26fa67b3a08424797822f6336829e6d016dc66:AndetSemesterOPG/Infrastructure/AttendeeRepository.cs
=======
>>>>>>>> da2b4ff8de43e05aaf8d57acce4c3158b8d921ae:AndetSemesterOPG/Infrastructure/AttendeeRepository.cs
>>>>>>> Stashed changes
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

        
<<<<<<< Updated upstream
>>>>>>> 7f26fa67b3a08424797822f6336829e6d016dc66
=======
>>>>>>> da2b4ff8de43e05aaf8d57acce4c3158b8d921ae
>>>>>>> Stashed changes

    }
}
