using SelectionCommittee.Domain;

namespace SelectionCommittee.Tests;

/// <summary>
/// Тестирование сущностей приемной комиссии с помощью LINQ.
/// </summary>
public class QueryTests
{
    /// <summary>
    /// Вывести информацию об абитуриентах из указанного города.
    /// </summary>
    [Fact]
    public void FirstQueryTest()
    {
        var defaultDate = DateTime.Now;
        var correctResult = new List<Enrollee>
        {
            new Enrollee()
            {
                FirstName = "Михаил",
                LastName = "Иванов",
                Country = "Russia",
                City = "Samara",
            },

            new Enrollee
            {
                FirstName = "Петр",
                LastName = "Игнатьев",
                Country = "Russia",
                City = "Samara",
            },
        };

        var enrollees = new List<Enrollee>
        {
            new Enrollee
            {
                FirstName = "Михаил",
                LastName = "Иванов",
                Country = "Russia",
                City = "Samara",

            },

            new Enrollee
            {
                FirstName = "Виктор",
                LastName = "Иванов",
                Country = "Russia",
                City = "Moscow",
            },

            new Enrollee
            {
                FirstName = "Петр",
                LastName = "Игнатьев",
                Country = "Russia",
                City = "Samara",
            },
        };


        var result = enrollees
            .Where(enrollee => enrollee.City == "Samara")
            .ToList();

        Assert.Equal(correctResult.Count, result.Count);

        for (var index = 0; index < result.Count; index++)
        {
            Assert.Equal(result[index].City, correctResult[index].City);
        }
    }

    /// <summary>
    /// Вывести информацию об абитуриентах старше 20 лет, упорядочить по ФИО.
    /// </summary>
    [Fact]
    public void SecondQueryTest()
    {
        var enrollees = new List<Enrollee>();
        var size = 10;


        for (var index = 0; index < size; index++)
        {
            enrollees.Add(new Enrollee
            {
                FirstName = $"FirstName{index}",
                LastName = $"LastName{index}",
                Patronymic = $"Patronymic{index}",
                Age = new Random().Next(21, 25)
            });
        }

        var correctResult = new List<Enrollee>(enrollees);

        enrollees.Add(new Enrollee
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Patronymic = "Patronymic",
            Age = 17
        });

        var result = enrollees
            .Where(enrollee => enrollee.Age > 20)
            .OrderBy(enrollee => enrollee.LastName)
            .ThenBy(enrollee => enrollee.FirstName)
            .ThenBy(enrollee => enrollee.Patronymic)
            .ToList();

        Assert.Equal(result.Count, correctResult.Count);

