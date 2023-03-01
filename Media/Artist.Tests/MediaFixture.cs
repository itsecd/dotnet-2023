namespace Artist.Tests;

using Media.Domain;
using System;
using System.Collections.Generic;

public class MediaFixture
{
    public List<Genre> FixtureGenres
    {
        get
        {
            var artists = new List<Artist>();
            for (var i = 0; i < 4; i++)
            {
                var artist = new Artist();
                artist.Id = i;
                artist.Name = "Artist №" + i.ToString();
                artist.Description = "Description about artist №" + i.ToString();
                artists.Add(artist);
            }

            var Albums = new List<Album>();
            for (var i = 0; i < 6; i++)
            {
                var Album = new Album();
                Album.Id = i;
                Album.Name = "Album №" + i.ToString() + " of Artist №" + (i % 4).ToString();
                Album.Year = 2000 + i % 4;
                Album.Artist = artists[i % 4];
                Albums.Add(Album);
            }

            var tracks = new List<Track>();
            for (var i = 0; i < 12; i++)
            {
                var track = new Track();
                track.Id = i;
                track.Duration = i * 100 % 301;
                track.Number = Convert.ToInt32(i / 6) + 1;
                track.Album = Albums[i % 6];
                track.Name = "Track №" + i.ToString() + "in Album №" + (i % 6).ToString();
                tracks.Add(track);
            }

            var genres = new List<Genre>();
            for (var i = 0; i < 3; i++)
            {
                var genre = new Genre();
                genre.Id = i;
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
