using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    //Interface der definerer en repository til at hente information om camps fra databasen
    internal interface ICampRepository //Emil
    {
        //Metode der henter kapaciteten for en given camp fra databasen og returnerer den som en int
        int GetCampCapacity(string campName);

        //Metode der henter alle camps fra databasen og returnerer dem som en liste
        List<Camp> GetAllCamps();
    }
}
