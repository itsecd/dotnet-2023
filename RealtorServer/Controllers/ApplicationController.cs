using Microsoft.AspNetCore.Mvc;
using Realtor;
using RealtorServer.Dto;
using RealtorServer.Repository;
using AutoMapper;

namespace RealtorServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ApplicationController : ControllerBase
{
    private readonly ILogger<ApplicationController> _logger;
    private readonly IRealtorRepository _realtorRepository;
    private readonly IMapper _mapper;
    public ApplicationController (ILogger<ApplicationController> logger, IRealtorRepository realtorRepository, IMapper mapper)
    {
        _logger = logger;
        _realtorRepository = realtorRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IEnumerable<ApplicationGetDto> Get()
    {
        _logger.LogInformation("Get applications");
        return _realtorRepository.Applications.Select(application => _mapper.Map<ApplicationGetDto>(application));
    }

    
    [HttpGet("{id}")]
    public ActionResult<Application> Get(int id)
    {
        var application= _realtorRepository.Applications.FirstOrDefault(Application => Application.Id == id);
        if (application == null)
        {
            _logger.LogInformation("Not found application with id {id}",id);
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<ApplicationGetDto>(application));
        }
    }

    
    [HttpPost]
    public void Post([FromBody] ApplicationPostDto application)
    {
        _realtorRepository.Applications.Add(_mapper.Map<Application>(application));

    }

    
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ApplicationPostDto applicationToPut)
    {
        var application = _realtorRepository.Applications.FirstOrDefault(Application => Application.Id == id);
        if (application == null)
        {
            _logger.LogInformation("Not found application with id {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(applicationToPut, application);
            return Ok();
        }
    }

    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var application = _realtorRepository.Applications.FirstOrDefault(Application => Application.Id == id);
        if (application == null)
        {
            _logger.LogInformation("Not found application with id {id}", id);
            return NotFound();
        }
        else
        {
            _realtorRepository.Applications.Remove(application);
            return Ok();
        }
    }
}
