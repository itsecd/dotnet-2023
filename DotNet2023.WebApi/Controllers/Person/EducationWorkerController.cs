using AutoMapper;
using DotNet2023.Domain.Person;
using DotNet2023.WebApi.Interfaces.Person;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.Person;

[Route("api/[controller]")]
[ApiController]
public class EducationWorkerController : Controller
{
    private readonly IEducationWorker _repository;
    private readonly IMapper _mapper;

    public EducationWorkerController(IEducationWorker repository,
        IMapper mapper) =>
        (_repository, _mapper) = (repository, mapper);

    [HttpGet]
    public IActionResult GetEducationWorkers()
    {
        var educationWorker = _mapper
            .Map<List<EducationWorker>>
            (_repository.GetEducationWorkers());
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(educationWorker);
    }

    [HttpGet("GetEducationWorker")]
    public IActionResult GetEducationWorker(string idEducationWorker)
    {
        var institution = _mapper
            .Map<EducationWorker>
            (_repository.GetEducationWorkerById(idEducationWorker));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(institution);
    }


    [HttpPost("CreateEducationWorker")]
    public IActionResult CreateEducationWorker(
    [FromBody] EducationWorker educationWorker)
    {
        if (educationWorker == null)
            return BadRequest(ModelState);

        var educationWorkerMap = _mapper
            .Map<EducationWorker>(educationWorker);

        if (!_repository.CreateEducationWorker(educationWorkerMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Successfully created");
    }

    [HttpDelete("DeleteEducationWorker")]
    public IActionResult DeleteEducationWorker(string idEducationWorker)
    {
        if (!_repository.EducationWorkerExistsById(idEducationWorker))
            return NotFound();

        var educationWorkerToDelete = _repository
            .GetEducationWorkerById(idEducationWorker);

        if (!ModelState.IsValid || educationWorkerToDelete == null)
            return BadRequest(ModelState);

        if (!_repository.DeleteEducationWorker(educationWorkerToDelete))
            ModelState.AddModelError("", "Something went wrong deleting institution");

        return Ok("Successfully deleted");
    }


    [HttpPut("UpdateEducationWorker")]
    public IActionResult UpdateEducationWorker(
        [FromBody] EducationWorker educationWorker)
    {
        if (educationWorker == null)
            return BadRequest(ModelState);

        if (!_repository.EducationWorkerExistsById(educationWorker.Id))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var educationWorkerToUpdate = _mapper.Map<EducationWorker>(educationWorker);
        if (!_repository.UpdateEducationWorker(educationWorkerToUpdate))
        {
            ModelState.AddModelError("", "Something went wrong updating institution");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully updated");
    }
}
