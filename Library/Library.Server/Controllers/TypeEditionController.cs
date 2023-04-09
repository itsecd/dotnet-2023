using Library.Domain;
using Library.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TypeEditionController : ControllerBase
{
    private readonly ILogger<TypeEditionController> _logger;

    private readonly ILibraryRepository _librariesRepository;

    public TypeEditionController(ILogger<TypeEditionController> logger, ILibraryRepository librariesRepository)
    {
        _logger = logger;
        _librariesRepository = librariesRepository;
    }

    [HttpGet]
    public IEnumerable<TypeEdition> Get()
    {
        return _librariesRepository.BookTypes;
    }

    [HttpGet("{id}")]
    public ActionResult<TypeEdition> Get(int id)
    {
        var bookType = _librariesRepository.BookTypes.FirstOrDefault(type => type.Id == id);
        if (bookType == null)
        {
            _logger.LogInformation("Not found book type: {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(bookType);
        }
    }
}