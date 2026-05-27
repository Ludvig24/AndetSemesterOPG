using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface IArtistRepository
    {
        void AddArtist(Artist artist);

        void GetAllArtists();

        void DeleteArtist(Artist artist);
    }
}
