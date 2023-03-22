using AutoMapper;
using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.WebApi.Interfaces.InstituteDocumentation;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.InstituteDocumentation;

[Route("api/[controller]")]
[ApiController]
public class InstituteSpecialityController : Controller
{
    private readonly IInstituteSpeciality _repository;
    private readonly IMapper _mapper;

    public InstituteSpecialityController(IInstituteSpeciality Repository,
        IMapper mapper) =>
        (_repository, _mapper) = (Repository, mapper);

    [HttpGet]
    public IActionResult GetInstituteSpecialities()
    {
        var instituteSpecialities = _mapper
            .Map<List<InstituteSpeciality>>
            (_repository.GetInstituteSpecialities());
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(instituteSpecialities);
    }

    [HttpGet("GetInstituteSpecialitiesByCode")]
    public IActionResult GetInstituteSpecialitiesByCode(string code)
    {
        var instituteSpecialit = _mapper
            .Map<InstituteSpeciality>
            (_repository.GetInstituteSpecialitiesByCode(code));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(instituteSpecialit);
    }

    [HttpGet("GetInstituteSpecialitiesByInstitution")]
    public IActionResult GetInstituteSpecialitiesByInstitution(string idInstitution)
    {
        var instituteSpecialit = _mapper
            .Map<InstituteSpeciality>
            (_repository.GetInstituteSpecialitiesByInstitution(idInstitution));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(instituteSpecialit);
    }

    [HttpGet("GetInstituteSpeciality")]
    public IActionResult GetInstituteSpeciality(string code, string idInstitution)
    {
        var instituteSpeciality = _mapper
            .Map<InstituteSpeciality>
            (_repository.GetInstituteSpeciality(code, idInstitution));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(instituteSpeciality);
    }

    [HttpPost("CreateInstituteSpeciality")]
    public IActionResult CreateInstituteSpeciality(
    [FromBody] InstituteSpeciality instituteSpeciality)
    {
        if (instituteSpeciality == null)
            return BadRequest(ModelState);

        var instituteSpecialityMap = _mapper
            .Map<InstituteSpeciality>(instituteSpeciality);

        if (!_repository.CreateInstituteSpeciality(instituteSpecialityMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }

    [HttpDelete("DeleteInstituteSpeciality")]
    public IActionResult DeleteInstituteSpeciality(string code, string idInstitution)
    {
        if (!_repository.InstituteSpecialityExistsByCode(idInstitution))
            return NotFound();

        var instituteSpecialityToDelete = _repository
            .GetInstituteSpeciality(code, idInstitution);

        if (!ModelState.IsValid || instituteSpecialityToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteInstituteSpeciality(instituteSpecialityToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }

    [HttpPut("UpdateInstituteSpeciality")]
    public IActionResult UpdateInstituteSpeciality(
    [FromBody] InstituteSpeciality instituteSpeciality)
    {
        if (instituteSpeciality == null)
            return BadRequest(ModelState);

        if (!_repository.InstituteSpecialityExists(
            instituteSpeciality!.IdSpeciality,
            instituteSpeciality!.IdHigherEducationInstitution))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var institutionToUpdate = _mapper.Map<InstituteSpeciality>(instituteSpeciality);
        if (!_repository.UpdateInstituteSpeciality(institutionToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
}
