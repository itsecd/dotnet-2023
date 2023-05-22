using AutoMapper;
using DotNet2023.Domain.InstitutionStructure;
using DotNet2023.WebApi.DtoModels.InstitutionStructure;
using DotNet2023.WebApi.Interfaces.InstitutionStructure;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.InstitutionStructure;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : Controller
{
    private readonly IDepartment _repository;
    private readonly IMapper _mapper;
    public readonly ILogger<Department> _logger;

    public DepartmentController(IDepartment repository,
        IMapper mapper, ILogger<Department> logger) =>
        (_repository, _mapper, _logger) = (repository, mapper, logger);

    /// <summary>
    /// Get all departments
    /// </summary>
    /// <returns>IActionResult with List<DepartmentDto></returns>
    [HttpGet]
    public IEnumerable<DepartmentDto> GetDepartments() =>
        _mapper
            .Map<List<DepartmentDto>>
            (_repository.GetDepartments());

    /// <summary>
    /// Async Get all departments
    /// </summary>
    /// <returns>IActionResult with List<DepartmentDto></returns>
    [HttpGet("GetDepartmentsAsync")]
    public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync() =>
        _mapper
            .Map<List<DepartmentDto>>
            (await _repository.GetDepartmentsAsync());

    /// <summary>
    /// Get department by id
    /// </summary>
    /// <param name="idDepartment">id department</param>
    /// <returns>IActionResult with DepartmentDto</returns>
    [HttpGet("GetDepartment")]
    public DepartmentDto GetDepartment(string idDepartment) =>
        _mapper
            .Map<DepartmentDto>
            (_repository.GetDepartmentById(idDepartment));
    /// <summary>
    /// Async Get department by id
    /// </summary>
    /// <param name="idDepartment">id department</param>
    /// <returns>IActionResult with DepartmentDto</returns>
    [HttpGet("GetDepartmentAsync")]
    public async Task<DepartmentDto> GetDepartmentAsync(string idDepartment) =>
        _mapper
            .Map<DepartmentDto>
            (await _repository.GetDepartmentByIdAsync(idDepartment));

    /// <summary>
    /// Create a new Department
    /// </summary>
    /// <param name="department">new department</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPost("CreateDepartment")]
    public IActionResult CreateDepartment(
    [FromBody] DepartmentDto department)
    {
        if (department == null)
            return BadRequest(ModelState);

        var departmentMap = _mapper
            .Map<Department>(department);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!_repository.CreateDepartment(departmentMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }
    /// <summary>
    /// Async Create a new Department
    /// </summary>
    /// <param name="department">new department</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPost("CreateDepartmentAsync")]
    public async Task<IActionResult> CreateDepartmentAsync(
    [FromBody] DepartmentDto department)
    {
        if (department == null)
            return BadRequest(ModelState);

        var departmentMap = _mapper
            .Map<Department>(department);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!await _repository.CreateDepartmentAsync(departmentMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }

    /// <summary>
    /// Delete a Department
    /// </summary>
    /// <param name="idDepartment">id department</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpDelete("DeleteDepartment")]
    public IActionResult DeleteDepartment(string idDepartment)
    {
        if (!_repository.DepartmentExistsById(idDepartment))
            return NotFound();
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        var departmentToDelete = _repository
            .GetDepartmentById(idDepartment);

        if (!ModelState.IsValid || departmentToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteDepartment(departmentToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }
    /// <summary>
    /// Delete a Department
    /// </summary>
    /// <param name="idDepartment">id department</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpDelete("DeleteDepartmentAsync")]
    public async Task<IActionResult> DeleteDepartmentAsync(string idDepartment)
    {
        if (!await _repository.DepartmentExistsByIdAsync(idDepartment))
            return NotFound();
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        var departmentToDelete = await _repository
            .GetDepartmentByIdAsync(idDepartment);

        if (!ModelState.IsValid || departmentToDelete == null)
            return BadRequest(ModelState);

        if (!await _repository.DeleteDepartmentAsync(departmentToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }

    /// <summary>
    /// Update a Department
    /// </summary>
    /// <param name="department">update department</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPut("UpdateDepartment")]
    public IActionResult UpdateDepartment(
        [FromBody] DepartmentDto department)
    {
        if (department == null)
            return BadRequest(ModelState);

        if (!_repository.DepartmentExistsById(department.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var departmentToUpdate = _mapper.Map<Department>(department);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!_repository.UpdateDepartment(departmentToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully updated");
    }
    /// <summary>
    /// Async Update a Department
    /// </summary>
    /// <param name="department">update department</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPut("UpdateDepartmentAsync")]
    public async Task<IActionResult> UpdateDepartmentAsync(
        [FromBody] DepartmentDto department)
    {
        if (department == null)
            return BadRequest(ModelState);

        if (!await _repository.DepartmentExistsByIdAsync(department.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var departmentToUpdate = _mapper.Map<Department>(department);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!await _repository.UpdateDepartmentAsync(departmentToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully updated");
    }
}
