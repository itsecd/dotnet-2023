using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Domain;
using Library.Server.Dto;

namespace Library.Server.Controllers;
/// <summary>
/// TypeDepartment controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TypeDepartmentController : ControllerBase
{
    private readonly LibraryDbContext _context;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// TypeDepartment controller's constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public TypeDepartmentController(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of all types of departments
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TypeDepartmentGetDto>>> Get()
    {
        if (_context.TypesDepartment == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<TypeDepartmentGetDto>(_context.TypesDepartment).ToListAsync();
    }
    /// <summary>
    /// Return info about type by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TypeDepartmentGetDto>> Get(int id)
    {
        if (_context.TypesDepartment == null)
        {
            return NotFound();
        }
        var typeDepartment = await _context.TypesDepartment.FindAsync(id);

        if (typeDepartment == null)
        {
            return NotFound();
        }

        return _mapper.Map<TypeDepartmentGetDto>(typeDepartment);
    }
}