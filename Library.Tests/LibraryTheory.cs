using Library.Domain;

namespace Library.Tests;


public class LibraryTheory
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
            var typeDepartments = new List<TypeDepartment>
            {
                new TypeDepartment
                {
                    Id = 0,
                    Name = "IT",
                    Departments = { departments[3] }
                },
                new TypeDepartment
                {
                    Id = 1,
                    Name = "Study",
                    Departments = { departments[0], departments[1], departments[2] }
                },
                new TypeDepartment
                {
                    Id = 2,
                    Name = "Biology",
                    Departments = { departments[4] }
                }
            };
            return typeDepartments;
        }
    }

    public List<Book> FixtureBook
    {
        get
        {
            var cards = FixtureCard;
            var departments = FixtureDepartment;

            var books = new List<Book>
            {
                new Book
                {
                    Id = 0,
                    Cipher = "1234/5678",
                    Author = "Иванов А.А.",
                    Name = "Свет в конце туннеля",
                    PlaceEdition = "Москва",
                    YearEdition = 1999,
                    TypeEditionId = 2,
                    Cards = { cards[0], cards[7] },
                    Departments = { departments[0] }
                },
                new Book
                {
                    Id = 1,
                    Cipher = "9876/5432",
                    Author = "Петров В.В.",
                    Name = "Шаг за шагом",
                    PlaceEdition = "Санкт-Петербург",
                    YearEdition = 2005,
                    TypeEditionId = 1,
                    Cards = { cards[3], cards[6] },
                    Departments = { departments[1] }
                },
                new Book
                {
                    Id = 2,
                    Cipher = "2468/1357",
                    Author = "Сидоров С.С.",
                    Name = "В поисках смысла",
                    PlaceEdition = "Екатеринбург",
                    YearEdition = 2010,
                    TypeEditionId = 0,
                    Cards = { cards[4], cards[5] },
                    Departments = { departments[2] }
                },
                new Book
                {
                    Id = 3,
                    Cipher = "5555/0000",
                    Author = "Федоров Л.И.",
                    Name = "Секреты Вселенной",
                    PlaceEdition = "Казань",
                    YearEdition = 2018,
                    TypeEditionId = 1,
                    Cards = { cards[1], cards[2] },
                    Departments = { departments[3], departments[4] }
                }
            };
            return books;
        }
    }

    public List<Department> FixtureDepartment
    {
        get
        {
            var departments = new List<Department>();

            for (int i = 0; i < 7; i++)
            {
                var department = new Department
                {
                    Id = i,
                    TypeDepartmentId = i % 3,
                    BookId = i % 4,
                    Count = (i + 2) * 2
                };

                departments.Add(department);
            }
            return departments;
        }
    }

    public List<Reader> FixtureReader
    {
        get
        {
            var cards = FixtureCard;
            var readers = new List<Reader>();

            var firstReader = new Reader
            {
                Id = 0,
                FullName = "Иванов Иван Иванович",
                Address = "ул. Ленина, д. 10, кв. 5",
                Phone = "89123456789",
                RegistrationDate = new DateTime(2023, 3, 15)
            };
            firstReader.Cards.Add(cards[0]);
            firstReader.Cards.Add(cards[1]);
            readers.Add(firstReader);

            var secondReader = new Reader
            {
                Id = 1,
                FullName = "Петров Петр Петрович",
                Address = "ул. Гагарина, д. 20, кв. 10",
                Phone = "89098765432",
                RegistrationDate = new DateTime(2023, 3, 16)
            };
            secondReader.Cards.Add(cards[2]);
            secondReader.Cards.Add(cards[3]);
            secondReader.Cards.Add(cards[4]);
            readers.Add(secondReader);

            var thirdReader = new Reader
            {
                Id = 2,
                FullName = "Сидоров Сидор Сидорович",
                Address = "ул. Пушкина, д. 30, кв. 15",
                Phone = "89987654321",
                RegistrationDate = new DateTime(2023, 3, 17)
            };
            thirdReader.Cards.Add(cards[5]);
            readers.Add(thirdReader);

            var fourthReader = new Reader
            {
                Id = 3,
                FullName = "Николаев Николай Николаевич",
                Address = "ул. Толстого, д. 40, кв. 20",
                Phone = "89991234567",
                RegistrationDate = new DateTime(2023, 3, 18)
            };
            fourthReader.Cards.Add(cards[6]);
            readers.Add(fourthReader);

            var fifthReader = new Reader
            {
                Id = 4,
                FullName = "Кузнецова Ольга Петровна",
                Address = "ул. Кирова, д. 50, кв. 25",
                Phone = "89876543210",
                RegistrationDate = new DateTime(2023, 3, 19)
            };
            fifthReader.Cards.Add(cards[7]);
            readers.Add(fifthReader);

            var sixthReader = new Reader
            {
                Id = 5,
                FullName = "Васильев Василий Васильевич",
                Address = "ул. Красной, д. 60, кв. 30",
                Phone = "89765432109",
                RegistrationDate = new DateTime(2023, 3, 20)
            };
            sixthReader.Cards.Add(cards[7]);
            readers.Add(sixthReader);

            return readers;
        }
    }

    public List<Card> FixtureCard
    {
        get
        {
            var cards = new List<Card>();

            var firstCard = new Card
            {
                Id = 0,
                DateIssue = new DateTime(2022, 12, 29),
                DateReturn = new DateTime(2023, 1, 28),
                DayCount = 31,
                ReaderId = 0,
                BookId = 0
            };
            cards.Add(firstCard);

            var secondCard = new Card
            {
                Id = 1,
                DateIssue = new DateTime(2022, 12, 29),
                DateReturn = new DateTime(2023, 1, 28),
                DayCount = 31,
                ReaderId = 0,
                BookId = 3
            };
            cards.Add(secondCard);

            var thirdCard = new Card
            {
                Id = 2,
                DateIssue = new DateTime(2022, 12, 29),
                DateReturn = new DateTime(2023, 1, 28),
                DayCount = 31,
                ReaderId = 1,
                BookId = 3
            };
            cards.Add(thirdCard);

            var fourthCard = new Card
            {
                Id = 3,
                DateIssue = new DateTime(2022, 12, 29),
                DateReturn = new DateTime(2023, 1, 28),
                DayCount = 31,
                ReaderId = 1,
                BookId = 1
            };
            cards.Add(fourthCard);

            var fifthCard = new Card
            {
                Id = 4,
                DateIssue = new DateTime(2022, 12, 29),
                DateReturn = new DateTime(2023, 1, 31),
                DayCount = 31,
                ReaderId = 1,
                BookId = 2
            };
            cards.Add(fifthCard);

            var sixthCard = new Card
            {
                Id = 5,
                DateIssue = new DateTime(2022, 12, 30),
                DateReturn = new DateTime(2023, 2, 14),
                DayCount = 30,
                ReaderId = 2,
                BookId = 2
            };
            cards.Add(sixthCard);

            var seventhCard = new Card
            {
                Id = 6,
                DateIssue = new DateTime(2022, 12, 30),
                DateReturn = new DateTime(2023, 2, 14),
                DayCount = 30,
                ReaderId = 3,
                BookId = 1
            };
            cards.Add(seventhCard);

            var eighthCard = new Card
            {
                Id = 7,
                DateIssue = new DateTime(2023, 2, 14),
                DateReturn = new DateTime(2023, 2, 28),
                DayCount = 21,
                ReaderId = 4,
                BookId = 0
            };
            cards.Add(eighthCard);

            return cards;
        }
    }
}