        for (var index = 0; index < result.Count; index++)
        {
            Assert.Equal(result[index].Age, correctResult[index].Age);
        }
    }

    /// <summary>
    /// Вывести информацию об абитуриентах, поступающих на указанную специальность (без учета приоритета),
    /// упорядочить по сумме баллов за экзамены.
    /// </summary>
    [Fact]
    public void ThirdQueryTest()
    {
        var enrollees = new List<Enrollee>
        {
            new Enrollee
            {
                FirstName = "Михаил",
                LastName = "Иванов",
                Country = "Russia",
                City = "Samara",
                Specializations = new List<Specialization>
                {
                    new Specialization
                    {
                        Name = "ИБАС"
                    }
                },
                ExamResults = new List<ExamResult>
                {
                    new ExamResult
                    {
                        Points = 0
                    }
                }

            },

            new Enrollee
            {
                FirstName = "Виктор",
                LastName = "Иванов",
                Country = "Russia",
                City = "Moscow",
                Specializations = new List<Specialization>
                {
                    new Specialization
                    {
                        Name = "ИБАС"
                    }
                },
                ExamResults = new List<ExamResult>
                {
                    new ExamResult
                    {
                        Points = 0
                    }
                }
            }
        };

        var correctResult = new List<Enrollee>(enrollees);

        enrollees.Add(new Enrollee
        {
            FirstName = "Петр",
            LastName = "Игнатьев",
            Country = "Russia",
            City = "Samara",
            Specializations = new List<Specialization>
            {
                new Specialization
                {
                    Name = "ФИИТ"
                }
            },
            ExamResults = new List<ExamResult>
                {
                    new ExamResult
                    {
                        Points = 0
                    }
                }
        });

        var result = enrollees
            .Where(enrollee => enrollee.Specializations![0].Name == "ИБАС")
            .OrderBy(enrollee => enrollee.ExamResults!.Sum(examResult => examResult.Points))
            .ToList();

        Assert.Equal(result.Count, correctResult.Count);

        for (var index = 0; index < result.Count; index++)
        {
            Assert.Equal(result[index].Specializations![0].Name, correctResult[index]
                .Specializations![0].Name);
        }
    }

    /// <summary>
    /// Вывести информацию о количестве абитуриентов, поступающих на каждую специальность по первому 
    /// приоритету.
    /// </summary>
    [Fact]
    public void FourthQueryTest()
    {
        var correctResult = new List<Enrollee>
        {
            new Enrollee
            {
                FirstName = "Михаил",
                LastName = "Иванов",
                Country = "Russia",
                City = "Samara",
                Specializations = new List<Specialization>
                {
                    new Specialization
                    {
                        Name = "ИБАС",
                        Priority = 1
                    }
                },
                ExamResults = new List<ExamResult>
                {
                    new ExamResult
                    {
                        Points = 0
                    }
                }
            },

            new Enrollee
            {
                FirstName = "Михаил",
                LastName = "Иванов",
                Country = "Russia",
                City = "Samara",
                Specializations = new List<Specialization>
                {
                    new Specialization
                    {
                        Name = "ИБАС",
                        Priority = 1
                    }
                },
                ExamResults = new List<ExamResult>
                {
                    new ExamResult
                    {
                        Points = 0
                    }
                }
            },
        };

        var enrollees = new List<Enrollee>(correctResult);
        enrollees.Add(new Enrollee
        {
            FirstName = "Михаил",
            LastName = "Иванов",
            Country = "Russia",
            City = "Samara",
            Specializations = new List<Specialization>
                {
                    new Specialization
                    {
                        Name = "ИБАС",
                        Priority = 2
                    }
                },
            ExamResults = new List<ExamResult>
                {
                    new ExamResult
                    {
                        Points = 0
                    }
                }
        });

        var result = enrollees
            .Where(enrollee => enrollee.Specializations![0].Name == "ИБАС"
                && enrollee.Specializations![0].Priority == 1)
            .ToList();

        Assert.Equal(result.Count, correctResult.Count);

        for (var index = 0; index < correctResult.Count; index++)
        {
            Assert.True(result[index].Specializations![0].Priority == 1);
        }
    }

    /// <summary>
    /// Вывести информацию о топ 5 абитуриентах, набравших наибольшее число баллов за три предмета.
    /// </summary>
    [Fact]
    public void FifthQueryTest()
    {
        var pointsList = new List<int> { 200, 190, 180, 170, 160, 150, 140, 130 };
        var correctResult = new List<Enrollee>();
        var enrollees = new List<Enrollee>();
        var resultSize = 5;

        for (var i = 0; i < resultSize; i++)
        {
            correctResult.Add(new Enrollee
            {
                ExamResults = new List<ExamResult>
                {
                    new ExamResult
                    {
                        Points = pointsList[i]
                    }
                }
            });
        }

        for (var i = pointsList.Count - 1; i >= 0; i--)
        {
            enrollees.Add(new Enrollee
            {
                ExamResults = new List<ExamResult>
                {
                    new ExamResult
                    {
                        Points = pointsList[i]
                    }
                }
            });
        }

        var result = enrollees
            .OrderByDescending(enrollee =>
                enrollee!.ExamResults!.Sum(examResult => examResult.Points))
            .Take(5)
            .ToList();

        Assert.Equal(result.Count, correctResult.Count);

        for (var i = 0; i < result.Count; i++)
        {
            Assert.Equal(result[i]!.ExamResults![0].Points, correctResult[i]!.ExamResults![0].Points);
        }
    }
}
