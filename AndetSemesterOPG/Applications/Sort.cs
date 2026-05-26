using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    internal class Sort
    {


        //Bubblesort

        //lav counter der tæller antal sammenligninger - kan bruges som en form for test af hvilken sorting algoritme der er bedst i vores tilfælde - dette kan vi skrive om i rapport
        public List<Attendee> SortByEntranceId(List<Attendee> attendees)
        {
 
            bool swapped = true;
            while (swapped == true)
            {
                swapped = false;
                for (int i = 1; i < attendees.Count; i++)
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

     

        //Insertion sort
        public List<Attendee> SortByCampName(List<Attendee> attendees)
        {


            for(int i = 1; i < attendees.Count; i++)
            {
                Attendee attendee = attendees[i];
                int pointer = i;
                while (pointer > 0 && attendee.CampName[5] < attendees[pointer - 1].CampName[5])
                {
                    attendees[pointer] = attendees[pointer - 1];
                    pointer = pointer - 1;
                }
                attendees[pointer] = attendee;
            }

            return attendees;

        }

        //Quick sort
        public List<Attendee> SortByFirstName()
        {
            return null;
        }

    }
}
