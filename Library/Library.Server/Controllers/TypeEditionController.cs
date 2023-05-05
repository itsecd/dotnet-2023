using AutoMapper;
using Library.Server.Dto;
using Library.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.Server.Controllers;
/// <summary>
/// TypeEdition controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TypeEditionController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<TypeEditionController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly ILibraryRepository _librariesRepository;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// TypeEdition controller's constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="librariesRepository"></param>
    /// <param name="mapper"></param>
    public TypeEditionController(ILogger<TypeEditionController> logger, ILibraryRepository librariesRepository, IMapper mapper)
    {
        _logger = logger;
        _librariesRepository = librariesRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of all types of books
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<TypeEditionGetDto> Get()
    {
        return _librariesRepository.BookTypes.Select(type => _mapper.Map<TypeEditionGetDto>(type));
    }
    /// <summary>
    /// Return info about type by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<TypeEditionGetDto> Get(int id)
    {
        var bookType = _librariesRepository.BookTypes.FirstOrDefault(type => type.Id == id);
        if (bookType == null)
        {
            _logger.LogInformation("Not found book type: {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<TypeEditionGetDto>(bookType));
        }
    }
}