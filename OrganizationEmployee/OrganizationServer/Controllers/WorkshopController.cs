using AutoMapper;
using EmployeeDomain;
using Microsoft.AspNetCore.Mvc;
using OrganizationServer.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrganizationServer.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WorkshopController : ControllerBase
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;

    public WorkshopController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }


    // GET: api/<WorkshopController>
    [HttpGet]
    public IEnumerable<Workshop> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)  //здесь можно сделать page-nation, он принимает
                                                                                            //номер страницы и размер страницы (чтобы если у нас очень много данных - выводить их страницами)
    {
        return _organizationRepository.Workshops; // использовать Take() и Skip()
    }

    // GET api/<WorkshopController>/5
    [HttpGet("{id}")]
    public ActionResult<Workshop> Get(int id)
    {
        var workshop = _organizationRepository.Workshops.FirstOrDefault(workshop => workshop.Id == id);
        if (workshop == null) return NotFound();
        return Ok(workshop);
    }

    // POST api/<WorkshopController>
    [HttpPost]
    public void Post([FromBody] WorkshopDTO workshop)
    {
        var mappedWorkshop = _mapper.Map<Workshop>(workshop);
        _organizationRepository.Workshops.Add(mappedWorkshop);
    }

    // PUT api/<WorkshopController>/5
    [HttpPut("{id}")]
    public ActionResult<Workshop> Put(int id, [FromBody] WorkshopDTO newWorkshop)
    {
        var workshop = _organizationRepository.Workshops.FirstOrDefault(workshop => workshop.Id == id);
        if (workshop == null) return NotFound();
        _organizationRepository.Workshops.Remove(workshop);
        var mappedWorkshop = _mapper.Map<Workshop>(newWorkshop);
        _organizationRepository.Workshops.Add(mappedWorkshop);

        //или еще:
        //workshop.Id = newWorkshop.Id;
        // ...
        //В рамках ЛР2 без разницы, так как в ЛР3 все равно переделывать :)
        return Ok();
    }

    // DELETE api/<WorkshopController>/5
    [HttpDelete("{id}")]
    public ActionResult<Workshop> Delete(int id)
    {
        var workshop = _organizationRepository.Workshops.FirstOrDefault(workshop => workshop.Id == id);
        if (workshop == null) return NotFound();
        _organizationRepository.Workshops.Remove(workshop);
        return Ok();
    }
}
