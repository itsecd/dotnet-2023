using Media.Domain;
using System.Diagnostics;

namespace Media.Server.Repository;

public class MediaRepository : IMediaRepository
{
    private readonly List<Genre> _genres;

    private readonly List<Track> _tracks;

    private readonly List<Album> _albums;

    private readonly List<Artist> _artists;

    public MediaRepository()
    {
        _genres = new List<Genre>();
        for (var i = 0; i < 3; i++)
        {
            var genre = new Genre();
            genre.Id = i;
            genre.Name = "Genre #" + i;
            _genres.Add(genre);
        }

        _tracks = new List<Track>();
        for (var i = 0; i < 12; i++)
        {
            var track = new Track();
            track.Id = i;
            track.Duration = i * 100 % 301;
            track.Number = i % 2;
            track.AlbumId = Convert.ToInt32(i / 2);
            track.Name = "Track #" + i;
            _tracks.Add(track);
        }

        var albums = new List<Album>();
        _albums = new List<Album>();
        for (var i = 0; i < 6; i++)
        {
            var album = new Album();
            album.Id = i;
            album.Name = "Album #" + i;
            album.Year = 2000 + i % 4;
            album.Tracks = new List<Track>();
            for (var j = 0; j < 2; j++)
            {
                album.Tracks.Add(_tracks[i * 2 + j]);
            }
            album.Genre = _genres[i % 3];
            album.GenreId = i % 3;
            albums.Add(album);
            _albums.Add(album);
        }
        var artists = new List<Artist>();
        for (var i = 0; i < 4; i++)
        {
            var artist = new Artist();
            artist.Id = i;
            artist.Name = "Artist #" + i;
            artist.Description = "Description about artist #" + i;
            artist.Albums = new List<Album>();
            for (var j = 0; j < Convert.ToInt32(i + 4) / 6 % 2 + 1; j++)
            {
                artist.Albums.Add(albums.First());
                _albums.Find(album => album.Id == albums.First().Id)!.ArtistId=i;
                albums.RemoveAt(0);
            }
            artists.Add(artist);
        }
        _artists = artists;
    }

    public List<Genre> Genres => _genres;

    public List<Track> Tracks => _tracks;

    public List<Album> Albums => _albums;

    public List<Artist> Artists => _artists;
}
