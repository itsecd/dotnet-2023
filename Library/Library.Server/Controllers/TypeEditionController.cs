using AutoMapper;
using Library.Domain;
using Library.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Server.Controllers;
/// <summary>
/// TypeEdition controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TypeEditionController : ControllerBase
{
    private readonly LibraryDbContext _context;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// TypeEdition controller's constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public TypeEditionController(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of all types of books
    /// </summary>
    /// <returns> List of all types of books </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TypeEditionGetDto>>> GetTypesEdition()
    {
        return await _mapper.ProjectTo<TypeEditionGetDto>(_context.TypesEdition).ToListAsync();
    }
    /// <summary>
    /// Return info about type by id
    /// </summary>
    /// <param name="id"> TypeEdition's id </param>
    /// <returns> TypeEdition by id </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TypeEditionGetDto>> GetTypeEdition(int id)
    {
        var typeEdition = await _context.TypesEdition.FindAsync(id);

        if (typeEdition == null)
        {
            return NotFound();
        }

        return _mapper.Map<TypeEditionGetDto>(typeEdition);
    }
}