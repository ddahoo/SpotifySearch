using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace SpotifySearch
{
    public class Track
    {
        public string Title { get; set; }
        public List<string> Artists { get; set; }
        public string artistsString
        {
            get
            {
                return string.Join(", ", Artists);
            }
        }
        public string Album { get; set; }
        public BitmapImage AlbumArt { get; set; }
        public Uri previewUrl { get; set; }
    }
}
