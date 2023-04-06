using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizationEmployee.EmployeeDomain;
using OrganizationEmployee.Server.Dto;
using OrganizationEmployee.Server.Repository;

namespace OrganizationEmployee.Server.Controllers;
/// <summary>
/// Controller for Occupation class
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class OccupationController : Controller
{
    private OrganizationRepository _organizationRepository;
    private IMapper _mapper;
    /// <summary>
    /// A constructor of the OccupationController
    /// </summary>
    public OccupationController(OrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }
    /// <summary>
    /// The method returns all the occupations in the organization
    /// </summary>
    /// <returns>All the occupations in the organization</returns>
    [HttpGet]
    public IEnumerable<OccupationDto> Get()
    {
        return _mapper.Map<IEnumerable<OccupationDto>>(_organizationRepository.Occupations);
    }
    /// <summary>
    /// The method returns an occupation by ID
    /// </summary>
    /// <param name="id">Occupation ID</param>
    /// <returns>Occupation with the given ID or 404 code if occupation is not found</returns>
    [HttpGet("{id}")]
    public ActionResult<OccupationDto> Get(int id)
    {
        var occupation = _organizationRepository.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null) return NotFound();
        var mappedOccupation = _mapper.Map<OccupationDto>(occupation);
        return Ok(mappedOccupation);
    }
    /// <summary>
    /// The method adds a new occupation into organization
    /// </summary>
    /// <param name="occupation">A new occupation that needs to be added</param>
    /// <returns>Code 200 with an added occupation</returns>
    [HttpPost]
    public ActionResult<OccupationDto> Post([FromBody] OccupationDto occupation)
    {
        var mappedOccupation = _mapper.Map<Occupation>(occupation);
        _organizationRepository.Occupations.Add(mappedOccupation);
        return Ok(occupation);
    }
    /// <summary>
    /// The method updates an occupation information by ID
    /// </summary>
    /// <param name="id">An ID of the occupation</param>
    /// <param name="newDepartment">New information of the occupation</param>
    /// <returns>Code 200 and the updated occupation class if success; 
    /// 404 code if an occupation is not found;</returns>
    [HttpPut("{id}")]
    public ActionResult<OccupationDto> Put(int id, [FromBody] OccupationDto newDepartment)
    {
        var occupation = _organizationRepository.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null) return NotFound();
        _organizationRepository.Occupations.Remove(occupation);
        var mappedOccupation = _mapper.Map<Occupation>(occupation);
        _organizationRepository.Occupations.Add(mappedOccupation);
        return Ok(newDepartment);
    }
    /// <summary>
    /// The method deletes an occupation by ID
    /// </summary>
    /// <param name="id">An ID of the occupation</param>
    /// <returns>Code 200 if operation is successful, code 404 overwise</returns>
    [HttpDelete("{id}")]
    public ActionResult<OccupationDto> Delete(int id)
    {
        var occupation = _organizationRepository.Occupations.FirstOrDefault(occupation => occupation.Id == id);
        if (occupation == null) return NotFound();
        _organizationRepository.Occupations.Remove(occupation);
        return Ok();
    }
}
