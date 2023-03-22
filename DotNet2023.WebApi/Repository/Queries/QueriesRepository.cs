using DotNet2023.Domain.InstituteDocumentation;
using DotNet2023.Domain.Organization;
using DotNet2023.Queries;
using DotNet2023.WebApi.DataBase;
using DotNet2023.WebApi.Interfaces.Queries;

namespace DotNet2023.WebApi.Repository.Queries;
public class QueriesRepository : IQueries
{
    private readonly DbContextWebApi _dbContext;
    public QueriesRepository(DbContextWebApi dbContext) =>
        _dbContext = dbContext;

    public HigherEducationInstitution? GetInstitutionById(string id) =>
        QueriesToDomainModel.GetInstitutionById(_dbContext, id);

    public HigherEducationInstitution? GetInstitutionByInitials(string initials) =>
        QueriesToDomainModel.GetInstitutionByInitials(_dbContext, initials);

    public ResponseUniversityStructByProperty[]? GetInstitutionStruct(
        InstitutionalProperty institutionalProperty, 
        BuildingProperty buildingProperty) =>
        QueriesToDomainModel.GetInstitutionStruct(_dbContext, institutionalProperty, 
            buildingProperty);

    public ResponseUniversityStructByInitials? GetInstitutionStructByInitials(
        string initials) =>
        QueriesToDomainModel.GetInstitutionStructByInitials(_dbContext, initials);

    public HigherEducationInstitution[]? GetInstitutionsWithMaxDepartments() =>
        QueriesToDomainModel.GetInstitutionsWithMaxDepartments(_dbContext);

    public Dictionary<string, int> GetOwnershipInstitutionAndGroup(
        InstitutionalProperty property) =>
        QueriesToDomainModel.GetOwnershipInstitutionAndGroup(_dbContext, property);

    public Speciality[]? GetPopularSpeciality() =>
        QueriesToDomainModel.GetPopularSpeciality(_dbContext);
}