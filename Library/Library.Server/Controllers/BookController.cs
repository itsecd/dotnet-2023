using Library.Domain;
using Library.Server.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Library.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;

    private readonly LibraryRepository _librariesRepository;

    public BookController(ILogger<BookController> logger, LibraryRepository librariesRepository)
    {
        _logger = logger;
        _librariesRepository = librariesRepository;
    }

    [HttpGet]
    public IEnumerable<BookGetDto> Get()
    {
        return _librariesRepository.FixtureBook.Select(book => 
            new BookGetDto
            {
                Id = book.Id,
                Cipher = book.Cipher,
                Author = book.Author,
                Name = book.Name,
                PlaceEdition = book.PlaceEdition,
                YearEdition = book.YearEdition,
                TypeEditionId = book.TypeEditionId,
                IsIssued = book.IsIssued
            }
        );
    }

    [HttpGet("{id}")]
    public ActionResult<BookGetDto> Get(int id)
    {
        var book = _librariesRepository.FixtureBook.FirstOrDefault(book => book.Id == id);
        if (book == null)
        {
            _logger.LogInformation($"Not found book type: {id}");
            return NotFound();
        }
        else
        {
            return Ok(new BookGetDto
            {
                Id = book.Id,
                Cipher = book.Cipher,
                Author = book.Author,
                Name = book.Name,
                PlaceEdition = book.PlaceEdition,
                YearEdition = book.YearEdition,
                TypeEditionId = book.TypeEditionId,
                IsIssued = book.IsIssued
            });
        }
    }

    [HttpPost]
    public void Post([FromBody] BookPostDto book)
    {
        _librariesRepository.FixtureBook.Add(new Book()
        {
            Cipher = book.Cipher,
            Author = book.Author,
            Name = book.Name,
            PlaceEdition = book.PlaceEdition,
            YearEdition = book.YearEdition,
            TypeEditionId = book.TypeEditionId,
            IsIssued = book.IsIssued
        });
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}