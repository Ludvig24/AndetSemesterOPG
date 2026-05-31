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
        WindowNavigator windowNavigator;
        internal MenuWindow(WindowNavigator windowNavigator)
        {
            InitializeComponent();
            this.windowNavigator = windowNavigator;
        }

        private void AttendeeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            windowNavigator.OpenAttendeeWindow();
            this.Hide();
        }

        private void FestivalWindowButton_Click(object sender, RoutedEventArgs e)
        {
            windowNavigator.OpenFestivalWindow();
            this.Hide();
        }

        private void StageArtistWindowButton_Click(object sender, RoutedEventArgs e)
        {
            windowNavigator.OpenStageArtistWindow();
            this.Hide();
        }
    }
}
