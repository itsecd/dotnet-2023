namespace Library.Tests;

using System.Linq;

public class LibraryTests : IClassFixture<LibraryFixture>
{
    private readonly LibraryFixture _fixture;

    public LibraryTests(LibraryFixture fixture)
    {
        _fixture = fixture;
    }
    /// <summary>
    /// First request - give info about book by the cipher
    /// </summary>
    [Fact]
    public void CipherTest()
    {
        var fixtureBook = _fixture.FixtureBook;
        var request = (from book in fixtureBook
                       where book.Cipher == "5698/197b"
                       select book).Count();
        Assert.Equal(1, request);
    }
    /// <summary>
    /// Second request - give info about all books issued order by book's name
    /// </summary>
    [Fact]
    public void BooksTest()
    {
        var fixtureBook = _fixture.FixtureBook;
        var request = (from book in fixtureBook
                       where book.IsIssued == true
                       orderby book.Name
                       select book).Count();
        Assert.Equal(4, request);
    }
    /// <summary>
    /// Third request - give info on the availability of the selected book in different departments and their quantity
    /// </summary>
    [Fact]
    public void CountBooksTest()
    {
        var fixtureDepartment = _fixture.FixtureDepartment.ToList();
        var request = (from department in fixtureDepartment
                       from b in department.IdBooks
                       where b.Id == 3
                       select new { departments = department, count = department.Count });
        Assert.Equal(2, request.Count());
        Assert.Equal(15, request.First(x => x.departments.Id == 3).count);
        Assert.Equal(20, request.First(x => x.departments.Id == 4).count);
    }
}