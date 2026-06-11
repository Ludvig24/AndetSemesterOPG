using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
[assembly: InternalsVisibleTo("QuickSortTest")]
[assembly: InternalsVisibleTo("BubbleSortTest")]

namespace AndetSemesterOPG.Domain
{
    internal interface ISort // Tobias
    {
        int bubbleComparisons { get; set; }
        int insertComparisons { get; set; }
        int quickComparisons { get; set; }

        // Metode der sorterer en liste af attendees baseret på deres entranceId ved hjælp af forskellige sorteringsalgorytmer
        List<Attendee> SortByEntranceId(List<Attendee> attendees);
        // Metode der sorterer en liste af attendees baseret på deres campName ved hjælp af forskellige sorteringsalgorytmer
        List<Attendee> SortByCampName(List<Attendee> attendees);
        // Metode der sorterer en liste af attendees baseret på deres firstName ved hjælp af forskellige sorteringsalgorytmer
        List<Attendee> SortByFirstName(List<Attendee> attendees, int left, int right);



    }
}
