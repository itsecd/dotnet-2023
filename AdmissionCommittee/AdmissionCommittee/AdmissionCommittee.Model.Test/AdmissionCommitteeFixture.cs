namespace AdmissionCommittee.Model.Test;
public class AdmissionCommitteeFixture
{
    /// <summary>
    /// List of Specialty with empty StatementSpecialties
    /// </summary>
    public List<Specialty> SpecialityFixture
    {
        get
        {
            return new List<Specialty>
            {
                new Specialty
                {
                    IdSpecialty = 1,
                    Cypher="100503D",
                    NameSpecialty="Information security of automated systems",
                    Faculty = "Computer science and Cybernetics",
                    StatementSpecialties = new List<StatementSpecialty>()
                },

                new Specialty
                {
                    IdSpecialty = 2,
                    Cypher = "010302D",
                    NameSpecialty = "Applied Mathematics and Computer science",
                    Faculty = "Computer science and Cybernetics",
                    StatementSpecialties = new List<StatementSpecialty>()
                },

                new Specialty
                {
                    IdSpecialty = 3,
                    Cypher = "390301D",
                    NameSpecialty = "Sociology",
                    Faculty = "Sociological",
                    StatementSpecialties = new List<StatementSpecialty>()
                },

                new Specialty
                {
                    IdSpecialty = 4,
                    Cypher = "410305D",
                    NameSpecialty = "International relations",
                    Faculty = "Historical",
                    StatementSpecialties = new List<StatementSpecialty>()
                },

                new Specialty
                {
                    IdSpecialty = 5,
                    Cypher = "020302D",
                    NameSpecialty = "Computer security",
                    Faculty = "Computer science and Cybernetics",
                    StatementSpecialties = new List<StatementSpecialty>()
                },

                new Specialty
                {
                    IdSpecialty = 6,
                    Cypher = "020301D",
                    NameSpecialty = "International relations and foreign policy",
                    Faculty = "Historical",
                    StatementSpecialties = new List<StatementSpecialty>()
                },

                new Specialty
                {
                    IdSpecialty = 7,
                    Cypher = "040401D",
                    NameSpecialty = "Chemistry",
                    Faculty = "Natural Science",
                    StatementSpecialties = new List<StatementSpecialty>()
                }
            };
        }
    }

    /// <summary>
    /// List of StatementSpecialty with Speciality and empty Statement
    /// </summary>
    public List<StatementSpecialty> StatementSpecialtyWithSpecialtyFixture
    {
        get
        {
            var specialtyList = SpecialityFixture;

            var statementSpecialtyList = new List<StatementSpecialty>()
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

            specialtyList[0].StatementSpecialties.Add(statementSpecialtyList[0]);
            specialtyList[0].StatementSpecialties.Add(statementSpecialtyList[4]);
            specialtyList[0].StatementSpecialties.Add(statementSpecialtyList[5]);

            specialtyList[1].StatementSpecialties.Add(statementSpecialtyList[1]);
            specialtyList[1].StatementSpecialties.Add(statementSpecialtyList[3]);
            specialtyList[1].StatementSpecialties.Add(statementSpecialtyList[7]);

            specialtyList[2].StatementSpecialties.Add(statementSpecialtyList[8]);
            specialtyList[2].StatementSpecialties.Add(statementSpecialtyList[11]);
            specialtyList[2].StatementSpecialties.Add(statementSpecialtyList[12]);

            specialtyList[3].StatementSpecialties.Add(statementSpecialtyList[9]);
            specialtyList[3].StatementSpecialties.Add(statementSpecialtyList[10]);
            specialtyList[3].StatementSpecialties.Add(statementSpecialtyList[15]);
            specialtyList[3].StatementSpecialties.Add(statementSpecialtyList[17]);

            specialtyList[4].StatementSpecialties.Add(statementSpecialtyList[2]);
            specialtyList[4].StatementSpecialties.Add(statementSpecialtyList[6]);

            specialtyList[5].StatementSpecialties.Add(statementSpecialtyList[13]);
            specialtyList[5].StatementSpecialties.Add(statementSpecialtyList[16]);
            specialtyList[5].StatementSpecialties.Add(statementSpecialtyList[18]);

            specialtyList[6].StatementSpecialties.Add(statementSpecialtyList[14]);
            specialtyList[6].StatementSpecialties.Add(statementSpecialtyList[19]);


            statementSpecialtyList[0].Specialty = specialtyList[0];
            statementSpecialtyList[1].Specialty = specialtyList[1];
            statementSpecialtyList[2].Specialty = specialtyList[4];
            statementSpecialtyList[3].Specialty = specialtyList[1];
            statementSpecialtyList[4].Specialty = specialtyList[0];
            statementSpecialtyList[5].Specialty = specialtyList[0];
            statementSpecialtyList[6].Specialty = specialtyList[4];
            statementSpecialtyList[7].Specialty = specialtyList[1];
            statementSpecialtyList[8].Specialty = specialtyList[2];
            statementSpecialtyList[9].Specialty = specialtyList[3];
            statementSpecialtyList[10].Specialty = specialtyList[3];
            statementSpecialtyList[11].Specialty = specialtyList[2];
            statementSpecialtyList[12].Specialty = specialtyList[2];
            statementSpecialtyList[13].Specialty = specialtyList[5];
            statementSpecialtyList[14].Specialty = specialtyList[6];
            statementSpecialtyList[15].Specialty = specialtyList[3];
            statementSpecialtyList[16].Specialty = specialtyList[5];
            statementSpecialtyList[17].Specialty = specialtyList[3];
            statementSpecialtyList[18].Specialty = specialtyList[5];
            statementSpecialtyList[19].Specialty = specialtyList[6];

            return statementSpecialtyList;
        }
    }

