namespace Artist.Tests;

using Media.Domain;
using System.Collections.Generic;
using System.Linq;

public class MediaTest : IClassFixture<MediaFixture>
{
    private MediaFixture _fixture;

    public MediaTest (MediaFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void FirtstRequest()
    {
        var resultList = (from genre in _fixture.FixtureGenres
                 from track in genre.Tracks
                 select track.Albom.Artist).Distinct().ToList();
        Assert.Equal(4, resultList.Count());
    }

    [Fact]
    public void SecondRequest()
    {
        var resultList = (from genre in _fixture.FixtureGenres
                 from track in genre.Tracks
                 where track.Albom.Name == "Albom ¹0 of Artist ¹0"
                 orderby track.Number
                 select track).ToList();
        Assert.Equal(2, resultList.Count());
    }

    [Fact]
    public void ThirdRequest()
    {
        var resultList = (from track in (from genre in _fixture.FixtureGenres
                                from track in genre.Tracks
                                select track)
                 where track.Albom.Year == 2000
                 group track by track.Albom into groupedTracks
                 select new { Albom = groupedTracks.Key, Count = groupedTracks.Count() }).ToList();
        Assert.Equal(2, resultList.Count());
    }

    [Fact]
    public void FourthRequest()
    {
        var resultList = (from albomInformation in (from track in (from genre in _fixture.FixtureGenres
                                                          from track in genre.Tracks
                                                          select track)
                                           group track by track.Albom into g
                                           select new { Albom = g.Key, Duration = g.Sum(x => x.Duration) })
                 orderby albomInformation.Duration descending
                 select albomInformation).Take(5).ToList();
        Assert.Equal(5, resultList.Count());
    }

    [Fact]
    public void FifthRequest()
    {
        var countAlbomList = (from albom in (from genre in _fixture.FixtureGenres
                                             from track in genre.Tracks
                                             select track.Albom).Distinct()
                              group albom by albom.Artist into a
                              select new { Artist = a.Key, Count = a.Count() });

        var resultList = (from achievment in countAlbomList
                 where achievment.Count == countAlbomList.Max(a => a.Count)
                 select achievment.Artist).ToList();
        Assert.Equal(2, resultList.Count());
    }

    [Fact]
    public void SixthRequest()
    {
        var durationAlbomList = (from track in (from genre in _fixture.FixtureGenres
                                                from track in genre.Tracks
                                                select track)
                                 group track by track.Albom into g
                                 select new { Albom = g.Key, Duration = g.Sum(x => x.Duration) });
        var min = durationAlbomList.Min(a => a.Duration);

        var max = durationAlbomList.Max(a => a.Duration);

        var avg = durationAlbomList.Average(a => a.Duration);

        Assert.Equal(196, min);
        Assert.Equal(598, max);
        Assert.Equal(347.5, avg);
    }
}