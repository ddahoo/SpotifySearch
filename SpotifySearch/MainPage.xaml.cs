using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SpotifySearch
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<Track> trackList = new List<Track>();
        public MainPage()
        {
            this.InitializeComponent();
            trackListView.ItemsSource = trackList;
        }

        private void trackListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var music = (Track)e.ClickedItem;
            this.Frame.Navigate(typeof(DetailsPage), music);
        }

        private async void searchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (sender.Text != null)
            {
                var service = new SpotifyService();
                var searchString = (sender.Text).Replace(" ", "+");
                trackList = await service.GetTracks(searchString);
                trackListView.ItemsSource = trackList;
            }            
        }
    }
}
