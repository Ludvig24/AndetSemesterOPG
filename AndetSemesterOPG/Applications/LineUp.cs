using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;


namespace AndetSemesterOPG.Applications
{
    //Klasse der repræsentere festivalens line-up, og indeholder metoder til at tilføje og fjerne artister fra line-uppet
    internal class LineUp // Tobias
    {
        //Variabler der skal bruges i klassen
        IArtistService artistService;
        List<Artist> artistList;

        //Konstruktor der tager en ArtistService som parameter og gemmer den i en instansvariabel
        public LineUp(IArtistService artistService)
        {
            this.artistService = artistService;
        }

        //Metode der tager en tid som parameter og returnere den tilsvarende række i line-uppet
        public int GetRowFromTime(string time)
        {
            switch (time)
            {
                case "16:00":
                    return 0;
                case "18:00":
                    return 1;
                case "20:00":
                    return 2;
                case "22:00":
                    return 3;
                case "":
                    break;
            }
            throw new ArgumentException("Invalid tid");
        }

        //Metode der tager en dag som parameter og returnere den tilsvarende kolonne i line-uppet
        public int GetColumnFromDate(string day)
        {
            switch (day)
            {
                case "Onsdag":
                    return 0;
                case "Torsdag":
                    return 1;
                case "Fredag":
                    return 2;
                case "Lørdag":
                    return 3;
                case "Søndag":
                    return 4;
                case "":
                    break;

            }
            
            throw new ArgumentException("Invalid dag");
        }

        //Metode der tager en liste af Grid som parameter og tilføjer artisterne i artistList til line-uppet baseret på deres StageId, ArtistTime og ArtistDate
        public void AddArtistToLineUp(List<Grid> stages)
        {
            artistList = artistService.RetrieveAllArtists();

            //itererer gennem stages
            for(int i = 1; i < stages.Count+1; i++)
            {
                //itererer gennem listen af artists
                for(int j = 0; j < artistList.Count; j++)
                {
                    //tjekker om artist på index j's StageId er lig i
                    if (artistList[j].StageId == i)
                    {
                        //gemmer række og kolonne hentet med GetRowFromTime() og GetColumnFromDate() metoderne
                        int row = GetRowFromTime(artistList[j].ArtistTime);
                        int column = GetColumnFromDate(artistList[j].ArtistDate);

                        //Opretter TextBlock der skal holde en artists navn
                        TextBlock text = new TextBlock();
                        text.Text = artistList[j].ArtistName;

                        //Tildeler textblocken som child-element til Grid'et på indeks i-1
                        stages[i-1].Children.Add(text);

                        //setter textblocken i grid'et
                        Grid.SetColumn(text, column);
                        Grid.SetRow(text, row);
                       
                    }
                }

                
            }

        }

        //Metode der tager en liste af Grid som parameter og fjerner alle artisterne fra line-uppet ved at sætte RowDefinitions og ColumnDefinitions til null
        public void RemoveArtistFromLineUp(List<Grid> stages)
        {
            foreach(Grid grid in stages)
            {
                grid.RowDefinitions = null;
                grid.ColumnDefinitions = null;

            }
        }

    }
}
