using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.Server.Controllers.Enrollees.Dto;
using SelectionCommittee.Server.Repository;

namespace SelectionCommittee.Server.Controllers.Enrollees;

///
/// Выполнение CRUD операций для абитуриента.
///
[Route("api/[controller]")]
[ApiController]
public class EnrolleeController : Controller
{
    /// <summary>
    /// Репозиторий для сущностей приемной комиссии.
    /// </summary>
    private readonly ISelectionCommitteeRepository _selectionCommitteeRepository;

    /// <summary>
    /// Создание контроллера с помощью указанных параметров.
    /// </summary>
    /// <param name="selectionCommitteeRepository">Репозиторий сущностей приемной комиссии.</param>
    public EnrolleeController(ISelectionCommitteeRepository selectionCommitteeRepository)
    {
        _selectionCommitteeRepository = selectionCommitteeRepository;
    }

    [HttpGet]
    public IEnumerable<EnrolleeDtoGet> Get() 
    {
        return _selectionCommitteeRepository.Enrollees.Select(x => new EnrolleeDtoGet
        {

        });
    }

    [HttpGet]
    public ActionResult<EnrolleeDtoGet> Get(int id)
    {
        var enrollee = _selectionCommitteeRepository.Enrollees.FirstOrDefault(e => e.Id == id);

        if (enrollee == null) 
        {
            return NotFound();
        }
    }
}
