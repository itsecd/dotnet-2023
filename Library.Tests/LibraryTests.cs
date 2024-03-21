namespace Library.Tests
{
    public class LibraryTests : IClassFixture<LibraryTheory>
    {
        private readonly LibraryTheory _fixture;

        public LibraryTests(LibraryTheory fixture)
        {
            _fixture = fixture;
        }

        /// <summary>
        /// 1) Вывести информацию о выбранной книге по ее шифру.
        /// </summary>
        [Fact]
        public void CipherTest()
        {
            var fixtureBook = _fixture.FixtureBook.ToList();
            var request = (from book in fixtureBook
                           where book.Cipher == "1234/5678"
                           select book).Count();
            Assert.Equal(1, request);
        }

        /// <summary>
        /// 2) Вывести информацию о выданных книгах, упорядоченных по названию.
        /// </summary>
        [Fact]
        public void BooksTest()
        {
            var fixtureBook = _fixture.FixtureBook.ToList();
            var fixtureCard = _fixture.FixtureCard.ToList();
            var request = (from book in fixtureBook
                           join card in fixtureCard on book.Id equals card.BookId
                           orderby book.Name
                           group book by book.Id into b
                           select b).Count();
            Assert.Equal(4, request);
        }

        /// <summary>
        /// 3) Вывести информацию о наличии выбранной книги в разных отделах и количестве.
        /// </summary>
        [Fact]
        public void CountBooksTest()
        {
            var fixtureBook = _fixture.FixtureBook.ToList();
            var fixtureDepartment = _fixture.FixtureDepartment.ToList();
            var request = (from department in fixtureDepartment
                           join book in fixtureBook on department.BookId equals book.Id
                           where book.Id == 2
                           select new { departments = department, count = department.Count }).ToList();
            Assert.Equal(2, request.Count());
            Assert.Equal(8, request.First(x => x.departments.Id == 2).count);
            Assert.Equal(16, request.First(x => x.departments.Id == 6).count);
        }

        /// <summary>
        /// 4) Вывести информацию о количестве книг в различных отделах для каждого типа издания.
        /// </summary>
        [Fact]
        public void CountTypesTest()
        {
            var fixtureBook = _fixture.FixtureBook.ToList();
            var fixtureTypeEdition = _fixture.FixtureTypeEdition.ToList();
            var fixtureDepartment = _fixture.FixtureDepartment.ToList();
            var request = (from mass in
                           (from department in fixtureDepartment
                            join book in fixtureBook on department.BookId equals book.Id
                            join type in fixtureTypeEdition on book.TypeEditionId equals type.Id
                            select new
                            {
                                types = type.Name,
                                count = department.Count
                            })
                           group mass by mass.types into gr
                           select new
                           {
                               Count = gr.Sum(ret => ret.count),
                               gr.Key
                           }).ToList();
            Assert.Equal(24, request.First(x => x.Key == "Tutorial").Count);
            Assert.Equal(30, request.First(x => x.Key == "Monograph").Count);
            Assert.Equal(16, request.First(x => x.Key == "Methodological guidelines").Count);
        }

        /// <summary>
        /// 5) Вывести информацию о топ 5 читателей, прочитавших больше всего книг за заданный период.
        /// </summary>
        [Fact]
        public void TopFiveTest()
        {
            var fixtureCard = _fixture.FixtureCard.ToList();
            var fixtureReader = _fixture.FixtureReader.ToList();
            var date = new DateTime(2023, 3, 1);
            var numOfReaders = (from card in fixtureCard
                                join reader in fixtureReader on card.ReaderId equals reader.Id
                                where card.DateReturn < date
                                group card by reader.Id into g
                                select new
                                {
                                    readers = g.Key,
                                    count = g.Count()
                                }).ToList();
            var request = (from reader in numOfReaders
                           orderby reader.count descending
                           select reader).Take(5).ToList();
            var first = request.First();
            Assert.Equal(1, first.readers);
            Assert.Equal(5, request.Count);
        }

        /// <summary>
        /// 6) Вывести информацию о читателях, задержавших книги на наибольший период времени, упорядочить по ФИО
        /// </summary>
        [Fact]
        public void DelayReadersTest()
        {
            var fixtureCard = _fixture.FixtureCard.ToList();
            var fixtureReader = _fixture.FixtureReader.ToList();
            var maxDelay = (from card in fixtureCard
                            join reader in fixtureReader on card.ReaderId equals reader.Id
                            group card by reader.FullName into g
                            select new
                            {
                                Delay = g.Key,
                                MaxDay = g.Select(x => (x.DateReturn - x.DateIssue).TotalDays - x.DayCount).Max(),
                                Count = g.Count()
                            }).ToList();
            var request = (from readers in maxDelay
                           where (readers.MaxDay == maxDelay.Max(x => x.MaxDay))
                           orderby readers.Delay
                           select readers.Count).Count();
            Assert.Equal(2, request);
        }
    }
}