    /// <summary>
    /// List of Statement with StatementSpecialty and empty Entrant
    /// </summary>
    public List<Statement> StatementFixture
    {
        get
        {
            var statementSpecialtyList = StatementSpecialtyWithSpecialtyFixture;

            var statementList = new List<Statement>
            {
                new Statement {IdStatement = 1},
                new Statement {IdStatement = 2},
                new Statement {IdStatement = 3},
                new Statement {IdStatement = 4},
                new Statement {IdStatement = 5},
                new Statement {IdStatement = 6},
                new Statement {IdStatement = 7},
                new Statement {IdStatement = 8},
                new Statement {IdStatement = 9},
                new Statement {IdStatement = 10}
            };

            statementSpecialtyList[0].Statement = statementList[0];
            statementSpecialtyList[1].Statement = statementList[0];
            statementSpecialtyList[2].Statement = statementList[0];

            statementSpecialtyList[3].Statement = statementList[1];
            statementSpecialtyList[4].Statement = statementList[1];

            statementSpecialtyList[5].Statement = statementList[2];
            statementSpecialtyList[6].Statement = statementList[2];
            statementSpecialtyList[7].Statement = statementList[2];

            statementSpecialtyList[8].Statement = statementList[3];
            statementSpecialtyList[9].Statement = statementList[3];

            statementSpecialtyList[10].Statement = statementList[4];
            statementSpecialtyList[11].Statement = statementList[4];

            statementSpecialtyList[12].Statement = statementList[5];
            statementSpecialtyList[13].Statement = statementList[5];

            statementSpecialtyList[14].Statement = statementList[6];

            statementSpecialtyList[15].Statement = statementList[7];
            statementSpecialtyList[16].Statement = statementList[7];

            statementSpecialtyList[17].Statement = statementList[8];
            statementSpecialtyList[18].Statement = statementList[8];

            statementSpecialtyList[19].Statement = statementList[9];


            statementList[0].StatementSpecialties.Add(statementSpecialtyList[0]);
            statementList[0].StatementSpecialties.Add(statementSpecialtyList[1]);
            statementList[0].StatementSpecialties.Add(statementSpecialtyList[2]);

            statementList[1].StatementSpecialties.Add(statementSpecialtyList[3]);
            statementList[1].StatementSpecialties.Add(statementSpecialtyList[4]);

            statementList[2].StatementSpecialties.Add(statementSpecialtyList[5]);
            statementList[2].StatementSpecialties.Add(statementSpecialtyList[6]);
            statementList[2].StatementSpecialties.Add(statementSpecialtyList[7]);

            statementList[3].StatementSpecialties.Add(statementSpecialtyList[8]);
            statementList[3].StatementSpecialties.Add(statementSpecialtyList[9]);

            statementList[4].StatementSpecialties.Add(statementSpecialtyList[10]);
            statementList[4].StatementSpecialties.Add(statementSpecialtyList[11]);

            statementList[5].StatementSpecialties.Add(statementSpecialtyList[12]);
            statementList[5].StatementSpecialties.Add(statementSpecialtyList[13]);

            statementList[6].StatementSpecialties.Add(statementSpecialtyList[14]);

            statementList[7].StatementSpecialties.Add(statementSpecialtyList[15]);
            statementList[7].StatementSpecialties.Add(statementSpecialtyList[16]);

            statementList[8].StatementSpecialties.Add(statementSpecialtyList[17]);
            statementList[8].StatementSpecialties.Add(statementSpecialtyList[18]);

            statementList[9].StatementSpecialties.Add(statementSpecialtyList[19]);

            return statementList;
        }
    }

