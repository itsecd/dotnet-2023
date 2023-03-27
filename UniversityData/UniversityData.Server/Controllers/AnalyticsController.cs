using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityData.Domain;
using UniversityData.Server.Dto;
using UniversityData.Server.Repository;
namespace UniversityData.Server.Controllers;

/// <summary>
/// Контроллер для заданий-запросов
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    /// <summary>
    /// Хранение логгера
    /// </summary>
    private readonly ILogger<UniversityController> _logger;
    /// <summary>
    /// Хранение репозитория
    /// </summary>
    private readonly IUniversityDataRepository _universityDataRepository;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<UniversityController> logger, IUniversityDataRepository universityDataRepository, IMapper mapper)
    {
        _logger = logger;
        _universityDataRepository = universityDataRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Запрос 1 - Вывести информацию о выбранном вузе.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    [HttpGet("information_of_university{number}")]
    public ActionResult<UniversityGetDto> GetInformationOfUniversity(string number)
    {
        var result = (from university in _universityDataRepository.Universities
                         where university.Number == number
                         select _mapper.Map<University, UniversityGetDto>(university)).ToList();
        if (result.Count == 0)
        {
            _logger.LogInformation("Not found university with number: {0}", number);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get information about university");
            return Ok(result);
        }

    }
    /// <summary>
    /// Запрос 2 - Вывести информацию о факультетах, кафедрах и специальностях данного вуза.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    [HttpGet("information_of_structure_of_university{number}")]
    public ActionResult<UniversityGetStructureDto> InformationOfStructure(string number)
    {
        _logger.LogInformation("Get information about university");
        var universities = (from university in _universityDataRepository.Universities
                            where university.Number == number
                            select _mapper.Map<University, UniversityGetStructureDto>(university)).ToList();
        if (universities.Count == 0)
        {
            _logger.LogInformation("Not found university with number: {0}", number);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get information about structure of university");
            return Ok(universities);
        }
    }
    /// <summary>
    /// Запрос 3 - Вывести информацию о топ 5 популярных специальностях (с максимальным количеством групп).
    /// </summary>
    /// <returns></returns>
    [HttpGet("top_five_specialties")]
    public IEnumerable<object> InformationOfStructure()
    {
        _logger.LogInformation("Get top five specialties");
        return (from specialtyNode in _universityDataRepository.SpecialtyTableNodes
                group specialtyNode by specialtyNode.Specialty.Code into specialtyGroup
                orderby specialtyGroup.Count() descending
                select new
                {
                    Specialty = specialtyGroup.Key,
                    numRequests = specialtyGroup.Count()
                }).Take(5).ToList();
    }
    /// <summary>
    /// Запрос 4 - Вывести информацию о ВУЗах с максимальным количеством кафедр, упорядочить по названию.
    /// </summary>
    /// <returns></returns>
    [HttpGet("university_with_max_departments")]
    public IEnumerable<UniversityGetDto> MaxCountDepartments()
    {
        _logger.LogInformation("Get universitites with max count departments");
        return (from university in _universityDataRepository.Universities
                where university.DepartmentsData.Count == _universityDataRepository.Universities.Max(university => university.DepartmentsData.Count)
                select _mapper.Map<University, UniversityGetDto>(university)).ToList();
    }
    /// <summary>
    /// Запрос 5 - Вывести информацию о ВУЗах с заданной собственностью учреждения, и количество групп в ВУЗе.
    /// </summary>
    /// <param name="universityproperty"></param>
    /// <returns></returns>
    [HttpGet("university_with_target_property")]
    public IEnumerable<object> UniversityWithProperty(string universityProperty)
    {
        _logger.LogInformation("Get information about universities with target Propety");
        return (from university in _universityDataRepository.Universities
                where (university.UniversityProperty == universityProperty)
                select new
                {
                    university.Id,
                    university.Name,
                    university.Number,
                    university.RectorId,
                    university.ConstructionProperty,
                    university.UniversityProperty,
                    count = university.SpecialtyTable.Sum(specialtyNode => specialtyNode.CountGroups)
                }).ToList();
    }
    /// <summary>
    /// Запрос 6 - Вывести информацию о количестве факультетов, кафедр, специальностей по каждому типу собственности учреждения и собственности здания.
    /// </summary>
    /// <returns></returns>
    [HttpGet("count_departments")]
    public IEnumerable<object> CountDepartments()
    {
        _logger.LogInformation("Get counts of faculty, departments and specialties");
        return (from university in _universityDataRepository.Universities
                group university by university.ConstructionProperty into universityConstGroup
                from universityPropGroup in
                (
                    from university in universityConstGroup
                    group university by university.UniversityProperty into universityPropGroup
                    select new
                    {
                        UnivesityProp = universityPropGroup.Key
                    }
                )
                select new
                {
                    ConstProp = universityConstGroup.Key,
                    UniversityProp = universityPropGroup.UnivesityProp,
                    Faculties = universityConstGroup.Sum(university => university.FacultiesData.Count),
                    Departments = universityConstGroup.Sum(university => university.DepartmentsData.Count),
                    Specialities = universityConstGroup.Sum(university => university.SpecialtyTable.Count)
                }).ToList();
    }
}