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
}