    /// <summary>
    /// List of Result with empty EntrantResult
    /// </summary>
    public List<Result> ResultFixture
    {
        get
        {
            return new List<Result>
            {
                new Result { IdResult = 1, NameSubject = "Mathematics", EntrantResults=new List<EntrantResult>() },
                new Result { IdResult = 2, NameSubject = "Russian language", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 3, NameSubject = "Physics", EntrantResults = new List<EntrantResult>() },

                new Result { IdResult = 4, NameSubject = "Mathematics", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 5, NameSubject = "Russian language", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 6, NameSubject = "Physics", EntrantResults = new List<EntrantResult>() },

                new Result { IdResult = 7, NameSubject = "Mathematics", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 8, NameSubject = "Russian language", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 9, NameSubject = "Computer science", EntrantResults = new List<EntrantResult>() },

                new Result { IdResult = 10, NameSubject = "Mathematics", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 11, NameSubject = "Russian language", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 12, NameSubject = "Social Studies", EntrantResults = new List<EntrantResult>() },

                new Result { IdResult = 13, NameSubject = "Mathematics", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 14, NameSubject = "Russian language", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 15, NameSubject = "History", EntrantResults = new List<EntrantResult>() },

                new Result { IdResult = 16, NameSubject = "Mathematics", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 17, NameSubject = "Russian language", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 18, NameSubject = "History", EntrantResults = new List<EntrantResult>() },

                new Result { IdResult = 19, NameSubject = "Mathematics", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 20, NameSubject = "Russian language", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 21, NameSubject = "Chemistry", EntrantResults = new List<EntrantResult>() },

                new Result { IdResult = 22, NameSubject = "Mathematics", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 23, NameSubject = "Russian language", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 24, NameSubject = "English language", EntrantResults = new List<EntrantResult>() },

                new Result { IdResult = 25, NameSubject = "Mathematics", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 26, NameSubject = "Russian language", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 27, NameSubject = "English language", EntrantResults = new List<EntrantResult>() },

                new Result { IdResult = 28, NameSubject = "Mathematics", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 29, NameSubject = "Russian language", EntrantResults = new List<EntrantResult>() },
                new Result { IdResult = 30, NameSubject = "Chemistry", EntrantResults = new List<EntrantResult>() }
            };
        }
    }

