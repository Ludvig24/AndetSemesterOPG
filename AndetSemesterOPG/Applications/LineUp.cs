using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;


namespace AndetSemesterOPG.Applications
{
    internal class LineUp
    {
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
            }
            throw new ArgumentException("Invalid dag");
        }

        public void AddArtistToLineUp(Artist artist, Grid grid)
        {
            int row = GetRowFromTime(artist.ArtistTime);
            int column = GetColumnFromDate(artist.ArtistDate);
            TextBlock text = new TextBlock();
            text.Text = artist.ArtistName;
            grid.Children.Add(text);
            Grid.SetColumn(text, column);
            Grid.SetRow(text, row);

        }

    }
}
