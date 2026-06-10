using AndetSemesterOPG.Domain;
using AndetSemesterOPG.UI;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;

namespace AndetSemesterOPG.Applications
{
    //Klasse der håndtere navigationen mellem de forskellige vinduer i wpf applikationen
    internal class WindowNavigator : IWindowNavigator // Tobias
    {
        //Variabler der repræsentere de forskellige vinduer i applikationen
        AttendeeWindow attendeeWindow;
        FestivalWindow festivalWindow;
        MenuWindow menuWindow;
        StageArtistWindow stageArtistWindow;

        //Konstruktor der tager imod de forskellige vinduer som parametre og gemmer dem i instansvariabler
        public void SetWindows(AttendeeWindow attendeeWindow, FestivalWindow festivalWindow, MenuWindow menuWindow, StageArtistWindow stageArtistWindow)
        {
            this.attendeeWindow = attendeeWindow;
            this.festivalWindow = festivalWindow;
            this.menuWindow = menuWindow;
            this.stageArtistWindow = stageArtistWindow;
        }


        //Metode der åbner det vindue der viser information om attendees
        public void OpenAttendeeWindow()
        {
            attendeeWindow.Show();
        }

        //Metode der åbner det vindue der viser information om festivalen
        public void OpenFestivalWindow()
        {
            festivalWindow.Show();
        }

        //Metode som åbner startmenuen
        public void OpenMenuWindow()
        {
            menuWindow.Show();
        }

        //Metode som åbner det vindue der viser information om scenen og artisterne
        public void OpenStageArtistWindow()
        {
            stageArtistWindow.Show();
        }


    }
}
