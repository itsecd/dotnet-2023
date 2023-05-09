using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.Domain;
using SelectionCommittee.Server.Controllers.Enrollees.Dto;
using SelectionCommittee.Server.Repository;

namespace SelectionCommittee.Server.Controllers;

/// <summary>
/// Выполнение LINQ запросов.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class QueryController : Controller
{
    /// <summary>
    /// Репозиторий для сущностей приемной комиссии.
    /// </summary>
    private readonly ISelectionCommitteeRepository _selectionCommitteeRepository;

    /// <summary>
    /// Создание контроллера с помощью указанных параметров.
    /// </summary>
    /// <param name="selectionCommitteeRepository">Репозиторий сущностей приемной комиссии.</param>
    public QueryController(ISelectionCommitteeRepository selectionCommitteeRepository)
    {
        _selectionCommitteeRepository = selectionCommitteeRepository;
    }

    /// <summary>
    /// Вывести информацию об абитуриентах из указанного города.
    /// </summary>
    /// <param name="city">Город.</param>
    /// <returns>Список абитуриентов.</returns>
    [HttpGet("GetEnrolleesByCity/{city}")]
    public async Task<List<EnrolleeDtoGet>> GetEnrolleesByCity(string city)
    {
        return (await _selectionCommitteeRepository.GetEnrollees())
            .Where(enrollee => enrollee.City == city)
            .Select(enrollee => new EnrolleeDtoGet
            {
                Id = enrollee.Id,
                FirstName = enrollee.FirstName,
                LastName = enrollee.LastName,
                Patronymic = enrollee.Patronymic,
                Age = enrollee.Age,
                BirthDate = enrollee.BirthDate,
                Country = enrollee.Country,
                City = enrollee.City,
                SpecializationId = enrollee.SpecializationId
            })
            .ToList();
    }

    /// <summary>
    /// Вывести информацию об абитуриентах старше определенного возраста, упорядочить по ФИО.
    /// </summary>
    /// <param name="age">Возраст.</param>
    /// <returns>Список абитуриентов.</returns>
    [HttpGet("GetSortedEnrolleesByAge/{age}")]
    public async Task<List<EnrolleeDtoGet>> GetSortedEnrolleesByAge(int age)
    {
        return (await _selectionCommitteeRepository.GetEnrollees())
            .Where(enrollee => enrollee.Age > age)
            .OrderBy(enrollee => enrollee.LastName)
            .ThenBy(enrollee => enrollee.FirstName)
            .ThenBy(enrollee => enrollee.Patronymic)
            .Select(enrollee => new EnrolleeDtoGet
            {
                Id = enrollee.Id,
                FirstName = enrollee.FirstName,
                LastName = enrollee.LastName,
                Patronymic = enrollee.Patronymic,
                Age = enrollee.Age,
                BirthDate = enrollee.BirthDate,
                Country = enrollee.Country,
                City = enrollee.City,
                SpecializationId = enrollee.SpecializationId
            })
            .ToList();
    }

    /// <summary>
    /// Получить информацию об абитуриентах, поступающих на указанную специальность (без учета приоритета),
    /// упорядочить по сумме баллов за экзамены.
    /// </summary>
    /// <param name="specialization">Специальность.</param>
    /// <returns>Список абитуриентов.</returns>
    [HttpGet("GetEnrolleesBySpecialization/{specialization}")]
    public async Task<ActionResult<List<EnrolleeDtoGet>>> GetEnrolleesBySpecialization(string specialization)
    {
        var entity = (await _selectionCommitteeRepository.GetSpecializations())
            .FirstOrDefault(specializationObject => specializationObject.Name == specialization);

        if (entity == null)
        {
            return NotFound("Указанная специальность не найдена!");
        }

        return Ok((await _selectionCommitteeRepository.GetEnrollees())
            .Where(enrollee => enrollee.SpecializationId == entity.Id)
            .Select(enrollee => new EnrolleeDtoGet
            {
                Id = enrollee.Id,
                FirstName = enrollee.FirstName,
                LastName = enrollee.LastName,
                Patronymic = enrollee.Patronymic,
                Age = enrollee.Age,
                BirthDate = enrollee.BirthDate,
                Country = enrollee.Country,
                City = enrollee.City,
                SpecializationId = enrollee.SpecializationId
            })
            .ToList());
    }

    /// <summary>
    /// Вывести информацию об абитуриентах, поступающих на специальность по указанному
    /// приоритету.
    /// </summary>
    /// <param name="specialization">Специальность.</param>
    /// <returns>Список абитуриентов.</returns>
    [HttpGet("GetEnrolleesBySpecializationAndPriority/{specialization}")]
    public async Task<ActionResult<List<Enrollee>>> GetEnrolleesBySpecializationAndPriority(string specialization, int priority)
    {
        var entity = (await _selectionCommitteeRepository.GetSpecializations())
            .FirstOrDefault(specializationObject => specializationObject.Name == specialization && specializationObject.Priority == priority);

        if (entity == null)
        {
            return NotFound("Указанная специальность не найдена!");
        }

        return Ok((await _selectionCommitteeRepository.GetEnrollees())
            .Where(enrollee => enrollee.SpecializationId == entity.Id)
            .Select(enrollee => new EnrolleeDtoGet
            {
                Id = enrollee.Id,
                FirstName = enrollee.FirstName,
                LastName = enrollee.LastName,
                Patronymic = enrollee.Patronymic,
                Age = enrollee.Age,
                BirthDate = enrollee.BirthDate,
                Country = enrollee.Country,
                City = enrollee.City,
                SpecializationId = enrollee.SpecializationId
            })
            .ToList());
    }

    /// <summary>
    /// Вывести информацию о топ 5 абитуриентах, набравших наибольшее число баллов за три предмета.
    /// <param name="count">Количество.</param>
    /// </summary>
    [HttpGet("GetEnrollesByExamResult/{count}")]
    public async Task<ActionResult<List<EnrolleeDtoGet>>> GetEnrollesByExamResult(int count)
    {
        if (count <= 0)
        {
            return BadRequest("Количество абитуриентов должно быть положительным числом!");
        }

        var examResults = await _selectionCommitteeRepository.GetExamResults();

        return (await _selectionCommitteeRepository.GetEnrollees())
            .OrderByDescending(enrollee => examResults.Where(result => result.EnrolleeId == enrollee.Id).Sum(result => result.Points))
            .Take(count)
            .Select(enrollee => new EnrolleeDtoGet
            {
                Id = enrollee.Id,
                FirstName = enrollee.FirstName,
                LastName = enrollee.LastName,
                Patronymic = enrollee.Patronymic,
                Age = enrollee.Age,
                BirthDate = enrollee.BirthDate,
                Country = enrollee.Country,
                City = enrollee.City,
                SpecializationId = enrollee.SpecializationId
            })
            .ToList();
    }
}
