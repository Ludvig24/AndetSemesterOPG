using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Infrastructure
{
    internal class ArtistRepository : IArtistRepository
    {
        IDBConnection connection;

        public ArtistRepository(IDBConnection connection)
        {
            this.connection = connection;
        }


        public void AddArtist(Artist artist)
        {
            connection.InsertArtist(artist);
        }

        public List<Artist> GetAllArtists()
        {
            return connection.ReadAllArtist();
        }

        public void DeleteArtist(Artist artist)
        {
            connection.RemoveArtist(artist);
        }

        public void EditArtist (Artist artist) 
        {
            connection.UpdateArtist(artist);
        }
    }
}
