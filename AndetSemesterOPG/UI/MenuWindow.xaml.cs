using AndetSemesterOPG.Applications;
using AndetSemesterOPG.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AndetSemesterOPG.UI
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        //Oprettelse af WindowNavigator, som bruges til at navigere mellem vinduerne i applikationen
        WindowNavigator windowNavigator;

        //Constructor for MenuWindow, hvor vi initialisere WindowNavigator
        internal MenuWindow(WindowNavigator windowNavigator)
        {
            InitializeComponent();
            this.windowNavigator = windowNavigator;
        }

        //Metode der åbner AttendeeWindow og skjuler MenuWindow, når brugeren klikker på "Attendees" knappen
        private void AttendeeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            windowNavigator.OpenAttendeeWindow();
            this.Hide();
        }

        //Metode der åbner FestivalWindow og skjuler MenuWindow, når brugeren klikker på "Festival" knappen
        private void FestivalWindowButton_Click(object sender, RoutedEventArgs e)
        {
            windowNavigator.OpenFestivalWindow();
            this.Hide();
        }

        //Metode der åbner StageArtistWindow og skjuler MenuWindow, når brugeren klikker på "Stage Artists" knappen
        private void StageArtistWindowButton_Click(object sender, RoutedEventArgs e)
        {
            windowNavigator.OpenStageArtistWindow();
            this.Hide();
        }
    }
}
