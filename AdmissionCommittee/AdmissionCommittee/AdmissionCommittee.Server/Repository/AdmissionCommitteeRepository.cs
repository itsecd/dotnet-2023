namespace AdmissionCommittee.Server.Repository;

public class AdmissionCommitteeRepository : IAdmissionCommitteeRepository
{
    /// <summary>
    /// _results - list consisiting of a list of entrants results in 3 subjects
    /// </summary>
    private readonly List<List<Result>> _results = new();

    /// <summary>
    /// _specialities - list for storing specialities
    /// </summary>
    private readonly List<Speciality> _specialities = new();

    /// <summary>
    /// _entrants - list for storing information about entrants
    /// </summary>
    private readonly List<Entrant> _entrants = new();

    /// <summary>
    /// _statements - list for storing entrants statements
    /// </summary>
    private readonly List<Statement> _statements = new();

    public AdmissionCommitteeRepository()
    {
        CreateResults();
        CreateSpecialities();
        CreateStatements();
        CreateEntrants();
    }

    /// <summary>
    /// Creating entrants results
    /// </summary>
    private void CreateResults()
    {
        _results.Add(new List<Result>() { new Result(1, "Mathematics", 100),
                                          new Result(1, "Russian language", 100),
                                          new Result(1, "Physics", 100)});

        _results.Add(new List<Result>() { new Result(2, "Mathematics", 77),
                                          new Result(2, "Russian language", 57),
                                          new Result(2, "Physics", 78)});

        _results.Add(new List<Result>() { new Result(3, "Mathematics", 58),
                                          new Result(3, "Russian language", 95),
                                          new Result(3, "Computer science", 71)});

        _results.Add(new List<Result>() { new Result(4, "Mathematics", 79),
                                          new Result(4, "Russian language", 54),
                                          new Result(4, "Social Studies", 57)});

        _results.Add(new List<Result>() { new Result(5, "Mathematics", 57),
                                          new Result(5, "Russian language", 65),
                                          new Result(5, "History", 72)});

        _results.Add(new List<Result>() { new Result(6, "Mathematics", 48),
                                          new Result(6, "Russian language", 93),
                                          new Result(6, "History", 59)});

        _results.Add(new List<Result>() { new Result(7, "Mathematics", 67),
                                          new Result(7, "Russian language", 56),
                                          new Result(7, "Chemistry", 42)});

        _results.Add(new List<Result>() { new Result(8, "Mathematics", 90),
                                          new Result(8, "Russian language", 77),
                                          new Result(8, "English language", 92)});

        _results.Add(new List<Result>() { new Result(9, "Mathematics", 71),
                                          new Result(9, "Russian language", 74),
                                          new Result(9, "English language", 98)});

        _results.Add(new List<Result>() { new Result(10, "Mathematics", 68),
                                          new Result(10, "Russian language", 72),
                                          new Result(10, "Chemistry", 74)});
    }

    /// <summary>
    /// Creating specialities
    /// </summary>
    private void CreateSpecialities()
    {
        _specialities.Add(new Speciality(1, "100503D", "Information security of automated systems", "Computer science and Cybernetics"));
        _specialities.Add(new Speciality(2, "010302D", "Applied Mathematics and Computer science", "Computer science and Cybernetics"));
        _specialities.Add(new Speciality(3, "390301D", "Sociology", "Sociological"));
        _specialities.Add(new Speciality(4, "410305D", "International relations", "Historical"));
        _specialities.Add(new Speciality(5, "020302D", "Computer security", "Computer science and Cybernetics"));
        _specialities.Add(new Speciality(6, "020302D", "International relations and foreign policy", "Historical"));
        _specialities.Add(new Speciality(7, "040401D", "Chemistry", "Natural Science"));
    }

    /// <summary>
    /// Creating entrants statements
    /// </summary>
    private void CreateStatements()
    {
        _statements.Add(new Statement(1, new Dictionary<Speciality, int> { { _specialities[0], 1 }, { _specialities[1], 2 }, { _specialities[4], 3 } }));
        _statements.Add(new Statement(2, new Dictionary<Speciality, int> { { _specialities[1], 1 }, { _specialities[0], 2 } }));
        _statements.Add(new Statement(3, new Dictionary<Speciality, int> { { _specialities[0], 1 }, { _specialities[4], 2 }, { _specialities[1], 3 } }));
        _statements.Add(new Statement(4, new Dictionary<Speciality, int> { { _specialities[2], 1 }, { _specialities[3], 2 } }));
        _statements.Add(new Statement(5, new Dictionary<Speciality, int> { { _specialities[3], 1 }, { _specialities[2], 2 } }));
        _statements.Add(new Statement(6, new Dictionary<Speciality, int> { { _specialities[2], 1 }, { _specialities[5], 2 } }));
        _statements.Add(new Statement(7, new Dictionary<Speciality, int> { { _specialities[6], 1 } }));
        _statements.Add(new Statement(8, new Dictionary<Speciality, int> { { _specialities[3], 1 }, { _specialities[5], 2 } }));
        _statements.Add(new Statement(9, new Dictionary<Speciality, int> { { _specialities[3], 1 }, { _specialities[5], 2 } }));
        _statements.Add(new Statement(10, new Dictionary<Speciality, int> { { _specialities[6], 1 } }));
    }

    /// <summary>
    /// Creating information about entrants
    /// </summary>
    private void CreateEntrants()
    {
        _entrants.Add(new Entrant(1, "Lebedeva Kira Romanovna", new DateTime(2005, 01, 19), "Russian Federation", "Saint-Petersburg", _statements[0], 1));
        _entrants.Add(new Entrant(2, "Popova Eva Artemovna", new DateTime(2002, 11, 12), "Russian Federation", "Kazan", _statements[1], 2));
        _entrants.Add(new Entrant(3, "Novikov Roman Evgenievich", new DateTime(2005, 08, 29), "Kazakhstan", "Astana", _statements[2], 3));
        _entrants.Add(new Entrant(4, "Isaev Nikita Grigorievich", new DateTime(2001, 01, 01), "Russian Federation", "Saint-Petersburg", _statements[3], 4));
        _entrants.Add(new Entrant(5, "Pastukhova Sofya Maksimovna", new DateTime(2004, 01, 29), "Uzbekistan", "Tashkent", _statements[4], 5));
        _entrants.Add(new Entrant(6, "Gromova Alyona Andreevna", new DateTime(2003, 08, 02), "Russian Federation", "Ekaterinburg", _statements[5], 6));
        _entrants.Add(new Entrant(7, "Bykova Anastasia Miroslavovna", new DateTime(2003, 08, 30), "Uzbekistan", "Mirabad", _statements[6], 7));
        _entrants.Add(new Entrant(8, "Soboleva Alice Yaroslavovna", new DateTime(2003, 08, 03), "Russian Federation", "Azov", _statements[7], 8));
        _entrants.Add(new Entrant(9, "Kalinina Elena Vasilyevna", new DateTime(2003, 02, 01), "Russian Federation", "Samara", _statements[8], 9));
        _entrants.Add(new Entrant(10, "Vinogradov Dmitry Artemovich", new DateTime(2005, 05, 31), "Latvia", "Smiltene", _statements[9], 10));


        for (int i = 0, j = 0; i < _entrants.Count; i++, j++)
        {
            _entrants[i].Results = _results[j];
        }
    }

    public List<List<Result>> GetResults => _results;

    public List<Speciality> GetSpecialities => _specialities;

    public List<Entrant> GetEntrants => _entrants;

    public List<Statement> GetStatements => _statements;
}