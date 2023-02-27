namespace Artist.Tests;

using Media.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

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
        for (var i = 0; i < 4; i++)
        {
            var albom = new Albom();
            albom.Name = "Albom №" + i.ToString();
            albom.Year = 2000 + i;
            albom.Artist = artists[i % 4];
            alboms.Add(albom);
        }

        var tracks = new List<Track>();
        for (var i = 0; i < 10; i++)
        {
            var rand = new Random();
            var track = new Track();
            track.Duration = rand.Next() % 301;
            track.Number = i % 4 + 1;
            track.Albom = alboms[i % 4];
            track.Name = "Track №" + i.ToString();
            tracks.Add(track);
        }

        var genres = new List<Genre>();
        for (var i = 0; i < 3; i++)
        {
            var genre = new Genre();
            genre.Name = "Genre №" + i.ToString();
            genre.Tracks = tracks;
            genres.Add(genre);
        }

        var resultLists =
            (from a in genres
             where a.Name == "Genre №1"
             select a.Name).ToList();
        var l = (from genre in genres
                from track in genre.Tracks
                 where track.Albom.Artist.Name == "Artist №1"
                select track.Albom.Year).ToList();


        Console.WriteLine(l);
        Assert.Equal(3, resultLists.Count());
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