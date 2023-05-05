using AutoMapper;
using Library.Domain;
using Library.Server.Dto;
using Library.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.Server.Controllers;
/// <summary>
/// Book controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<BookController> _logger;
    /// <summary>
    /// Used to store repository
    /// </summary>
    private readonly ILibraryRepository _librariesRepository;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Book controller's constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="librariesRepository"></param>
    /// <param name="mapper"></param>
    public BookController(ILogger<BookController> logger, ILibraryRepository librariesRepository, IMapper mapper)
    {
        _logger = logger;
        _librariesRepository = librariesRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of all books
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<BookGetDto> Get()
    {
        return _librariesRepository.Books.Select(book => _mapper.Map<BookGetDto>(book));
    }
    /// <summary>
    /// Return info about book by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<BookGetDto> Get(int id)
    {
        var book = _librariesRepository.Books.FirstOrDefault(book => book.Id == id);
        if (book == null)
        {
            _logger.LogInformation("Not found book: {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<BookGetDto>(book));
        }
    }
    /// <summary>
    /// Add a new book
    /// </summary>
    /// <param name="book"></param>
    [HttpPost]
    public void Post([FromBody] BookPostDto book)
    {
        _librariesRepository.Books.Add(_mapper.Map<Book>(book));
        _logger.LogInformation("Added");
    }
    /// <summary>
    /// Сhange info of selected book
    /// </summary>
    /// <param name="id"></param>
    /// <param name="bookToPut"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BookPostDto bookToPut)
    {
        var book = _librariesRepository.Books.FirstOrDefault(book => book.Id == id);
        if (book == null)
        {
            _logger.LogInformation("Not found book: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(bookToPut, book);
            return Ok();
        }
    }
    /// <summary>
    /// Delete book by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = _librariesRepository.Books.FirstOrDefault(book => book.Id == id);
        if (book == null)
        {
            _logger.LogInformation("Not found book: {id}", id);
            return NotFound();
        }
        else
        {
            _librariesRepository.Books.Remove(book);
            return Ok();
        }
    }
}