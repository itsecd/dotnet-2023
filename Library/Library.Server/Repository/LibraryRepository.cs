using Library.Domain;

namespace Library.Server.Repository;

public class LibraryRepository : ILibraryRepository
{
    private readonly List<TypeEdition> _bookTypes;

    private readonly List<Book> _books;

    private readonly List<TypeDepartment> _departmentTypes;

    private readonly List<Department> _departments;

    private readonly List<Reader> _readers;

    private readonly List<Card> _cards;

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

        _departmentTypes = new List<TypeDepartment>
        {
            new TypeDepartment { Id = 0, Name = "Scientific"},
            new TypeDepartment { Id = 1, Name = "Study"}
        };

        _departments = new List<Department>
        {
            new Department{ Id = 0, TypeDepartmentsId = 1, TypeDepartments = new List<TypeDepartment>{ _departmentTypes[1] }, BooksId = 0, Books = new List<Book> { _books[0] }, Count = 40 },
            new Department{ Id = 1, TypeDepartmentsId = 1, TypeDepartments = new List<TypeDepartment>{ _departmentTypes[1] }, BooksId = 1, Books = new List<Book> { _books[1] }, Count = 35 },
            new Department{ Id = 2, TypeDepartmentsId = 1, TypeDepartments = new List<TypeDepartment>{ _departmentTypes[1] }, BooksId = 2, Books = new List<Book> { _books[2] }, Count = 33 },
            new Department{ Id = 3, TypeDepartmentsId = 0, TypeDepartments = new List<TypeDepartment>{ _departmentTypes[0] }, BooksId = 3, Books = new List<Book> { _books[3] }, Count = 15 },
            new Department{ Id = 4, TypeDepartmentsId = 1, TypeDepartments = new List<TypeDepartment>{ _departmentTypes[1] }, BooksId = 3, Books = new List<Book> { _books[3] }, Count = 20 },
        };

        _readers = new List<Reader>
        {
            new Reader { Id = 0, FullName = "Chernyi Vladislav Andreevich", Address = "Moscow highway 34", Phone = "89277668974", RegistrationDate = new DateTime(2022, 12, 25)},
            new Reader { Id = 1, FullName = "Kurakin Artem Sergeevich", Address = "Moscow highway 34", Phone = "89277668974", RegistrationDate = new DateTime(2022, 12, 25)},
            new Reader { Id = 2, FullName = "Arapenkov Stepan Vladimirovich", Address = "Moscow highway 34", Phone = "89277352678", RegistrationDate = new DateTime(2022, 12, 25)},
            new Reader { Id = 3, FullName = "Danilov Artem Andreevich", Address = "Moscow highway 34", Phone = "89277114578", RegistrationDate = new DateTime(2022, 12, 26)},
            new Reader { Id = 4, FullName = "Denisov Stepan Vladimirovich", Address = "Moscow highway 34", Phone = "89277550173", RegistrationDate = new DateTime(2022, 12, 27)}
        };

        _cards = new List<Card>
        {
            new Card { Id = 0, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 0, Reader = new List<Reader> { _readers[0] }, BooksId = 0, Books = new List<Book> { _books[0] } },
            new Card { Id = 1, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 0, Reader = new List<Reader> { _readers[0] }, BooksId = 3, Books = new List<Book> { _books[3] } },
            new Card { Id = 2, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 1, Reader = new List<Reader> { _readers[1] }, BooksId = 3, Books = new List<Book> { _books[3] } },
            new Card { Id = 3, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 1, Reader = new List<Reader> { _readers[1] }, BooksId = 1, Books = new List<Book> { _books[1] } },
            new Card { Id = 4, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 31), DayCount = 31, ReaderId = 1, Reader = new List<Reader> { _readers[1] }, BooksId = 2, Books = new List<Book> { _books[2] } },
            new Card { Id = 5, DateOfIssue = new DateTime(2022, 12, 30), DateOfReturn = new DateTime(2023, 2, 14), DayCount = 30, ReaderId = 2, Reader = new List<Reader> { _readers[2] }, BooksId = 2, Books = new List<Book> { _books[2] } },
            new Card { Id = 6, DateOfIssue = new DateTime(2022, 12, 30), DateOfReturn = new DateTime(2023, 2, 14), DayCount = 30, ReaderId = 3, Reader = new List<Reader> { _readers[3] }, BooksId = 1, Books = new List<Book> { _books[1] } },
            new Card { Id = 7, DateOfIssue = new DateTime(2023, 2, 14), DateOfReturn = new DateTime(2023, 2, 28), DayCount = 21, ReaderId = 4, Reader = new List<Reader> { _readers[4] }, BooksId = 0, Books = new List<Book> { _books[0] } }
        };
    }

    public List<TypeEdition> BookTypes => _bookTypes;

    public List<Book> Books => _books;

    public List<TypeDepartment> DepartmentTypes => _departmentTypes;

    public List<Department> Departments => _departments;

    public List<Reader> Readers => _readers;

    public List<Card> Cards => _cards;
}