    /// <summary>
    /// List of EntrantResult with Result and empty Entrant
    /// </summary>
    public List<EntrantResult> EntrantResultWithResultFixture
    {
        get
        {
            var resultList = ResultFixture;
            var entrantResultList = new List<EntrantResult>()
            {
                new EntrantResult {EntrantId = 1,ResultId = 1, Mark = 100},
                new EntrantResult {EntrantId = 1,ResultId = 2, Mark = 100 },
                new EntrantResult {EntrantId = 1,ResultId = 3, Mark = 100 },

                new EntrantResult {EntrantId = 2,ResultId = 4 , Mark = 77},
                new EntrantResult {EntrantId = 2,ResultId = 5, Mark = 57 },
                new EntrantResult {EntrantId = 2,ResultId = 6, Mark = 78 },

                new EntrantResult {EntrantId = 3,ResultId = 7, Mark = 58 },
                new EntrantResult {EntrantId = 3,ResultId = 8, Mark = 95 },
                new EntrantResult {EntrantId = 3,ResultId = 9, Mark = 71 },

                new EntrantResult {EntrantId = 4,ResultId = 10, Mark = 79},
                new EntrantResult {EntrantId = 4,ResultId = 11, Mark = 54 },
                new EntrantResult {EntrantId = 4,ResultId = 12, Mark = 57 },

                new EntrantResult {EntrantId = 5,ResultId = 13, Mark = 57 },
                new EntrantResult {EntrantId = 5,ResultId = 14, Mark = 65 },
                new EntrantResult {EntrantId = 5,ResultId = 15, Mark = 72 },

                new EntrantResult {EntrantId = 6,ResultId = 16, Mark = 48 },
                new EntrantResult {EntrantId = 6,ResultId = 17, Mark = 93 },
                new EntrantResult {EntrantId = 6,ResultId = 18, Mark = 59 },

                new EntrantResult {EntrantId = 7,ResultId = 19, Mark = 67 },
                new EntrantResult {EntrantId = 7,ResultId = 20, Mark = 56 },
                new EntrantResult {EntrantId = 7,ResultId = 21, Mark = 42 },

                new EntrantResult {EntrantId = 8,ResultId = 22, Mark = 90 },
                new EntrantResult {EntrantId = 8,ResultId = 23, Mark = 77 },
                new EntrantResult {EntrantId = 8,ResultId = 24, Mark = 92 },

                new EntrantResult {EntrantId = 9,ResultId = 25, Mark = 71},
                new EntrantResult {EntrantId = 9,ResultId = 26, Mark = 74},
                new EntrantResult {EntrantId = 9,ResultId = 27, Mark = 98 },

                new EntrantResult {EntrantId = 10,ResultId = 28, Mark = 68 },
                new EntrantResult {EntrantId = 10,ResultId = 29, Mark = 72 },
                new EntrantResult {EntrantId = 10,ResultId = 30, Mark = 74 },

            };

            resultList[0].EntrantResults.Add(entrantResultList[0]);
            resultList[1].EntrantResults.Add(entrantResultList[1]);
            resultList[2].EntrantResults.Add(entrantResultList[2]);
            resultList[3].EntrantResults.Add(entrantResultList[3]);
            resultList[4].EntrantResults.Add(entrantResultList[4]);

            resultList[5].EntrantResults.Add(entrantResultList[5]);
            resultList[6].EntrantResults.Add(entrantResultList[6]);
            resultList[7].EntrantResults.Add(entrantResultList[7]);
            resultList[8].EntrantResults.Add(entrantResultList[8]);
            resultList[9].EntrantResults.Add(entrantResultList[9]);

            resultList[10].EntrantResults.Add(entrantResultList[10]);
            resultList[11].EntrantResults.Add(entrantResultList[11]);
            resultList[12].EntrantResults.Add(entrantResultList[12]);
            resultList[13].EntrantResults.Add(entrantResultList[13]);
            resultList[14].EntrantResults.Add(entrantResultList[14]);

            resultList[15].EntrantResults.Add(entrantResultList[15]);
            resultList[16].EntrantResults.Add(entrantResultList[16]);
            resultList[17].EntrantResults.Add(entrantResultList[17]);
            resultList[18].EntrantResults.Add(entrantResultList[18]);
            resultList[19].EntrantResults.Add(entrantResultList[19]);

            resultList[20].EntrantResults.Add(entrantResultList[20]);
            resultList[21].EntrantResults.Add(entrantResultList[21]);
            resultList[22].EntrantResults.Add(entrantResultList[22]);
            resultList[23].EntrantResults.Add(entrantResultList[23]);
            resultList[24].EntrantResults.Add(entrantResultList[24]);

            resultList[26].EntrantResults.Add(entrantResultList[26]);
            resultList[27].EntrantResults.Add(entrantResultList[27]);
            resultList[28].EntrantResults.Add(entrantResultList[28]);
            resultList[29].EntrantResults.Add(entrantResultList[29]);


            for (var i = 0; i < 30; i++)
            {
                entrantResultList[i].Result = resultList[i];
            }

            return entrantResultList;
        }
    }

    /// <summary>
    /// List of Entrant with Statement and empty EntrantResult
    /// </summary>
    public List<Entrant> EntrantWithStatementFixture
    {
        get
        {
            var statementList = StatementFixture;

            var entrantList = new List<Entrant>()
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
                    City = "Astana"
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


            statementList[0].Entrant = entrantList[0];
            statementList[1].Entrant = entrantList[1];
            statementList[2].Entrant = entrantList[2];
            statementList[3].Entrant = entrantList[3];
            statementList[4].Entrant = entrantList[4];
            statementList[5].Entrant = entrantList[5];
            statementList[6].Entrant = entrantList[6];
            statementList[7].Entrant = entrantList[7];
            statementList[8].Entrant = entrantList[8];
            statementList[9].Entrant = entrantList[9];


            entrantList[0].Statement = statementList[0];
            entrantList[1].Statement = statementList[1];
            entrantList[2].Statement = statementList[2];
            entrantList[3].Statement = statementList[3];
            entrantList[4].Statement = statementList[4];
            entrantList[5].Statement = statementList[5];
            entrantList[6].Statement = statementList[6];
            entrantList[7].Statement = statementList[7];
            entrantList[8].Statement = statementList[8];
            entrantList[9].Statement = statementList[9];

            return entrantList;
        }
    }

