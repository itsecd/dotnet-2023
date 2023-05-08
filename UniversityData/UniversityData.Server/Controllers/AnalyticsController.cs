using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    /// Хранение ContextFactory
    /// </summary>
    private readonly IDbContextFactory<UniversityDataDbContext> _contextFactory;
    /// <summary>
    /// Хранение маппера
    /// </summary>
    private readonly IMapper _mapper;
    public AnalyticsController(ILogger<UniversityController> logger, IDbContextFactory<UniversityDataDbContext> contextFactory, IMapper mapper)
    {
        _logger = logger;
        _contextFactory = contextFactory;
        _mapper = mapper;
    }

    /// <summary>
    /// Запрос 1 - Вывести информацию о выбранном вузе.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    [HttpGet("information_of_university{number}")]
    public async Task<ActionResult<UniversityGetDto>> GetInformationOfUniversity(string number)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var result = (from university in ctx.Universities
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
    public async Task<ActionResult<object>> InformationOfStructure(string number)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about university");
        var universities = (from university in ctx.Universities
                            where university.Number == number
                            select new
                            {
                                departments = _mapper.Map<IEnumerable<DepartmentGetDto>>(university.DepartmentsData),
                                faculties = _mapper.Map<IEnumerable<FacultyGetDto>>(university.FacultiesData),
                                specialties = _mapper.Map<IEnumerable<SpecialtyTableNodeGetDto>>(university.SpecialtyTable),
                            }).ToList();
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
    public async Task<IEnumerable<object>> InformationOfStructure()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get top five specialties");
        return (from specialtyNode in ctx.SpecialtyTableNodes
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
    public async Task<IEnumerable<UniversityGetDto>> MaxCountDepartments()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get universities with max count departments");
        return (from university in ctx.Universities
                where university.DepartmentsData.Count == ctx.Universities.Max(element => element.DepartmentsData.Count)
                select _mapper.Map<University, UniversityGetDto>(university)).ToList();
    }
    /// <summary>
    /// Запрос 5 - Вывести информацию о ВУЗах с заданной собственностью учреждения, и количество групп в ВУЗе.
    /// </summary>
    /// <param name="universityPropertyId"></param>
    /// <returns></returns>
    [HttpGet("university_with_target_property")]
    public async Task<IEnumerable<object>> UniversityWithProperty(int universityPropertyId)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about universities with target property");
        return (from university in ctx.Universities
                where (university.UniversityProperty.Id == universityPropertyId)
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
    public async Task<IEnumerable<object>> CountDepartments()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get counts of faculty, departments and specialties");
        return (from university in ctx.Universities
                group university by new {university.UniversityProperty.Id, university.ConstructionPropertyId} into universityConstGroup
                select new
                {
                    ConstProp = universityConstGroup.Key.ConstructionPropertyId,
                    UniversityProp = universityConstGroup.Key.Id,
                    Faculties = universityConstGroup.Sum(university => university.FacultiesData.Count),
                    Departments = universityConstGroup.Sum(university => university.DepartmentsData.Count),
                    Specialities = universityConstGroup.Sum(university => university.SpecialtyTable.Count)
                }).ToList();
    }
}
