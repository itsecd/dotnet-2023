using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.Domain.Organization;
using DotNet2023.Queries;
using DotNet2023.WebApi.DataBase;
using DotNet2023.WebApi.Interfaces.Queries;

namespace DotNet2023.WebApi.Repository.Queries;
public class QueriesRepository : IQueries
{
    private readonly DbContextWebApi _dbContext;
    public QueriesRepository(DbContextWebApi dbContext)
    {
        _dbContext = dbContext;
        _dbContext.Institutes.ToList();
        _dbContext.InstituteSpecialties.ToList();
        _dbContext.Faculties.ToList();
        _dbContext.Departments.ToList();
        _dbContext.GroupOfStudents.ToList();
        _dbContext.Students.ToList();
        _dbContext.EducationWorker.ToList();
        _dbContext.Specialties.ToList();
    }


    public HigherEducationInstitution? GetInstitutionById(string id) =>
        QueriesToDomainModel.GetInstitutionById(_dbContext, id);
    public async Task<HigherEducationInstitution>? GetInstitutionByIdAsync(string id) =>
        await QueriesToDomainModelAsync.GetInstitutionByIdAsync(_dbContext, id);


    public HigherEducationInstitution? GetInstitutionByInitials(string initials) =>
        QueriesToDomainModel.GetInstitutionByInitials(_dbContext, initials);
    public async Task<HigherEducationInstitution>? GetInstitutionByInitialsAsync(string initials) =>
        await QueriesToDomainModelAsync.GetInstitutionByInitialsAsync(_dbContext, initials);


    public ResponseUniversityStructByProperty[]? GetInstitutionStruct(
        InstitutionalProperty institutionalProperty,
        BuildingProperty buildingProperty) =>
        QueriesToDomainModel.GetInstitutionStruct(_dbContext, institutionalProperty,
            buildingProperty);
    public async Task<ResponseUniversityStructByProperty[]>? GetInstitutionStructAsync(
        InstitutionalProperty institutionalProperty,
        BuildingProperty buildingProperty) =>
        await QueriesToDomainModelAsync.GetInstitutionStructAsync(_dbContext, institutionalProperty,
            buildingProperty);


    public ResponseUniversityStructByInitials? GetInstitutionStructByInitials
        (string initials) =>
        QueriesToDomainModel.GetInstitutionStructByInitials(_dbContext, initials);
    public async Task<ResponseUniversityStructByInitials>? GetInstitutionStructByInitialsAsync
        (string initials) =>
        await QueriesToDomainModelAsync.GetInstitutionStructByInitialsAsync(_dbContext, initials);


    public HigherEducationInstitution[]? GetInstitutionsWithMaxDepartments() =>
        QueriesToDomainModel.GetInstitutionsWithMaxDepartments(_dbContext);
    public async Task<HigherEducationInstitution[]>? GetInstitutionsWithMaxDepartmentsAsync() =>
        await QueriesToDomainModelAsync.GetInstitutionsWithMaxDepartmentsAsync(_dbContext);


    public Dictionary<string, int> GetOwnershipInstitutionAndGroup
        (InstitutionalProperty property) =>
        QueriesToDomainModel.GetOwnershipInstitutionAndGroup(_dbContext, property);
    public async Task<Dictionary<string, int>> GetOwnershipInstitutionAndGroupAsync
        (InstitutionalProperty property) =>
        await QueriesToDomainModelAsync.GetOwnershipInstitutionAndGroupAsync(_dbContext, property);


    public Speciality[]? GetPopularSpeciality() =>
        QueriesToDomainModel.GetPopularSpeciality(_dbContext);
    public async Task<Speciality[]>? GetPopularSpecialityAsync() =>
        await QueriesToDomainModelAsync.GetPopularSpecialityAsync(_dbContext);
}