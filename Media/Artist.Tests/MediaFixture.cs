namespace Media.Tests;

using Media.Domain;
using System;
using System.Collections.Generic;

public class MediaFixture
{
    public List<Genre> FixtureGenres
    {
        get
        {
            var genres = new List<Genre>();
            for (var i = 0; i < 3; i++)
            {
                var genre = new Genre();
                genre.Id = i;
                genre.Name = "Genre #" + i;
                genres.Add(genre);
            }
            return genres;
        }
    }

    public List<Track> FixtureTracks
    {
        get
        {
            var tracks = new List<Track>();
            for (var i = 0; i < 12; i++)
            {
                var track = new Track();
                track.Id = i;
                track.Duration = i * 100 % 301;
                track.Number = i % 2;
                track.AlbumId = Convert.ToInt32(i / 2);
                track.Name = "Track #" + i;
                tracks.Add(track);
            }
            return tracks;
        }
    }

    public List<Album> FixtureAlbums
    {
        get
        {
            var genres = FixtureGenres;
            var tracks = FixtureTracks;
            var albums = new List<Album>();
            for (var i = 0; i < 6; i++)
            {
                var album = new Album();
                album.Id = i;
                album.Name = "Album #" + i;
                album.Year = 2000 + i % 4;
                for (var j = 0; j < 2; j++)
                {
                    album.Tracks.Add(tracks[i * 2 + j]);
                }
                album.Genre = genres[i % 3];
                albums.Add(album);
            }
            return albums;
        }
    }
    public List<Artist> FixtureArtists
    {
        get
        {
            var albums = FixtureAlbums;
            var artists = new List<Artist>();
            for (var i = 0; i < 4; i++)
            {
                var artist = new Artist();
                artist.Id = i;
                artist.Name = "Artist #" + i;
                artist.Description = "Description about artist #" + i;
                for (var j = 0; j < (Convert.ToInt32(i + 4) / 6) % 2 + 1; j++)
                {
                    artist.Albums.Add(albums.First());
                    albums.RemoveAt(0);
                }
                artists.Add(artist);
            }
            return artists;
        }
    }
}
