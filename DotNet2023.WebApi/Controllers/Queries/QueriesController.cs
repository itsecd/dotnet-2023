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
    public HigherEducationInstitutionDto GetInstitutionById(string id) =>
        _mapper.Map<HigherEducationInstitutionDto>(_repository.GetInstitutionById(id));

    /// <summary>
    /// Async Get information about your chosen university by id
    /// </summary>
    /// <param name="id">Id of the institute for which want to get information</param>
    /// <returns>IActionResult with HigherEducationInstitutionDto</returns>
    [HttpGet("GetInstitutionByIdAsync")]
    public async Task<HigherEducationInstitutionDto> GetInstitutionByIdAsync(string id) =>
        _mapper.Map<HigherEducationInstitutionDto>(
            await _repository.GetInstitutionByIdAsync(id));


    /// <summary>
    /// Get information about your chosen university by initials
    /// </summary>
    /// <param name="initials">Initials of the institute for which want to get information</param>
    /// <returns>IActionResult with HigherEducationInstitutionDto</returns>
    [HttpGet("GetInstitutionByInitials")]
    public HigherEducationInstitutionDto GetInstitutionByInitials(string initials) =>
        _mapper.Map<HigherEducationInstitutionDto>(
            _repository.GetInstitutionByInitials(initials));
    /// <summary>
    /// Async Get information about your chosen university by initials
    /// </summary>
    /// <param name="initials">Initials of the institute for which want to get information</param>
    /// <returns>IActionResult with HigherEducationInstitutionDto</returns>
    [HttpGet("GetInstitutionByInitialsAsync")]
    public async Task<HigherEducationInstitutionDto> GetInstitutionByInitialsAsync(string initials) =>
        _mapper.Map<HigherEducationInstitutionDto>(
            await _repository.GetInstitutionByInitialsAsync(initials));

    /// <summary>
    /// Get information about university in format: 
    /// Name, CountFaculties, CountDepartments and CountGroups
    /// </summary>
    /// <param name="institutionalProperty">InstitutionalProperty, value is 0 or 1</param>
    /// <param name="buildingProperty">BuildingProperty, value is 0, 1 or 2</param>
    /// <returns>IActionResult with ResponseUniversityStructByProperty</returns>
    [HttpGet("GetInstitutionStruct")]
    public IEnumerable<ResponseUniversityStructByProperty> GetInstitutionStruct(
        InstitutionalProperty institutionalProperty,
        BuildingProperty buildingProperty) =>
        _repository
            .GetInstitutionStruct(institutionalProperty, buildingProperty);

    /// <summary>
    /// Async Get information about university in format: 
    /// Name, CountFaculties, CountDepartments and CountGroups
    /// </summary>
    /// <param name="institutionalProperty">InstitutionalProperty, value is 0 or 1</param>
    /// <param name="buildingProperty">BuildingProperty, value is 0, 1 or 2</param>
    /// <returns>IActionResult with ResponseUniversityStructByProperty</returns>
    [HttpGet("GetInstitutionStructAsync")]
    public async Task<IEnumerable<ResponseUniversityStructByProperty>> GetInstitutionStructAsync(
        InstitutionalProperty institutionalProperty,
        BuildingProperty buildingProperty) =>
        await _repository
            .GetInstitutionStructAsync(institutionalProperty, buildingProperty);

    /// <summary>
    /// Get information about university in format: 
    /// Name, CountFaculties, CountDepartments and CountSpecialities
    /// </summary>
    /// <param name="initials">Initials of the institute for which want to get information</param>
    /// <returns></returns>
    [HttpGet("GetInstitutionStructByInitials")]
    public ResponseUniversityStructByInitials GetInstitutionStructByInitials(
        string initials) => _repository
            .GetInstitutionStructByInitials(initials);

    /// <summary>
    /// Async Get information about university in format: 
    /// Name, CountFaculties, CountDepartments and CountSpecialities
    /// </summary>
    /// <param name="initials">Initials of the institute for which want to get information</param>
    /// <returns></returns>
    [HttpGet("GetInstitutionStructByInitialsAsync")]
    public async Task<ResponseUniversityStructByInitials> GetInstitutionStructByInitialsAsync(string initials) =>
        await _repository
            .GetInstitutionStructByInitialsAsync(initials);

    /// <summary>
    /// Get institutions with max department count
    /// </summary>
    /// <returns>Array of HigherEducationInstitutionDto</returns>
    [HttpGet("GetInstitutionsWithMaxDepartments")]
    public IEnumerable<HigherEducationInstitutionDto> GetInstitutionsWithMaxDepartments() =>
        _mapper.Map<List<HigherEducationInstitutionDto>>(
            _repository.GetInstitutionsWithMaxDepartments());
    /// <summary>
    /// Async Get institutions with max department count
    /// </summary>
    /// <returns>Array of HigherEducationInstitutionDto</returns>
    [HttpGet("GetInstitutionsWithMaxDepartmentsAsync")]
    public async Task<IEnumerable<HigherEducationInstitutionDto>> GetInstitutionsWithMaxDepartmentsAsync() =>
        _mapper.Map<List<HigherEducationInstitutionDto>>(
            await _repository.GetInstitutionsWithMaxDepartmentsAsync());

    /// <summary>
    /// Get Ownership Institution And Group
    /// </summary>
    /// <param name="property">InstitutionalProperty, value is 0 or 1</param>
    /// <returns>Dictionary<string, int>, string - initials Inistitution, int - count of groups</returns>
    [HttpGet("GetOwnershipInstitutionAndGroup")]
    public Dictionary<string, int> GetOwnershipInstitutionAndGroup(
        InstitutionalProperty property) =>
        _repository
            .GetOwnershipInstitutionAndGroup(property);
    /// <summary>
    /// Async Get Ownership Institution And Group
    /// </summary>
    /// <param name="property">InstitutionalProperty, value is 0 or 1</param>
    /// <returns>Dictionary<string, int>, string - initials Inistitution, int - count of groups</returns>
    [HttpGet("GetOwnershipInstitutionAndGroupAsync")]
    public async Task<Dictionary<string, int>> GetOwnershipInstitutionAndGroupAsync(
        InstitutionalProperty property) =>
        await _repository
            .GetOwnershipInstitutionAndGroupAsync(property);

    /// <summary>
    /// Get Popular speciality
    /// </summary>
    /// <returns>IActionResult with SpecialityDto</returns>
    [HttpGet("GetPopularSpeciality")]
    public IEnumerable<SpecialityDto> GetPopularSpeciality() =>
        _mapper.Map<List<SpecialityDto>>(_repository.GetPopularSpeciality());
    /// <summary>
    /// Async Get Popular speciality
    /// </summary>
    /// <returns>IActionResult with SpecialityDto</returns>
    [HttpGet("GetPopularSpecialityAsync")]
    public async Task<IEnumerable<SpecialityDto>> GetPopularSpecialityAsync() =>
        _mapper.Map<List<SpecialityDto>>(await _repository.GetPopularSpecialityAsync());
}
