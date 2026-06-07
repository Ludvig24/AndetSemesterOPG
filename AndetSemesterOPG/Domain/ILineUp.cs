using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace AndetSemesterOPG.Domain
{
    internal interface ILineUp
    {
        int GetRowFromTime(string time);

        int GetColumnFromDate(string day);

        void AddArtistToLineUp(List<Grid> stages);

        void RemoveArtistFromLineUp(List<Grid> stages);
    }
}
