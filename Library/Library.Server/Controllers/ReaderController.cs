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
    /// <returns> List of all readers </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReaderGetDto>>> GetReaders()
    {
        return await _mapper.ProjectTo<ReaderGetDto>(_context.Readers).ToListAsync();
    }
    /// <summary>
    /// Return info about reader by id
    /// </summary>
    /// <param name="id"> Reader's id </param>
    /// <returns> Reader by id </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ReaderGetDto>> GetReader(int id)
    {
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
    /// <param name="reader"> New readers object </param>
    /// <returns> Inserted reader </returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<ReaderGetDto>> PostReader(ReaderPostDto reader)
    {
        var mappedReader = _mapper.Map<Reader>(reader);

        _context.Readers.Add(mappedReader);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostReader", new { id = mappedReader.Id }, _mapper.Map<ReaderGetDto>(mappedReader));
    }
    /// <summary>
    /// Сhange info of selected reader
    /// </summary>
    /// <param name="id"> Reader's id </param>
    /// <param name="reader"> New readers object </param>
    /// <returns> NoContent </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutReader(int id, ReaderPostDto reader)
    {
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
    /// <param name="id"> Reader's id </param>
    /// <returns> NoContent </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReader(int id)
    {
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