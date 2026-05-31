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
        AttendeeWindow attendeeWindow;
        FestivalWindow festivalWindow;
        StageArtistWindow stageArtistWindow;
        public MenuWindow(AttendeeWindow attendeeWindow, FestivalWindow festivalWindow, StageArtistWindow stageArtistWindow)
        {
            InitializeComponent();
            this.attendeeWindow = attendeeWindow;
            this.festivalWindow = festivalWindow;
            this.stageArtistWindow = stageArtistWindow;
        }

        private void AttendeeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            attendeeWindow.Show();
            this.Hide();
        }

        private void FestivalWindowButton_Click(object sender, RoutedEventArgs e)
        {
            festivalWindow.Show();
            this.Hide();
        }

        private void StageArtistWindowButton_Click(object sender, RoutedEventArgs e)
        {
            stageArtistWindow.Show();
            this.Hide();
        }
    }
}
