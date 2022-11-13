using BandMate.MusicCatalog.Models;
using MetaBrainz.MusicBrainz;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandMate.MusicCatalog.Persistence
{
    public class MusicBrainzArtistRepository : IArtistRepository
    {
        public Task<IEnumerable<Album>> GetAlbums(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Artist>> SearchArtistsAsync(string name)
        {
            using (var query = new Query("BandMate", "1.0", "wesleytunnermann@gmail.com"))
            {
                var artists = await query.FindArtistsAsync(name, 5);

                var mbId = artists.Results.FirstOrDefault()?.Item?.Id;

                var artistsWorks = await query.BrowseArtistWorksAsync(mbId.Value);

                var artistList = new List<Artist>();
                foreach (var artist in artists.Results)
                {
                    var songs = await query.BrowseArtistWorksAsync(mbId.Value);
                    artistList.Add(new Artist
                    {
                        Name = artist.Item.Name,
                        //Songs = songs.Results.Select(s => new Song
                        //{
                        //    Title = s.Title,
                        //}),
                    });
                }

                return artistList;
            }
        }
    }
}