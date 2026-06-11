using System;
using System.Collections.Generic;
using System.Text;
using AndetSemesterOPG.Domain;

namespace AndetSemesterOPG.Infrastructure
{
    //Klasse der implementerer ICampRepository og bruger IDBConnection til at hente data om camps fra databasen
    internal class CampRepository : ICampRepository // Laura
    {
        //IDBConnection bruges til at hente data om camps fra databasen
        IDBConnection connection;

        //Konstruktor der tager en IDBConnection som parameter og gemmer den i en instansvariabel
        public CampRepository(IDBConnection connection)
        {
            this.connection = connection;
        }

        //Metode der bruger IDBConnection til at hente kapaciteten for en given camp
        public int GetCampCapacity(string campName)
        {
            return connection.FindCampCapacity(campName);
        }

        //Metode der bruger IDBConnection til at hente en liste over alle camps i databasen
        public List<Camp> GetAllCamps()
        {
            return connection.ReadAllCamps();
        }
    }
}
