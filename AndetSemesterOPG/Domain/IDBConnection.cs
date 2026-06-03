using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface IDBConnection
    {
        void Insert(Attendee attendee);
        void InsertArtist(Artist artist);
        void UpdateArtist (Artist artist);
        void RemoveArtist(Artist artist);
        void FindByID(int id);

        List<Camp> ReadAllCamps();
        List<Attendee> FindByEntranceId(int id);
        List<Attendee> FindByCampName(string campName);
        List<Attendee> ReadAll();
        int FindCampCapacity(string campName);
        List<Artist> ReadAllArtist();




    }
}