    /// <summary>
    /// List of Entrant with EntrantResult
    /// </summary>
    public List<Entrant> EntrantWithEntrantResultFixture
    {
        get
        {
            var entrantResultList = EntrantResultWithResultFixture;
            var entrantList = EntrantWithStatementFixture;

            entrantResultList[0].Entrant = entrantList[0];
            entrantResultList[1].Entrant = entrantList[0];
            entrantResultList[2].Entrant = entrantList[0];

            entrantResultList[3].Entrant = entrantList[1];
            entrantResultList[4].Entrant = entrantList[1];
            entrantResultList[5].Entrant = entrantList[1];

            entrantResultList[6].Entrant = entrantList[2];
            entrantResultList[7].Entrant = entrantList[2];
            entrantResultList[8].Entrant = entrantList[2];

            entrantResultList[9].Entrant = entrantList[3];
            entrantResultList[10].Entrant = entrantList[3];
            entrantResultList[11].Entrant = entrantList[3];

            entrantResultList[12].Entrant = entrantList[4];
            entrantResultList[13].Entrant = entrantList[4];
            entrantResultList[14].Entrant = entrantList[4];

            entrantResultList[15].Entrant = entrantList[5];
            entrantResultList[16].Entrant = entrantList[5];
            entrantResultList[17].Entrant = entrantList[5];

            entrantResultList[18].Entrant = entrantList[6];
            entrantResultList[19].Entrant = entrantList[6];
            entrantResultList[20].Entrant = entrantList[6];

            entrantResultList[21].Entrant = entrantList[7];
            entrantResultList[22].Entrant = entrantList[7];
            entrantResultList[23].Entrant = entrantList[7];

            entrantResultList[24].Entrant = entrantList[8];
            entrantResultList[25].Entrant = entrantList[8];
            entrantResultList[26].Entrant = entrantList[8];

            entrantResultList[27].Entrant = entrantList[9];
            entrantResultList[28].Entrant = entrantList[9];
            entrantResultList[29].Entrant = entrantList[9];

            entrantList[0].EntrantResults.Add(entrantResultList[0]);
            entrantList[0].EntrantResults.Add(entrantResultList[1]);
            entrantList[0].EntrantResults.Add(entrantResultList[2]);
            entrantList[1].EntrantResults.Add(entrantResultList[3]);
            entrantList[1].EntrantResults.Add(entrantResultList[4]);
            entrantList[1].EntrantResults.Add(entrantResultList[5]);
            entrantList[2].EntrantResults.Add(entrantResultList[6]);
            entrantList[2].EntrantResults.Add(entrantResultList[7]);
            entrantList[2].EntrantResults.Add(entrantResultList[8]);
            entrantList[3].EntrantResults.Add(entrantResultList[9]);
            entrantList[3].EntrantResults.Add(entrantResultList[10]);
            entrantList[3].EntrantResults.Add(entrantResultList[11]);
            entrantList[4].EntrantResults.Add(entrantResultList[12]);
            entrantList[4].EntrantResults.Add(entrantResultList[13]);
            entrantList[4].EntrantResults.Add(entrantResultList[14]);
            entrantList[5].EntrantResults.Add(entrantResultList[15]);
            entrantList[5].EntrantResults.Add(entrantResultList[16]);
            entrantList[5].EntrantResults.Add(entrantResultList[17]);
            entrantList[6].EntrantResults.Add(entrantResultList[18]);
            entrantList[6].EntrantResults.Add(entrantResultList[19]);
            entrantList[6].EntrantResults.Add(entrantResultList[20]);
            entrantList[7].EntrantResults.Add(entrantResultList[21]);
            entrantList[7].EntrantResults.Add(entrantResultList[22]);
            entrantList[7].EntrantResults.Add(entrantResultList[23]);
            entrantList[8].EntrantResults.Add(entrantResultList[24]);
            entrantList[8].EntrantResults.Add(entrantResultList[25]);
            entrantList[8].EntrantResults.Add(entrantResultList[26]);
            entrantList[9].EntrantResults.Add(entrantResultList[27]);
            entrantList[9].EntrantResults.Add(entrantResultList[28]);
            entrantList[9].EntrantResults.Add(entrantResultList[29]);

            return entrantList;
        }
    }
}