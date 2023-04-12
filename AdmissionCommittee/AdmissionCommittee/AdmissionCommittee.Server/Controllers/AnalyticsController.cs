using AdmissionCommittee.Server.Dto;
using AdmissionCommittee.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{

    private readonly ILogger<AnalyticsController> _logger;

    private readonly IAdmissionCommitteeRepository _admissionCommitteeRepository;

    private readonly IMapper _mapper;

    public AnalyticsController(ILogger<AnalyticsController> logger, IAdmissionCommitteeRepository admissionCommitteeRepository, IMapper mapper)
    {
        _logger = logger;
        _admissionCommitteeRepository = admissionCommitteeRepository;
        _mapper = mapper;
    }

    private List<string> GetAllSubject()
    {
        var subjectList = new List<string>();
        foreach (var res in _admissionCommitteeRepository.Results)
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
    public ActionResult<List<EntrantGetDto>> GetEntrantsFromSpecifiedCity(string city)
    {
        var selectedEntrants = (from entrant in _admissionCommitteeRepository.EntrantsWithStatement
                                where entrant.City == city
                                select _mapper.Map<EntrantGetDto>(entrant)).ToList();

        if (selectedEntrants == null)
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
    public List<EntrantGetDto> GetEntrantsOverTwentyYearsOlder()
    {
        _logger.LogInformation($"Get information about Entrants Over Twenty Years Older");

        return (from entrant in _admissionCommitteeRepository.EntrantsWithStatement
                where (DateTime.Now.Year - entrant.DateBirth.Year) > 20
                orderby entrant.FullName
                select _mapper.Map<EntrantGetDto>(entrant)).ToList();
    }

    /// <summary>
    /// Entrants entering the specified specialty
    /// (without taking into account priority)
    /// </summary>
    /// <param name="specialty">name Speciality</param>
    /// <returns>list Entrants entering the specified specialty</returns>
    [HttpGet("GetEntrantsEnteringSpecifiedSpecialty")]
    public ActionResult<List<EntrantGetDto>> GetEntrantsEnteringSpecifiedSpecialty(string specialty)
    {
        var selectedEntrants = (from entrant in _admissionCommitteeRepository.EntrantsWithEntrantResult
                                from stspec in entrant.Statement.StatementSpecialties
                                where stspec.Specialty.NameSpecialty == specialty
                                orderby entrant.EntrantResults.Sum(t => t.Mark) descending
                                select _mapper.Map<EntrantGetDto>(entrant)).ToList();


        if (selectedEntrants == null)
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
    public ActionResult<dynamic> GetCountOfEntrantsEnteringEachSpecialty()
    {
        _logger.LogInformation($"Get information about count of Entrants entering each specialty");

        return (from entrant in _admissionCommitteeRepository.EntrantsWithEntrantResult
                from stspec in entrant.Statement.StatementSpecialties
                where stspec.Priority == 1
                group stspec by stspec.Specialty.NameSpecialty into gstspec
                select new
                {
                    NameSpecialty = gstspec.Key,
                    CountEntrants = (from entrant in _admissionCommitteeRepository.EntrantsWithEntrantResult
                                     from stspec in entrant.Statement.StatementSpecialties
                                     where stspec.Specialty.NameSpecialty.Equals(gstspec.Key)
                                     where stspec.Priority == 1
                                     select _mapper.Map<EntrantGetDto>(entrant)).Count()
                }
                ).ToList();
    }

    /// <summary>
    /// Top 5 Entrants who scored the highest number of marks for 3 subject
    /// </summary>
    /// <returns>list Entrant with the highest number of marks for 3 subject</returns>
    [HttpGet("TopFiveEntrants")]
    public List<EntrantGetDto> GetTopFiveEntrants()
    {
        _logger.LogInformation($"Get information about Top 5 Entrants");

        return ((from entrant in _admissionCommitteeRepository.EntrantsWithEntrantResult
                 orderby entrant.EntrantResults.Sum(t => t.Mark) descending
                 select _mapper.Map<EntrantGetDto>(entrant)).Take(5)).ToList();
    }

    /// <summary>
    /// Output information about the entrants (and their priority specialities) who scored the maxmum mark in each of the subject
    /// </summary>
    /// <returns>list of list entrants with max mark in each of the subject</returns>
    [HttpGet("EntrantsMaxMarkEachSubject")]
    public List<List<EntrantWithMaxMarkGet>> GetEntrantsMaxMarkEachSubject()
    {
        _logger.LogInformation("Get information about the entrants who scored the maxmum mark in each of the subject");
        var subjectList = GetAllSubject();
        var selectedEntrants = new List<List<EntrantWithMaxMarkGet>>();
        foreach (var subject in subjectList)
        {
            selectedEntrants.Add((from entrant in _admissionCommitteeRepository.EntrantsWithEntrantResult
                                  from stspec in entrant.Statement.StatementSpecialties
                                  from res in entrant.EntrantResults
                                  where res.Result.NameSubject == subject
                                  where res.Mark == (from entrant in _admissionCommitteeRepository.EntrantsWithEntrantResult
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

        return selectedEntrants;
    }
}