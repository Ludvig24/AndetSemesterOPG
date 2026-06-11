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


        public int bubbleComparisons { get; set; }
        public int insertComparisons { get; set; }
        public int quickComparisons { get; set; }        
        
        //Bubblesort

        //Metode der sorterer en liste af attendees baseret på deres entranceId ved hjælp af bubble sort algoritmen
        //Bubble sort algoritme der sammenligner hvert element i listen med det næste element, og bytter dem hvis de er i forkert rækkefølge, indtil hele listen er sorteret
        public List<Attendee> SortByEntranceId(List<Attendee> attendees) //Emil & Ludvig
        {
            bubbleComparisons++; // Bruges til at kunne teste effektivitet

            //Tjekker om listen er null eller indeholder 1 eller færre elementer, og viser en besked hvis det er tilfældet
            if (attendees == null || attendees.Count <= 1)
            {
                MessageBox.Show("Der er ikke noget at sortere");
                return null;
            }
            // En bool der holder styr på om der er blevet byttet elementer i den seneste gennemgang af listen
            bool swapped = true;
            // Så længe der er blevet byttet elementer i den seneste gennemgang, fortsætter algoritmen med at gennemgå listen
            while (swapped == true)
            {
                swapped = false;
                // forloop der sammenligner hvert element i listen med det næste element
                for (int i = 1; i < attendees.Count; i++)
                {
                    bubbleComparisons++;
                    //Hvis det forrige element har en større entranceId end det næste element, byttes de to elementer
                    if (attendees[i - 1].EntranceId > attendees[i].EntranceId)
                    {
                        // Bytter elementerne ved at gemme det forrige element i en midlertidig variabel, og derefter sætte det forrige element til det næste element
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
        //Metode der sorterer en liste af attendees baseret på deres campName ved hjælp af insertion sort algoritmen
        // Insertion sort algoritme der deler listen op i en sorteret og en usorteret del,
        // og indsætter hvert element fra den usorterede del på dets korrekte plads i den sorterede del, indtil hele listen er sorteret
        public List<Attendee> SortByCampName(List<Attendee> attendees) //Laura
        {
            // Tjekker om listen er null eller indeholder 1 eller færre elementer, og viser en besked hvis det er tilfældet
            if (attendees == null || attendees.Count <= 1)
            {
                MessageBox.Show("Der er ikke noget at sortere");
                return null;
            }
            // Forloop der starter ved det andet element i listen, og sammenligner det med de forrige elementer i den sorterede del af listen
            for (int i = 1; i < attendees.Count; i++)
            {
                // Gemmer det aktuelle element i en midlertidig variabel, og bruger en pointer til at holde styr på positionen i den sorterede del af listen
                Attendee attendee = attendees[i];
                int pointer = i;
                // Så længe pointeren er større end 0, og det forrige element i den sorterede del af listen har et campName der kommer efter det aktuelle elements campName i alfabetisk rækkefølge, flyttes det forrige element en plads til højre, og pointeren flyttes en plads til venstre
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
        //Metode der sorterer en liste af attendees baseret på deres firstName ved hjælp af quick sort algoritmen
        // Quick sort algoritme der vælger et pivot element, og deler listen op i to dele baseret på
        // om elementerne kommer før eller efter pivot elementet i alfabetisk rækkefølge,
        // og derefter sorterer hver del rekursivt ved at vælge nye pivot elementer, indtil hele listen er sorteret
        public List<Attendee> SortByFirstName(List<Attendee> attendees, int left, int right) //Tobias
        {

            quickComparisons++;
            // Tjekker om listen er null eller indeholder 1 eller færre elementer, og viser en besked hvis det er tilfældet
            if (attendees == null || attendees.Count <= 1)
            {
                MessageBox.Show("Der er ikke noget at sortere");
                return null;
            }

            int i = left;
            int j = right;

            //vælger pivot element
            string pivot = attendees[(left+right)/2].AttendeeFirstName;

            while(i <= j)
            {
                //String.Compare returnerer 1, 0 eller -1 -> 0 svarer til ens strings, -1 svarer til at første string skal placeres før den næste string.
                //1 svarer til at første string skal placeres efter den næste. og bruges til at sammenligne to strings i alfabetisk rækkefølge
                while (true)
                {
                    quickComparisons++;
                    // Så længe det aktuelle element kommer før pivot elementet i alfabetisk rækkefølge, flyttes pointeren i en plads til højre
                    if (String.Compare(attendees[i].AttendeeFirstName, pivot) < 0)
                        i++;
                    else
                        break;
                }
                while (true)
                {
                    quickComparisons++;
                    // Så længe det aktuelle element kommer efter pivot elementet i alfabetisk rækkefølge, flyttes pointeren i en plads til venstre
                    if (String.Compare(attendees[j].AttendeeFirstName, pivot) > 0)
                        j--;
                    else
                        break;
                }

                if (i <= j)
                {
                    // Bytter elementerne ved at gemme dem
                    Attendee attendee = attendees[i];
                    attendees[i] = attendees[j];
                    attendees[j] = attendee;
                    i++;
                    j--;
                }
            }
            // Hvis der er elementer i den venstre del af listen, sorteres den venstre del rekursivt
            if (left < j)
            {
                SortByFirstName(attendees,left,j);
            }
            // Hvis der er elementer i den højre del af listen, sorteres den højre del rekursivt
            if (i < right)
            {
                SortByFirstName(attendees, i, right);
            }

            
            return attendees;
            
        }



    }
}
