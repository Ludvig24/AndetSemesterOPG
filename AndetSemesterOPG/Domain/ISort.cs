using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
[assembly: InternalsVisibleTo("QuickSortTest")]

namespace AndetSemesterOPG.Domain
{
    internal interface ISort
    {

        List<Attendee> SortByEntranceId(List<Attendee> attendees);

        List<Attendee> SortByCampName(List<Attendee> attendees);

        List<Attendee> SortByFirstName(List<Attendee> attendees, int left, int right);



    }
}
