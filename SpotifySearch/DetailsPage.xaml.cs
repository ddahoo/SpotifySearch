using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SpotifySearch
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsPage : Page
    {
        Track trackDetails = new Track();

        public DetailsPage()
        {
            this.InitializeComponent();                       
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            trackDetails = (Track)e.Parameter;
            albumArtImage.Source = trackDetails.AlbumArt;
            artistText.Text = trackDetails.artistsString;
            titleText.Text = trackDetails.Title;
            albumText.Text = trackDetails.Album;
            mediaPlayer.Source = MediaSource.CreateFromUri(trackDetails.previewUrl);
            mediaPlayer.AutoPlay = true;            
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            mediaPlayer.MediaPlayer.Pause();
            mediaPlayer.MediaPlayer.Source = null;
        }
    }
}
