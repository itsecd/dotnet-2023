namespace AdmissionCommittee.Model;

/// <summary>
/// class containing initial data
/// </summary>
public class InitialData
{
    /// <summary>
    /// list of Entrants
    /// </summary>
    public List<Entrant> Entrants { get; set; } = null!;

    /// <summary>
    /// list link between Entrant and Result
    /// </summary>
    public List<EntrantResult> EntrantResults { get; set; } = null!;

    /// <summary>
    /// list of Results
    /// </summary>
    public List<Result> Results { get; set; } = null!;

    /// <summary>
    /// link of Statements
    /// </summary>
    public List<Statement> Statements { get; set; } = null!;

    /// <summary>
    /// list link between Statement and Specialty
    /// </summary>
    public List<StatementSpecialty> StatementSpecialties { get; set; } = null!;

    /// <summary>
    /// list of Specialties
    /// </summary>
    public List<Specialty> Specialties { get; set; } = null!;

    private void CreateEntrants()
    {
        Entrants = new List<Entrant>()
        {
            new Entrant
            {
                IdEntrant = 1,
                FullName = "Lebedeva Kira Romanovna",
                DateBirth = new DateTime(2005, 01, 19),
                Country = "Russian Federation",
                City = "Saint-Petersburg"
            },

            new Entrant
            {
                IdEntrant = 2,
                FullName = "Popova Eva Artemovna",
                DateBirth = new DateTime(2002, 11, 12),
                Country = "Russian Federation",
                City = "Kazan"
            },

            new Entrant
            {
                IdEntrant = 3,
                FullName = "Novikov Roman Evgenievich",
                DateBirth = new DateTime(2005, 08, 29),
                Country = "Kazakhstan",
                City = "Astana",
            },

            new Entrant
            {
                IdEntrant = 4,
                FullName = "Isaev Nikita Grigorievich",
                DateBirth = new DateTime(2001, 01, 01),
                Country = "Russian Federation",
                City = "Saint-Petersburg"
            },
            new Entrant
            {
                IdEntrant = 5,
                FullName = "Pastukhova Sofya Maksimovna",
                DateBirth = new DateTime(2004, 01, 29),
                Country = "Uzbekistan",
                City = "Tashkent"
            },
            new Entrant
            {
                IdEntrant = 6,
                FullName = "Gromova Alyona Andreevna",
                DateBirth = new DateTime(2003, 08, 02),
                Country = "Russian Federation",
                City = "Ekaterinburg"
            },
            new Entrant
            {
                IdEntrant = 7,
                FullName = "Bykova Anastasia Miroslavovna",
                DateBirth = new DateTime(2003, 08, 30),
                Country = "Uzbekistan",
                City = "Mirabad"
            },

            new Entrant
            {
                IdEntrant = 8,
                FullName = "Soboleva Alice Yaroslavovna",
                DateBirth = new DateTime(2003, 08, 03),
                Country = "Russian Federation",
                City = "Azov"
            },

            new Entrant
            {
                IdEntrant = 9,
                FullName = "Kalinina Elena Vasilyevna",
                DateBirth = new DateTime(2003, 02, 01),
                Country = "Russian Federation",
                City = "Samara"
            },

            new Entrant
            {
                IdEntrant = 10,
                FullName = "Vinogradov Dmitry Artemovich",
                DateBirth = new DateTime(2005, 05, 31),
                Country = "Latvia",
                City = "Smiltene"
            }
        };
    }

