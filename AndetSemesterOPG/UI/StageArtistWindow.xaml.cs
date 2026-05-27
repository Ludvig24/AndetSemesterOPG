using AndetSemesterOPG.Applications;
using AndetSemesterOPG.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Interaction logic for StageArtistWindow.xaml
    /// </summary>
    public partial class StageArtistWindow : Window
    {
        public StageArtistWindow()
        {
            InitializeComponent();
            
            ArtistService artistService = new ArtistService(new ArtistRepository(new DBConnection()));

            artistService.RetrieveAllArtists().ForEach(artist =>
            {
                LineUp lineUp = new LineUp();
                lineUp.AddArtistToLineUp(artist, Schedule_Orange);
            });




        }


    }
}
