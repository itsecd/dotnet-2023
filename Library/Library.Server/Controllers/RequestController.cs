using AutoMapper;
using Library.Domain;
using Library.Server.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Library.Server.Controllers;
/// <summary>
/// Request controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly LibraryDbContext _context;
    /// <summary>
    /// Used to store logger
    /// </summary>
    private readonly ILogger<RequestController> _logger;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Request controller's constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public RequestController(LibraryDbContext context, ILogger<RequestController> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }
    /// <summary>
    /// First request - give info about book by the cipher
    /// </summary>
    /// <param name="cipher"> Book's cipher </param>
    /// <returns> Info about book with this cipher </returns>
    [HttpGet("info_about_book")]
    public ActionResult<BookGetDto> Get(string cipher)
    {
        _logger.LogInformation("Get info about book");
        var request = (from book in _context.Books
                       where book.Cipher == cipher
                       select _mapper.Map<Book, BookGetDto>(book)).ToList();
        if (request.Count == 0)
        {
            _logger.LogInformation("Not found book: {id}", cipher);
            return NotFound();
        }
        else
        {
            return Ok(request);
        }
    }
    /// <summary>
    /// Second request - give info about all books issued order by book's name
    /// </summary>
    /// <returns> List of issued books </returns>
    [HttpGet("issued_books")]
    public ActionResult<BookGetDto> Get()
    {
        _logger.LogInformation("Get info about issued books");
        var request = (from book in _context.Books
                       join card in _context.Cards on book.Id equals card.BookId
                       orderby book.Name
                       group book by book into b
                       select new
                       {
                           book = _mapper.Map<Book, BookGetDto>(b.Key)
                       }).ToList();
        if (request.Count == 0)
        {
            _logger.LogInformation("Not found books");
            return NotFound();
        }
        else
        {
            return Ok(request);
        }
    }
    /// <summary>
    /// Third request - give info on the availability of the selected book in different departments and their quantity
    /// </summary>
    /// <param name="id"> Book's id </param>
    /// <returns> List of departments where selected book is available with it's count </returns>
    [HttpGet("availability_book")]
    public ActionResult<DepartmentGetDto> Get(int id)
    {
        _logger.LogInformation("Get info about availability of the selected book");
        var request = (from department in _context.Departments
                       join book in _context.Books on department.BookId equals book.Id
                       where book.Id == id
                       select new { department = department.TypeDepartmentId, count = department.Count }).ToList();
        if (request.Count == 0)
        {
            _logger.LogInformation("Not found book: {id}", id);
            return NotFound();
        }
        else
        {
            return Ok(request);
        }
    }
    /// <summary>
    /// Fourth request - give info about count of books in each department for each type edition
    /// </summary>
    /// <returns> List of types edition with count of books in all departments </returns>
    [HttpGet("count_types_book")]
    public ActionResult<DepartmentGetDto> GetCount()
    {
        _logger.LogInformation("Get info about count of books for all types edition");
        var request = (from mass in
                       (from department in _context.Departments
                        join book in _context.Books on department.BookId equals book.Id
                        join type in _context.TypesEdition on book.TypeEditionId equals type.Id
                        select new
                        {
                            types = type.Name,
                            count = department.Count
                        })
                       group mass by mass.types into gr
                       select new
                       {
                           Count = gr.Sum(ret => ret.count),
                           gr.Key
                       }).ToList();
        if (request.Count == 0)
        {
            _logger.LogInformation("Not found books");
            return NotFound();
        }
        else
        {
            return Ok(request);
        }
    }
    /// <summary>
    /// Fifth request - give info about top 5 readers who have read the most books in a given period
    /// </summary>
    /// <param name="date"> Period before that date </param>
    /// <returns> Top five readers with count of books they have read in a given period </returns>
    [HttpGet("top_readers")]
    public ActionResult<ReaderGetDto> GetTopReaders(DateTime date)
    {
        _logger.LogInformation("Get top five readers");
        var numOfReaders = (from card in _context.Cards
                            join reader in _context.Readers on card.ReaderId equals reader.Id
                            where card.DateOfReturn < date
                            group card by reader.FullName into g
                            select new
                            {
                                name = g.Key,
                                count = g.Count()
                            }).ToList();
        var request = (from reader in numOfReaders
                       orderby reader.count descending
                       select reader).Take(5).ToList();
        if (request.Count == 0)
        {
            _logger.LogInformation("Not found readers");
            return NotFound();
        }
        else
        {
            return Ok(request);
        }
    }
    /// <summary>
    /// Sixth request - give info about readers who have delayed books for the longest period of time, ordered by full name
    /// </summary>
    /// <returns> List of readers who have delayed books for the longest period of time </returns>
    [HttpGet("delay_readers")]
    public ActionResult<ReaderGetDto> GetDelayReaders()
    {
        _logger.LogInformation("Get info about readers who have delayed books for the longest period of time");
        var maxDelay = (from card in _context.Cards
                        join reader in _context.Readers on card.ReaderId equals reader.Id
                        group card by reader.FullName into g
                        select new
                        {
                            Name = g.Key,
                            MaxDelay = g.Select(x => (x.DateOfReturn - x.DateOfIssue).TotalDays - x.DayCount).Max()
                        }).ToList();
        var request = (from readers in maxDelay
                       where (readers.MaxDelay == maxDelay.Max(x => x.MaxDelay))
                       orderby readers.Name
                       select readers).ToList();
        if (request.Count == 0)
        {
            _logger.LogInformation("Not found readers");
            return NotFound();
        }
        else
        {
            return Ok(request);
        }
    }
}