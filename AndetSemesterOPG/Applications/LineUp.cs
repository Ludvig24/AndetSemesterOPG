using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;


namespace AndetSemesterOPG.Applications
{
    internal class LineUp
    {
        ArtistService artistService;
        List<Artist> artistList;
        public LineUp(ArtistService artistService)
        {
            this.artistService = artistService;
        }
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

        public void AddArtistToLineUp(List<Grid> stages)
        {
            artistList = artistService.RetrieveAllArtists();

            for(int i = 1; i < stages.Count+1; i++)
            {
                
                for(int j = 0; j < artistList.Count; j++)
                {
                    if (artistList[j].StageId == i)
                    {
                        int row = GetRowFromTime(artistList[j].ArtistTime);
                        int column = GetColumnFromDate(artistList[j].ArtistDate);
                        TextBlock text = new TextBlock();
                        text.Text = artistList[j].ArtistName;

                        stages[i-1].Children.Add(text);
                        Grid.SetColumn(text, column);
                        Grid.SetRow(text, row);
                    }
                }

                
            }

        }

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
