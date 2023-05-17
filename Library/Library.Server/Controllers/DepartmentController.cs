using AutoMapper;
using Library.Domain;
using Library.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Server.Controllers;
/// <summary>
/// Department controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly LibraryDbContext _context;
    /// <summary>
    /// Used to store map's object
    /// </summary>
    private readonly IMapper _mapper;
    /// <summary>
    /// Department controller's constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="mapper"></param>
    public DepartmentController(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    /// <summary>
    /// Return list of all departments
    /// </summary>
    /// <returns> List of all departments </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentGetDto>>> GetDepartments()
    {
        return await _mapper.ProjectTo<DepartmentGetDto>(_context.Departments).ToListAsync();
    }
    /// <summary>
    /// Return info about department by id
    /// </summary>
    /// <param name="id"> Department's id </param>
    /// <returns> Department by id </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentGetDto>> GetDepartment(int id)
    {
        var department = await _context.Departments.FindAsync(id);

        if (department == null)
        {
            return NotFound();
        }

        return _mapper.Map<DepartmentGetDto>(department);
    }
    /// <summary>
    /// Add a new department
    /// </summary>
    /// <param name="department"> New departments object </param>
    /// <returns> Inserted department </returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<DepartmentGetDto>> PostDepartment(DepartmentPostDto department)
    {
        var mappedDepartment = _mapper.Map<Department>(department);

        _context.Departments.Add(mappedDepartment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostDepartment", new { id = mappedDepartment.Id }, _mapper.Map<DepartmentGetDto>(mappedDepartment));
    }
    /// <summary>
    /// Сhange info of selected department
    /// </summary>
    /// <param name="id"> Department's id </param>
    /// <param name="department"> New departments object </param>
    /// <returns> NoContent </returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDepartment(int id, DepartmentPostDto department)
    {
        var departmentToModify = await _context.Departments.FindAsync(id);
        if (departmentToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(department, departmentToModify);

        await _context.SaveChangesAsync();

        return NoContent();
    }
    /// <summary>
    /// Delete department by id
    /// </summary>
    /// <param name="id"> Department's id </param>
    /// <returns> NoContent </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department == null)
        {
            return NotFound();
        }

        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}