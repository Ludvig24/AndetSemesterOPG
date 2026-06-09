using AndetSemesterOPG.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface IWindowNavigator

    {
        ////Konstruktor der tager imod de forskellige vinduer som parametre og gemmer dem i instansvariabler
        void SetWindows(AttendeeWindow attendeeWindow, FestivalWindow festivalWindow, MenuWindow menuWindow, StageArtistWindow stageArtistWindow);
        //Metoder til at åbne de forskellige vinduer, som kalder Show() metoden på det respektive vindue
        void OpenAttendeeWindow();
        void OpenFestivalWindow();
        void OpenMenuWindow();
        void OpenStageArtistWindow();

    }
}
