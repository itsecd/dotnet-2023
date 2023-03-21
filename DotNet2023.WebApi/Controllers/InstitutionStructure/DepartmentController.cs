using AutoMapper;
using DotNet2023.Domain.InstitutionStructure;
using DotNet2023.WebApi.Interfaces.InstitutionStructure;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.InstitutionStructure;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : Controller
{
    private readonly IDepartment _repository;
    private readonly IMapper _mapper;

    public DepartmentController(IDepartment repository,
        IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);


    [HttpGet]
    public IActionResult GetDepartments()
    {
        var institutions = _mapper
            .Map<List<Department>>
            (_repository.GetDepartments());
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(institutions);
    }

    [HttpGet("GetDepartment")]
    public IActionResult GetDepartment(string idDepartment)
    {
        var institution = _mapper
            .Map<Department>
            (_repository.GetDepartmentById(idDepartment));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(institution);
    }


    [HttpPost("CreateDepartment")]
    public IActionResult CreateDepartment(
    [FromBody] Department department)
    {
        if (department == null)
            return BadRequest(ModelState);

        var departmentMap = _mapper
            .Map<Department>(department);

        if (!_repository.CreateDepartment(departmentMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }

    [HttpDelete("DeleteDepartment")]
    public IActionResult DeleteDepartment(string idDepartment)
    {
        if (!_repository.DepartmentExistsById(idDepartment))
            return NotFound();

        var departmentToDelete = _repository
            .GetDepartmentById(idDepartment);

        if (!ModelState.IsValid || departmentToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteDepartment(departmentToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }


    [HttpPut("UpdateDepartment")]
    public IActionResult UpdateDepartment(
        [FromBody] Department department)
    {
        if (department == null)
            return BadRequest(ModelState);

        if (!_repository.DepartmentExistsById(department.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var departmentToUpdate = _mapper.Map<Department>(department);
        if (!_repository.UpdateDepartment(departmentToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
}
