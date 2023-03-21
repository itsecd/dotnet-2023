using AutoMapper;
using DotNet2023.Domain.Organization;
using DotNet2023.WebApi.DtoModels.Organization;
using DotNet2023.WebApi.Interfaces.Organization;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.Organization;

[Route("api/[controller]")]
[ApiController]
public class InstitutionController : Controller
{
    private readonly IHigherEducationInstitution _institutionRepository;
    private readonly IMapper _mapper;

    public InstitutionController(IHigherEducationInstitution institutionRepository,
        IMapper mapper) =>
        (_institutionRepository, _mapper) = (institutionRepository, mapper);


    [HttpGet]
    public IActionResult GetInstitutions()
    {
        var institutions = _mapper
            .Map<List<HigherEducationInstitutionDto>>
            (_institutionRepository.GetInstitutions());
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(institutions);
    }

    [HttpGet("GetInstitution")]
    public IActionResult GetInstitution(string idInstitution)
    {
        var institution = _mapper
            .Map<HigherEducationInstitutionDto>
            (_institutionRepository.GetInstitution(idInstitution));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(institution);

    }


    [HttpGet("GetInstitutionAsync")]
    public async Task<IActionResult>? GetInstitutionAsync(
        string idInstitution)
    {
        var institution = await _institutionRepository
            .GetInstitutionAsync(idInstitution);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(_mapper.Map<HigherEducationInstitutionDto>(institution));
     }


    [HttpPost("CreateInstructon")]
    public IActionResult CreateInstitution(
        [FromBody] HigherEducationInstitutionDto institution)
    {
        if (institution == null)
            return BadRequest(ModelState);

        var institutionMap = _mapper
            .Map<HigherEducationInstitution>(institution);
        
        if (!_institutionRepository.CreateInstructon(institutionMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }

    [HttpDelete("DeleteInstructon")]
    public IActionResult DeleteInstitution(string idInstitution)
    {
        if (!_institutionRepository.InstitutionExists(idInstitution))
            return NotFound();
        
        var institutionToDelete = _institutionRepository
            .GetInstitution(idInstitution);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_institutionRepository.DeleteInstructon(institutionToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");
        
        return Ok("Successfully deleted");
    }


    [HttpPut("UpdateInstitution")]
    public IActionResult UpdateInstitution(
        [FromBody] HigherEducationInstitutionDto institution)
    {
        if (institution == null)
            return BadRequest(ModelState);

        if (!_institutionRepository.InstitutionExists(institution.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var institutionToUpdate = _mapper.Map<HigherEducationInstitution>(institution);
        if (!_institutionRepository.UpdateInstructon(institutionToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
}
