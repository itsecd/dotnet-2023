using AutoMapper;
using Library.Domain;
using Library.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    /// <returns> List of all types of departments </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TypeDepartmentGetDto>>> GetTypesDepartment()
    {
        return await _mapper.ProjectTo<TypeDepartmentGetDto>(_context.TypesDepartment).ToListAsync();
    }
    /// <summary>
    /// Return info about type by id
    /// </summary>
    /// <param name="id"> TypeDepartment's id </param>
    /// <returns> TypeDepartment by id </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TypeDepartmentGetDto>> GetTypeDepartment(int id)
    {
        var typeDepartment = await _context.TypesDepartment.FindAsync(id);

        if (typeDepartment == null)
        {
            return NotFound();
        }

        return _mapper.Map<TypeDepartmentGetDto>(typeDepartment);
    }
}