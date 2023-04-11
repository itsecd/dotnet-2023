using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelectionCommittee.Server.Repository;

namespace SelectionCommittee.Server.Controllers.ExamResults;

///
/// Выполнение CRUD операций для результатов экзамена.
///
[Route("api/[controller]")]
[ApiController]
public class ExamResultController : Controller
{
    /// <summary>
    /// Репозиторий для сущностей приемной комиссии.
    /// </summary>
    private readonly ISelectionCommitteeRepository _selectionCommitteeRepository;

    /// <summary>
    /// Создание контроллера с помощью указанных параметров.
    /// </summary>
    /// <param name="selectionCommitteeRepository">Репозиторий сущностей приемной комиссии.</param>
    public ExamResultController(ISelectionCommitteeRepository selectionCommitteeRepository)
    {
        _selectionCommitteeRepository = selectionCommitteeRepository;
    }
}
