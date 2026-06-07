using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface IArtistService
    {
        void CreateArtist(Artist artist);

        void RemoveArtist(Artist artist);

        List<Artist> RetrieveAllArtists();

        void ModifyArtist(Artist artist);

        bool IsSlotTaken(Artist newArtist);

    }
}
