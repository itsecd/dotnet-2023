namespace Library.Tests;

using Library.Domain;

public class LibraryFixture
{
    public List<TypeEdition> FixtureTypeEdition
    {
        get
        {
            var books = FixtureBook;
            var typeEditions = new List<TypeEdition>();
            var firstType = new TypeEdition();
            firstType.Id = 0;
            firstType.Name = "Tutorial";
            firstType.Books.Add(books[2]);
            typeEditions.Add(firstType);
            var secondType = new TypeEdition();
            secondType.Id = 1;
            secondType.Name = "Monograph";
            secondType.Books.Add(books[3]);
            typeEditions.Add(secondType);
            var thirdType = new TypeEdition();
            thirdType.Id = 2;
            thirdType.Name = "Methodological guidelines";
            thirdType.Books.Add(books[0]);
            thirdType.Books.Add(books[1]);
            typeEditions.Add(thirdType);
            return typeEditions;
        }
    }

    public List<TypeDepartment> FixtureTypeDepartment
    {
        get
        {
            var departments = FixtureDepartment;
            var typeDepartments = new List<TypeDepartment>();
            var firstType = new TypeDepartment();
            firstType.Id = 0;
            firstType.Name = "Scientific";
            firstType.Departments.Add(departments[3]);
            typeDepartments.Add(firstType);
            var secondType = new TypeDepartment();
            secondType.Id = 1;
            secondType.Name = "Study";
            secondType.Departments.Add(departments[0]);
            secondType.Departments.Add(departments[1]);
            secondType.Departments.Add(departments[2]);
            secondType.Departments.Add(departments[4]);
            typeDepartments.Add(secondType);
            return typeDepartments;
        }
    }

    public List<Book> FixtureBook
    {
        get
        {
            var cards = FixtureCard;
            var departments = FixtureDepartment;
            var books = new List<Book>();
            var firstBook = new Book();
            firstBook.Id = 0;
            firstBook.Cipher = "5698/197b";
            firstBook.Author = "Vasilev A.V.";
            firstBook.Name = "Boolean algebra tutorial";
            firstBook.PlaceEdition = "Kuibyshev";
            firstBook.YearEdition = 1989;
            firstBook.TypeEditionId = 2;
            firstBook.Cards.Add(cards[0]);
            firstBook.Cards.Add(cards[7]);
            firstBook.Departments.Add(departments[0]);
            books.Add(firstBook);
            var secondBook = new Book();
            secondBook.Id = 1;
            secondBook.Cipher = "5696/197b";
            secondBook.Author = "Vasilev A.V.";
            secondBook.Name = "Mathematical analysis manual";
            secondBook.PlaceEdition = "Kuibyshev";
            secondBook.YearEdition = 1988;
            secondBook.TypeEditionId = 2;
            secondBook.Cards.Add(cards[3]);
            secondBook.Cards.Add(cards[6]);
            secondBook.Departments.Add(departments[1]);
            books.Add(secondBook);
            var thirdBook = new Book();
            thirdBook.Id = 2;
            thirdBook.Cipher = "5832/198c";
            thirdBook.Author = "Merkulov D.A.";
            thirdBook.Name = "Computer science and computer engineering";
            thirdBook.PlaceEdition = "Samara";
            thirdBook.YearEdition = 2005;
            thirdBook.TypeEditionId = 0;
            thirdBook.Cards.Add(cards[4]);
            thirdBook.Cards.Add(cards[5]);
            thirdBook.Departments.Add(departments[2]);
            books.Add(thirdBook);
            var fourthBook = new Book();
            fourthBook.Id = 3;
            fourthBook.Cipher = "7896/215a";
            fourthBook.Author = "Andropov I.S.";
            fourthBook.Name = "Nanoelectronics and medicine";
            fourthBook.PlaceEdition = "Samara";
            fourthBook.YearEdition = 2017;
            fourthBook.TypeEditionId = 1;
            fourthBook.Cards.Add(cards[1]);
            fourthBook.Cards.Add(cards[2]);
            fourthBook.Departments.Add(departments[3]);
            fourthBook.Departments.Add(departments[4]);
            books.Add(fourthBook);
            return books;
        }
    }

    public List<Department> FixtureDepartment
    {
        get
        {
            var departments = new List<Department>();
            var firstDepartment = new Department();
            firstDepartment.Id = 0;
            firstDepartment.TypeDepartmentsId = 1;
            firstDepartment.BookId = 0;
            firstDepartment.Count = 40;
            departments.Add(firstDepartment);
            var secondDepartment = new Department();
            secondDepartment.Id = 1;
            secondDepartment.TypeDepartmentsId = 1;
            secondDepartment.BookId = 1;
            secondDepartment.Count = 35;
            departments.Add(secondDepartment);
            var thirdDepartment = new Department();
            thirdDepartment.Id = 2;
            thirdDepartment.TypeDepartmentsId = 1;
            thirdDepartment.BookId = 2;
            thirdDepartment.Count = 33;
            departments.Add(thirdDepartment);
            var fourthDepartment = new Department();
            fourthDepartment.Id = 3;
            fourthDepartment.TypeDepartmentsId = 0;
            fourthDepartment.BookId = 3;
            fourthDepartment.Count = 15;
            departments.Add(fourthDepartment);
            var fifthDepartment = new Department();
            fifthDepartment.Id = 4;
            fifthDepartment.TypeDepartmentsId = 1;
            fifthDepartment.BookId = 3;
            fifthDepartment.Count = 20;
            departments.Add(fifthDepartment);
            return departments;
        }
    }

