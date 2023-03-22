using DotNet2023.Domain.Organization;
using DotNet2023.WebApi.DataBase;

namespace DotNet2023.WebApi.DtoModels.Queries;
public class QueriesDto
{
    public static HigherEducationInstitution? GetHigherEducationInstitutionById
    (DbContextWebApi db, string id) =>
    db.Institutes.FirstOrDefault(x => x.Id == id);



}