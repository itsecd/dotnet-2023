namespace Artist.Tests;

using Media.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MediaFixture
{
    public List<Genre> FixtureGenres {
        get
        {
            var artists = new List<Artist>();
            for (var i = 0; i < 4; i++)
            {
                var artist = new Artist();
                artist.ArtistId = i;
                artist.Name = "Artist №" + i.ToString();
                artist.Description = "Description about artist №" + i.ToString();
                artists.Add(artist);
            }

            var alboms = new List<Albom>();
            for (var i = 0; i < 6; i++)
            {
                var albom = new Albom();
                albom.AlbomId = i;
                albom.Name = "Albom №" + i.ToString() + " of Artist №" + (i % 4).ToString();
                albom.Year = 2000 + i%4;
                albom.Artist = artists[i % 4];
                alboms.Add(albom);
            }

            var tracks = new List<Track>();
            for (var i = 0; i < 12; i++)
            {
                var track = new Track();
                track.TrackId = i;
                track.Duration = i*100 % 301;
                track.Number = Convert.ToInt32(i / 6) + 1;
                track.Albom = alboms[i % 6];
                track.Name = "Track №" + i.ToString() + "in Albom №" + (i % 6).ToString();
                tracks.Add(track);
            }

            var genres = new List<Genre>();
            for (var i = 0; i < 3; i++)
            {
                var genre = new Genre();
                genre.GenreId = i;
                genre.Name = "Genre №" + i.ToString();
                genre.Tracks = new List<Track>();
                for (var j = 0; j < 4; j++)
                {
                    genre.Tracks.Add(tracks[i * 4 + j]);
                }
                genres.Add(genre);
            }
            return genres;
        }
    }
}
