using AdmissionCommittee.Server.Dto;
using AdmissionCommittee.Server.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdmissionCommittee.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnaliticController : ControllerBase
{

    private readonly ILogger<AnaliticController> _logger;

    private readonly IAdmissionCommitteeRepository _admissionCommitteeRepository;

    private readonly IMapper _mapper;

    public AnaliticController(ILogger<AnaliticController> logger, IAdmissionCommitteeRepository admissionCommitteeRepository, IMapper mapper)
    {
        _logger = logger;
        _admissionCommitteeRepository = admissionCommitteeRepository;
        _mapper = mapper;
    }


    /// <summary>
    /// Entrants from the specified city
    /// </summary>
    /// <param name="city">Name city</param>
    /// <returns>list Entrants from specified city</returns>
    [HttpGet("GetEntrantsFromSpecifiedCity")]
    public ActionResult<List<EntrantGetDto>> GetEntrantsFromSpecifiedCity(string city)
    {
        var selectedEntrants = (from entrant in _admissionCommitteeRepository.GetEntrants
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
    public List<EntrantGetDto> EntrantsOverTwentyYearsOlder()
    {
        _logger.LogInformation($"Get information about Entrants Over Twenty Years Older");

        return (from entrant in _admissionCommitteeRepository.GetEntrants
                where (DateTime.Now.Year - entrant.DateBirth.Year) > 20
                orderby entrant.FullName
                select _mapper.Map<EntrantGetDto>(entrant)).ToList();
    }

    /// <summary>
    /// Entrants entering the specified speciality
    /// (without taking into account priority)
    /// </summary>
    /// <param name="speciality">name Speciality</param>
    /// <returns>list Entrants entering the specified speciality</returns>
    [HttpGet("GetEntrantsEnteringSpecifiedSpeciality")]
    public ActionResult<List<EntrantGetDto>> GetEntrantsEnteringSpecifiedSpeciality(string speciality)
    {
        var selectedEntrants = (from entrant in _admissionCommitteeRepository.GetEntrants
                                from spec in entrant.Statement.PrioritySpecialities
                                where spec.Key.NameSpeciality == speciality
                                orderby entrant.Results.Sum(t => t.Mark) descending
                                select _mapper.Map<EntrantGetDto>(entrant)).ToList();


        if (selectedEntrants == null)
        {
            _logger.LogInformation("Not found Entrants entering the speciality {speciality}", speciality);
            return NotFound($"The Entrants does't exist entering the speciality {speciality}");
        }
        else
        {
            _logger.LogInformation("Get information about Entrants entering the speciality {speciality}", speciality);
            return Ok(selectedEntrants);
        }
    }

    /// <summary>
    /// Count of Entrants entering each speciality according to the first priority
    /// </summary>
    /// <returns>list name of Specialities with count of Entrants</returns>
    [HttpGet("CountOfEntrantsEnteringEachSpeciality")]
    public ActionResult<dynamic> GetCountOfEntrantsEnteringEachSpeciality()
    {
        _logger.LogInformation($"Get information about count of Entrants entering each speciality");

        return (from entrant in _admissionCommitteeRepository.GetEntrants
                from spec in entrant.Statement.PrioritySpecialities
                where spec.Value == 1
                group spec by spec.Key.NameSpeciality into gspec
                select new
                {
                    NameSpeciality = gspec.Key,
                    CountEntrants = (from entrant in _admissionCommitteeRepository.GetEntrants
                                     from spec in entrant.Statement.PrioritySpecialities
                                     where spec.Key.NameSpeciality.Equals(gspec.Key)
                                     where spec.Value == 1
                                     select _mapper.Map<EntrantGetDto>(entrant)).Count()
                }
                ).ToList();
    }

    /// <summary>
    /// Top 5 Entrants who scored the highest number of marks for 3 subject
    /// </summary>
    /// <returns></returns>
    [HttpGet("TopFiveEntrants")]
    public List<EntrantGetDto> GetTopFiveEntrants()
    {
        _logger.LogInformation($"Get information about Top 5 Entrants");

        return ((from entrant in _admissionCommitteeRepository.GetEntrants
                 orderby entrant.Results.Sum(t => t.Mark) descending
                 select _mapper.Map<EntrantGetDto>(entrant)).Take(5)).ToList();
    }

    //[HttpGet("GetEntrantsEnteringSpecifiedSpeciality")]
    //public ActionResult<dynamic> GetEntrantMaxMark(string nameSubject)
    //{
    //    var entrantSubject = (from entrant in _admissionCommitteeRepository.GetEntrants
    //                          from spec in entrant.Statement.PrioritySpecialities
    //                          from res in entrant.Results
    //                          where res.NameSubject == nameSubject
    //                          where res.Mark == (from entrant in _admissionCommitteeRepository.GetEntrants
    //                                             from res in entrant.Results
    //                                             where res.NameSubject == nameSubject
    //                                             select res.Mark).Max()
    //                         select new
    //                         {
    //                            NameEntrant = entrant.FullName,
    //                            Speciality = spec.Key.NameSpeciality,
    //                            MaxMark = res.Mark
    //                         }
    //                         ).ToList();

    //    //if (entrantSubject == null)
    //    //{
    //    //    _logger.LogInformation("Not found Entrants entering the speciality {speciality}", speciality);
    //    //    return NotFound($"The Entrants does't exist entering the speciality {speciality}");
    //    //}
    //    //else
    //    //{
    //    //    _logger.LogInformation("Get information about Entrants entering the speciality {speciality}", speciality);
    //    //    return Ok(selectedEntrants);
    //    //}
    //}
}