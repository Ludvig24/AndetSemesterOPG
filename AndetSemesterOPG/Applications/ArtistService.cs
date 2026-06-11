using AndetSemesterOPG.Domain;
using AndetSemesterOPG.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;

namespace AndetSemesterOPG.Applications
{
    //Klasse der implementerer logikken for at håndtere artists
    internal class ArtistService : IArtistService  //Ludvig
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

        //Er lavet for at der ikke kan laves flere kunstnere på samme dag,tid og scene
        public bool IsSlotTaken(Artist newArtist)
        {
            List<Artist> artistsListe = RetrieveAllArtists();
            //Any ser igennem listen og retunere en bool afhægig af om den indeholder det krav der kommer. Og lamda udtrykket => betyder "for hver Artist i listen, kør disse krav
            return artistsListe.Any(artist =>
            //Den første er til for at hvis vi kalder update, og ikke ændre tid,dato og scene, så kan den stadig opdatere den kunstner på samme plads i skemaet
                artist.ArtistId != newArtist.ArtistId &&
                artist.StageId == newArtist.StageId &&
                artist.ArtistDate == newArtist.ArtistDate &&
                artist.ArtistTime == newArtist.ArtistTime);
        }
    }
}
