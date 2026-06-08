using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;


namespace AndetSemesterOPG.Applications
{
    //Klasse der indeholder forskellige sorteringsalgoritmer til at sortere festivalens deltagere efter forskellige kriterier
    internal class Sort : ISort
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
        public List<Attendee> SortByFirstName(List<Attendee> attendees, int left, int right)
        {

            if (attendees.Count <= 1 || attendees == null)
            {
                MessageBox.Show("Der er ikke noget at sortere");
                return null;
            }

            int i = left;
            int j = right;

            string pivot = attendees[(left+right)/2].AttendeeFirstName;

            while(i <= j)
            {
                //String.Compare returnerer 1, 0 eller -1 -> 0 svarer til ens strings, -1 svarer til at første string skal placeres før den næste string. 1 svarer til at første string skal placeres efter den næste
                while (String.Compare(attendees[i].AttendeeFirstName, pivot) < 0)
                {
                    i++;
                }
                while(String.Compare(attendees[j].AttendeeFirstName, pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    Attendee attendee = attendees[i];
                    attendees[i] = attendees[j];
                    attendees[j] = attendee;
                    i++;
                    j--;
                }
            }

            if(left < j)
            {
                SortByFirstName(attendees,left,j);
            }

            if (i < right)
            {
                SortByFirstName(attendees, i, right);
            }
            return attendees;
        }

    }
}
