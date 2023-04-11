using Microsoft.AspNetCore.Http;
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
    /// <returns></returns>
    [HttpGet]
    public List<Enrollee> GetEnrolleesByCity(string city)
    {
        return _selectionCommitteeRepository.Enrollees
            .Where(enrollee => enrollee.City == city)
            .ToList();
    }

    /// <summary>
    /// Вывести информацию об абитуриентах старше определенного возраста, упорядочить по ФИО.
    /// </summary>
    /// <param name="age"></param>
    /// <returns></returns>
    [HttpGet]
    public List<Enrollee> GetSortedEnrolleesByAge(int age)
    {

    }
}
