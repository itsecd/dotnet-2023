using AutoMapper;
using DotNet2023.Domain.Person;
using DotNet2023.WebApi.DtoModels.Person;
using DotNet2023.WebApi.Interfaces.Person;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.Person;

[Route("api/[controller]")]
[ApiController]
public class EducationWorkerController : Controller
{
    private readonly IEducationWorker _repository;
    private readonly IMapper _mapper;
    public readonly ILogger<EducationWorker> _logger;

    public EducationWorkerController(IEducationWorker repository,
        IMapper mapper, ILogger<EducationWorker> logger) =>
        (_repository, _mapper, _logger) = (repository, mapper, logger);

    /// <summary>
    /// get all EducationWorker
    /// </summary>
    /// <returns>IActionResult with List<EducationWorkerDto></returns>
    [HttpGet]
    public IActionResult GetEducationWorkers()
    {
        var educationWorker = _mapper
            .Map<List<EducationWorkerDto>>
            (_repository.GetEducationWorkers());
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(educationWorker);
    }

    /// <summary>
    /// Get EducationWorker by id
    /// </summary>
    /// <param name="idEducationWorker">id EducationWorker</param>
    /// <returns>IActionResult with EducationWorkerDto</returns>
    [HttpGet("GetEducationWorker")]
    public IActionResult GetEducationWorker(string idEducationWorker)
    {
        var educationWorker = _mapper
            .Map<EducationWorkerDto>
            (_repository.GetEducationWorkerById(idEducationWorker));
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(educationWorker);
    }

    /// <summary>
    /// Create a new educationWorker
    /// </summary>
    /// <param name="educationWorker">new educationWorker</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPost("CreateEducationWorker")]
    public IActionResult CreateEducationWorker(
    [FromBody] EducationWorkerDto educationWorker)
    {
        if (educationWorker == null)
            return BadRequest(ModelState);

        var educationWorkerMap = _mapper
            .Map<EducationWorker>(educationWorker);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!_repository.CreateEducationWorker(educationWorkerMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }

    /// <summary>
    /// Delete by id EducationWorker
    /// </summary>
    /// <param name="idEducationWorker">id EducationWorker</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpDelete("DeleteEducationWorker")]
    public IActionResult DeleteEducationWorker(string idEducationWorker)
    {
        if (!_repository.EducationWorkerExistsById(idEducationWorker))
            return NotFound();

        var educationWorkerToDelete = _repository
            .GetEducationWorkerById(idEducationWorker);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!ModelState.IsValid || educationWorkerToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteEducationWorker(educationWorkerToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }

    /// <summary>
    /// Update model
    /// </summary>
    /// <param name="educationWorker">model that is updated</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPut("UpdateEducationWorker")]
    public IActionResult UpdateEducationWorker(
        [FromBody] EducationWorkerDto educationWorker)
    {
        if (educationWorker == null)
            return BadRequest(ModelState);

        if (!_repository.EducationWorkerExistsById(educationWorker.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var educationWorkerToUpdate = _mapper.Map<EducationWorker>(educationWorker);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!_repository.UpdateEducationWorker(educationWorkerToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
}
