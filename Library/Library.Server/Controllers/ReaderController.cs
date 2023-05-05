using AutoMapper;
using Library.Domain;
using Library.Server.Dto;
using Library.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.Server.Controllers;
/// <summary>
/// Reader controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ReaderController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<ReaderController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly ILibraryRepository _librariesRepository;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Reader controller's constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="librariesRepository"></param>
    /// <param name="mapper"></param>
    public ReaderController(ILogger<ReaderController> logger, ILibraryRepository librariesRepository, IMapper mapper)
    {
        _logger = logger;
        _librariesRepository = librariesRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of all readers
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<ReaderGetDto> Get()
    {
        return _librariesRepository.Readers.Select(reader => _mapper.Map<ReaderGetDto>(reader));
    }
    /// <summary>
    /// Return info about reader by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<ReaderGetDto> Get(int id)
    {
        var reader = _librariesRepository.Readers.FirstOrDefault(reader => reader.Id == id);
        if (reader == null)
        {
            _logger.LogInformation("Not found reader: {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ReaderGetDto>(reader));
        }
    }
    /// <summary>
    /// Add a new reader
    /// </summary>
    /// <param name="reader"></param>
    [HttpPost]
    public void Post([FromBody] ReaderPostDto reader)
    {
        _librariesRepository.Readers.Add(_mapper.Map<Reader>(reader));
        _logger.LogInformation("Added");
    }
    /// <summary>
    /// Сhange info of selected reader
    /// </summary>
    /// <param name="id"></param>
    /// <param name="readerToPut"></param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ReaderPostDto readerToPut)
    {
        var reader = _librariesRepository.Readers.FirstOrDefault(reader => reader.Id == id);
        if (reader == null)
        {
            _logger.LogInformation("Not found reader: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(readerToPut, reader);
            return Ok();
        }
    }
    /// <summary>
    /// Delete reader by id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var reader = _librariesRepository.Readers.FirstOrDefault(reader => reader.Id == id);
        if (reader == null)
        {
            _logger.LogInformation("Not found reader: {id}", id);
            return NotFound();
        }
        else
        {
            _librariesRepository.Readers.Remove(reader);
            return Ok();
        }
    }
}