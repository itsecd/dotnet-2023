using Microsoft.AspNetCore.Mvc;
using Policlinic;
using PoliclinicServer.Repository;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PoliclinicServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SpecializationController : ControllerBase
{
    private readonly ILogger<SpecializationController> _logger;

    private readonly IPoliclinicRepository _policlinicRepository;

    public SpecializationController(ILogger<SpecializationController> logger, IPoliclinicRepository policlinicRepository)
    {
        _logger = logger;
        _policlinicRepository = policlinicRepository;
    }

    [HttpGet]
    public IEnumerable<Specialization> Get()
    {
        _logger.LogInformation("Get specializations");
        return _policlinicRepository.Specializations;
    }

    // GET api/<SpecializationController>/5
    [HttpGet("{id}")]
    public ActionResult<Specialization> Get(int id)
    {
        //_logger.LogInformation($"Get specialization with id {id}");
        var specialization = _policlinicRepository.Specializations.FirstOrDefault(specialization => specialization.Id == id);
        if (specialization == null)
        {
            _logger.LogInformation($"Not found specializaion with id = {id}");
            return NotFound();
        }
        else
        {
            _logger.LogInformation($"Get specialization with id {id}");
            return Ok(specialization);
        }
        //_logger.LogInformation($"Get specialization with id {id}");
        //return _policlinicRepository.CreateDefaultSpecializations.FirstOrDefault(specialization => specialization.Id == id);
    }

    //// POST api/<SpecializationController>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/<SpecializationController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<SpecializationController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}
