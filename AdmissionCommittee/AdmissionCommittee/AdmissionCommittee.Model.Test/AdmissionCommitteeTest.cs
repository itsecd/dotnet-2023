namespace AdmissionCommittee.Model.Test;

public class AdmissionCommitteeTest : IClassFixture<AdmissionCommitteeFixture>
{
    private readonly AdmissionCommitteeFixture _fixture;

    public AdmissionCommitteeTest(AdmissionCommitteeFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Output information about entrants from the specified city
    /// </summary>
    [Fact]
    public void TestEntrantsFromSpecifiedCity()
    {
        var selectedEntrants = (from entrant in _fixture.EntrantWithStatementFixture
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
        var selectedEntrants = (from entrant in _fixture.EntrantWithStatementFixture
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
        var selectedEntrants = (from entrant in _fixture.EntrantWithEntrantResultFixture
                                from stspec in entrant.Statement.StatementSpecialties
                                where stspec.Specialty.NameSpecialty == "Information security of automated systems"
                                orderby entrant.EntrantResults.Sum(t => t.Mark) descending
                                select entrant).ToList();

        Assert.Equal("Lebedeva Kira Romanovna", selectedEntrants[0].FullName);
        Assert.Equal("Novikov Roman Evgenievich", selectedEntrants[1].FullName);
        Assert.Equal("Popova Eva Artemovna", selectedEntrants[2].FullName);

        Assert.Equal(300, selectedEntrants[0].EntrantResults.Sum(t => t.Mark));
        Assert.Equal(224, selectedEntrants[1].EntrantResults.Sum(t => t.Mark));
        Assert.Equal(212, selectedEntrants[2].EntrantResults.Sum(t => t.Mark));
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
        var entrantsCount = (from entrant in _fixture.EntrantWithStatementFixture
                             from stspec in entrant.Statement.StatementSpecialties
                             where stspec.Priority == 1
                             group stspec by stspec.Specialty.NameSpecialty into gstspec
                             select new
                             {
                                 NameSpeciality = gstspec.Key,
                                 CountEntrants = (from entrant in _fixture.EntrantWithStatementFixture
                                                  from stspec in entrant.Statement.StatementSpecialties
                                                  where stspec.Specialty.NameSpecialty.Equals(gstspec.Key)
                                                  where stspec.Priority == 1
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
        var entrantsTopFive = ((from entrant in _fixture.EntrantWithEntrantResultFixture
                                orderby entrant.EntrantResults.Sum(t => t.Mark) descending
                                select entrant).Take(5)).ToList();

        Assert.Equal(5, entrantsTopFive.Count);//Verify the number of items in the list

        Assert.Equal("Lebedeva Kira Romanovna", entrantsTopFive[0].FullName);
        Assert.Equal(300, entrantsTopFive[0].EntrantResults.Sum(c => c.Mark));

        Assert.Equal("Soboleva Alice Yaroslavovna", entrantsTopFive[1].FullName);
        Assert.Equal(259, entrantsTopFive[1].EntrantResults.Sum(c => c.Mark));

        Assert.Equal("Kalinina Elena Vasilyevna", entrantsTopFive[2].FullName);
        Assert.Equal(243, entrantsTopFive[2].EntrantResults.Sum(c => c.Mark));

        Assert.Equal("Novikov Roman Evgenievich", entrantsTopFive[3].FullName);
        Assert.Equal(224, entrantsTopFive[3].EntrantResults.Sum(c => c.Mark));

        Assert.Equal("Vinogradov Dmitry Artemovich", entrantsTopFive[4].FullName);
        Assert.Equal(214, entrantsTopFive[4].EntrantResults.Sum(c => c.Mark));
    }


    public List<string> GetAllSubject()
    {
        var subjectList = new List<string>();
        foreach (var res in _fixture.ResultFixture)
        {
            subjectList.Add(res.NameSubject);
        }
        return subjectList.Distinct().ToList();
    }

    /// <summary>
    /// Output information about the entrant (and their priority specialities) who scored the maxmum mark in each of the subkect
    /// </summary>
    [Fact]
    public void TestEntrantMaxMarkMathematics()
    {
        var subjectList = GetAllSubject();
        var selectedEntrants = new List<List<EntrantWithMaxMarkGet>>();
        foreach (var subject in subjectList)
        {
            selectedEntrants.Add((from entrant in _fixture.EntrantWithEntrantResultFixture
                                  from stspec in entrant.Statement.StatementSpecialties
                                  from res in entrant.EntrantResults
                                  where res.Result.NameSubject == subject
                                  where res.Mark == (from entrant in _fixture.EntrantWithEntrantResultFixture
                                                     from res in entrant.EntrantResults
                                                     where res.Result.NameSubject == subject
                                                     select res.Mark).Max()
                                  select new EntrantWithMaxMarkGet
                                  {
                                      NameEntrant = entrant.FullName,
                                      NameSpecialty = stspec.Specialty.NameSpecialty,
                                      MaxMark = res.Mark
                                  }).ToList());
        }

        //Assert.Equal(3, selectedEntrants.Count);
        //Math
        Assert.Equal("Lebedeva Kira Romanovna", selectedEntrants[0][0].NameEntrant);
        Assert.Equal("Information security of automated systems", selectedEntrants[0][0].NameSpecialty);
        Assert.Equal(100, selectedEntrants[0][0].MaxMark);

        Assert.Equal("Lebedeva Kira Romanovna", selectedEntrants[0][1].NameEntrant);
        Assert.Equal("Applied Mathematics and Computer science", selectedEntrants[0][1].NameSpecialty);
        Assert.Equal(100, selectedEntrants[0][1].MaxMark);

        Assert.Equal("Lebedeva Kira Romanovna", selectedEntrants[0][2].NameEntrant);
        Assert.Equal("Computer security", selectedEntrants[0][2].NameSpecialty);
        Assert.Equal(100, selectedEntrants[0][2].MaxMark);

        ////Rus
        Assert.Equal("Lebedeva Kira Romanovna", selectedEntrants[1][0].NameEntrant);
        Assert.Equal("Information security of automated systems", selectedEntrants[1][0].NameSpecialty);
        Assert.Equal(100, selectedEntrants[1][0].MaxMark);

        Assert.Equal("Lebedeva Kira Romanovna", selectedEntrants[1][1].NameEntrant);
        Assert.Equal("Applied Mathematics and Computer science", selectedEntrants[1][1].NameSpecialty);
        Assert.Equal(100, selectedEntrants[1][1].MaxMark);

        Assert.Equal("Lebedeva Kira Romanovna", selectedEntrants[1][2].NameEntrant);
        Assert.Equal("Computer security", selectedEntrants[1][2].NameSpecialty);
        Assert.Equal(100, selectedEntrants[1][2].MaxMark);

        ////Physics
        Assert.Equal("Lebedeva Kira Romanovna", selectedEntrants[2][0].NameEntrant);
        Assert.Equal("Information security of automated systems", selectedEntrants[2][0].NameSpecialty);
        Assert.Equal(100, selectedEntrants[2][0].MaxMark);

        Assert.Equal("Lebedeva Kira Romanovna", selectedEntrants[2][1].NameEntrant);
        Assert.Equal("Applied Mathematics and Computer science", selectedEntrants[2][1].NameSpecialty);
        Assert.Equal(100, selectedEntrants[2][1].MaxMark);

        Assert.Equal("Lebedeva Kira Romanovna", selectedEntrants[2][2].NameEntrant);
        Assert.Equal("Computer security", selectedEntrants[2][2].NameSpecialty);
        Assert.Equal(100, selectedEntrants[2][2].MaxMark);

        ////Computer Science
        Assert.Equal("Novikov Roman Evgenievich", selectedEntrants[3][0].NameEntrant);
        Assert.Equal("Information security of automated systems", selectedEntrants[3][0].NameSpecialty);
        Assert.Equal(71, selectedEntrants[3][0].MaxMark);

        Assert.Equal("Novikov Roman Evgenievich", selectedEntrants[3][1].NameEntrant);
        Assert.Equal("Computer security", selectedEntrants[3][1].NameSpecialty);
        Assert.Equal(71, selectedEntrants[3][1].MaxMark);

        Assert.Equal("Novikov Roman Evgenievich", selectedEntrants[3][2].NameEntrant);
        Assert.Equal("Applied Mathematics and Computer science", selectedEntrants[3][2].NameSpecialty);
        Assert.Equal(71, selectedEntrants[3][2].MaxMark);

        ////Social Studies
        Assert.Equal("Isaev Nikita Grigorievich", selectedEntrants[4][0].NameEntrant);
        Assert.Equal("Sociology", selectedEntrants[4][0].NameSpecialty);
        Assert.Equal(57, selectedEntrants[4][0].MaxMark);

        Assert.Equal("Isaev Nikita Grigorievich", selectedEntrants[4][1].NameEntrant);
        Assert.Equal("International relations", selectedEntrants[4][1].NameSpecialty);
        Assert.Equal(57, selectedEntrants[4][1].MaxMark);

        ////History
        Assert.Equal("Pastukhova Sofya Maksimovna", selectedEntrants[5][0].NameEntrant);
        Assert.Equal("International relations", selectedEntrants[5][0].NameSpecialty);
        Assert.Equal(72, selectedEntrants[5][0].MaxMark);

        Assert.Equal("Pastukhova Sofya Maksimovna", selectedEntrants[5][1].NameEntrant);
        Assert.Equal("Sociology", selectedEntrants[5][1].NameSpecialty);
        Assert.Equal(72, selectedEntrants[5][1].MaxMark);

        ////Chemistry
        Assert.Equal("Vinogradov Dmitry Artemovich", selectedEntrants[6][0].NameEntrant);
        Assert.Equal("Chemistry", selectedEntrants[6][0].NameSpecialty);
        Assert.Equal(74, selectedEntrants[6][0].MaxMark);

        ////English language
        Assert.Equal("Kalinina Elena Vasilyevna", selectedEntrants[7][0].NameEntrant);
        Assert.Equal("International relations", selectedEntrants[7][0].NameSpecialty);
        Assert.Equal(98, selectedEntrants[7][0].MaxMark);

        Assert.Equal("Kalinina Elena Vasilyevna", selectedEntrants[7][1].NameEntrant);
        Assert.Equal("International relations and foreign policy", selectedEntrants[7][1].NameSpecialty);
        Assert.Equal(98, selectedEntrants[7][1].MaxMark);
    }
}