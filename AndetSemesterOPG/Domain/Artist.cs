using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace AndetSemesterOPG.Domain
{
    internal class Artist
    {
        string artistName;
        int artistId;
        string artistDate;
        string artistTime;
        int stageId;

        public Artist (string artistName, string artistDate, string artistTime, int stageId)
        {
            this.artistName = artistName;
            this.artistDate = artistDate;
            this.artistTime = artistTime;
            this.stageId = stageId;
        }
    }
}
