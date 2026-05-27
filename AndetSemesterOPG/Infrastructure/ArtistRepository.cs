using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Infrastructure
{
    internal class ArtistRepository : IArtistRepository
    {
        DBConnection connection;

        public ArtistRepository(DBConnection connection)
        {
            this.connection = connection;
        }

        public void AddArtist(Artist artist)
        {
            connection.InsertArtist(artist);
        }

        public void GetAllArtists()
        {

        }

        public void DeleteArtist(Artist artist)
        {
            connection.RemoveArtist(artist);
        }
    }
}
