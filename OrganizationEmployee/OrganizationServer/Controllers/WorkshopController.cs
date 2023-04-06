using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizationEmployee.EmployeeDomain;
using OrganizationEmployee.Server.Dto;
using OrganizationEmployee.Server.Repository;

namespace OrganizationEmployee.Server.Controllers;
/// <summary>
/// Controller for Workshop class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class WorkshopController : ControllerBase
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;
    /// <summary>
    /// A constructor of the WorkshopController
    /// </summary>
    public WorkshopController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// The method returns all the workshops in the organization
    /// </summary>
    /// <returns>All the workshops in the organization</returns>
    [HttpGet]
    public IEnumerable<WorkshopDto> Get()
    {
        return _mapper.Map<IEnumerable<WorkshopDto>>(_organizationRepository.Workshops);
    }
    /// <summary>
    /// The method returns an workshop by ID
    /// </summary>
    /// <param name="id">Workshop ID</param>
    /// <returns>Workshop with the given ID or 404 code if workshop is not found</returns>
    [HttpGet("{id}")]
    public ActionResult<WorkshopDto> Get(int id)
    {
        var workshop = _organizationRepository.Workshops.FirstOrDefault(workshop => workshop.Id == id);
        if (workshop == null) return NotFound();
        var mappedWorkshop = _mapper.Map<WorkshopDto>(workshop);
        return Ok(mappedWorkshop);
    }
    /// <summary>
    /// The method adds a new workshop into organization
    /// </summary>
    /// <param name="workshop">A new workshop that needs to be added</param>
    /// <returns>Code 200 with an added workshop</returns>
    [HttpPost]
    public ActionResult<WorkshopDto> Post([FromBody] WorkshopDto workshop)
    {
        var mappedWorkshop = _mapper.Map<Workshop>(workshop);
        _organizationRepository.Workshops.Add(mappedWorkshop);
        return Ok(workshop);
    }
    /// <summary>
    /// The method updates a workshop information by ID
    /// </summary>
    /// <param name="id">An ID of the workshop</param>
    /// <param name="newWorkshop">New information of the workshop</param>
    /// <returns>Code 200 and the updated workshop class if success; 
    /// 404 code if a workshop is not found;</returns>
    [HttpPut("{id}")]
    public ActionResult<WorkshopDto> Put(int id, [FromBody] WorkshopDto newWorkshop)
    {
        var workshop = _organizationRepository.Workshops.FirstOrDefault(workshop => workshop.Id == id);
        if (workshop == null) return NotFound();
        _organizationRepository.Workshops.Remove(workshop);
        var mappedWorkshop = _mapper.Map<Workshop>(newWorkshop);
        _organizationRepository.Workshops.Add(mappedWorkshop);
        return Ok(newWorkshop);
    }
    /// <summary>
    /// The method deletes a workshop by ID
    /// </summary>
    /// <param name="id">An ID of the workshop</param>
    /// <returns>Code 200 if operation is successful, code 404 overwise</returns>
    [HttpDelete("{id}")]
    public ActionResult<WorkshopDto> Delete(int id)
    {
        var workshop = _organizationRepository.Workshops.FirstOrDefault(workshop => workshop.Id == id);
        if (workshop == null) return NotFound();
        _organizationRepository.Workshops.Remove(workshop);
        return Ok();
    }
}
