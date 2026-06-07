using AndetSemesterOPG.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Domain
{
    internal interface IWindowNavigator
    {
        void SetWindows(AttendeeWindow attendeeWindow, FestivalWindow festivalWindow, MenuWindow menuWindow, StageArtistWindow stageArtistWindow);

        void OpenAttendeeWindow();
        void OpenFestivalWindow();
        void OpenMenuWindow();
        void OpenStageArtistWindow();

    }
}
