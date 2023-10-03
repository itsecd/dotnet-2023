using AutoMapper;
using Company.Domain;
using Company.Server.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Server.Controllers;

/// <summary>
/// Controller for Department of Company
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<DepartmentController> _logger;
    private readonly CompanyDbContext _context;


    /// <summary>
    /// A constructor of the DepartmentController
    /// </summary>
    public DepartmentController(IMapper mapper, ILogger<DepartmentController> logger, CompanyDbContext context)
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }


    /// <summary>
    /// Method returns all Departments in the Company
    /// </summary>
    /// <returns>All Departments in the Company</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentGetDto>>> GetDepartments()
    {
        if (_context.DepartmentDb == null)
        {
            _logger.LogInformation("Departments database is empty");
            return NotFound();
        }
        return await _mapper.ProjectTo<DepartmentGetDto>(_context.DepartmentDb).ToListAsync();
    }


    /// <summary>
    /// Method returns Department by id
    /// </summary>
    /// <param name="id">Id of Department</param>
    /// <returns>Department with the given id, if operation is successful, code 404 otherwise</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentGetDto>> GetDepartment(int id)
    {
        if (_context.DepartmentDb == null)
        {
            _logger.LogInformation("Departments database is empty");
            return NotFound();
        }
        var department = await _context.DepartmentDb.FindAsync(id);
        if (department == null)
        {
            _logger.LogInformation("The Department with Id {id} is not found", id);
            return NotFound();
        }
        return _mapper.Map<DepartmentGetDto>(department);
    }


    /// <summary>
    /// Method updates Department information by id
    /// </summary>
    /// <param name="id">Id of Department</param>
    /// <param name="department">New information about Department</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDepartment(int id, DepartmentPostDto department)
    {
        if (_context.DepartmentDb == null)
        {
            _logger.LogInformation("Departments database is empty");
            return NotFound();
        }
        var departmentToModify = await _context.DepartmentDb.FindAsync(id);
        if (departmentToModify == null)
        {
            _logger.LogInformation("The Department with Id {id} is not found", id);
            return NotFound();
        }

        _mapper.Map(department, departmentToModify);
        await _context.SaveChangesAsync();

        return Ok();
    }


    /// <summary>
    /// Method adds Department in Company
    /// </summary>
    /// <param name="department">New Department</param>
    /// <returns>Added Department and code 201, if operation is successful, code 404 otherwise</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<DepartmentGetDto>> PostDepartment(DepartmentPostDto department)
    {
        if (_context.DepartmentDb == null)
        {
            _logger.LogInformation("Departments database is empty");
            return NotFound();
        }
        var mappedDepartment = _mapper.Map<Department>(department);

        _context.DepartmentDb.Add(mappedDepartment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("PostDepartment", new { id = mappedDepartment.Id }, _mapper.Map<DepartmentGetDto>(mappedDepartment));
    }


    /// <summary>
    /// Method deletes Department by id
    /// </summary>
    /// <param name="id">Id of Department</param>
    /// <returns>Code 200, if operation is successful, code 404 otherwise</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        if (_context.DepartmentDb == null)
        {
            _logger.LogInformation("Departments database is empty");
            return NotFound();
        }
        var department = await _context.DepartmentDb.FindAsync(id);
        if (department == null)
        {
            _logger.LogInformation("The Department with Id {id} is not found", id);
            return NotFound();
        }

        _context.DepartmentDb.Remove(department);
        await _context.SaveChangesAsync();

        return Ok();
    }
}