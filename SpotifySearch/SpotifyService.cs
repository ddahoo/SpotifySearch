using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace SpotifySearch
{
    public class SpotifyService
    {
        public async Task<List<Track>> GetTracks(string trackQuery)
        {
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();
            List<Track> tracks = new List<Track>();
            string reqString = $"https://api.spotify.com/v1/search?q={trackQuery}&type=track&offset=20";
            Uri requestUri = new Uri(reqString);
            Windows.Web.Http.HttpResponseMessage httpResponse = new Windows.Web.Http.HttpResponseMessage();
            string responseBody = "";
            try
            {
                httpResponse = await httpClient.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                responseBody = await httpResponse.Content.ReadAsStringAsync();                
                JObject spotifySearch = JObject.Parse(responseBody);
                foreach(var item in spotifySearch["tracks"]["items"])
                {
                    var artists = from p in item["artists"].Children()
                                  select (string)p["name"];
                    tracks.Add(new Track
                    {
                        Title = (string)item["name"],
                        Artists = new List<string>(artists),
                        Album = (string)item["album"]["name"],
                        AlbumArt = new Windows.UI.Xaml.Media.Imaging.BitmapImage((Uri)item["album"]["images"][0]["url"]),
                        previewUrl = new Uri((string)item["preview_url"])
                    });
                }
                return tracks;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return tracks;
            }
        }
    }
}
