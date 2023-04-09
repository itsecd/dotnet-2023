using Library.Domain;

namespace Library.Server;

public class LibraryRepository
{
    private readonly List<TypeEdition> _bookTypes;

    private readonly List<Book> _books;

    public LibraryRepository()
    {
        _bookTypes = new List<TypeEdition>
        {
            new TypeEdition { Id = 0, Name = "Tutorial"},
            new TypeEdition { Id = 1, Name = "Monograph"},
            new TypeEdition { Id = 2, Name = "Methodological guidelines"},
        };

        _books = new List<Book>
        {
            new Book { Id = 0, Cipher = "5698/197b", Author = "Vasilev A.V.", Name = "Boolean algebra tutorial", PlaceEdition = "Kuibyshev", YearEdition = 1989, TypeEditionId = 2, TypeEdition = new List<TypeEdition> { _bookTypes[2] }, IsIssued = true},
            new Book { Id = 1, Cipher = "5696/197b", Author = "Vasilev A.V.", Name = "Mathematical analysis manual", PlaceEdition = "Kuibyshev", YearEdition = 1988, TypeEditionId = 2, TypeEdition = new List<TypeEdition> { _bookTypes[2] }, IsIssued = true},
            new Book { Id = 2, Cipher = "5832/198c", Author = "Merkulov D.A.", Name = "Computer science and computer engineering", PlaceEdition = "Samara", YearEdition = 2005, TypeEditionId =0, TypeEdition = new List<TypeEdition> { _bookTypes[0] }, IsIssued = true},
            new Book { Id = 3, Cipher = "7896/215a", Author = "Andropov I.S.", Name = "Nanoelectronics and medicine", PlaceEdition = "Samara", YearEdition = 2017, TypeEditionId = 1, TypeEdition = new List<TypeEdition> { _bookTypes[1] }, IsIssued = true}
        };
    }

    public List<TypeEdition> BookTypes => _bookTypes;

    public List<Book> Books => _books;
}