    private void CreateEntrantResults()
    {
        EntrantResults = new List<EntrantResult>()
        {
            new EntrantResult {IdEntrantResult = 1, EntrantId = 1,ResultId = 1, Mark = 100 },
            new EntrantResult {IdEntrantResult = 2, EntrantId = 1,ResultId = 2, Mark = 100 },
            new EntrantResult {IdEntrantResult = 3, EntrantId = 1,ResultId = 3, Mark = 100 },

            new EntrantResult {IdEntrantResult = 4, EntrantId = 2,ResultId = 4, Mark = 77 },
            new EntrantResult {IdEntrantResult = 5, EntrantId = 2,ResultId = 5, Mark = 57 },
            new EntrantResult {IdEntrantResult = 6, EntrantId = 2,ResultId = 6, Mark = 78 },

            new EntrantResult {IdEntrantResult = 7, EntrantId = 3,ResultId = 7, Mark = 58 },
            new EntrantResult {IdEntrantResult = 8, EntrantId = 3,ResultId = 8, Mark = 95 },
            new EntrantResult {IdEntrantResult = 9, EntrantId = 3,ResultId = 9, Mark = 71 },

            new EntrantResult {IdEntrantResult = 10, EntrantId = 4,ResultId = 10, Mark = 79 },
            new EntrantResult {IdEntrantResult = 11, EntrantId = 4,ResultId = 11, Mark = 54 },
            new EntrantResult {IdEntrantResult = 12, EntrantId = 4,ResultId = 12, Mark = 57 },

            new EntrantResult {IdEntrantResult = 13, EntrantId = 5,ResultId = 13, Mark = 57 },
            new EntrantResult {IdEntrantResult = 14, EntrantId = 5,ResultId = 14, Mark = 65 },
            new EntrantResult {IdEntrantResult = 15, EntrantId = 5,ResultId = 15, Mark = 72 },

            new EntrantResult {IdEntrantResult = 16, EntrantId = 6,ResultId = 16, Mark = 48 },
            new EntrantResult {IdEntrantResult = 17, EntrantId = 6,ResultId = 17, Mark = 93 },
            new EntrantResult {IdEntrantResult = 18, EntrantId = 6,ResultId = 18, Mark = 59 },

            new EntrantResult {IdEntrantResult = 19, EntrantId = 7,ResultId = 19, Mark = 67 },
            new EntrantResult {IdEntrantResult = 20, EntrantId = 7,ResultId = 20, Mark = 56 },
            new EntrantResult {IdEntrantResult = 21, EntrantId = 7,ResultId = 21, Mark = 42 },

            new EntrantResult {IdEntrantResult = 22, EntrantId = 8,ResultId = 22, Mark = 90 },
            new EntrantResult {IdEntrantResult = 23, EntrantId = 8,ResultId = 23, Mark = 77 },
            new EntrantResult {IdEntrantResult = 24, EntrantId = 8,ResultId = 24, Mark = 92 },

            new EntrantResult {IdEntrantResult = 25, EntrantId = 9,ResultId = 25, Mark = 71 },
            new EntrantResult {IdEntrantResult = 26, EntrantId = 9,ResultId = 26, Mark = 74 },
            new EntrantResult {IdEntrantResult = 27, EntrantId = 9,ResultId = 27, Mark = 98 },

            new EntrantResult {IdEntrantResult = 28, EntrantId = 10,ResultId = 28, Mark = 68 },
            new EntrantResult {IdEntrantResult = 29, EntrantId = 10,ResultId = 29, Mark = 72 },
            new EntrantResult {IdEntrantResult = 30, EntrantId = 10,ResultId = 30, Mark = 74 },
        };
    }

    private void CreateResuts()
    {
        Results = new List<Result>()
        {
            new Result { IdResult = 1, NameSubject = "Mathematics" },
            new Result { IdResult = 2, NameSubject = "Russian language" },
            new Result { IdResult = 3, NameSubject = "Physics" },

            new Result { IdResult = 4, NameSubject = "Mathematics" },
            new Result { IdResult = 5, NameSubject = "Russian language" },
            new Result { IdResult = 6, NameSubject = "Physics" },

            new Result { IdResult = 7, NameSubject = "Mathematics" },
            new Result { IdResult = 8, NameSubject = "Russian language" },
            new Result { IdResult = 9, NameSubject = "Computer science" },

            new Result { IdResult = 10, NameSubject = "Mathematics" },
            new Result { IdResult = 11, NameSubject = "Russian language" },
            new Result { IdResult = 12, NameSubject = "Social Studies" },

            new Result { IdResult = 13, NameSubject = "Mathematics" },
            new Result { IdResult = 14, NameSubject = "Russian language" },
            new Result { IdResult = 15, NameSubject = "History" },

            new Result { IdResult = 16, NameSubject = "Mathematics" },
            new Result { IdResult = 17, NameSubject = "Russian language" },
            new Result { IdResult = 18, NameSubject = "History" },

            new Result { IdResult = 19, NameSubject = "Mathematics" },
            new Result { IdResult = 20, NameSubject = "Russian language" },
            new Result { IdResult = 21, NameSubject = "Chemistry" },

            new Result { IdResult = 22, NameSubject = "Mathematics" },
            new Result { IdResult = 23, NameSubject = "Russian language" },
            new Result { IdResult = 24, NameSubject = "English language" },

            new Result { IdResult = 25, NameSubject = "Mathematics" },
            new Result { IdResult = 26, NameSubject = "Russian language" },
            new Result { IdResult = 27, NameSubject = "English language" },

            new Result { IdResult = 28, NameSubject = "Mathematics" },
            new Result { IdResult = 29, NameSubject = "Russian language" },
            new Result { IdResult = 30, NameSubject = "Chemistry" }
        };
    }

