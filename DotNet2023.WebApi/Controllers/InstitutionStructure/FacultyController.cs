using AutoMapper;
using DotNet2023.Domain.InstitutionStructure;
using DotNet2023.WebApi.Interfaces.InstitutionStructure;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.InstitutionStructure;

[Route("api/[controller]")]
[ApiController]
public class FacultyController : Controller
{
    private readonly IFaculty _repository;
    private readonly IMapper _mapper;

    public FacultyController(IFaculty repository,
        IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);

    [HttpGet]
    public IActionResult GetFaculties()
    {
        var institutions = _mapper
            .Map<List<Faculty>>
            (_repository.GetFaculties());
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(institutions);
    }

    [HttpGet("GetFaculty")]
    public IActionResult GetFaculty(string idFaculty)
    {
        var institution = _mapper
            .Map<Faculty>
            (_repository.GetFacultyById(idFaculty));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(institution);
    }


    [HttpPost("CreateFaculty")]
    public IActionResult CreateFaculty(
    [FromBody] Faculty faculty)
    {
        if (faculty == null)
            return BadRequest(ModelState);

        var facultyMap = _mapper
            .Map<Faculty>(faculty);

        if (!_repository.CreateFaculty(facultyMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }

    [HttpDelete("DeleteFaculty")]
    public IActionResult DeleteFaculty(string idFaculty)
    {
        if (!_repository.FacultytExistsById(idFaculty))
            return NotFound();

        var facultyToDelete = _repository
            .GetFacultyById(idFaculty);

        if (!ModelState.IsValid || facultyToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteFaculty(facultyToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }


    [HttpPut("UpdateFaculty")]
    public IActionResult UpdateInstitution(
        [FromBody] Faculty faculty)
    {
        if (faculty == null)
            return BadRequest(ModelState);

        if (!_repository.FacultytExistsById(faculty.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var facultyToUpdate = _mapper.Map<Faculty>(faculty);
        if (!_repository.UpdateFaculty(facultyToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
}