    public List<Reader> FixtureReader
    {
        get
        {
            var cards = FixtureCard;
            var readers = new List<Reader>();
            var firstReader = new Reader();
            firstReader.Id = 0;
            firstReader.FullName = "Chernyi Vladislav Andreevich";
            firstReader.Address = "Moscow highway 34";
            firstReader.Phone = "89277665533";
            firstReader.RegistrationDate = new DateTime(2022, 12, 25);
            firstReader.Cards.Add(cards[0]);
            firstReader.Cards.Add(cards[1]);
            readers.Add(firstReader);
            var secondReader = new Reader();
            secondReader.Id = 1;
            secondReader.FullName = "Kurakin Artem Sergeevich";
            secondReader.Address = "Moscow highway 34";
            secondReader.Phone = "89277668974";
            secondReader.RegistrationDate = new DateTime(2022, 12, 25);
            secondReader.Cards.Add(cards[2]);
            secondReader.Cards.Add(cards[3]);
            secondReader.Cards.Add(cards[4]);
            readers.Add(secondReader);
            var thirdReader = new Reader();
            thirdReader.Id = 2;
            thirdReader.FullName = "Arapenkov Stepan Vladimirovich";
            thirdReader.Address = "Moscow highway 34";
            thirdReader.Phone = "89277352678";
            thirdReader.RegistrationDate = new DateTime(2022, 12, 25);
            thirdReader.Cards.Add(cards[5]);
            readers.Add(thirdReader);
            var fourthReader = new Reader();
            fourthReader.Id = 3;
            fourthReader.FullName = "Danilov Artem Andreevich";
            fourthReader.Address = "Moscow highway 34";
            fourthReader.Phone = "89277114578";
            fourthReader.RegistrationDate = new DateTime(2022, 12, 26);
            fourthReader.Cards.Add(cards[6]);
            readers.Add(fourthReader);
            var fifthReader = new Reader();
            fifthReader.Id = 4;
            fifthReader.FullName = "Denisov Stepan Vladimirovich";
            fifthReader.Address = "Moscow highway 34";
            fifthReader.Phone = "89277550173";
            fifthReader.RegistrationDate = new DateTime(2022, 12, 27);
            fifthReader.Cards.Add(cards[7]);
            readers.Add(fifthReader);
            return readers;
        }
    }

    public List<Card> FixtureCard
    {
        get
        {
            var cards = new List<Card>();
            var firstCard = new Card();
            firstCard.Id = 0;
            firstCard.DateOfIssue = new DateTime(2022, 12, 29);
            firstCard.DateOfReturn = new DateTime(2023, 1, 28);
            firstCard.DayCount = 31;
            firstCard.ReaderId = 0;
            firstCard.BooksId = 0;
            cards.Add(firstCard);
            var secondCard = new Card();
            secondCard.Id = 1;
            secondCard.DateOfIssue = new DateTime(2022, 12, 29);
            secondCard.DateOfReturn = new DateTime(2023, 1, 28);
            secondCard.DayCount = 31;
            secondCard.ReaderId = 0;
            secondCard.BooksId = 3;
            cards.Add(secondCard);
            var thirdCard = new Card();
            thirdCard.Id = 2;
            thirdCard.DateOfIssue = new DateTime(2022, 12, 29);
            thirdCard.DateOfReturn = new DateTime(2023, 1, 28);
            thirdCard.DayCount = 31;
            thirdCard.ReaderId = 1;
            thirdCard.BooksId = 3;
            cards.Add(thirdCard);
            var fourthCard = new Card();
            fourthCard.Id = 3;
            fourthCard.DateOfIssue = new DateTime(2022, 12, 29);
            fourthCard.DateOfReturn = new DateTime(2023, 1, 28);
            fourthCard.DayCount = 31;
            fourthCard.ReaderId = 1;
            fourthCard.BooksId = 1;
            cards.Add(fourthCard);
            var fifthCard = new Card();
            fifthCard.Id = 4;
            fifthCard.DateOfIssue = new DateTime(2022, 12, 29);
            fifthCard.DateOfReturn = new DateTime(2023, 1, 31);
            fifthCard.DayCount = 31;
            fifthCard.ReaderId = 1;
            fifthCard.BooksId = 2;
            cards.Add(fifthCard);
            var sixthCard = new Card();
            sixthCard.Id = 5;
            sixthCard.DateOfIssue = new DateTime(2022, 12, 30);
            sixthCard.DateOfReturn = new DateTime(2023, 2, 14);
            sixthCard.DayCount = 30;
            sixthCard.ReaderId = 2;
            sixthCard.BooksId = 2;
            cards.Add(sixthCard);
            var seventhCard = new Card();
            seventhCard.Id = 6;
            seventhCard.DateOfIssue = new DateTime(2022, 12, 30);
            seventhCard.DateOfReturn = new DateTime(2023, 2, 14);
            seventhCard.DayCount = 30;
            seventhCard.ReaderId = 3;
            seventhCard.BooksId = 1;
            cards.Add(seventhCard);
            var eighthCard = new Card();
            eighthCard.Id = 7;
            eighthCard.DateOfIssue = new DateTime(2023, 2, 14);
            eighthCard.DateOfReturn = new DateTime(2023, 2, 28);
            eighthCard.DayCount = 21;
            eighthCard.ReaderId = 4;
            eighthCard.BooksId = 0;
            cards.Add(eighthCard);
            return cards;
        }
    }
}