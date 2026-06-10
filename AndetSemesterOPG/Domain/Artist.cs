using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace AndetSemesterOPG.Domain
{
    //Klasse der repræsentere en artist, og indeholder information om artisten
    internal class Artist // Emil
    {
        //Properties for Artist
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string ArtistDate { get; set; }
        public string ArtistTime { get; set; }
        public int StageId {  get; set; }

        //Contructor Artist, som tager understående argumenter med.
        public Artist (string ArtistName, string ArtistTime, string ArtistDate, int StageId)
        {
            this.ArtistName = ArtistName;
            this.ArtistDate = ArtistDate;
            this.ArtistTime = ArtistTime;
            this.StageId = StageId;
        }
    }
}
