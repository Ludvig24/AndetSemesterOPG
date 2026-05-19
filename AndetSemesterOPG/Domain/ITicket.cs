using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface ITicket
    {
        string ticketType { get; set; }
        string entrancetype { get; set; }
        string campName { get; set; }

        
    }
}
