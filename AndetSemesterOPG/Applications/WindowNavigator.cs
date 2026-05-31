using AndetSemesterOPG.UI;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    internal class WindowNavigator
    {
        AttendeeWindow attendeeWindow;
        FestivalWindow festivalWindow;
        MenuWindow menuWindow;
        StageArtistWindow stageArtistWindow;

        public void SetWindows(AttendeeWindow attendeeWindow, FestivalWindow festivalWindow, MenuWindow menuWindow, StageArtistWindow stageArtistWindow)
        {
            this.attendeeWindow = attendeeWindow;
            this.festivalWindow = festivalWindow;
            this.menuWindow = menuWindow;
            this.stageArtistWindow = stageArtistWindow;
        }



        public void OpenAttendeeWindow()
        {
            attendeeWindow.Show();
        }

        public void OpenFestivalWindow()
        {
            festivalWindow.Show();
        }

        public void OpenMenuWindow()
        {
            menuWindow.Show();
        }

        public void OpenStageArtistWindow()
        {
            stageArtistWindow.Show();
        }


    }
}
