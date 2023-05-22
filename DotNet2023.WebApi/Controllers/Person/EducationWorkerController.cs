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
    public IEnumerable<EducationWorkerDto> GetEducationWorkers() =>
        _mapper
            .Map<List<EducationWorkerDto>>
            (_repository.GetEducationWorkers());
    /// <summary>
    /// Async Get all EducationWorker
    /// </summary>
    /// <returns>IActionResult with List<EducationWorkerDto></returns>
    [HttpGet("GetEducationWorkersAsync")]
    public async Task<IEnumerable<EducationWorkerDto>> GetEducationWorkersAsync() =>
        _mapper
            .Map<List<EducationWorkerDto>>
            (await _repository.GetEducationWorkersAsync());

    /// <summary>
    /// Get EducationWorker by id
    /// </summary>
    /// <param name="idEducationWorker">id EducationWorker</param>
    /// <returns>IActionResult with EducationWorkerDto</returns>
    [HttpGet("GetEducationWorker")]
    public EducationWorkerDto GetEducationWorker(string idEducationWorker) =>
        _mapper
            .Map<EducationWorkerDto>
            (_repository.GetEducationWorkerById(idEducationWorker));


    /// <summary>
    /// Async Get EducationWorker by id
    /// </summary>
    /// <param name="idEducationWorker">id EducationWorker</param>
    /// <returns>IActionResult with EducationWorkerDto</returns>
    [HttpGet("GetEducationWorkerAsync")]
    public async Task<EducationWorkerDto> GetEducationWorkerAsync(string idEducationWorker) =>
         _mapper
            .Map<EducationWorkerDto>
            (await _repository.GetEducationWorkerByIdAsync(idEducationWorker));

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
    /// Async Create a new educationWorker
    /// </summary>
    /// <param name="educationWorker">new educationWorker</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPost("CreateEducationWorkerAsync")]
    public async Task<IActionResult> CreateEducationWorkerAsync(
    [FromBody] EducationWorkerDto educationWorker)
    {
        if (educationWorker == null)
            return BadRequest(ModelState);

        var educationWorkerMap = _mapper
            .Map<EducationWorker>(educationWorker);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!await _repository.CreateEducationWorkerAsync(educationWorkerMap))
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
    /// Async Delete by id EducationWorker
    /// </summary>
    /// <param name="idEducationWorker">id EducationWorker</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpDelete("DeleteEducationWorkerAsync")]
    public async Task<IActionResult> DeleteEducationWorkerAsync(string idEducationWorker)
    {
        if (!await _repository.EducationWorkerExistsByIdAsync(idEducationWorker))
            return NotFound();

        var educationWorkerToDelete = await _repository
            .GetEducationWorkerByIdAsync(idEducationWorker);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!ModelState.IsValid || educationWorkerToDelete == null)
            return BadRequest(ModelState);

        if (!await _repository.DeleteEducationWorkerAsync(educationWorkerToDelete))
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
    /// <summary>
    /// Async Update model
    /// </summary>
    /// <param name="educationWorker">model that is updated</param>
    /// <returns>Ok :) or Not Ok :(</returns>
    [HttpPut("UpdateEducationWorkerAsync")]
    public async Task<IActionResult> UpdateEducationWorkerAsync(
        [FromBody] EducationWorkerDto educationWorker)
    {
        if (educationWorker == null)
            return BadRequest(ModelState);

        if (!await _repository.EducationWorkerExistsByIdAsync(educationWorker.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var educationWorkerToUpdate = _mapper.Map<EducationWorker>(educationWorker);
        _logger.LogInformation($"ModelState {ModelState}, method CreateInstituteSpeciality");

        if (!await _repository.UpdateEducationWorkerAsync(educationWorkerToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
}
