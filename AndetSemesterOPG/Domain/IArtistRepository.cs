using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    //Interface der definerer en repository til at hente information om artists fra databasen, og indeholder metoderne dertil
    internal interface IArtistRepository
    {
        //Metode der tilføjer en artist til databasen
        void AddArtist(Artist artist);

        //Metode der henter alle artists fra databasen
        List<Artist> GetAllArtists();

        //Metode der sletter en artist fra databasen
        void DeleteArtist(Artist artist);

        //Metode der opdaterer en artist i databasen
        void EditArtist(Artist artist);
    }
}
