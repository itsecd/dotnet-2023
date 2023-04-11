using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.Server.Repository;

namespace SelectionCommittee.Server.Controllers.Specializations;

///
/// Выполнение CRUD операций для специализации.
///
[Route("api/[controller]")]
[ApiController]
public class SpecializationController : Controller
{
    /// <summary>
    /// Репозиторий для сущностей приемной комиссии.
    /// </summary>
    private readonly ISelectionCommitteeRepository _selectionCommitteeRepository;

    /// <summary>
    /// Создание контроллера с помощью указанных параметров.
    /// </summary>
    /// <param name="selectionCommitteeRepository">Репозиторий сущностей приемной комиссии.</param>
    public SpecializationController(ISelectionCommitteeRepository selectionCommitteeRepository)
    {
        _selectionCommitteeRepository = selectionCommitteeRepository;
    }
}
