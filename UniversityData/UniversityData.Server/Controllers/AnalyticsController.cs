using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityData.Domain;
using UniversityData.Server.Dto;
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
    /// Запрос 1 - Вывести информацию о выбранном вузе
    /// </summary>
    /// <param name="name"></param>
    /// <returns>
    /// Информация об университете
    /// </returns>
    [HttpGet("information_of_university/{name}")]
    public async Task<ActionResult<UniversityGetDto>> GetInformationOfUniversity(string name)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        var result = await (from university in ctx.Universities
                            where university.Name == name
                            select _mapper.Map<University, UniversityGetDto>(university)).ToListAsync();
        if (result.Any())
        {
            _logger.LogInformation("Get information about university");
            return Ok(result.First());
        }
        else
        {

            _logger.LogInformation("Not found university with name {id}", name);
            return NotFound();
        }

    }

    /// <summary>
    /// Запрос 2 - Вывести информацию о факультетах, кафедрах и специальностях данного вуза
    /// </summary>
    /// <param name="name"></param>
    /// <returns>
    /// Основная информация об университете
    /// Количество структурных подразделений для данного университета
    /// </returns>
    [HttpGet("information_of_structure_of_university/{name}")]
    public async Task<ActionResult<UniversityStructureDto>> InformationOfStructure(string name)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about university");
        var universities = await (from university in ctx.Universities
                                  where university.Name == name
                                  select new UniversityStructureDto
                                  {
                                      Id = university.Id,
                                      Number = university.Number,
                                      Name = university.Name,
                                      CountDepartments = university.DepartmentsData.Count,
                                      CountFaculties = university.FacultiesData.Count,
                                      CountSpecialties = university.SpecialtyTable.Count
                                  }).ToListAsync();
        if (universities.Any())
        {
            _logger.LogInformation("Get information about structure of university");
            return Ok(universities.First());
        }
        else
        {
            _logger.LogInformation("Not found university with name: {id}", name);
            return NotFound();
        }
    }

    /// <summary>
    /// Запрос 3 - Вывести информацию о топ 5 популярных специальностях (с максимальным количеством групп)
    /// </summary>
    /// <returns>
    /// Коллекция специальностей с максимальным количеством групп
    /// </returns>
    [HttpGet("top_five_specialties")]
    public async Task<IEnumerable<MostPopularSpecialtyDto>> MostPopularSpecialties()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get top five specialties");
        return await (from specialtyNode in ctx.SpecialtyTableNodes
                      group specialtyNode by specialtyNode.Specialty.Code into specialtyGroup
                      orderby specialtyGroup.Count() descending
                      select new MostPopularSpecialtyDto
                      {
                          Id = specialtyGroup.First().Specialty.Id,
                          Name = specialtyGroup.First().Specialty.Name,
                          Code = specialtyGroup.First().Specialty.Code,
                          CountGroups = specialtyGroup.Count()
                      }).Take(5).ToListAsync();
    }

    /// <summary>
    /// Запрос 4 - Вывести информацию о ВУЗах с максимальным количеством кафедр, упорядочить по названию
    /// </summary>
    /// <returns>
    /// Коллекция университетов с максимальным количеством групп
    /// </returns>
    [HttpGet("university_with_max_departments")]
    public async Task<IEnumerable<UniversityGetDto>> MaxCountDepartments()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get universities with max count departments");
        return await (from university in ctx.Universities
                      where university.DepartmentsData.Count == ctx.Universities.Max(element => element.DepartmentsData.Count)
                      select _mapper.Map<University, UniversityGetDto>(university)).ToListAsync();
    }
    /// <summary>
    /// Запрос 5 - Вывести информацию о ВУЗах с заданной собственностью учреждения, и количество групп в ВУЗе
    /// </summary>
    /// <param name="universityPropertyId"></param>
    /// <returns>
    /// Коллекция университетов с заданной собственностью организации
    /// </returns>
    [HttpGet("university_with_target_property/{universityPropertyId}")]
    public async Task<IEnumerable<UniversityWithGivenPropertyDto>> UniversityWithProperty(int universityPropertyId)
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get information about universities with target property");
        return await (from university in ctx.Universities
                      where (university.UniversityProperty.Id == universityPropertyId)
                      select new UniversityWithGivenPropertyDto
                      {
                          Id = university.Id,
                          Name = university.Name,
                          Number = university.Number,
                          UniversityPropertyId = university.UniversityPropertyId,
                          CountGroups = university.SpecialtyTable.Sum(specialtyNode => specialtyNode.CountGroups)
                      }).ToListAsync();
    }

    /// <summary>
    /// Запрос 6 - Вывести информацию о количестве факультетов, кафедр, специальностей по каждому типу собственности учреждения и собственности здания
    /// </summary>
    /// <returns>
    /// Коллекция объектов, описываюищх общее количество подразделений университетов по всем комбинациям собственности зданий и собственности университета
    /// </returns>
    [HttpGet("count_divisions")]
    public async Task<IEnumerable<CountDivisionsWithDifferentProperties>> CountDepartments()
    {
        await using UniversityDataDbContext ctx = await _contextFactory.CreateDbContextAsync();
        _logger.LogInformation("Get counts of faculty, departments and specialties");
        return await (from university in ctx.Universities
                      group university by new { university.UniversityProperty.Id, university.ConstructionPropertyId } into universityConstGroup
                      select new CountDivisionsWithDifferentProperties
                      {
                          ConstructionPropertyId = universityConstGroup.Key.ConstructionPropertyId,
                          UniversityPropertyId = universityConstGroup.Key.Id,
                          CountFaculties = universityConstGroup.Sum(university => university.FacultiesData.Count),
                          CountDepartments = universityConstGroup.Sum(university => university.DepartmentsData.Count),
                          CountSpecialties = universityConstGroup.Sum(university => university.SpecialtyTable.Count)
                      }).ToListAsync();
    }
}
