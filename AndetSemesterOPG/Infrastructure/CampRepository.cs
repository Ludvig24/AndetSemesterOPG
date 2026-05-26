using System;
using System.Collections.Generic;
using System.Text;
using AndetSemesterOPG.Domain;

namespace AndetSemesterOPG.Infrastructure
{
    internal class CampRepository : ICampRepository
    {
        DBConnection connection;

        public CampRepository(DBConnection connection)
        {
            this.connection = connection;
        }

        public int GetCampCapacity(string campName)
        {
            return connection.FindCampCapacity(campName);
        }
    }
}
