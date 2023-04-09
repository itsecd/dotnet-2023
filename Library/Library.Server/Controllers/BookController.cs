using AutoMapper;
using Library.Domain;
using Library.Server.Dto;
using Library.Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Library.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;

    private readonly ILibraryRepository _librariesRepository;

    private readonly IMapper _mapper;

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

    [HttpGet("{id}")]
    public ActionResult<BookGetDto> Get(int id)
    {
        var book = _librariesRepository.Books.FirstOrDefault(book => book.Id == id);
        if (book == null)
        {
            _logger.LogInformation("Not found book type: {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<BookGetDto>(book));
        }
    }

    [HttpPost]
    public void Post([FromBody] BookPostDto book)
    {
        _librariesRepository.Books.Add(_mapper.Map<Book>(book));
        _logger.LogInformation("Added");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BookPostDto bookToPut)
    {
        var book = _librariesRepository.Books.FirstOrDefault(book => book.Id == id);
        if (book == null)
        {
            _logger.LogInformation("Not found book type: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(bookToPut, book);
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = _librariesRepository.Books.FirstOrDefault(book => book.Id == id);
        if (book == null)
        {
            _logger.LogInformation("Not found book type: {id}", id);
            return NotFound();
        }
        else
        {
            _librariesRepository.Books.Remove(book);
            return Ok();
        }
    }
}