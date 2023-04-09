using Library.Domain;
using Library.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

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
        return _librariesRepository.Books.Select(book => 
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
        var book = _librariesRepository.Books.FirstOrDefault(book => book.Id == id);
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
        _librariesRepository.Books.Add(new Book()
        {
            Cipher = book.Cipher,
            Author = book.Author,
            Name = book.Name,
            PlaceEdition = book.PlaceEdition,
            YearEdition = book.YearEdition,
            TypeEditionId = book.TypeEditionId,
            IsIssued = book.IsIssued
        });
        _logger.LogInformation("Added");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] BookPostDto bookToPut)
    {
        var book = _librariesRepository.Books.FirstOrDefault(book => book.Id == id);
        if (book == null)
        {
            _logger.LogInformation($"Not found book type: {id}");
            return NotFound();
        }
        else
        {
            book.Cipher = bookToPut.Cipher;
            book.Author = bookToPut.Author;
            book.Name = bookToPut.Name;
            book.PlaceEdition = bookToPut.PlaceEdition;
            book.YearEdition = bookToPut.YearEdition;
            book.TypeEditionId = bookToPut.TypeEditionId;
            book.IsIssued = bookToPut.IsIssued;
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var book = _librariesRepository.Books.FirstOrDefault(book => book.Id == id);
        if (book == null)
        {
            _logger.LogInformation($"Not found book type: {id}");
            return NotFound();
        }
        else
        {
            _librariesRepository.Books.Remove(book);
            return Ok();
        }
    }
}