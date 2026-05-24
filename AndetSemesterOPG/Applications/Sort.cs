using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    internal class Sort
    {



        public List<Attendee> SortTest(List<Attendee> attendees)
        {
            List<Attendee> sortedAttendees;

            sortedAttendees = attendees.OrderBy(o=>o.AttendeeFirstName).ToList();


            

            
            return sortedAttendees;
        }

        /*
        public List<T> SortTest<T>(List<T> list) //kunne være sejt med en generisk sortering, men så skal vi have en separat metode til at trække fx alle fornavne fra attendees ud som vi så kan sende til den her metode
        {
            
            list.Sort();
            return list;
        }
        */

    }
}
