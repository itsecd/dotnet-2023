using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.Domain;
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
    public List<Enrollee> GetEnrolleesByCity(string city)
    {
        //return _selectionCommitteeRepository.Enrollees
        //    .Where(enrollee => enrollee.City == city)
        //    .ToList();

        return new List<Enrollee>();
    }

    /// <summary>
    /// Вывести информацию об абитуриентах старше определенного возраста, упорядочить по ФИО.
    /// </summary>
    /// <param name="age">Возраст.</param>
    /// <returns>Список абитуриентов.</returns>
    [HttpGet(" GetSortedEnrolleesByAge/{age}")]
    public List<Enrollee> GetSortedEnrolleesByAge(int age)
    {
        //return _selectionCommitteeRepository.Enrollees
        //    .Where(enrollee => enrollee.Age > age)
        //    .OrderBy(enrollee => enrollee.LastName)
        //    .ThenBy(enrollee => enrollee.FirstName)
        //    .ThenBy(enrollee => enrollee.Patronymic)
        //    .ToList();

        return new List<Enrollee>();
    }

    /// <summary>
    /// Получить информацию об абитуриентах, поступающих на указанную специальность (без учета приоритета),
    /// упорядочить по сумме баллов за экзамены.
    /// </summary>
    /// <param name="specialization">Специальность.</param>
    /// <returns>Список абитуриентов.</returns>
    [HttpGet("GetEnrolleesBySpecialization/{specialization}")]
    public List<Enrollee> GetEnrolleesBySpecialization(string specialization)
    {
        //return _selectionCommitteeRepository.Enrollees
        //    .Where(enrollee => enrollee.Specializations![0].Name == specialization)
        //    .OrderBy(enrollee => enrollee.ExamResults!.Sum(examResult => examResult.Points))
        //    .ToList();

        return new List<Enrollee>();
    }

    /// <summary>
    /// Вывести информацию об абитуриентах, поступающих на специальность по указанному
    /// приоритету.
    /// </summary>
    /// <param name="specialization">Специальность.</param>
    /// <returns>Список абитуриентов.</returns>
    [HttpGet("GetEnrolleesBySpecializationAndPriority/{specialization}")]
    public List<Enrollee> GetEnrolleesBySpecializationAndPriority(string specialization)
    {
        //return _selectionCommitteeRepository.Enrollees
        //    .Where(enrollee => enrollee.Specializations![0].Name == specialization
        //        && enrollee.Specializations![0].Priority == 1)
        //    .ToList();

        return new List<Enrollee>();
    }

    /// <summary>
    /// Вывести информацию о топ 5 абитуриентах, набравших наибольшее число баллов за три предмета.
    /// <param name="count">Количество.</param>
    /// </summary>
    [HttpGet("GetEnrollesByExamResult/{count}")]
    public List<Enrollee> GetEnrollesByExamResult(int count) 
    {
        //return _selectionCommitteeRepository.Enrollees
        //    .OrderByDescending(enrollee =>
        //        enrollee!.ExamResults!.Sum(examResult => examResult.Points))
        //    .Take(count)
        //    .ToList();

        return new List<Enrollee>();
    }
}
