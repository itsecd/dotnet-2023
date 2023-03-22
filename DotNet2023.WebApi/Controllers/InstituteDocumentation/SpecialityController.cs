using AutoMapper;
using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.WebApi.DtoModels.InstituteDocumentation;
using DotNet2023.WebApi.Interfaces.InstituteDocumentation;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.InstituteDocumentation;

[Route("api/[controller]")]
[ApiController]
public class SpecialityController : Controller
{
    private readonly ISpeciality _repository;
    private readonly IMapper _mapper;
    public readonly ILogger<Speciality> _logger;

    public SpecialityController(ISpeciality repository,
        IMapper mapper, ILogger<Speciality> logger) =>
        (_repository, _mapper, _logger) = (repository, mapper, logger);

    /// <summary>
    /// Get all specialities
    /// </summary>
    /// <returns>IActionResult with SpecialityDto</returns>
    [HttpGet]
    public IActionResult GetSpecialities()
    {
        var specialities = _mapper
            .Map<List<SpecialityDto>>
            (_repository.GetSpecialities());
        _logger.LogInformation($"ModelState {ModelState}, method GetSpecialities");
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(specialities);
    }

    /// <summary>
    /// Get speciality by code
    /// </summary>
    /// <param name="code">id speciality</param>
    /// <returns>IActionResult with SpecialityDto</returns>
    [HttpGet("GetSpeciality")]
    public IActionResult GetSpeciality(string code)
    {
        var speciality = _mapper
            .Map<SpecialityDto>
            (_repository.GetSpeciality(code));
        _logger.LogInformation($"ModelState {ModelState}, method GetSpecialities");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(speciality);
    }

    /// <summary>
    /// create a new speciality
    /// </summary>
    /// <param name="speciality">new speciality</param>
    /// <returns>Ok :) or not Ok :(</returns>
    [HttpPost("CreateSpeciality")]
    public IActionResult CreateSpeciality(
        [FromBody] SpecialityDto speciality)
    {
        if (speciality == null)
            return BadRequest(ModelState);
        _logger.LogInformation($"ModelState {ModelState}, method GetSpecialities");

        var specialityMap = _mapper
            .Map<Speciality>(speciality);

        if (!_repository.CreateSpeciality(specialityMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }

    /// <summary>
    /// delete speciality by code
    /// </summary>
    /// <param name="code">id speciality</param>
    /// <returns>Ok :) or not Ok :(</returns>
    [HttpDelete("DeleteSpeciality")]
    public IActionResult DeleteSpeciality(string code)
    {
        if (!_repository.SpecialityExists(code))
            return NotFound();

        var institutionToDelete = _repository
            .GetSpeciality(code);
        _logger.LogInformation($"ModelState {ModelState}, method GetSpecialities");

        if (!ModelState.IsValid || institutionToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteSpeciality(institutionToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }

    /// <summary>
    /// update speciality
    /// </summary>
    /// <param name="speciality">update speciality</param>
    /// <returns>Ok :) or not Ok :(</returns>
    [HttpPut("UpdateSpeciality")]
    public IActionResult UpdateSpeciality(
        [FromBody] SpecialityDto speciality)
    {
        if (speciality == null)
            return BadRequest(ModelState);

        if (!_repository.SpecialityExists(speciality.Code))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var specialityToUpdate = _mapper.Map<Speciality>(speciality);

        _logger.LogInformation($"ModelState {ModelState}, method GetSpecialities");

        if (!_repository.UpdateSpeciality(specialityToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
}
