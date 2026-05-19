using System;
using System.Collections.Generic;
using System.Text;
<<<<<<< HEAD

namespace AndetSemesterOPG.Applications
{
    internal class EntranceEastFactory
    {
=======
using AndetSemesterOPG.Domain;

namespace AndetSemesterOPG.Applications
{
    internal class EntranceEastFactory : ITicketFactory
    {
        
        public ITicket CreateCampA()
        {
            EntranceEastCampA entranceEastCampA = new EntranceEastCampA();
            return (ITicket)entranceEastCampA;
        }
        public ITicket CreateCampB() 
        {
            EntranceEastCampA entranceEastCampA = new EntranceEastCampA();
            return (ITicket)entranceEastCampA;
        }
>>>>>>> 7f26fa67b3a08424797822f6336829e6d016dc66
    }
}
