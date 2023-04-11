using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.Server.Repository;

namespace SelectionCommittee.Server.Controllers.Faculties;

///
/// Выполнение CRUD операций для факультета.
///
[Route("api/[controller]")]
[ApiController]
public class FacultyController : Controller
{
    /// <summary>
    /// Репозиторий для сущностей приемной комиссии.
    /// </summary>
    private readonly ISelectionCommitteeRepository _selectionCommitteeRepository;

    /// <summary>
    /// Создание контроллера с помощью указанных параметров.
    /// </summary>
    /// <param name="selectionCommitteeRepository">Репозиторий сущностей приемной комиссии.</param>
    public FacultyController(ISelectionCommitteeRepository selectionCommitteeRepository)
    {
        _selectionCommitteeRepository = selectionCommitteeRepository;
    }
}
