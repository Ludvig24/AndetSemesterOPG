using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Infrastructure
{
    //Klasse der implementerer IArtistRepository og bruger IDBConnection til at hente data om artists fra databasen
    internal class ArtistRepository : IArtistRepository //Tobias
    {
        //IDBConnection bruges til at hente data om artists fra databasen
        IDBConnection connection;

        //Konstruktor der tager en IDBConnection som parameter og gemmer den i en instansvariabel
        public ArtistRepository(IDBConnection connection)
        {
            this.connection = connection;
        }

        //Metode der bruger IDBConnection til at tilføje en artist til databasen
        public void AddArtist(Artist artist)
        {
            connection.InsertArtist(artist);
        }

        //Metode der bruger IDBConnection til at hente alle artists fra databasen og returnere dem som en liste
        public List<Artist> GetAllArtists()
        {
            return connection.ReadAllArtist();
        }

        //Metode der bruger IDBConnection til at fjerne en artist fra databasen
        public void DeleteArtist(Artist artist)
        {
            connection.RemoveArtist(artist);
        }

        //Metode der bruger IDBConnection til at opdatere en artist i databasen
        public void EditArtist (Artist artist) 
        {
            connection.UpdateArtist(artist);
        }
    }
}
