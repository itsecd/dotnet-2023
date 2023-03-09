namespace Library.Tests;

using Library.Domain;

public class LibraryFixture
{
    public List<TypeEdition> FixtureTypeEdition
    {
        get
        {
            var typeEditions = new List<TypeEdition>();
            var firstType = new TypeEdition();
            firstType.Id = 0;
            firstType.Name = "Tutorial";
            typeEditions.Add(firstType);
            var secondType = new TypeEdition();
            secondType.Id = 1;
            secondType.Name = "Monograph";
            typeEditions.Add(secondType);
            var thirdType = new TypeEdition();
            thirdType.Id = 2;
            thirdType.Name = "Methodological guidelines";
            typeEditions.Add(thirdType);
            return typeEditions;
        }
    }

    public List<TypeDepartment> FixtureTypeDepartment
    {
        get
        {
            var typeDepartments = new List<TypeDepartment>();
            var firstType = new TypeDepartment();
            firstType.Id = 0;
            firstType.Name = "Scientific";
            typeDepartments.Add(firstType);
            var secondType = new TypeDepartment();
            secondType.Id = 1;
            secondType.Name = "Study";
            typeDepartments.Add(secondType);
            return typeDepartments;
        }
    }

    public List<Book> FixtureBook
    {
        get
        {
            var typeEditions = FixtureTypeEdition;
            var books = new List<Book>();
            var firstBook = new Book();
            firstBook.Id = 0;
            firstBook.Cipher = "5698/197b";
            firstBook.Autor = "Vasilev A.V.";
            firstBook.Name = "Boolean algebra tutorial";
            firstBook.PlaceEdition = "Kuibyshev";
            firstBook.YearEdition = 1989;
            firstBook.IdTypeEdition.Add(typeEditions[2]);
            firstBook.IsIssued = true;
            books.Add(firstBook);
            var secondBook = new Book();
            secondBook.Id = 1;
            secondBook.Cipher = "5696/197b";
            secondBook.Autor = "Vasilev A.V.";
            secondBook.Name = "Mathematical analysis manual";
            secondBook.PlaceEdition = "Kuibyshev";
            secondBook.YearEdition = 1988;
            secondBook.IdTypeEdition.Add(typeEditions[2]);
            secondBook.IsIssued = true;
            books.Add(secondBook);
            var thirdBook = new Book();
            thirdBook.Id = 2;
            thirdBook.Cipher = "5832/198c";
            thirdBook.Autor = "Merkulov D.A.";
            thirdBook.Name = "Computer science and computer engineering";
            thirdBook.PlaceEdition = "Samara";
            thirdBook.YearEdition = 2005;
            thirdBook.IdTypeEdition.Add(typeEditions[0]);
            thirdBook.IsIssued = true;
            books.Add(thirdBook);
            var fourthBook = new Book();
            fourthBook.Id = 3;
            fourthBook.Cipher = "7896/215a";
            fourthBook.Autor = "Andropov I.S.";
            fourthBook.Name = "Nanoelectronics and medicine";
            fourthBook.PlaceEdition = "Samara";
            fourthBook.YearEdition = 2017;
            fourthBook.IdTypeEdition.Add(typeEditions[1]);
            fourthBook.IsIssued = true;
            books.Add(fourthBook);
            return books;
        }
    }

    public List<Department> FixtureDepartment
    {
        get
        {
            var books = FixtureBook;
            var typeDepartments = FixtureTypeDepartment;
            var departments = new List<Department>();
            var firstDepartment = new Department();
            firstDepartment.Id = 0;
            firstDepartment.IdTypeDepartments.Add(typeDepartments[1]);
            firstDepartment.IdBooks.Add(books[0]);
            firstDepartment.Count = 40;
            departments.Add(firstDepartment);
            var secondDepartment = new Department();
            secondDepartment.Id = 1;
            secondDepartment.IdTypeDepartments.Add(typeDepartments[1]);
            secondDepartment.IdBooks.Add(books[1]);
            secondDepartment.Count = 35;
            departments.Add(secondDepartment);
            var thirdDepartment = new Department();
            thirdDepartment.Id = 2;
            thirdDepartment.IdTypeDepartments.Add(typeDepartments[1]);
            thirdDepartment.IdBooks.Add(books[2]);
            thirdDepartment.Count = 33;
            departments.Add(thirdDepartment);
            var fourthDepartment = new Department();
            fourthDepartment.Id = 3;
            fourthDepartment.IdTypeDepartments.Add(typeDepartments[0]);
            fourthDepartment.IdBooks.Add(books[3]);
            fourthDepartment.Count = 15;
            departments.Add(fourthDepartment);
            var fifthDepartment = new Department();
            fifthDepartment.Id = 4;
            fifthDepartment.IdTypeDepartments.Add(typeDepartments[1]);
            fifthDepartment.IdBooks.Add(books[3]);
            fifthDepartment.Count = 15;
            departments.Add(fifthDepartment);
            return departments;
        }
    }

