using AndetSemesterOPG.Domain;
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

        

    }
}
