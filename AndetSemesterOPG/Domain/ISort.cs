using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface ISort
    {

        List<Attendee> SortByEntranceId(List<Attendee> attendees);

        List<Attendee> SortByCampName(List<Attendee> attendees);

        List<Attendee> SortByFirstName(List<Attendee> attendees, int left, int right);



    }
}
