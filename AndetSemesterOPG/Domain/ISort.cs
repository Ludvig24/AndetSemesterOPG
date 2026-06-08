using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
[assembly: InternalsVisibleTo("QuickSortTest")]
[assembly: InternalsVisibleTo("BubbleSortTest")]

namespace AndetSemesterOPG.Domain
{
    internal interface ISort
    {
        int bubbleComparisons { get; set; }
        int insertComparisons { get; set; }
        int quickComparisons { get; set; }
        List<Attendee> SortByEntranceId(List<Attendee> attendees);

        List<Attendee> SortByCampName(List<Attendee> attendees);

        List<Attendee> SortByFirstName(List<Attendee> attendees, int left, int right);



    }
}
