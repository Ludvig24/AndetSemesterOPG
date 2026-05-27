using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace AndetSemesterOPG.Domain
{
    internal class Artist
    {
        public string ArtistName { get; set; }
        public string ArtistDate { get; set; }
        public string ArtistTime { get; set; }
        public int StageId {  get; set; }

        public Artist (string ArtistName, string ArtistDate, string ArtistTime, int StageId)
        {
            this.ArtistName = ArtistName;
            this.ArtistDate = ArtistDate;
            this.ArtistTime = ArtistTime;
            this.StageId = StageId;
        }
    }
}
