using AndetSemesterOPG.Domain;
using AndetSemesterOPG.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;

namespace AndetSemesterOPG.Applications
{
    internal class ArtistService
    {
        //Field for klassen
        IArtistRepository artistRepository;

        //Constructor for ArtistService, som tager understående parameter med
        public ArtistService (IArtistRepository artistRepository)
        {
            this.artistRepository = artistRepository;
        }

        //CreateArtist metode, som kalder AddArtist metoden fra Interfacet IArtist Repository
        public void CreateArtist(Artist artist)
        {
            artistRepository.AddArtist(artist);
        }

        //RemoveArtist metode, som kalder DeleteArtist metoden fra Interfacet IArtist Repository
        public void RemoveArtist(Artist artist)
        {
            if (artist == null)
            {
                return;
            }

            artistRepository.DeleteArtist(artist);
        }

        //RetrieveAllArtists metode, som kalder GetAllArtist metoden fra Interfacet IArtist Repository
        public List<Artist> RetrieveAllArtists()
        {
            return artistRepository.GetAllArtists();
        }

        //ModifyArtists metode, som kalder EditArtist metoden fra Interfacet IArtist Repository
        public void ModifyArtist (Artist artist) 
        {
            if (artist.ArtistName == null)
            {
                return;
            }
            if (artist.ArtistTime == null)
            {
                return;
            }
            if (artist.ArtistDate == null)
            {
                return;
            }
            if (artist.StageId == null)
            {  
                return; 
            }
            artistRepository.EditArtist(artist);
        }
    }
}