    private void CreateStatements()
    {
        Statements = new List<Statement>()
        {
            new Statement {IdStatement = 1, EntrantId = 1},
            new Statement {IdStatement = 2, EntrantId = 2},
            new Statement {IdStatement = 3, EntrantId = 3},
            new Statement {IdStatement = 4, EntrantId = 4},
            new Statement {IdStatement = 5, EntrantId = 5},
            new Statement {IdStatement = 6, EntrantId = 6},
            new Statement {IdStatement = 7, EntrantId = 7},
            new Statement {IdStatement = 8, EntrantId = 8},
            new Statement {IdStatement = 9, EntrantId = 9},
            new Statement {IdStatement = 10, EntrantId = 10}
        };
    }

    private void CreateStatementSpecialties()
    {
        StatementSpecialties = new List<StatementSpecialty>()
        {
            new StatementSpecialty { IdStatementSpecialty = 1, StatementId = 1, SpecialtyId = 1, Priority = 1 },
            new StatementSpecialty { IdStatementSpecialty = 2, StatementId = 1, SpecialtyId = 2, Priority = 2 },
            new StatementSpecialty { IdStatementSpecialty = 3, StatementId = 1, SpecialtyId = 5, Priority = 3 },

            new StatementSpecialty { IdStatementSpecialty = 4, StatementId = 2, SpecialtyId = 2, Priority = 1 },
            new StatementSpecialty { IdStatementSpecialty = 5, StatementId = 2, SpecialtyId = 1, Priority = 2 },

            new StatementSpecialty { IdStatementSpecialty = 6, StatementId = 3, SpecialtyId = 1, Priority = 1 },
            new StatementSpecialty { IdStatementSpecialty = 7, StatementId = 3, SpecialtyId = 5, Priority = 2 },
            new StatementSpecialty { IdStatementSpecialty = 8, StatementId = 3, SpecialtyId = 2, Priority = 3 },

            new StatementSpecialty { IdStatementSpecialty = 9, StatementId = 4, SpecialtyId = 3, Priority = 1 },
            new StatementSpecialty { IdStatementSpecialty = 10, StatementId = 4, SpecialtyId = 4, Priority = 2 },

            new StatementSpecialty { IdStatementSpecialty = 11, StatementId = 5, SpecialtyId = 4, Priority = 1 },
            new StatementSpecialty { IdStatementSpecialty = 12, StatementId = 5, SpecialtyId = 3, Priority = 2 },

            new StatementSpecialty { IdStatementSpecialty = 13, StatementId = 6, SpecialtyId = 3, Priority = 1 },
            new StatementSpecialty { IdStatementSpecialty = 14, StatementId = 6, SpecialtyId = 6, Priority = 2 },

            new StatementSpecialty { IdStatementSpecialty = 15, StatementId = 7, SpecialtyId = 7, Priority = 1 },

            new StatementSpecialty { IdStatementSpecialty = 16, StatementId = 8, SpecialtyId = 4, Priority = 1 },
            new StatementSpecialty { IdStatementSpecialty = 17, StatementId = 8, SpecialtyId = 6, Priority = 2 },

            new StatementSpecialty { IdStatementSpecialty = 18, StatementId = 9, SpecialtyId = 4, Priority = 1 },
            new StatementSpecialty { IdStatementSpecialty = 19, StatementId = 9, SpecialtyId = 6, Priority = 2 },

            new StatementSpecialty { IdStatementSpecialty = 20, StatementId = 10, SpecialtyId = 7, Priority = 1 },

        };
    }

    private void CreateSpecialties()
    {
        Specialties = new List<Specialty>()
        {
            new Specialty
            {
                IdSpecialty = 1,
                Cypher="100503D",
                NameSpecialty="Information security of automated systems",
                Faculty = "Computer science and Cybernetics",
            },

            new Specialty
            {
                IdSpecialty = 2,
                Cypher = "010302D",
                NameSpecialty = "Applied Mathematics and Computer science",
                Faculty = "Computer science and Cybernetics",
            },

            new Specialty
            {
                IdSpecialty = 3,
                Cypher = "390301D",
                NameSpecialty = "Sociology",
                Faculty = "Sociological",
            },

            new Specialty
            {
                IdSpecialty = 4,
                Cypher = "410305D",
                NameSpecialty = "International relations",
                Faculty = "Historical",
            },

            new Specialty
            {
                IdSpecialty = 5,
                Cypher = "020302D",
                NameSpecialty = "Computer security",
                Faculty = "Computer science and Cybernetics",
            },

            new Specialty
            {
                IdSpecialty = 6,
                Cypher = "020301D",
                NameSpecialty = "International relations and foreign policy",
                Faculty = "Historical",
            },

            new Specialty
            {
                IdSpecialty = 7,
                Cypher = "040401D",
                NameSpecialty = "Chemistry",
                Faculty = "Natural Science",
            }
        };
    }

    public InitialData()
    {
        CreateEntrants();
        CreateEntrantResults();
        CreateResuts();
        CreateStatements();
        CreateStatementSpecialties();
        CreateSpecialties();
    }
}