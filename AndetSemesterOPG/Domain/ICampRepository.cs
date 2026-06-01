using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface ICampRepository
    {
        int GetCampCapacity(string campName);

        List<Camp> GetAllCamps();
    }
}
