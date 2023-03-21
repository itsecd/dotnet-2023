using AutoMapper;
using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.WebApi.Interfaces.InstituteDocumentation;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.InstituteDocumentation;

[Route("api/[controller]")]
[ApiController]
public class SpecialityController : Controller
{
    private readonly ISpeciality _repository;
    private readonly IMapper _mapper;

    public SpecialityController(ISpeciality Repository,
        IMapper mapper) =>
        (_repository, _mapper) = (Repository, mapper);


    [HttpGet]
    public IActionResult GetSpecialities()
    {
        var specialities = _mapper
            .Map<List<Speciality>>
            (_repository.GetSpecialities());
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(specialities);
    }


    [HttpGet("GetSpeciality")]
    public IActionResult GetSpeciality(string code)
    {
        var speciality = _mapper
            .Map<Speciality>
            (_repository.GetSpeciality(code));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(speciality);
    }

    [HttpPost("CreateSpeciality")]
    public IActionResult CreateSpeciality(
        [FromBody] Speciality speciality)
    {
        if (speciality == null)
            return BadRequest(ModelState);

        var specialityMap = _mapper
            .Map<Speciality>(speciality);

        if (!_repository.CreateSpeciality(specialityMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }

    [HttpDelete("DeleteSpeciality")]
    public IActionResult DeleteSpeciality(string code)
    {
        if (!_repository.SpecialityExists(code))
            return NotFound();

        var institutionToDelete = _repository
            .GetSpeciality(code);

        if (!ModelState.IsValid || institutionToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteSpeciality(institutionToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }


    [HttpPut("UpdateSpeciality")]
    public IActionResult UpdateSpeciality(
        [FromBody] Speciality speciality)
    {
        if (speciality == null)
            return BadRequest(ModelState);

        if (!_repository.SpecialityExists(speciality.Code))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var specialityToUpdate = _mapper.Map<Speciality>(speciality);
        if (!_repository.UpdateSpeciality(specialityToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
}
