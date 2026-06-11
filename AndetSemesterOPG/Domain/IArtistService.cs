using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface IArtistService // Laura
    {
        // metode der opretter en artist, og tager en artist som parameter
        void CreateArtist(Artist artist);
        // metode der fjerner en artist, og tager en artist som parameter
        void RemoveArtist(Artist artist);
        // metode der henter alle artister, og returnerer en liste af artister
        List<Artist> RetrieveAllArtists();
        // metode der henter en artist, og tager en artist som parameter
        void ModifyArtist(Artist artist);
        // metode der tjekker om en slot(plads) er taget, og tager en artist som parameter, og returnerer en bool
        bool IsSlotTaken(Artist newArtist);

    }
}
