using AndetSemesterOPG.Domain;
using AndetSemesterOPG.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    internal class ArtistService
    {
        IArtistRepository artistRepository;

        public ArtistService (IArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
        }
        public void CreateArtist(Artist artist)
        {
            artistRepository.AddArtist(artist);
        }

        public void RemoveArtist(Artist artist)
        {
            artistRepository.DeleteArtist(artist);
        }

        public List<Artist> RetrieveAllArtists()
        {
            return artistRepository.GetAllArtists();
        }
    }
}
