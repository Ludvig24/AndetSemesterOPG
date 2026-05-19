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
        AttendeeTestData attendeeTestData; //Vil et interface være bedre kodeskik? 
        IAttendeeRepository attendeeRepository;

        public AttendeeCreator(IAttendeeRepository attendeeRepository, AttendeeTestData attendeeTestData)
        {
            this.attendeeRepository = attendeeRepository;
            this.attendeeTestData = attendeeTestData;
        }

        public Attendee CreateAttendee()
        {
            List<string> attendeeNames = attendeeTestData.NameCombiner();
            string firstName = attendeeNames[0];
            string lastName = attendeeNames[1];

            //ticket tingeling


            Attendee attendee = new Attendee(firstName, lastName);
            attendeeRepository.AddAttendee(attendee);
            return attendee;
        }

        
>>>>>>> 7f26fa67b3a08424797822f6336829e6d016dc66

    }
}
