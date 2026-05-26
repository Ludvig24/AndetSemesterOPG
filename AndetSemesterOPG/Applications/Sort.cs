using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    internal class Sort
    {


        //Bubblesort
        public List<Attendee> SortByEntranceId(List<Attendee> attendees)
        {
 
            bool swapped = true;
            while (swapped == true)
            {
                swapped = false;
                for (int i = 1; i < attendees.Count - 1; i++)
                {

                    if (attendees[i - 1].EntranceId > attendees[i].EntranceId)
                    {
                        Attendee attendee = attendees[i - 1];
                        attendees[i - 1] = attendees[i];
                        attendees[i] = attendee;
                        swapped = true;



                    }
                }
            }
            return attendees; 
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
