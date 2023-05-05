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
        _cards = new List<Card>
        {
            new Card { Id = 0, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 0, BooksId = 0, },
            new Card { Id = 1, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 0, BooksId = 3 },
            new Card { Id = 2, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 1, BooksId = 3 },
            new Card { Id = 3, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 1, BooksId = 1 },
            new Card { Id = 4, DateOfIssue = new DateTime(2022, 12, 29), DateOfReturn = new DateTime(2023, 1, 31), DayCount = 31, ReaderId = 1, BooksId = 2 },
            new Card { Id = 5, DateOfIssue = new DateTime(2022, 12, 30), DateOfReturn = new DateTime(2023, 2, 14), DayCount = 30, ReaderId = 2, BooksId = 2 },
            new Card { Id = 6, DateOfIssue = new DateTime(2022, 12, 30), DateOfReturn = new DateTime(2023, 2, 14), DayCount = 30, ReaderId = 3, BooksId = 1 },
            new Card { Id = 7, DateOfIssue = new DateTime(2023, 2, 14), DateOfReturn = new DateTime(2023, 2, 28), DayCount = 21, ReaderId = 4, BooksId = 0 }
        };

        _departments = new List<Department>
        {
            new Department{ Id = 0, TypeDepartmentsId = 1, BooksId = 0, Count = 40 },
            new Department{ Id = 1, TypeDepartmentsId = 1, BooksId = 1, Count = 35 },
            new Department{ Id = 2, TypeDepartmentsId = 1, BooksId = 2, Count = 33 },
            new Department{ Id = 3, TypeDepartmentsId = 0, BooksId = 3, Count = 15 },
            new Department{ Id = 4, TypeDepartmentsId = 1, BooksId = 3, Count = 20 },
        };

        _books = new List<Book>
        {
            new Book { Id = 0, Cipher = "5698/197b", Author = "Vasilev A.V.", Name = "Boolean algebra tutorial", PlaceEdition = "Kuibyshev", YearEdition = 1989, TypeEditionId = 2, IsIssued = true, Cards = new List<Card> { _cards[0], _cards[7] }, Departments = new List<Department> { _departments[0] } },
            new Book { Id = 1, Cipher = "5696/197b", Author = "Vasilev A.V.", Name = "Mathematical analysis manual", PlaceEdition = "Kuibyshev", YearEdition = 1988, TypeEditionId = 2, IsIssued = true, Cards = new List < Card > { _cards[3], _cards[6] }, Departments = new List < Department > { _departments[1] }},
            new Book { Id = 2, Cipher = "5832/198c", Author = "Merkulov D.A.", Name = "Computer science and computer engineering", PlaceEdition = "Samara", YearEdition = 2005, TypeEditionId =0, IsIssued = true, Cards = new List<Card> { _cards[4], _cards[5] }, Departments = new List<Department> { _departments[2] } },
            new Book { Id = 3, Cipher = "7896/215a", Author = "Andropov I.S.", Name = "Nanoelectronics and medicine", PlaceEdition = "Samara", YearEdition = 2017, TypeEditionId = 1, IsIssued = true, Cards = new List<Card> { _cards[1], _cards[2] }, Departments = new List<Department> { _departments[3], _departments[4] } }
        };

        _bookTypes = new List<TypeEdition>
        {
            new TypeEdition { Id = 0, Name = "Tutorial", Books = new List<Book> { _books[2] } },
            new TypeEdition { Id = 1, Name = "Monograph", Books = new List < Book > { _books[3] }},
            new TypeEdition { Id = 2, Name = "Methodological guidelines", Books = new List < Book > { _books[0], _books[1] }},
        };

        _departmentTypes = new List<TypeDepartment>
        {
            new TypeDepartment { Id = 0, Name = "Scientific", Departments = new List<Department> { _departments[3] } },
            new TypeDepartment { Id = 1, Name = "Study", Departments = new List<Department> { _departments[0], _departments[1], _departments[2], _departments[4] }}
        };

        _readers = new List<Reader>
        {
            new Reader { Id = 0, FullName = "Chernyi Vladislav Andreevich", Address = "Moscow highway 34", Phone = "89277668974", RegistrationDate = new DateTime(2022, 12, 25), Cards = new List<Card> { _cards[0], _cards[1] } },
            new Reader { Id = 1, FullName = "Kurakin Artem Sergeevich", Address = "Moscow highway 34", Phone = "89277668974", RegistrationDate = new DateTime(2022, 12, 25), Cards = new List < Card > { _cards[2], _cards[3], _cards[4] }},
            new Reader { Id = 2, FullName = "Arapenkov Stepan Vladimirovich", Address = "Moscow highway 34", Phone = "89277352678", RegistrationDate = new DateTime(2022, 12, 25), Cards = new List<Card> { _cards[5] } },
            new Reader { Id = 3, FullName = "Danilov Artem Andreevich", Address = "Moscow highway 34", Phone = "89277114578", RegistrationDate = new DateTime(2022, 12, 26), Cards = new List<Card> { _cards[6] } },
            new Reader { Id = 4, FullName = "Denisov Stepan Vladimirovich", Address = "Moscow highway 34", Phone = "89277550173", RegistrationDate = new DateTime(2022, 12, 27), Cards = new List<Card> { _cards[7] }}
        };
    }

    public List<TypeEdition> BookTypes => _bookTypes;

    public List<Book> Books => _books;

    public List<TypeDepartment> DepartmentTypes => _departmentTypes;

    public List<Department> Departments => _departments;

    public List<Reader> Readers => _readers;

    public List<Card> Cards => _cards;
}
