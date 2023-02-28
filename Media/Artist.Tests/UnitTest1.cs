namespace Artist.Tests;

using Media.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Xunit.Sdk;

public class ClassesTest
{
    [Fact]
    public void TestDescriptionOfArtists()
    {
        var artists = new List<Artist>();
        for (var i = 0; i < 4; i++)
        {
            var artist = new Artist();
            artist.Name = "Artist №" + i.ToString();
            artist.Description = "Description about artist №" + i.ToString();
            artists.Add(artist);
        }

        var alboms = new List<Albom>();
        for (var i = 0; i < 6; i++)
        {
            var rand = new Random();
            var albom = new Albom();
            albom.Name = "Albom №" + i.ToString() + " of Artist №" + (i%4).ToString();
            albom.Year = 2000 + rand.Next()%2;
            albom.Artist = artists[i % 4];
            alboms.Add(albom);
        }

        var tracks = new List<Track>();
        for (var i = 0; i < 12; i++)
        {
            var rand = new Random();
            var track = new Track();
            track.Duration = rand.Next() % 301;
            track.Number = Convert.ToInt32(i / 6) + 1;
            track.Albom = alboms[i % 6];
            track.Name = "Track №" + i.ToString() + "in Albom №" + (i%6).ToString();
            tracks.Add(track);
        }

        var genres = new List<Genre>();
        for (var i = 0; i < 3; i++)
        {
            var genre = new Genre();
            genre.Name = "Genre №" + i.ToString();
            genre.Tracks = new List<Track>();
            for (var j = 0; j < 4; j++)
            {
                genre.Tracks.Add(tracks[i * 4+j]);
            }
            genres.Add(genre);
        }
        //1
        var l = (from artist in (from genre in genres
                                 from track in genre.Tracks
                                 select track.Albom.Artist)
                 select artist).Distinct().ToList();
        //2
        var t = (from genre in genres
                 from track in genre.Tracks
                 where track.Albom.Name == "Albom №2 of Artist №2"
                 orderby track.Number
                 select track).ToList();
        //3
        var k = (from track in (from genre in genres
                                from track in genre.Tracks
                                select track)
                 where track.Albom.Year == 2000
                 group track by track.Albom into groupedTracks
                 select new { Albom = groupedTracks.Key, Count = groupedTracks.Count() }).ToList();
        //4
        var o = (from albInfo in (from track in (from genre in genres
                                                 from track in genre.Tracks
                                                 select track)
                                  group track by track.Albom into g
                                  select new { Albom = g.Key, Duration = g.Sum(x => x.Duration) })
                 orderby albInfo.Duration descending
                 select albInfo).Take(5).ToList();
        //5
        var f = (from achievment in (from albom in (from genre in genres
                                                    from track in genre.Tracks
                                                    select track.Albom).Distinct()
                                     group albom by albom.Artist into a
                                     select new { Artist = a.Key, Count = a.Count() })
                 where achievment.Count == (from albom in (from genre in genres
                                                           from track in genre.Tracks
                                                           select track.Albom).Distinct()
                                            group albom by albom.Artist into a
                                            select new { Artist = a.Key, Count = a.Count() }).Max(a=>a.Count)
                 select achievment.Artist).ToList();
        //6
        var min = (from track in (from genre in genres
                                  from track in genre.Tracks
                                  select track)
                   group track by track.Albom into g
                   select new { Albom = g.Key, Duration = g.Sum(x => x.Duration) }).Min(a => a.Duration);

        var max = (from track in (from genre in genres
                                  from track in genre.Tracks
                                  select track)
                   group track by track.Albom into g
                   select new { Albom = g.Key, Duration = g.Sum(x => x.Duration) }).Max(a => a.Duration);

        var avg = (from track in (from genre in genres
                                  from track in genre.Tracks
                                  select track)
                   group track by track.Albom into g
                   select new { Albom = g.Key, Duration = g.Sum(x => x.Duration) }).Average(a => a.Duration);

        //Assert.Equal(3, resultLists.Count());
    }
    /*[Fact]
    public void TestSumInt()
    {
        var a = 5;
        var b = 6;
        var c = a + b;
        Assert.Equal(11, c);
    }

    [Fact]
    public void TestSumString()
    {
        var a = "ast";
        var b = "qwe";
        var c = a + b;
        Assert.Equal("astqwe", c);

        var arr = new int[10] { 1,2,3,4,5,6,7,8,9,10}; // array - можно обратиться по индексу и т.д.
        var list = new List<Artist>()
        {
            new Artist
            {
                Name = "a",
                Description = "b"
            },
            new Artist
            {
                Name = "c",
                Description = "d"
            },
            new Artist
            {
                Name = "a",
                Description = "g"
            }
        };
        list.Add(new Artist() { Name = "x", Description = "y" });
        var resultList = new List<Artist>();
        for (var i = 0; i < list.Count; i++)
        {
            if (list[i].Name == "a")
            {
                resultList.Add(list[i]);
            }
        }
        foreach (var i in list)
        {
            if (i.Name == "a")
            {
                resultList.Add(i);
            }
        }
        //list.Find(c => c.Name == "a");


        //LINQ
        list.FirstOrDefault();
        list.Max(c=>c.Name);

        var resultLists =
            (from a in list
            where a.Name == "a"
            orderby a.Name
            select a.Description).ToList();
    }


    [Fact]
    public void TestMediaClasses()
    {
        var a = new Artist() { Name = "a", Description = "b"};
        a.Name = "a";
        a.Description = "b";
        var b = a.GetName();
        Assert.Equal("a", a.GetName());
    }*/

}