namespace AdmissionCommittee.Model.Test;

public class AdmissionCommitteeTest
{
    /// <summary>
    /// _results - list consisiting of a list of entrants results in 3 subjects
    /// </summary>
    private readonly List<List<Result>> _results = new();

    /// <summary>
    /// _specialities - list for storing specialities
    /// </summary>
    private readonly List<Specialty> _specialities = new();

    /// <summary>
    /// _entrants - list for storing information about entrants
    /// </summary>
    private readonly List<Entrant> _entrants = new();

    /// <summary>
    /// _statements - list for storing entrants statements
    /// </summary>
    private readonly List<Statement> _statements = new();

    public AdmissionCommitteeTest()
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
        _specialities.Add(new Specialty(1, "100503D", "Information security of automated systems", "Computer science and Cybernetics"));
        _specialities.Add(new Specialty(2, "010302D", "Applied Mathematics and Computer science", "Computer science and Cybernetics"));
        _specialities.Add(new Specialty(3, "390301D", "Sociology", "Sociological"));
        _specialities.Add(new Specialty(4, "410305D", "International relations", "Historical"));
        _specialities.Add(new Specialty(5, "020302D", "Computer security", "Computer science and Cybernetics"));
        _specialities.Add(new Specialty(6, "020302D", "International relations and foreign policy", "Historical"));
        _specialities.Add(new Specialty(7, "040401D", "Chemistry", "Natural Science"));
    }

    /// <summary>
    /// Creating entrants statements
    /// </summary>
    private void CreateStatements()
    {
        _statements.Add(new Statement(1, new Dictionary<Specialty, int> { { _specialities[0], 1 }, { _specialities[1], 2 }, { _specialities[4], 3 } },
                                         new Dictionary<int, int> { { 1, 1 }, { 2, 2 }, { 5, 3 } }));

        _statements.Add(new Statement(2, new Dictionary<Specialty, int> { { _specialities[1], 1 }, { _specialities[0], 2 } },
                                         new Dictionary<int, int> { { 2, 1 }, { 1, 2 } }));

        _statements.Add(new Statement(3, new Dictionary<Specialty, int> { { _specialities[0], 1 }, { _specialities[4], 2 }, { _specialities[1], 3 } },
                                         new Dictionary<int, int> { { 1, 1 }, { 5, 2 }, { 2, 3 } }));

        _statements.Add(new Statement(4, new Dictionary<Specialty, int> { { _specialities[2], 1 }, { _specialities[3], 2 } },
                                         new Dictionary<int, int> { { 3, 1 }, { 4, 2 } }));

        _statements.Add(new Statement(5, new Dictionary<Specialty, int> { { _specialities[3], 1 }, { _specialities[2], 2 } },
                                         new Dictionary<int, int> { { 4, 1 }, { 3, 2 } }));

        _statements.Add(new Statement(6, new Dictionary<Specialty, int> { { _specialities[2], 1 }, { _specialities[5], 2 } },
                                         new Dictionary<int, int> { { 3, 1 }, { 6, 2 } }));

        _statements.Add(new Statement(7, new Dictionary<Specialty, int> { { _specialities[6], 1 } },
                                         new Dictionary<int, int> { { 7, 1 } }));

        _statements.Add(new Statement(8, new Dictionary<Specialty, int> { { _specialities[3], 1 }, { _specialities[5], 2 } },
                                         new Dictionary<int, int> { { 4, 1 }, { 6, 2 } }));

        _statements.Add(new Statement(9, new Dictionary<Specialty, int> { { _specialities[3], 1 }, { _specialities[5], 2 } },
                                         new Dictionary<int, int> { { 4, 1 }, { 6, 2 } }));

        _statements.Add(new Statement(10, new Dictionary<Specialty, int> { { _specialities[6], 1 } },
                                          new Dictionary<int, int> { { 7, 1 } }));
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


    /// <summary>
    /// Output information about entrants from the specified city
    /// </summary>
    [Fact]
    public void TestEntrantsFromSpecifiedCity()
    {
        var selectedEntrants = (from entrant in _entrants
                                where entrant.City == "Saint-Petersburg"
                                select entrant).ToList();

        Assert.Equal("Lebedeva Kira Romanovna", selectedEntrants[0].FullName);
        Assert.Equal("Isaev Nikita Grigorievich", selectedEntrants[1].FullName);
    }

    /// <summary>
    /// Output information about entrants older than 20 years, arrange by full name
    /// </summary>
    [Fact]
    public void TestEntrantsOverTwentyYearsOlder()
    {
        var selectedEntrants = (from entrant in _entrants
                                where (DateTime.Now.Year - entrant.DateBirth.Year) > 20
                                orderby entrant.FullName
                                select entrant).ToList();

        Assert.Equal("Isaev Nikita Grigorievich", selectedEntrants[0].FullName);
        Assert.Equal("Popova Eva Artemovna", selectedEntrants[1].FullName);
    }

    /// <summary>
    /// Output information about entrants entering the specified speciality
    /// (without taking into account priority), arrange by the sum of marks for exams
    /// 
    /// For example, for "Information security of automated systems"
    /// 
    /// "Lebedeva Kira Romanovna"     (100+100+100)=300
    /// "Novikov Roman Evgenievich"   (58+95+71)=224
    /// "Popova Eva Artemovna"        (77+57+78)=212
    /// 
    /// </summary>
    [Fact]
    public void TestEntrantsEnteringSpecifiedSpeciality()
    {
        var selectedEntrants = (from entrant in _entrants
                                from spec in entrant.Statement.PrioritySpecialities
                                where spec.Key.NameSpeciality == "Information security of automated systems"
                                orderby entrant.Results.Sum(t => t.Mark) descending
                                select entrant).ToList();

        Assert.Equal("Lebedeva Kira Romanovna", selectedEntrants[0].FullName);
        Assert.Equal("Novikov Roman Evgenievich", selectedEntrants[1].FullName);
        Assert.Equal("Popova Eva Artemovna", selectedEntrants[2].FullName);

        Assert.Equal(300, selectedEntrants[0].Results.Sum(t => t.Mark));
        Assert.Equal(224, selectedEntrants[1].Results.Sum(t => t.Mark));
        Assert.Equal(212, selectedEntrants[2].Results.Sum(t => t.Mark));
    }

    /// <summary>
    /// Output information about the count of entrants entering each speciality according to the first priority
    /// 
    /// "Information security of automated systems"   2
    /// "Applied Mathematics and Computer science"    1
    /// "Sociology"                                   2
    /// "International relations"                     3
    /// "Chemistry"                                   2
    /// 
    /// 
    /// </summary>
    [Fact]
    public void TestCountOfEntrantsEnteringEachSpeciality()
    {
        var entrantsCount = (from entrant in _entrants
                             from spec in entrant.Statement.PrioritySpecialities
                             where spec.Value == 1
                             group spec by spec.Key.NameSpeciality into gspec
                             select new
                             {
                                 NameSpeciality = gspec.Key,
                                 CountEntrants = (from entrant in _entrants
                                                  from spec in entrant.Statement.PrioritySpecialities
                                                  where spec.Key.NameSpeciality.Equals(gspec.Key)
                                                  where spec.Value == 1
                                                  select entrant).Count()
                             }
                             ).ToList();

        Assert.Equal("Information security of automated systems", entrantsCount[0].NameSpeciality);
        Assert.Equal(2, entrantsCount[0].CountEntrants);
        Assert.Equal("Applied Mathematics and Computer science", entrantsCount[1].NameSpeciality);
        Assert.Equal(1, entrantsCount[1].CountEntrants);
        Assert.Equal("Sociology", entrantsCount[2].NameSpeciality);
        Assert.Equal(2, entrantsCount[2].CountEntrants);
        Assert.Equal("International relations", entrantsCount[3].NameSpeciality);
        Assert.Equal(3, entrantsCount[3].CountEntrants);
        Assert.Equal("Chemistry", entrantsCount[4].NameSpeciality);
        Assert.Equal(2, entrantsCount[4].CountEntrants);
    }



    /// <summary>
    /// Output information about top 5 entrants who scored the highest number of marks for 3 subject
    /// </summary>
    [Fact]
    public void TestTopFiveEntrants()
    {
        var entrantsTopFive = ((from entrant in _entrants
                                orderby entrant.Results.Sum(t => t.Mark) descending
                                select entrant).Take(5)).ToList();

        Assert.Equal(5, entrantsTopFive.Count);//Verify the number of items in the list

        Assert.Equal("Lebedeva Kira Romanovna", entrantsTopFive[0].FullName);
        Assert.Equal(300, entrantsTopFive[0].Results.Sum(c => c.Mark));

        Assert.Equal("Soboleva Alice Yaroslavovna", entrantsTopFive[1].FullName);
        Assert.Equal(259, entrantsTopFive[1].Results.Sum(c => c.Mark));

        Assert.Equal("Kalinina Elena Vasilyevna", entrantsTopFive[2].FullName);
        Assert.Equal(243, entrantsTopFive[2].Results.Sum(c => c.Mark));

        Assert.Equal("Novikov Roman Evgenievich", entrantsTopFive[3].FullName);
        Assert.Equal(224, entrantsTopFive[3].Results.Sum(c => c.Mark));

        Assert.Equal("Vinogradov Dmitry Artemovich", entrantsTopFive[4].FullName);
        Assert.Equal(214, entrantsTopFive[4].Results.Sum(c => c.Mark));
    }


    /// <summary>
    /// Output information about the entrant (and their priority specialities) who scored the maxmum mark in each of the subkect
    /// 
    /// First, "Mathematics"
    /// "Lebedeva Kira Romanovna"  "Information security of automated systems"    100
    /// "Lebedeva Kira Romanovna"  "Applied Mathematics and Computer science"     100
    /// "Lebedeva Kira Romanovna"  "Computer security"                            100
    /// 
    /// </summary>
    [Fact]
    public void TestEntrantMaxMarkMathematics()
    {
        var entrantMath = (from entrant in _entrants
                           from spec in entrant.Statement.PrioritySpecialities
                           from res in entrant.Results
                           where res.NameSubject == "Mathematics"
                           where res.Mark == (from entrant in _entrants
                                              from res in entrant.Results
                                              where res.NameSubject == "Mathematics"
                                              select res.Mark).Max()
                           select new
                           {
                               NameEntrant = entrant.FullName,
                               Speciality = spec.Key.NameSpeciality,
                               MaxMark = res.Mark
                           }
                           ).ToList();

        Assert.Equal(3, entrantMath.Count);

        Assert.Equal("Lebedeva Kira Romanovna", entrantMath[0].NameEntrant);
        Assert.Equal("Information security of automated systems", entrantMath[0].Speciality);
        Assert.Equal(100, entrantMath[0].MaxMark);

        Assert.Equal("Lebedeva Kira Romanovna", entrantMath[1].NameEntrant);
        Assert.Equal("Applied Mathematics and Computer science", entrantMath[1].Speciality);
        Assert.Equal(100, entrantMath[1].MaxMark);

        Assert.Equal("Lebedeva Kira Romanovna", entrantMath[2].NameEntrant);
        Assert.Equal("Computer security", entrantMath[2].Speciality);
        Assert.Equal(100, entrantMath[2].MaxMark);
    }

    /// <summary>
    /// Russian Language
    /// 
    /// "Lebedeva Kira Romanovna"  "Information security of automated systems"    100
    /// "Lebedeva Kira Romanovna"  "Applied Mathematics and Computer science"     100
    /// "Lebedeva Kira Romanovna"  "Computer security"                            100
    /// </summary>
    [Fact]
    public void TestEntrantMaxMarkRussianLanguage()
    {
        var entrantRus = (from entrant in _entrants
                          from spec in entrant.Statement.PrioritySpecialities
                          from res in entrant.Results
                          where res.NameSubject == "Russian language"
                          where res.Mark == (from entrant in _entrants
                                             from res in entrant.Results
                                             where res.NameSubject == "Russian language"
                                             select res.Mark).Max()
                          select new
                          {
                              NameEntrant = entrant.FullName,
                              Speciality = spec.Key.NameSpeciality,
                              MaxMark = res.Mark
                          }
                          ).ToList();

        Assert.Equal(3, entrantRus.Count);

        Assert.Equal("Lebedeva Kira Romanovna", entrantRus[0].NameEntrant);
        Assert.Equal("Information security of automated systems", entrantRus[0].Speciality);
        Assert.Equal(100, entrantRus[0].MaxMark);

        Assert.Equal("Lebedeva Kira Romanovna", entrantRus[1].NameEntrant);
        Assert.Equal("Applied Mathematics and Computer science", entrantRus[1].Speciality);
        Assert.Equal(100, entrantRus[1].MaxMark);

        Assert.Equal("Lebedeva Kira Romanovna", entrantRus[2].NameEntrant);
        Assert.Equal("Computer security", entrantRus[2].Speciality);
        Assert.Equal(100, entrantRus[2].MaxMark);
    }

    /// <summary>
    /// Physics
    /// "Lebedeva Kira Romanovna"  "Information security of automated systems"    100
    /// "Lebedeva Kira Romanovna"  "Applied Mathematics and Computer science"     100
    /// "Lebedeva Kira Romanovna"  "Computer security"                            100
    /// </summary>
    [Fact]
    public void TestEntrantMaxMarkPhysics()
    {
        var entrantPhys = (from entrant in _entrants
                           from spec in entrant.Statement.PrioritySpecialities
                           from res in entrant.Results
                           where res.NameSubject == "Physics"
                           where res.Mark == (from entrant in _entrants
                                              from res in entrant.Results
                                              where res.NameSubject == "Physics"
                                              select res.Mark).Max()
                           select new
                           {
                               NameEntrant = entrant.FullName,
                               Speciality = spec.Key.NameSpeciality,
                               MaxMark = res.Mark
                           }
                           ).ToList();

        Assert.Equal(3, entrantPhys.Count);

        Assert.Equal("Lebedeva Kira Romanovna", entrantPhys[0].NameEntrant);
        Assert.Equal("Information security of automated systems", entrantPhys[0].Speciality);
        Assert.Equal(100, entrantPhys[0].MaxMark);

        Assert.Equal("Lebedeva Kira Romanovna", entrantPhys[1].NameEntrant);
        Assert.Equal("Applied Mathematics and Computer science", entrantPhys[1].Speciality);
        Assert.Equal(100, entrantPhys[1].MaxMark);

        Assert.Equal("Lebedeva Kira Romanovna", entrantPhys[2].NameEntrant);
        Assert.Equal("Computer security", entrantPhys[2].Speciality);
        Assert.Equal(100, entrantPhys[2].MaxMark);
    }

    /// <summary>
    /// Computer Science
    /// 
    /// "Novikov Roman Evgenievich"   "Information security of automated systems"   71
    /// "Novikov Roman Evgenievich"   "Computer security"                           71
    /// "Novikov Roman Evgenievich"   "Applied Mathematics and Computer science"    71
    /// </summary>
    [Fact]
    public void TestEntrantMaxMarkComputerScience()
    {
        var entrantCompscience = (from entrant in _entrants
                                  from spec in entrant.Statement.PrioritySpecialities
                                  from res in entrant.Results
                                  where res.NameSubject == "Computer science"
                                  where res.Mark == (from entrant in _entrants
                                                     from res in entrant.Results
                                                     where res.NameSubject == "Computer science"
                                                     select res.Mark).Max()
                                  select new
                                  {
                                      NameEntrant = entrant.FullName,
                                      Speciality = spec.Key.NameSpeciality,
                                      MaxMark = res.Mark
                                  }
                                  ).ToList();

        Assert.Equal(3, entrantCompscience.Count);

        Assert.Equal("Novikov Roman Evgenievich", entrantCompscience[0].NameEntrant);
        Assert.Equal("Information security of automated systems", entrantCompscience[0].Speciality);
        Assert.Equal(71, entrantCompscience[0].MaxMark);

        Assert.Equal("Novikov Roman Evgenievich", entrantCompscience[1].NameEntrant);
        Assert.Equal("Computer security", entrantCompscience[1].Speciality);
        Assert.Equal(71, entrantCompscience[1].MaxMark);

        Assert.Equal("Novikov Roman Evgenievich", entrantCompscience[2].NameEntrant);
        Assert.Equal("Applied Mathematics and Computer science", entrantCompscience[2].Speciality);
        Assert.Equal(71, entrantCompscience[2].MaxMark);
    }

    /// <summary>
    /// Social Studies
    /// 
    /// "Isaev Nikita Grigorievich"  "Sociology"                   57
    /// "Isaev Nikita Grigorievich"  "International relations"     57
    /// 
    /// </summary>
    [Fact]
    public void TestEntrantMaxMarkSocialStudies()
    {
        var entrantSocialStudies = (from entrant in _entrants
                                    from spec in entrant.Statement.PrioritySpecialities
                                    from res in entrant.Results
                                    where res.NameSubject == "Social Studies"
                                    where res.Mark == (from entrant in _entrants
                                                       from res in entrant.Results
                                                       where res.NameSubject == "Social Studies"
                                                       select res.Mark).Max()
                                    select new
                                    {
                                        NameEntrant = entrant.FullName,
                                        Speciality = spec.Key.NameSpeciality,
                                        MaxMark = res.Mark
                                    }
                                    ).ToList();

        Assert.Equal(2, entrantSocialStudies.Count);

        Assert.Equal("Isaev Nikita Grigorievich", entrantSocialStudies[0].NameEntrant);
        Assert.Equal("Sociology", entrantSocialStudies[0].Speciality);
        Assert.Equal(57, entrantSocialStudies[0].MaxMark);

        Assert.Equal("Isaev Nikita Grigorievich", entrantSocialStudies[1].NameEntrant);
        Assert.Equal("International relations", entrantSocialStudies[1].Speciality);
        Assert.Equal(57, entrantSocialStudies[1].MaxMark);

    }

    /// <summary>
    /// History
    /// "Pastukhova Sofya Maksimovna"   "International relations"  72
    /// "Pastukhova Sofya Maksimovna"   "Sociology"                72
    /// 
    /// </summary>
    [Fact]
    public void TestEntrantMaxMarkHistory()
    {
        var entrantHistory = (from entrant in _entrants
                              from spec in entrant.Statement.PrioritySpecialities
                              from res in entrant.Results
                              where res.NameSubject == "History"
                              where res.Mark == (from entrant in _entrants
                                                 from res in entrant.Results
                                                 where res.NameSubject == "History"
                                                 select res.Mark).Max()
                              select new
                              {
                                  NameEntrant = entrant.FullName,
                                  Speciality = spec.Key.NameSpeciality,
                                  MaxMark = res.Mark
                              }
                              ).ToList();

        Assert.Equal(2, entrantHistory.Count);

        Assert.Equal("Pastukhova Sofya Maksimovna", entrantHistory[0].NameEntrant);
        Assert.Equal("International relations", entrantHistory[0].Speciality);
        Assert.Equal(72, entrantHistory[0].MaxMark);

        Assert.Equal("Pastukhova Sofya Maksimovna", entrantHistory[1].NameEntrant);
        Assert.Equal("Sociology", entrantHistory[1].Speciality);
        Assert.Equal(72, entrantHistory[1].MaxMark);
    }

    /// <summary>
    /// Chemistry
    /// 
    /// "Vinogradov Dmitry Artemovich"  "Chemistry"   74
    /// 
    /// </summary>
    [Fact]
    public void TestEntrantMaxMarkChemistry()
    {
        var entrantChemistry = (from entrant in _entrants
                                from spec in entrant.Statement.PrioritySpecialities
                                from res in entrant.Results
                                where res.NameSubject == "Chemistry"
                                where res.Mark == (from entrant in _entrants
                                                   from res in entrant.Results
                                                   where res.NameSubject == "Chemistry"
                                                   select res.Mark).Max()
                                select new
                                {
                                    NameEntrant = entrant.FullName,
                                    Speciality = spec.Key.NameSpeciality,
                                    MaxMark = res.Mark
                                }
                                ).ToList();

        Assert.Equal(1, entrantChemistry.Count);

        Assert.Equal("Vinogradov Dmitry Artemovich", entrantChemistry[0].NameEntrant);
        Assert.Equal("Chemistry", entrantChemistry[0].Speciality);
        Assert.Equal(74, entrantChemistry[0].MaxMark);
    }

    /// <summary>
    /// English language
    /// 
    /// "Kalinina Elena Vasilyevna"  "International relations"                     98
    /// "Kalinina Elena Vasilyevna"  "International relations and foreign policy"  98
    /// </summary>
    [Fact]
    public void TestEntrantMaxMarkEnglishLanguage()
    {
        var entrantEng = (from entrant in _entrants
                          from spec in entrant.Statement.PrioritySpecialities
                          from res in entrant.Results
                          where res.NameSubject == "English language"
                          where res.Mark == (from entrant in _entrants
                                             from res in entrant.Results
                                             where res.NameSubject == "English language"
                                             select res.Mark).Max()
                          select new
                          {
                              NameEntrant = entrant.FullName,
                              Speciality = spec.Key.NameSpeciality,
                              MaxMark = res.Mark
                          }
                          ).ToList();

        Assert.Equal(2, entrantEng.Count);

        Assert.Equal("Kalinina Elena Vasilyevna", entrantEng[0].NameEntrant);
        Assert.Equal("International relations", entrantEng[0].Speciality);
        Assert.Equal(98, entrantEng[0].MaxMark);

        Assert.Equal("Kalinina Elena Vasilyevna", entrantEng[1].NameEntrant);
        Assert.Equal("International relations and foreign policy", entrantEng[1].Speciality);
        Assert.Equal(98, entrantEng[1].MaxMark);
    }
}