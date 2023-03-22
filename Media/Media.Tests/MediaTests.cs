namespace Media.Tests;

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
        var resultList = (from artist in _fixture.FixtureArtists
                          select artist).ToList();
        Assert.Equal(4, resultList.Count);
    }

    [Fact]
    public void TracksInfoTest()
    {
        var resultList = (from album in _fixture.FixtureAlbums
                          where album.Name == "Album #0"
                          from track in album.Tracks
                          orderby track.Number
                          select track).ToList();
        Assert.Equal(2, resultList.Count);
    }

    [Fact]
    public void AlbumsInfoTest()
    {
        var resultList = (from album in _fixture.FixtureAlbums
                          where album.Year == 2001
                          select new { Album = album, Count = album.Tracks.Count }).ToList();
        Assert.Equal(2, resultList.Count);
    }

    [Fact]
    public void TopAlbumsTest()
    {
        var resultList = (from album in _fixture.FixtureAlbums
                          orderby album.Tracks.Sum(x => x.Duration) descending
                          select new { Album = album, Duration = album.Tracks.Sum(x => x.Duration) }).Take(5).ToList();
        Assert.Equal(5, resultList.Count);
    }

    [Fact]
    public void MaxAlbumArtistTest()
    {
        var resultList = (from artist in _fixture.FixtureArtists
                          where artist.Albums.Count == _fixture.FixtureArtists.Max(x => x.Albums.Count)
                          select artist).ToList();
        Assert.Equal(2, resultList.Count);
    }

    [Fact]
    public void AlbumDurationInfoTest()
    {
        var durationAlbumList = (from album in _fixture.FixtureAlbums
                                 select new { Album = album, Duration = album.Tracks.Sum(x => x.Duration) });
        var min = durationAlbumList.Min(a => a.Duration);

        var max = durationAlbumList.Max(a => a.Duration);

        var avg = durationAlbumList.Average(a => a.Duration);

        Assert.Equal(100, min);
        Assert.Equal(500, max);
        Assert.Equal(347.5, avg);
    }
}