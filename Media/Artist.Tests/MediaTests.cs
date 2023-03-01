namespace Artist.Tests;
using System.Linq;

public class MediaTest : IClassFixture<MediaFixture>
{
    private MediaFixture _fixture;

    public MediaTest(MediaFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void ArtistInfoTest()
    {
        var resultList = (from genre in _fixture.FixtureGenres
                          from track in genre.Tracks
                          select track.Album.Artist).Distinct().ToList();
        Assert.Equal(4, resultList.Count());
    }

    [Fact]
    public void TracksInfoTest()
    {
        var resultList = (from genre in _fixture.FixtureGenres
                          from track in genre.Tracks
                          where track.Album.Name == "Album ¹0 of Artist ¹0"
                          orderby track.Number
                          select track).ToList();
        Assert.Equal(2, resultList.Count());
    }

    [Fact]
    public void AlbumsInfoTest()
    {
        var resultList = (from track in (from genre in _fixture.FixtureGenres
                                         from track in genre.Tracks
                                         select track)
                          where track.Album.Year == 2000
                          group track by track.Album into groupedTracks
                          select new { Album = groupedTracks.Key, Count = groupedTracks.Count() }).ToList();
        Assert.Equal(2, resultList.Count());
    }

    [Fact]
    public void TopAlbumsTest()
    {
        var resultList = (from AlbumInformation in (from track in (from genre in _fixture.FixtureGenres
                                                                   from track in genre.Tracks
                                                                   select track)
                                                    group track by track.Album into g
                                                    select new { Album = g.Key, Duration = g.Sum(x => x.Duration) })
                          orderby AlbumInformation.Duration descending
                          select AlbumInformation).Take(5).ToList();
        Assert.Equal(5, resultList.Count());
    }

    [Fact]
    public void MaxAlbumArtistTest()
    {
        var countAlbumList = (from Album in (from genre in _fixture.FixtureGenres
                                             from track in genre.Tracks
                                             select track.Album).Distinct()
                              group Album by Album.Artist into a
                              select new { Artist = a.Key, Count = a.Count() });

        var resultList = (from achievment in countAlbumList
                          where achievment.Count == countAlbumList.Max(a => a.Count)
                          select achievment.Artist).ToList();
        Assert.Equal(2, resultList.Count());
    }

    [Fact]
    public void AlbumDurationInfoTest()
    {
        var durationAlbumList = (from track in (from genre in _fixture.FixtureGenres
                                                from track in genre.Tracks
                                                select track)
                                 group track by track.Album into g
                                 select new { Album = g.Key, Duration = g.Sum(x => x.Duration) });
        var min = durationAlbumList.Min(a => a.Duration);

        var max = durationAlbumList.Max(a => a.Duration);

        var avg = durationAlbumList.Average(a => a.Duration);

        Assert.Equal(196, min);
        Assert.Equal(598, max);
        Assert.Equal(347.5, avg);
    }
}