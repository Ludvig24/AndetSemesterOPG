using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal class Entrance
    {
        int entranceID;
        string entranceName;
        List<Attendee> entranceAttendees;
        int entranceCounter;

        Entrance(int entranceID, string entranceName)
        {
            this.entranceID = entranceID;
            this.entranceName = entranceName;
            this.entranceAttendees = new List<Attendee>();
            this.entranceCounter = 0;
        }

    }
}
