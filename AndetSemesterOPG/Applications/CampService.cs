using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    internal class CampService
    {
        ICampRepository campRepository;
        public CampService(ICampRepository campRepository)
        {
            this.campRepository = campRepository;
        }

        public int RetrieveCampCapacity(string campName)
        {
            return campRepository.GetCampCapacity(campName);
        }

        
    }
}
