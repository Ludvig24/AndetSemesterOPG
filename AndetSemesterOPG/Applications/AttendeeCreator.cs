using AndetSemesterOPG.Domain;
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

        

    }
}
