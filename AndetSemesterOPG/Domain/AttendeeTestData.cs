using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    //Klasse der indeholder data der skal tilføjes til festivalens deltagere
    internal class AttendeeTestData // Tobias
    {
        //Lister der indeholder 100 fornavne og 100 efternavne
        List<string> firstNames = ["Anna", "Peter", "Maria", "Jens", "Sofie", "Lars", "Emma", "Mikkel", "Julie", "Thomas", "Freja", "Henrik", "Clara", "Kasper", "Ida", "Anders", "Laura", "Martin", "Alberte", "Rasmus", "Camilla", "Nicolai", "Katrine", "Christian", "Mathilde", "Frederik", "Josefine", "Søren", "Amalie", "Emil", "Cecilie", "Jacob", "Line", "Oliver", "Sarah", "Gustav", "Louise", "Magnus", "Nanna", "Victor", "Mia", "Simon", "Astrid", "Anton", "Helene", "Noah", "Liv", "Sebastian", "Ellen", "Tobias", "Eva", "Alexander", "Alma", "William", "Johanne", "Philip", "Agnes", "Felix", "Karoline", "Benjamin", "Elina", "Oscar", "Emilie", "Lucas", "Frida", "Jonathan", "Vera", "Elias", "Aya", "Daniel", "Selma", "Malte", "Signe", "Johan", "Esther", "August", "Lærke", "Valdemar", "Isabella", "Pelle", "Ronja", "Villads", "Andrea", "Rune", "Maja", "Troels", "Gry", "Aksel", "Olivia", "Bjørn", "Rosa", "Erik", "Monika", "Leif", "Tilde", "Allan", "Rebekka", "Kim", "Ditte", "Bo", "Yasmine"];
        List<string> lastNames = ["Andersen", "Jensen", "Nielsen", "Hansen", "Pedersen", "Christensen", "Larsen", "Sørensen", "Rasmussen", "Jørgensen", "Petersen", "Madsen", "Kristensen", "Olsen", "Thomsen", "Christiansen", "Poulsen", "Johansen", "Møller", "Mortensen", "Knudsen", "Eriksen", "Jacobsen", "Jakobsen", "Svendsen", "Lauridsen", "Friis", "Berg", "Holm", "Bundgaard", "Jeppesen", "Vestergaard", "Aagaard", "Krogh", "Winther", "Toft", "Lund", "Bach", "Bruun", "Overgaard", "Dahl", "Skov", "Vad", "Kjær", "Hviid", "Schou", "Nørgaard", "Sejersen", "Østergaard", "Buhl", "Falk", "Mejer", "Gade", "Kruse", "Bonde", "Enevoldsen", "Due", "Iversen", "Lykke", "Myhre", "Rohde", "Bisgaard", "Kirk", "Bjerre", "Torp", "Schiøtz", "Elkjær", "Funch", "Hald", "Leth", "Wulff", "Stage", "Barfoed", "Dons", "Guldberg", "Heide", "Koch", "Lassen", "Munk", "Quist", "Riis", "Sabroe", "Tange", "Uhrenholt", "Valeur", "Wessel", "Yde", "Zahle", "Aistrup", "Balle", "Clemmensen", "Dalgaard", "Eskildsen", "Fog", "Graversen", "Hesselberg", "Illum", "Juul", "Kappel", "Lindholm", "Meldgaard", "Nymann"];

        //Metode der kombinerer et tilfældigt fornavn og et tilfældigt efternavn fra listerne, og returnerer dem som en liste
        public List<string> NameCombiner()
        {
            Random r = new Random();
            string randomFirstName = firstNames[r.Next(0, firstNames.Count)];
            string randomLastName = lastNames[r.Next(0, lastNames.Count)];

            List<string> name = [randomFirstName, randomLastName];
            return name;

        }


    }


}
