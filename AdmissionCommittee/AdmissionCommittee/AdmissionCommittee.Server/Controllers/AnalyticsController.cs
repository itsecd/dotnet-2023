using AdmissionCommittee.Model;
using AdmissionCommittee.Server.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILogger<AnalyticsController> _logger;

    private readonly IDbContextFactory<AdmissionCommitteeContext> _contextFactory;

    private readonly IMapper _mapper;

    public AnalyticsController(ILogger<AnalyticsController> logger, IDbContextFactory<AdmissionCommitteeContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    private async Task<List<string>> GetAllSubject()
    {
        var subjectList = new List<string>();
        var ctx = await _contextFactory.CreateDbContextAsync();
        foreach (var res in ctx.Results)
        {
            subjectList.Add(res.NameSubject);
        }
        return subjectList.Distinct().ToList();
    }

    /// <summary>
    /// Entrants from the specified city
    /// </summary>
    /// <param name="city">Name city</param>
    /// <returns>list Entrants from specified city</returns>
    [HttpGet("GetEntrantsFromSpecifiedCity")]
    public async Task<ActionResult<List<EntrantGetDto>>> GetEntrantsFromSpecifiedCity(string city)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();

        var selectedEntrants = await (from entrant in ctx.Entrants
                                      where entrant.City == city
                                      select _mapper.Map<EntrantGetDto>(entrant)).ToListAsync();

        if (!selectedEntrants.Any())
        {
            _logger.LogInformation("Not found Entrants from {city}", city);
            return NotFound($"The Entrants does't exist from city {city}");
        }
        else
        {
            _logger.LogInformation("Get information about Entrants From Specified City: {city}", city);
            return Ok(selectedEntrants);
        }
    }

    /// <summary>
    /// Entrants older than 20 years, arrange by full name
    /// </summary>
    /// <returns>list Entrants older than 20 years</returns>
    [HttpGet("GetEntrantsOverTwentyYearsOlder")]
    public async Task<List<EntrantGetDto>> GetEntrantsOverTwentyYearsOlder()
    {
        _logger.LogInformation("Get information about Entrants Over Twenty Years Older");
        var ctx = await _contextFactory.CreateDbContextAsync();

        var selectedEntrants = await (from entrant in ctx.Entrants
                                      where (DateTime.Now.Year - entrant.DateBirth.Year) > 20
                                      orderby entrant.FullName
                                      select _mapper.Map<EntrantGetDto>(entrant)).ToListAsync();

        return selectedEntrants;
    }

    /// <summary>
    /// Entrants entering the specified specialty
    /// (without taking into account priority)
    /// </summary>
    /// <param name="specialty">name Specialty</param>
    /// <returns>list Entrants entering the specified specialty</returns>
    [HttpGet("GetEntrantsEnteringSpecifiedSpecialty")]
    public async Task<ActionResult<List<EntrantGetDto>>> GetEntrantsEnteringSpecifiedSpecialty(string specialty)
    {
        var ctx = await _contextFactory.CreateDbContextAsync();

        var selectedEntrants = await (from entrant in ctx.Entrants
                                      from stspec in entrant.Statement.StatementSpecialties
                                      where stspec.Specialty.NameSpecialty == specialty
                                      orderby entrant.EntrantResults.Sum(t => t.Mark) descending
                                      select _mapper.Map<EntrantGetDto>(entrant)).ToListAsync();

        if (!selectedEntrants.Any())
        {
            _logger.LogInformation("Not found Entrants entering the specialty {specialty}", specialty);
            return NotFound($"The Entrants does't exist entering the specialty {specialty}");
        }
        else
        {
            _logger.LogInformation("Get information about Entrants entering the specialty {specialty}", specialty);
            return Ok(selectedEntrants);
        }
    }

    /// <summary>
    /// Count of Entrants entering each specialty according to the first priority
    /// </summary>
    /// <returns>list name of Specialties with count of Entrants</returns>
    [HttpGet("CountOfEntrantsEnteringEachSpecialty")]
    public async Task<ActionResult<dynamic>> GetCountOfEntrantsEnteringEachSpecialty()
    {
        _logger.LogInformation("Get information about count of Entrants entering each specialty");

        var ctx = await _contextFactory.CreateDbContextAsync();

        var countEntrantsEachSpecialties = await (from entrant in ctx.Entrants
                                                  from stspec in entrant.Statement.StatementSpecialties
                                                  where stspec.Priority == 1
                                                  group stspec by stspec.Specialty.NameSpecialty into gstspec
                                                  select new
                                                  {
                                                      NameSpecialty = gstspec.Key,
                                                      CountEntrants = (from entrant in ctx.Entrants
                                                                       from stspec in entrant.Statement.StatementSpecialties
                                                                       where stspec.Specialty.NameSpecialty.Equals(gstspec.Key)
                                                                       where stspec.Priority == 1
                                                                       select _mapper.Map<EntrantGetDto>(entrant)).Count()
                                                  }).ToListAsync();

        return countEntrantsEachSpecialties;
    }

    /// <summary>
    /// Top 5 Entrants who scored the highest number of marks for 3 subject
    /// </summary>
    /// <returns>list Entrant with the highest number of marks for 3 subject</returns>
    [HttpGet("TopFiveEntrants")]
    public async Task<List<EntrantGetDto>> GetTopFiveEntrants()
    {
        _logger.LogInformation("Get information about Top 5 Entrants");

        var ctx = await _contextFactory.CreateDbContextAsync();

        var topFiveEntrants = await ((from entrant in ctx.Entrants
                                      orderby entrant.EntrantResults.Sum(t => t.Mark) descending
                                      select _mapper.Map<EntrantGetDto>(entrant)).Take(5)).ToListAsync();

        return topFiveEntrants;
    }

    /// <summary>
    /// Output information about the entrants (and their priority specialities) who scored the maxmum mark in each of the subject
    /// </summary>
    /// <returns>list of list entrants with max mark in each of the subject</returns>
    [HttpGet("EntrantsMaxMarkEachSubject")]
    public async Task<Dictionary<string, List<EntrantWithMaxMarkGet>>> GetEntrantsMaxMarkEachSubject()
    {
        _logger.LogInformation("Get information about the entrants who scored the maxmum mark in each of the subject");
        var subjectList = await GetAllSubject();

        var subjectsWithEntrants = new Dictionary<string, List<EntrantWithMaxMarkGet>>();

        var ctx = await _contextFactory.CreateDbContextAsync();
        foreach (var subject in subjectList)
        {
            subjectsWithEntrants.Add(subject, await (from entrant in ctx.Entrants
                                                     from stspec in entrant.Statement.StatementSpecialties
                                                     from res in entrant.EntrantResults
                                                     where res.Result.NameSubject == subject
                                                     where res.Mark == (from entrant in ctx.Entrants
                                                                        from res in entrant.EntrantResults
                                                                        where res.Result.NameSubject == subject
                                                                        select res.Mark).Max()
                                                     select new EntrantWithMaxMarkGet
                                                     {
                                                         NameEntrant = entrant.FullName,
                                                         NameSpecialty = stspec.Specialty.NameSpecialty,
                                                         MaxMark = res.Mark
                                                     }).ToListAsync());
        }

        return subjectsWithEntrants;
    }
}