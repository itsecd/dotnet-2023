using AutoMapper;
using Library.Domain;
using Library.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Server.Controllers;

/// <summary>
/// Book controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly LibraryDbContext _context;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Book controller's constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public BookController(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of all books
    /// </summary>
    /// <returns> List of all books </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookGetDto>>> GetBooks()
    {
        return await _mapper.ProjectTo<BookGetDto>(_context.Books).ToListAsync();
    }
    /// <summary>
    /// Return info about book by id
    /// </summary>
    /// <param name="id"> Book's id </param>
    /// <returns> Book by id </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BookGetDto>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return _mapper.Map<BookGetDto>(book);
    }
    /// <summary>
    /// Add a new book
    /// </summary>
    /// <param name="book"> New books object </param>
    /// <returns> Inserted book </returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<BookGetDto>> PostBook(BookPostDto book)
    {
        var mappedBook = _mapper.Map<Book>(book);

        _context.Books.Add(mappedBook);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostBook", new { id = mappedBook.Id }, _mapper.Map<BookGetDto>(mappedBook));
    }
    /// <summary>
    /// Сhange info of selected book
    /// </summary>
    /// <param name="id"> Book's id </param>
    /// <param name="book"> New books object </param>
    /// <returns> NoContent </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int id, BookPostDto book)
    {
        var bookToModify = await _context.Books.FindAsync(id);
        if (bookToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(book, bookToModify);

        await _context.SaveChangesAsync();

        return NoContent();
    }
    /// <summary>
    /// Delete book by id
    /// </summary>
    /// <param name="id"> Book's id </param>
    /// <returns> NoContent </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}