    public List<Reader> FixtureReader
    {
        get
        {
            var readers = new List<Reader>();
            var firstReader = new Reader();
            firstReader.Id = 0;
            firstReader.FullName = "Chernyi Vladislav Andreevich";
            firstReader.Address = "Moscow highway 34";
            firstReader.Phone = "89277665533";
            firstReader.RegistrationDate = new DateOnly(2022, 12, 25);
            readers.Add(firstReader);
            var secondReader = new Reader();
            secondReader.Id = 1;
            secondReader.FullName = "Kurakin Artem Sergeevich";
            secondReader.Address = "Moscow highway 34";
            secondReader.Phone = "89277668974";
            secondReader.RegistrationDate = new DateOnly(2022, 12, 25);
            readers.Add(secondReader);
            var thirdReader = new Reader();
            thirdReader.Id = 2;
            thirdReader.FullName = "Arapenkov Stepan Vladimirovich";
            thirdReader.Address = "Moscow highway 34";
            thirdReader.Phone = "89277352678";
            thirdReader.RegistrationDate = new DateOnly(2022, 12, 25);
            readers.Add(thirdReader);
            var fourthReader = new Reader();
            fourthReader.Id = 3;
            fourthReader.FullName = "Danilov Artem Andreevich";
            fourthReader.Address = "Moscow highway 34";
            fourthReader.Phone = "89277114578";
            fourthReader.RegistrationDate = new DateOnly(2022, 12, 26);
            readers.Add(fourthReader);
            var fifteenReader = new Reader();
            fifteenReader.Id = 4;
            fifteenReader.FullName = "Denisov Stepan Vladimirovich";
            fifteenReader.Address = "Moscow highway 34";
            fifteenReader.Phone = "89277550173";
            fifteenReader.RegistrationDate = new DateOnly(2022, 12, 27);
            readers.Add(fifteenReader);
            return readers;
        }
    }

    public List<Card> FixtureCard
    {
        get
        {
            var readers = FixtureReader;
            var books = FixtureBook;
            var cards = new List<Card>();
            var firstCard = new Card();
            firstCard.Id = 0;
            firstCard.DateOfIssue = new DateOnly(2022, 12, 29);
            firstCard.DateOfReturn = new DateOnly(2023, 1, 28);
            firstCard.DayCount = 31;
            firstCard.IdReader.Add(readers[0]);
            firstCard.IdBooks.Add(books[0]);
            cards.Add(firstCard);
            var secondCard = new Card();
            secondCard.Id = 1;
            secondCard.DateOfIssue = new DateOnly(2022, 12, 29);
            secondCard.DateOfReturn = new DateOnly(2023, 1, 28);
            secondCard.DayCount = 31;
            secondCard.IdReader.Add(readers[0]);
            secondCard.IdBooks.Add(books[3]);
            cards.Add(secondCard);
            var thirdCard = new Card();
            thirdCard.Id = 2;
            thirdCard.DateOfIssue = new DateOnly(2022, 12, 29);
            thirdCard.DateOfReturn = new DateOnly(2023, 1, 28);
            thirdCard.DayCount = 31;
            thirdCard.IdReader.Add(readers[1]);
            thirdCard.IdBooks.Add(books[3]);
            cards.Add(thirdCard);
            var fourthCard = new Card();
            fourthCard.Id = 3;
            fourthCard.DateOfIssue = new DateOnly(2022, 12, 29);
            fourthCard.DateOfReturn = new DateOnly(2023, 1, 28);
            fourthCard.DayCount = 31;
            fourthCard.IdReader.Add(readers[1]);
            fourthCard.IdBooks.Add(books[1]);
            cards.Add(fourthCard);
            var fifthCard = new Card();
            fifthCard.Id = 4;
            fifthCard.DateOfIssue = new DateOnly(2022, 12, 29);
            fifthCard.DateOfReturn = new DateOnly(2023, 1, 31);
            fifthCard.DayCount = 31;
            fifthCard.IdReader.Add(readers[1]);
            fifthCard.IdBooks.Add(books[2]);
            cards.Add(fifthCard);
            var sixthCard = new Card();
            sixthCard.Id = 5;
            sixthCard.DateOfIssue = new DateOnly(2022, 12, 30);
            sixthCard.DateOfReturn = new DateOnly(2023, 2, 14);
            sixthCard.DayCount = 30;
            sixthCard.IdReader.Add(readers[2]);
            sixthCard.IdBooks.Add(books[2]);
            cards.Add(sixthCard);
            var seventhCard = new Card();
            seventhCard.Id = 6;
            seventhCard.DateOfIssue = new DateOnly(2022, 12, 30);
            seventhCard.DateOfReturn = new DateOnly(2023, 2, 14);
            seventhCard.DayCount = 30;
            seventhCard.IdReader.Add(readers[3]);
            seventhCard.IdBooks.Add(books[1]);
            cards.Add(seventhCard);
            var eighthCard = new Card();
            eighthCard.Id = 7;
            eighthCard.DateOfIssue = new DateOnly(2023, 2, 14);
            eighthCard.DateOfReturn = new DateOnly(2023, 2, 28);
            eighthCard.DayCount = 21;
            eighthCard.IdReader.Add(readers[4]);
            eighthCard.IdBooks.Add(books[0]);
            cards.Add(eighthCard);
            return cards;
        }
    }
}
