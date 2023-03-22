using AutoMapper;
using DotNet2023.Domain.Organization;
using DotNet2023.Queries;
using DotNet2023.WebApi.DtoModels.InstituteDocumentation;
using DotNet2023.WebApi.DtoModels.Organization;
using DotNet2023.WebApi.Interfaces.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DotNet2023.WebApi.Controllers.Queries;

/// <summary>
/// Api Controller for Queries 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class QueriesController : Controller
{
    private readonly IQueries _repository;
    public readonly ILogger<QueriesToDomainModel> _logger;
    private readonly IMapper _mapper;


    public QueriesController(IQueries repository, ILogger<QueriesToDomainModel> logger, IMapper mapper) =>
        (_repository, _logger, _mapper) = (repository, logger, mapper);

    /// <summary>
    /// Get information about your chosen university by id
    /// </summary>
    /// <param name="id">Id of the institute for which want to get information</param>
    /// <returns>IActionResult with HigherEducationInstitutionDto</returns>
    [HttpGet("GetInstitutionById")]
    public IActionResult GetInstitutionById(string id)
    {
        var result = _mapper.Map<HigherEducationInstitutionDto>(_repository.GetInstitutionById(id));
        if (!ModelState.IsValid)
        {
            _logger.LogError($"Not found by id = {id}, method GetInstitutionById");
            return BadRequest(ModelState);
        }
        _logger.LogInformation($"Found by id = {id}");
        return Ok(result);
    }

    /// <summary>
    /// Get information about your chosen university by initials
    /// </summary>
    /// <param name="initials">Initials of the institute for which want to get information</param>
    /// <returns>IActionResult with HigherEducationInstitutionDto</returns>
    [HttpGet("GetInstitutionByInitials")]
    public IActionResult GetInstitutionByInitials(string initials)
    {
        var result = _mapper.Map<HigherEducationInstitutionDto>(
            _repository.GetInstitutionByInitials(initials));

        if (!ModelState.IsValid)
        {
            _logger.LogError($"Not found by initials {initials}, " +
                $"method GetInstitutionByInitials");
            return BadRequest(ModelState);
        }
        _logger.LogInformation($"Found by initials = {initials}");
        return Ok(result);
    }

    /// <summary>
    /// Get information about university in format: 
    /// Name, CountFaculties, CountDepartments and CountGroups
    /// </summary>
    /// <param name="institutionalProperty">InstitutionalProperty, value is 0 or 1</param>
    /// <param name="buildingProperty">BuildingProperty, value is 0, 1 or 2</param>
    /// <returns>IActionResult with ResponseUniversityStructByProperty</returns>
    [HttpGet("GetInstitutionStruct")]
    public IActionResult GetInstitutionStruct(
        InstitutionalProperty institutionalProperty,
        BuildingProperty buildingProperty)
    {
        var result = _repository
            .GetInstitutionStruct(institutionalProperty, buildingProperty);
        if (!ModelState.IsValid)
        {
            _logger.LogError($"Not found in GetInstitutionStruct, method GetInstitutionStruct");
            return BadRequest(ModelState);
        }
        _logger.LogInformation($"All okay, method GetInstitutionStruct");
        return Ok(result);
    }

    /// <summary>
    /// Get information about university in format: 
    /// Name, CountFaculties, CountDepartments and CountSpecialities
    /// </summary>
    /// <param name="initials">Initials of the institute for which want to get information</param>
    /// <returns></returns>
    [HttpGet("GetInstitutionStructByInitials")]
    public IActionResult GetInstitutionStructByInitials(string initials)
    {
        var result = _repository
            .GetInstitutionStructByInitials(initials);
        if (!ModelState.IsValid)
        {
            _logger.LogError($"Not found by initials {initials}, " +
                $"method GetInstitutionStructByInitials");
            return BadRequest(ModelState);
        }
        _logger.LogInformation($"All okay, method GetInstitutionStructByInitials");
        return Ok(result);
    }

    /// <summary>
    /// Get institutions with max department count
    /// </summary>
    /// <returns>Array of HigherEducationInstitutionDto</returns>
    [HttpGet("GetInstitutionsWithMaxDepartments")]
    public IActionResult GetInstitutionsWithMaxDepartments()
    {
        var result = _mapper.Map<HigherEducationInstitutionDto>(
            _repository.GetInstitutionsWithMaxDepartments());

        if (!ModelState.IsValid)
        {
            _logger.LogError($"Not found, method GetInstitutionsWithMaxDepartments");
            return BadRequest(ModelState);
        }
        _logger.LogInformation($"All okay, method GetInstitutionsWithMaxDepartments");
        return Ok(result);
    }

    /// <summary>
    /// Get Ownership Institution And Group
    /// </summary>
    /// <param name="property">InstitutionalProperty, value is 0 or 1</param>
    /// <returns>Dictionary<string, int>, string - initials Inistitution, int - count of groups</returns>
    [HttpGet("GetOwnershipInstitutionAndGroup")]
    public IActionResult GetOwnershipInstitutionAndGroup(InstitutionalProperty property)
    {
        var result = _repository
            .GetOwnershipInstitutionAndGroup(property);
        if (!ModelState.IsValid)
        {
            _logger.LogError($"Not found, method GetOwnershipInstitutionAndGroup");
            return BadRequest(ModelState);
        }
        _logger.LogInformation($"All okay, method GetOwnershipInstitutionAndGroup");
        return Ok(result);
    }

    /// <summary>
    /// Get Popular speciality
    /// </summary>
    /// <returns>IActionResult with SpecialityDto</returns>
    [HttpGet("GetPopularSpeciality")]
    public IActionResult GetPopularSpeciality()
    {
        var result = _mapper.Map<SpecialityDto>(_repository.GetPopularSpeciality());

        if (!ModelState.IsValid)
        {
            _logger.LogError($"Not found, method GetPopularSpeciality");
            return BadRequest(ModelState);
        }
        _logger.LogInformation($"All okay, method GetPopularSpeciality");
        return Ok(result);
    }
}
