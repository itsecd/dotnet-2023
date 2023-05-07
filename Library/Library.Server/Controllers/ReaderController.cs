using AutoMapper;
using Library.Domain;
using Library.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Server.Controllers;
/// <summary>
/// Reader controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ReaderController : ControllerBase
{
    private readonly LibraryDbContext _context;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Reader controller's constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public ReaderController(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of all readers
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReaderGetDto>>> Get()
    {
        if (_context.Readers == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<ReaderGetDto>(_context.Readers).ToListAsync();
    }
    /// <summary>
    /// Return info about reader by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ReaderGetDto>> Get(int id)
    {
        if (_context.Readers == null)
        {
            return NotFound();
        }
        var reader = await _context.Readers.FindAsync(id);

        if (reader == null)
        {
            return NotFound();
        }

        return _mapper.Map<ReaderGetDto>(reader);
    }
    /// <summary>
    /// Add a new reader
    /// </summary>
    /// <param name="reader"></param>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<ReaderGetDto>> PostCard(ReaderPostDto reader)
    {
        if (_context.Readers == null)
        {
            return Problem("Entity set 'LibraryDbContext.Readers'  is null.");
        }
        var mappedReader = _mapper.Map<Reader>(reader);

        _context.Readers.Add(mappedReader);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostReader", new { id = mappedReader.Id }, _mapper.Map<ReaderGetDto>(mappedReader));
    }
    /// <summary>
    /// Сhange info of selected reader
    /// </summary>
    /// <param name="id"></param>
    /// <param name="reader"></param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ReaderPostDto reader)
    {
        if (_context.Readers == null)
        {
            return NotFound();
        }
        var readerToModify = await _context.Readers.FindAsync(id);
        if (readerToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(reader, readerToModify);

        await _context.SaveChangesAsync();

        return NoContent();
    }
    /// <summary>
    /// Delete reader by id
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (_context.Readers == null)
        {
            return NotFound();
        }
        var reader = await _context.Readers.FindAsync(id);
        if (reader == null)
        {
            return NotFound();
        }

        _context.Readers.Remove(reader);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}