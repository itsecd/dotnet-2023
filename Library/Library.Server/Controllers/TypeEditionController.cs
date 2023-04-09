using Library.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Library.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TypeEditionController : ControllerBase
{
    private readonly ILogger<TypeEditionController> _logger;

    private readonly LibraryRepository _librariesRepository;

    public TypeEditionController(ILogger<TypeEditionController> logger, LibraryRepository librariesRepository)
    {
        _logger = logger;
        _librariesRepository = librariesRepository;
    }

    [HttpGet]
    public IEnumerable<TypeEdition> Get()
    {
        return _librariesRepository.FixtureTypeEdition;
    }

    [HttpGet("{id}")]
    public ActionResult<TypeEdition> Get(int id)
    {
        var bookType = _librariesRepository.FixtureTypeEdition.FirstOrDefault(type => type.Id == id);
        if (bookType == null)
        {
            _logger.LogInformation($"Not found book type: {id}");
            return NotFound();
        }
        else
        {
            return Ok(bookType);
        }
    }
}