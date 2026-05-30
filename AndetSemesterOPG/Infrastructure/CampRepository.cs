using System;
using System.Collections.Generic;
using System.Text;
using AndetSemesterOPG.Domain;

namespace AndetSemesterOPG.Infrastructure
{
    internal class CampRepository : ICampRepository
    {
        IDBConnection connection;

        public CampRepository(IDBConnection connection)
        {
            this.connection = connection;
        }

        public int GetCampCapacity(string campName)
        {
            return connection.FindCampCapacity(campName);
        }
    }
}
